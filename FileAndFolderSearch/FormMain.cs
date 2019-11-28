using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

using MS_VB_FileIO = Microsoft.VisualBasic.FileIO;

using Ookii.Dialogs;
using SHOpenFolderAndSelectItems;

namespace FileAndFolderSearch
{
    public partial class FormMain : Form
    {
        #region Fields and Properties

        VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
        Task SearchTask;
        CancellationTokenSource SearchTask_CancellationTs;

        bool IsSearchTaskRunning
        {
            get
            {
                return SearchTask != null && SearchTask.Status == TaskStatus.Running;
            }
        }

        public const string AppMsgBoxCaption = "File And Folder Search message";

        // Currently this list is filled while searching but only used for querying the number of matches…
        List<Match> MatchedFiles = new List<Match>();

        Stopwatch SearchStopwatch = new Stopwatch();
        SearchState SearchState = SearchState.None;

        DataGridViewRow ClickedRow = null;

        Properties.Settings Settings = Properties.Settings.Default;

        const string FontName = "Courier New";
        const int FontSize = 9;
        static readonly Font DataGridViewResults_Font = new Font(FontName, FontSize);
        static readonly Color DataGridViewResults_ForColor = Color.Black;
        static readonly Font DataGridViewResults_DeletedFont = new Font(FontName, FontSize, FontStyle.Strikeout);
        static readonly Color DataGridViewResults_DeletedForColor = Color.DarkGray;

        #endregion Fields and Properties


        #region Constructor

        public FormMain()
        {
            InitializeComponent();
            this.MinimumSize = new Size(640, 430);
            this.DoubleBufferedAll(true);

            Text += " v" + FileVersionInfo.GetVersionInfo(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                .FileVersion;

            DataGridViewResults_Init();

            rbDeleteToRecycleBin.Checked = Settings.DeleteToRecycleBin;
            rbDeletePermanently.Checked = !Settings.DeleteToRecycleBin;

            rbRemoveDeleted.Checked = Settings.RemoveDeleted;
            rbMarkDeleted.Checked = !Settings.RemoveDeleted;
        }

        #endregion Constructor


        #region OnLoad/OnClosing Methods

        protected override void OnLoad(EventArgs e)
        {
            SetButtonIdleState();
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
            StopSearchTask();
            base.OnClosing(e);
        }

        #endregion OnLoad/OnClosing Methods


        #region Methods

        private void DataGridViewResults_Init()
        {
            dataGridViewResults.DefaultCellStyle.Font = DataGridViewResults_Font;
            dataGridViewResults.CellMouseDoubleClick += dataGridViewResults_CellMouseDoubleClick;
            // ToDo: Complete Context-Menu
            //dataGridViewResults.CellMouseClick += DataGridViewResults_CellMouseClick;
            dataGridViewResults.CellMouseUp += DataGridViewResults_CellMouseUp;
            dataGridViewResults.Sorted += DataGridViewResults_Sorted;
            dataGridViewResults.KeyDown += DataGridViewResults_KeyDown;
            dataGridViewResults.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            
            foreach (DataGridViewColumn col in dataGridViewResults.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void DataGridViewResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                var pathList = dataGridViewResults.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Cells[ColumnPath.Index].Value).Cast<string>().ToList();
                string pathText = string.Join("\r\n", pathList);
                Clipboard.SetData(DataFormats.Text, pathText);
            }
        }

        private void SetButtonIdleState()
        {
            btnSearch.Text = "Search";
            btnSearch.BackColor = Color.FromArgb(90, 235, 120);
            btnBrowse.Enabled = true;
            cbMatchCase.Enabled = true;
            cbMatchWholeFileName.Enabled = true;
            txtSearchPattern.Enabled = true;
            txtParentFolderName.Enabled = true;
        }

        private void SetButtonBusyState()
        {
            btnSearch.Text = "Stop";
            btnSearch.BackColor = Color.FromArgb(255, 100, 80);
            btnBrowse.Enabled = false;
            cbMatchCase.Enabled = false;
            cbMatchWholeFileName.Enabled = false;
            txtSearchPattern.Enabled = false;
            txtParentFolderName.Enabled = false;
            txtSearchPattern.BackColor = Color.White;
            txtParentFolderName.BackColor = Color.White;

        }

        private static void DeleteFilesAndFolders(List<string> fileList, List<string> folderList, bool sendToRecycleOption)
        {
            MS_VB_FileIO.RecycleOption recycleOption = sendToRecycleOption
                ? MS_VB_FileIO.RecycleOption.SendToRecycleBin
                : MS_VB_FileIO.RecycleOption.DeletePermanently;

            foreach (string file in fileList)
            {
                MS_VB_FileIO.FileSystem.DeleteFile(
                    file,
                    MS_VB_FileIO.UIOption.OnlyErrorDialogs,
                    recycleOption,
                    MS_VB_FileIO.UICancelOption.DoNothing);
            }

            foreach (string folder in folderList)
            {
                MS_VB_FileIO.FileSystem.DeleteDirectory(
                    folder,
                    MS_VB_FileIO.UIOption.OnlyErrorDialogs,
                    recycleOption,
                    MS_VB_FileIO.UICancelOption.DoNothing);
            }
        }

        #endregion Methods


        #region DataGridView row methods

        private void OpenFileOrFolderLocation(DataGridViewRow row)
        {
            MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
            string fileName = (string)row.Cells[ColumnPath.Index].Value;

            if (matchType == MatchType.None) return;
            if (matchType == MatchType.File && !File.Exists(fileName)) return;
            if (matchType == MatchType.Folder && !Directory.Exists(fileName)) return;


            // Use task to temporarily fix when trying to open unaccessible files/folders
            // It can throw an error after a a minute
            // TODO: find a better solution

            // --> Temp section START

            Exception exception = null;

            Task task = Task.Factory.StartNew(new Action(() =>
            {
                try
                {
                    ShowSelectedInExplorer.FilesOrFolders(Path.GetDirectoryName(fileName), Path.GetFileName(fileName));
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }));

            // --> Temp section END

            // ShowSelectedInExplorer.FilesOrFolders(Path.GetDirectoryName(fileName), Path.GetFileName(fileName));


        }

        private DialogResult ConfirmDetlete()
        {
            string msg = "";
            if (rbDeleteToRecycleBin.Checked)
            {
                msg =
                    "Are you sure you want to delete these files and folders?\r\n" +
                    "They will be deleted to the recycle-bin!";
            }
            else
            {
                msg =
                    "Are you sure you want to delete these files and folders?\r\n" +
                    "They will be deleted permanently!";
            }

            return MessageBox.Show(
                   this,
                   msg,
                   AppMsgBoxCaption,
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Warning);
        }

        private void DataGridViewResults_EndEdit(bool setDefaultCursor, bool resumeAoutoSize)
        {
            if (resumeAoutoSize)
            {
                for (int i = 0; i < dataGridViewResults.Columns.Count - 1; i++)
                {
                    dataGridViewResults.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                dataGridViewResults.Columns[dataGridViewResults.Columns.Count - 1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
            }

            dataGridViewResults.RefreshEdit();

            if (setDefaultCursor) this.Cursor = Cursors.Default;
        }

        private void DataGridViewResults_BeginEdit(bool setWaitCursor, bool pauseAoutoSize)
        {
            if (setWaitCursor) this.Cursor = Cursors.WaitCursor;

            if (pauseAoutoSize)
            {
                for (int i = 0; i < dataGridViewResults.Columns.Count; i++)
                {
                    dataGridViewResults.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
            }
        }

        private void GetChecekedFilesAndFolders(out List<string> fileList, out List<string> folderList)
        {
            fileList = new List<string>();
            folderList = new List<string>();

            foreach (DataGridViewRow row in dataGridViewResults.Rows)
            {
                if ((bool)row.Cells[ColumnChecked.Index].Value)
                {
                    MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                    string path = (string)row.Cells[ColumnPath.Index].Value;

                    if (matchType == MatchType.File && File.Exists(path))
                    {
                        fileList.Add(path);
                    }
                    else if (matchType == MatchType.Folder && Directory.Exists(path))
                    {
                        folderList.Add(path);
                    }
                }
            }
        }

        private void GetHighlightedFilesAndFolders(out List<string> fileList, out List<string> folderList)
        {
            fileList = new List<string>();
            folderList = new List<string>();

            foreach (DataGridViewRow row in dataGridViewResults.SelectedRows)
            {
                //row.Cells[ColumnChecked.Index].Value = true;
                MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                string path = (string)row.Cells[ColumnPath.Index].Value;

                if (matchType == MatchType.File && File.Exists(path))
                {
                    fileList.Add(path);
                }
                else if (matchType == MatchType.Folder && Directory.Exists(path))
                {
                    folderList.Add(path);
                }
            }
        }

        private void GetAllFilesAndFolders(out List<string> fileList, out List<string> folderList)
        {
            fileList = new List<string>();
            folderList = new List<string>();

            foreach (DataGridViewRow row in dataGridViewResults.Rows)
            {
                //row.Cells[ColumnChecked.Index].Value = true;
                MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                string path = (string)row.Cells[ColumnPath.Index].Value;

                if (matchType == MatchType.File && File.Exists(path))
                {
                    fileList.Add(path);
                }
                else if (matchType == MatchType.Folder && Directory.Exists(path))
                {
                    folderList.Add(path);
                }
            }
        }

        private void RemoveNoneExisting()
        {
            DataGridViewResults_BeginEdit(true, true);

            for (int i = 0; i < dataGridViewResults.RowCount; i++)
            {
                DataGridViewRow row = dataGridViewResults.Rows[i];
                MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                string path = (string)row.Cells[ColumnPath.Index].Value;

                if (matchType == MatchType.File && !File.Exists(path)
                    || matchType == MatchType.Folder && !Directory.Exists(path))
                {
                    if(dataGridViewResults.CurrentRow == row)
                    {
                        dataGridViewResults.CurrentCell = null;
                    }

                    dataGridViewResults.Rows.Remove(row);
                    i--;
                }
                else
                {
                    row.DefaultCellStyle = null;
                }
            }

            DataGridViewResults_EndEdit(true, true);
        }

        private void MarkNoneExisting()
        {
            DataGridViewResults_BeginEdit(true, true);

            for (int i = 0; i < dataGridViewResults.RowCount; i++)
            {
                DataGridViewRow row = dataGridViewResults.Rows[i];
                MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                string path = (string)row.Cells[ColumnPath.Index].Value;

                if (matchType == MatchType.File && !File.Exists(path)
                    || matchType == MatchType.Folder && !Directory.Exists(path))
                {
                    row.DefaultCellStyle.Font = DataGridViewResults_DeletedFont;
                    row.DefaultCellStyle.ForeColor = DataGridViewResults_DeletedForColor;
                }
                else
                {
                    row.DefaultCellStyle = null;
                }
            }

            DataGridViewResults_EndEdit(true, true);
        }

        private void RemoveOrMarkNoneExisting()
        {
            if(rbRemoveDeleted.Checked)
            {
                RemoveNoneExisting();
            }
            else
            {
                MarkNoneExisting();
            }
        }

        private void CheckHighlightedFilesAndFolders()
        {
            DataGridViewResults_BeginEdit(true, true);

            foreach (DataGridViewRow row in dataGridViewResults.SelectedRows)
            {
                //row.Cells[ColumnChecked.Index].Value = true;
                //MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                //string path = (string)row.Cells[ColumnPath.Index].Value;

                row.Cells[ColumnChecked.Index].Value = true;
            }

            DataGridViewResults_EndEdit(true, true);
        }

        private void UncheckHighlightedFilesAndFolders()
        {
            DataGridViewResults_BeginEdit(true, true);

            foreach (DataGridViewRow row in dataGridViewResults.SelectedRows)
            {
                //row.Cells[ColumnChecked.Index].Value = true;
                //MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                //string path = (string)row.Cells[ColumnPath.Index].Value;

                row.Cells[ColumnChecked.Index].Value = false;
            }

            DataGridViewResults_EndEdit(true, true);
        }

        private void CheckAll()
        {
            DataGridViewResults_BeginEdit(true, true);

            foreach (DataGridViewRow row in dataGridViewResults.Rows)
            {
                //row.Cells[ColumnChecked.Index].Value = true;
                //MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                //string path = (string)row.Cells[ColumnPath.Index].Value;

                row.Cells[ColumnChecked.Index].Value = true;
            }

            DataGridViewResults_EndEdit(true, true);
        }

        private void UncheckAll()
        {
            DataGridViewResults_BeginEdit(true, true);

            foreach (DataGridViewRow row in dataGridViewResults.Rows)
            {
                //row.Cells[ColumnChecked.Index].Value = true;
                //MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                //string path = (string)row.Cells[ColumnPath.Index].Value;

                row.Cells[ColumnChecked.Index].Value = false;
            }

            DataGridViewResults_EndEdit(true, true);
        }

        private void CheckOrUncheckAll()
        {
            DataGridViewResults_BeginEdit(true, true);

            bool allCehecked = true;

            foreach (DataGridViewRow row in dataGridViewResults.Rows)
            {
                //row.Cells[ColumnChecked.Index].Value = true;
                //MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                //string path = (string)row.Cells[ColumnPath.Index].Value;

                if ((bool)row.Cells[ColumnChecked.Index].Value == false) ;
                {
                    allCehecked = false;
                    break;
                }
            }

            foreach (DataGridViewRow row in dataGridViewResults.Rows)
            {
                //row.Cells[ColumnChecked.Index].Value = true;
                //MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                //string path = (string)row.Cells[ColumnPath.Index].Value;

                row.Cells[ColumnChecked.Index].Value = !allCehecked;
            }

            DataGridViewResults_EndEdit(true, true);
        }

        private void InvertChecked()
        {
            DataGridViewResults_BeginEdit(true, true);

            foreach (DataGridViewRow row in dataGridViewResults.Rows)
            {
                //row.Cells[ColumnChecked.Index].Value = true;
                //MatchType matchType = (MatchType)row.Cells[ColumnType.Index].Value;
                //string path = (string)row.Cells[ColumnPath.Index].Value;

                row.Cells[ColumnChecked.Index].Value = !(bool)row.Cells[ColumnChecked.Index].Value;
            }

            DataGridViewResults_EndEdit(true, true);
        }

        private void UnhighlightAll()
        {
            DataGridViewResults_BeginEdit(true, true);

            foreach (DataGridViewRow row in dataGridViewResults.SelectedRows)
            {
                row.Selected = false;
            }

            DataGridViewResults_EndEdit(true, true);
        }

        private void InvertHiglighted()
        {
            DataGridViewResults_BeginEdit(true, true);

            foreach (DataGridViewRow row in dataGridViewResults.Rows)
            {
                row.Selected = !row.Selected;
            }

            DataGridViewResults_EndEdit(true, true);
        }

        private void ClearResults()
        {
            if (dataGridViewResults.RowCount > 0)
            {
                string msg =
                    "Are you sure you want to clear all the results?";

                DialogResult diagResult = MessageBox.Show(
                       this,
                       msg,
                       AppMsgBoxCaption,
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);

                if (diagResult == DialogResult.Yes)
                {
                    if (dataGridViewResults.RowCount > 0)
                    {
                        dataGridViewResults.Rows.Clear();
                    }
                }
            }
        }

        private void DeleteChecked()
        {
            if (dataGridViewResults.RowCount > 0 && ConfirmDetlete() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                List<string> fileList;
                List<string> folderList;

                GetChecekedFilesAndFolders(out fileList, out folderList);

                DeleteFilesAndFolders(fileList, folderList, rbDeleteToRecycleBin.Checked);

                MarkNoneExisting();

                dataGridViewResults.Refresh();

                this.Cursor = Cursors.Default;
            }
        }

        private void DeleteAll()
        {
            if (dataGridViewResults.RowCount > 0 && ConfirmDetlete() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                List<string> fileList;
                List<string> folderList;

                GetAllFilesAndFolders(out fileList, out folderList);

                DeleteFilesAndFolders(fileList, folderList, rbDeleteToRecycleBin.Checked);

                RemoveOrMarkNoneExisting();

                dataGridViewResults.Refresh();

                this.Cursor = Cursors.Default;
            }
        }

        private void DeleteHighlighted()
        {
            if (dataGridViewResults.RowCount > 0 && ConfirmDetlete() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                List<string> fileList;
                List<string> folderList;

                GetHighlightedFilesAndFolders(out fileList, out folderList);

                DeleteFilesAndFolders(fileList, folderList, rbDeleteToRecycleBin.Checked);

                RemoveOrMarkNoneExisting();

                dataGridViewResults.Refresh();

                this.Cursor = Cursors.Default;
            }
        }

        #endregion DataGridView row methods


        #region Search methods

        SearchState Search()
        {
            string parentFolder = null;
            string[] searchPatterns = null; // Holds the search patterns in an array. 
            bool matchCase = true;
            bool matchWholeFileName = true;
            bool searchFiles = true;
            bool searchFolders = true;
            string folder = "";

            SearchState searchState = SearchState.None;

            this.Invoke(() =>
            {
                UpdateSearchStatistics();

                parentFolder = txtParentFolderName.Text;
                // The searchPattern can hold multiple search patterns separated by a "|".
                searchPatterns = txtSearchPattern.Text.Split('|');
                matchCase = cbMatchCase.Checked;
                matchWholeFileName = cbMatchWholeFileName.Checked;
                searchFiles = cbSearchFiles.Checked;
                searchFolders = cbSearchFolders.Checked;

                if (!Directory.Exists(parentFolder))
                {
                    MessageBox.Show(
                        this,
                        string.Format("The directory {0} dos not exist!", parentFolder),
                        AppMsgBoxCaption);

                    searchState = SearchState.Canceled;
                    return;
                }

                if (searchPatterns.Length == 0 || searchPatterns[0] == string.Empty)
                {
                    if(matchWholeFileName)
                    {
                       MessageBox.Show(
                        this,
                        "'File name' is empty and 'Match whole name' is checked,\n" +
                        "nothing can be found!\n",
                        AppMsgBoxCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                        searchState = SearchState.Canceled;
                        return;
                    }

                    DialogResult diagResult = MessageBox.Show(
                        this,
                        "'File name' is empty, everything is a match!\n" +
                        "Do you want to search anyway?",
                        AppMsgBoxCaption,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if(diagResult != DialogResult.Yes)
                    {
                        searchState = SearchState.Canceled;
                        return;
                    }
                }

                SetButtonBusyState();
                txtSearchStateVerbus.Text = "Searching...";
                txtSearchStateShort.Text = "Searching...";
                dataGridViewResults.Rows.Clear();
                ColumnChecked.ReadOnly = true;
                SearchState = SearchState.Searching;
                SearchStopwatch.Restart();
                UpdateSearchStatisticsTimer.Start();
            });

            if (searchState == SearchState.Canceled)
            {
                return searchState;
            }

            searchState = SearchState.Searching;

            MatchedFiles = new List<Match>(); // Gathers all the matches. Currently its not used.
            List<Match> newMatches = new List<Match>(); // Holds the new matches of the currently searced foldr.
            List<string> folderStack = new List<string>(); // The folders to be searched. used as a stack - 
                                                           // after the folder at the top of the stack is searched, 
                                                           // it is removed and its subfolders are added to the top of the stack.
                                                           // When the stack is empty, the search is done.
                                                           // Add root folder.
            folderStack.Add(parentFolder);

            if (!matchCase)
            {
                searchPatterns = searchPatterns.Select(str => str.ToUpper()).ToArray();
            }

            while (folderStack.Count > 0)
            {
                folder = folderStack[folderStack.Count - 1];
                folderStack.RemoveAt(folderStack.Count - 1);

                this.Invoke(() =>
                {
                    txtSearchStateVerbus.Text = "Searching... \r\n" + folder;
                    // Display new matches from the previous folder.
                    DataGridViewResults_AddMatches(newMatches);
                });

                if (SearchTask_CancellationTs.IsCancellationRequested)
                {
                    searchState = SearchState.Stopped;
                    break;
                }

                try
                {
                    newMatches.Clear();

                    // Get new matches.
                    if (matchCase && matchWholeFileName)
                    {
                        if (searchFiles)
                        {
                            newMatches.AddRange(
                                Directory.EnumerateFiles(folder, "*", SearchOption.TopDirectoryOnly)
                                .Where(file => searchPatterns.Any(searchFile => Path.GetFileName(file) == searchFile))
                                .Select(file => new Match(file, MatchType.File)));
                        }

                        if (searchFolders)
                        {
                            newMatches.AddRange(
                                Directory.EnumerateDirectories(folder, "*", SearchOption.TopDirectoryOnly)
                                .Where(file => searchPatterns.Any(searchFile => Path.GetFileName(file) == searchFile))
                                .Select(file => new Match(file, MatchType.Folder)));
                        }
                    }
                    else if (!matchCase && matchWholeFileName)
                    {
                        if (searchFiles)
                        {
                            newMatches.AddRange(
                                Directory.EnumerateFiles(folder, "*", SearchOption.TopDirectoryOnly)
                                .Where(file => searchPatterns.Any(searchFile => Path.GetFileName(file).ToUpper() == searchFile))
                                .Select(file => new Match(file, MatchType.File)));
                        }

                        if (searchFolders)
                        {
                            newMatches.AddRange(
                                Directory.EnumerateDirectories(folder, "*", SearchOption.TopDirectoryOnly)
                                .Where(file => searchPatterns.Any(searchFile => Path.GetFileName(file).ToUpper() == searchFile))
                                .Select(file => new Match(file, MatchType.Folder)));
                        }
                    }
                    else if (matchCase && !matchWholeFileName)
                    {
                        if (searchFiles)
                        {
                            newMatches.AddRange(
                                Directory.EnumerateFiles(folder, "*", SearchOption.TopDirectoryOnly)
                                .Where(file => searchPatterns.Any(searchFile => Path.GetFileName(file).Contains(searchFile)))
                                .Select(file => new Match(file, MatchType.File)));
                        }

                        if (searchFolders)
                        {
                            newMatches.AddRange(
                                Directory.EnumerateDirectories(folder, "*", SearchOption.TopDirectoryOnly)
                                .Where(file => searchPatterns.Any(searchFile => Path.GetFileName(file).Contains(searchFile)))
                                .Select(file => new Match(file, MatchType.Folder)));
                        }
                    }
                    else if (!matchCase && !matchWholeFileName)
                    {
                        if (searchFiles)
                        {
                            newMatches.AddRange(
                                Directory.EnumerateFiles(folder, "*.*", SearchOption.TopDirectoryOnly)
                                .Where(file => searchPatterns.Any(searchFile => Path.GetFileName(file).ToUpper().Contains(searchFile)))
                                .Select(file => new Match(file, MatchType.File)));
                        }

                        if (searchFolders)
                        {
                            newMatches.AddRange(
                                Directory.EnumerateDirectories(folder, "*.*", SearchOption.TopDirectoryOnly)
                                .Where(file => searchPatterns.Any(searchFile => Path.GetFileName(file).ToUpper().Contains(searchFile)))
                                .Select(file => new Match(file, MatchType.Folder)));
                        }
                    }

                    MatchedFiles.AddRange(newMatches);
                }
                catch { }

                try
                {
                    // Add subfolders of the current folder. 
                    // The folders are retrieved in an acceding order bot are used last first (FIFO) so the order is reversed.

                    int previouseCount = folderStack.Count;

                    folderStack.AddRange(Directory.EnumerateDirectories(
                        folder, "*", SearchOption.TopDirectoryOnly).Reverse());
                }
                catch { }
            }

            this.Invoke(() =>
            {
                // Display new matches from the last folder.
                DataGridViewResults_AddMatches(newMatches);

                dataGridViewResults.Refresh();
            });

            if(searchState == SearchState.Searching)
            {
                searchState = SearchState.Completed;
            }
            return searchState;
        }

        private void StartSearchTask()
        {
            SearchState = SearchState.Searching;

            SearchTask_CancellationTs = new CancellationTokenSource();
            SearchTask = Task.Factory.StartNew(() =>
            {
                SearchState searchState = SearchState.None;

                try
                {
                    searchState = Search();
                }
                catch
                {

                }
                finally
                {
                    this.BeginInvoke(() =>
                    {
                        SearchStopwatch.Stop();
                        UpdateSearchStatisticsTimer.Stop();

                        SearchState = searchState;

                        if (SearchState == SearchState.Stopped)
                        {
                            txtSearchStateShort.Text = "Search Stopped";
                            txtSearchStateVerbus.Text = "Search Stopped.";
                        }
                        else if (SearchState == SearchState.Canceled)
                        {
                            txtSearchStateShort.Text = "Search Canceled";
                            txtSearchStateVerbus.Text = "Search Canceled.";
                        }
                        else if (SearchState == SearchState.Completed)
                        {
                            txtSearchStateShort.Text = "Search Completed";
                            txtSearchStateVerbus.Text = "Search Completed.";
                        }
                        else
                        {
                            txtSearchStateShort.Text = "Search (" + SearchState + ") ???.";
                            txtSearchStateVerbus.Text = "Search (" + SearchState  + ") ???.";
                        }

                        SearchTask_CancellationTs.Dispose();
                        SearchTask_CancellationTs = null;

                        UpdateSearchStatistics();
                        SetButtonIdleState();

                        ColumnChecked.ReadOnly = false;
                    });
                }
            },
            SearchTask_CancellationTs.Token,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }

        void StopSearchTask()
        {
            if (IsSearchTaskRunning)
            {
                try
                {
                    SearchTask_CancellationTs.Cancel();
                }
                catch
                {
                    // SaveSnapshotsTask_CancellationTS may allready be disposed and null'ed -
                    // - if the task just completed (a samll chance...).
                }
            }

            while (IsSearchTaskRunning) // Wait for task to complete/cancel
            {
                // Allow the main loop to process events...
                Application.DoEvents();
            }
        }

        private void UpdateSearchStatistics()
        {
            // Update state: current folder, total time, matches found.

            int totalSec = (int)SearchStopwatch.ElapsedMilliseconds / 1000;
            int h = totalSec / 3600;
            int m = (totalSec / 60) % 60;
            int s = totalSec % 60;
            txtSerchTime.Text = string.Format("{0:00}:{1:00}:{2:00}", h, m, s);

            txtMatchesFound.Text = MatchedFiles.Count.ToString();
        }

        private bool StartSearch(bool showErrorMessage, bool searchIfNoName)
        {
            if(!searchIfNoName && string.IsNullOrEmpty(txtSearchPattern.Text))
            {
                return false;
            }

            if (SearchState != SearchState.Searching)
            {
                if (!cbSearchFiles.Checked && !cbSearchFolders.Checked)
                {
                    if (showErrorMessage)
                    {
                        MessageBox.Show(
                               this,
                               "Error!:\r\nPlease select Files and/or folders",
                               AppMsgBoxCaption,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Asterisk);
                    }

                    return false;
                }

                StartSearchTask();
                return true;
            }

            return false;
        }

        private void StopSearch(bool showErrorMessage)
        {
            StopSearchTask();
        }

        private void ToggleSearch(bool showErrorMessage, bool searchIfNoName)// toggle
        {
            if (SearchState != SearchState.Searching)
            {
                StartSearch(showErrorMessage, searchIfNoName);
            }
            else
            {
                StopSearch(showErrorMessage);
            }
        }

        private void DataGridViewResults_AddMatches(List<Match> newMatches)
        {
            if (newMatches.Count() > 0)
            {
                txtMatchesFound.Text = MatchedFiles.Count.ToString();
                foreach (var match in newMatches)
                {
                    dataGridViewResults.Rows.Add(false, match.MatchType, Path.GetFileName(match.Name), match.Name);
                }

                dataGridViewResults.CurrentCell = null;
            }
        }

        #endregion Search methods


        #region Events

        private void DataGridViewResults_CellMouseUp(Object sender, DataGridViewCellMouseEventArgs e)
        {
            // ToDo: Complete Context-Menu

            ClickedRow = null;

            if (e.RowIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ClickedRow = dataGridViewResults.Rows[e.RowIndex];
                    contextMenuStrip.Show(MousePosition);
                    //contextMenuStrip.Show(dataGridViewResults[e.ColumnIndex, e.RowIndex].;
                }
            }
            else if (e.RowIndex == -1)
            {
                if (dataGridViewResults.RowCount > 0)
                {
                    DataGridViewColumn col = dataGridViewResults.Columns[e.ColumnIndex];

                    ListSortDirection sortDirection = ListSortDirection.Ascending;
                    if(dataGridViewResults.SortedColumn == col &&
                        dataGridViewResults.SortOrder == SortOrder.Ascending)
                    {
                        sortDirection = ListSortDirection.Descending;
                    }
                    
                    DataGridViewResults_BeginEdit(true, false);
                    dataGridViewResults.Sort(col, sortDirection);
                    DataGridViewResults_EndEdit(true, false);

                    foreach (DataGridViewColumn c in dataGridViewResults.Columns)
                    {
                        DataGridViewColumnHeaderCell headerCell = c.HeaderCell;
                        if(headerCell != col.HeaderCell)
                        {
                            headerCell.SortGlyphDirection = SortOrder.None;
                        }
                    }

                    col.HeaderCell.SortGlyphDirection = dataGridViewResults.SortOrder;
                }
            }
        }

        void dataGridViewResults_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.Button != MouseButtons.Left) return;

            DataGridViewRow row = dataGridViewResults.Rows[e.RowIndex];
            OpenFileOrFolderLocation(row);
        }

        private void DataGridViewResults_Sorted(Object sender, EventArgs e)
        {
            DataGridViewResults_EndEdit(true, true);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = txtParentFolderName.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtParentFolderName.Text = folderBrowserDialog.SelectedPath;
                if (!txtParentFolderName.Text.EndsWith("\\"))
                {
                    txtParentFolderName.Text += "\\";
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ToggleSearch(true, true);
        }

        private void UpdateSearchStatisticsTimer_Tick(object sender, EventArgs e)
        {
            UpdateSearchStatistics();
        }

        private void btnDeleteChecked_Click(object sender, EventArgs e)
        {
            DeleteChecked();
        }

        private void btnDeleteHighlighted_Click(object sender, EventArgs e)
        {
            DeleteHighlighted();
        }

        private void btnDeleteAll_Click(Object sender, EventArgs e)
        {
            // Delete Permanently 
            DeleteAll();
        }

        private void btnClearResults_Click(Object sender, EventArgs e)
        {
            ClearResults();
        }

        private void btnRemoveDeleted_Click(Object sender, EventArgs e)
        {
            RemoveNoneExisting();
        }

        private void btnMarkDeleted_Click(Object sender, EventArgs e)
        {
            MarkNoneExisting();
        }

        private void TsmiSelectDeselect_Click(Object sender, EventArgs e)
        {
            if (ClickedRow != null)
            {
                ClickedRow.Selected = !ClickedRow.Selected;
                ClickedRow = null;
            }
        }

        private void CbSearchFilesFolders_CheckedChanged(Object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null) return;

            if (!cbSearchFiles.Checked && !cbSearchFolders.Checked)
            {
                cb.Checked = true;
            }
        }

        private void TxtSearchPattern_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StartSearch(false, true);
            }
        }

        private void TxtParentFolderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StartSearch(false, true);
            }
        }

        #endregion Events


        #region Context Menu Strip Events

        private void tsmiOpenLocation_Click(object sender, EventArgs e)
        {
            if(ClickedRow != null)
            {
                OpenFileOrFolderLocation(ClickedRow);
                ClickedRow = null;
            }
        }

        private void tsmiCheckHighlighted_Click(object sender, EventArgs e)
        {
            ClickedRow = null;
            CheckHighlightedFilesAndFolders();
        }

        private void tsmiUncheckHighlighted_Click(object sender, EventArgs e)
        {
            ClickedRow = null;
            UncheckHighlightedFilesAndFolders();
        }

        private void tsmiCheckAll_Click(object sender, EventArgs e)
        {
            ClickedRow = null;
            CheckAll();
        }

        private void tsmiUncheckAll_Click(object sender, EventArgs e)
        {
            ClickedRow = null;
            UncheckAll();
        }

        private void tsmiHighlightAll_Click(object sender, EventArgs e)
        {
            ClickedRow = null;
            dataGridViewResults.SelectAll(); 
        }

        private void tsmiUnhighlightAll_Click(object sender, EventArgs e)
        {
            ClickedRow = null;
            UnhighlightAll();
        }

        private void tsmiInvertChecked_Click(object sender, EventArgs e)
        {
            ClickedRow = null;
            InvertChecked();
        }

        private void tsmiInvertHiglighted_Click(object sender, EventArgs e)
        {
            ClickedRow = null;
            InvertHiglighted();
        }

        private void tsmiRemoveDeleted_Click(object sender, EventArgs e)
        {
            ClickedRow = null;
            RemoveNoneExisting();
        }

        private void tsmiClearResults_Click(Object sender, EventArgs e)
        {
            ClickedRow = null;
            ClearResults();
        }

        private void tsmiMarkDeleted_Click(Object sender, EventArgs e)
        {
            ClickedRow = null;
            MarkNoneExisting();
        }

        #endregion Context Menu Strip Events

        
    }
}

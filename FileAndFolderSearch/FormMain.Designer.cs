namespace FileAndFolderSearch
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMatchesFound = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerchTime = new System.Windows.Forms.TextBox();
            this.txtSearchStateVerbus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.ColumnChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmpty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateSearchStatisticsTimer = new System.Windows.Forms.Timer(this.components);
            this.btnDeleteChecked = new System.Windows.Forms.Button();
            this.btnDeleteHighlighted = new System.Windows.Forms.Button();
            this.tsmiOpenLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSelectDeselect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUncheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInvertChecked = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiHighlightAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUnhighlightAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInvertHiglighted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCheckHighlighted = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUncheckHighlighted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRefreshResults = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveDeleted = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearResults = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMarkDeleted = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearchStateShort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSearchOptions = new System.Windows.Forms.TabPage();
            this.tabPageAction = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbMarkDeleted = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbDeletePermanently = new System.Windows.Forms.RadioButton();
            this.rbDeleteToRecycleBin = new System.Windows.Forms.RadioButton();
            this.btnRemoveDeleted = new System.Windows.Forms.Button();
            this.btnClearResults = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.tabPageSearchState = new System.Windows.Forms.TabPage();
            this.cbMatchCase = new System.Windows.Forms.CheckBox();
            this.cbMatchWholeFileName = new System.Windows.Forms.CheckBox();
            this.cbSearchFiles = new System.Windows.Forms.CheckBox();
            this.cbSearchFolders = new System.Windows.Forms.CheckBox();
            this.txtParentFolderName = new System.Windows.Forms.TextBox();
            this.txtSearchPattern = new System.Windows.Forms.TextBox();
            this.rbRemoveDeleted = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageSearchOptions.SuspendLayout();
            this.tabPageAction.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageSearchState.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(619, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(69, 27);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(55, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 43);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Parent Folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "File Neme";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Matches Found";
            // 
            // txtMatchesFound
            // 
            this.txtMatchesFound.Location = new System.Drawing.Point(109, 115);
            this.txtMatchesFound.Name = "txtMatchesFound";
            this.txtMatchesFound.ReadOnly = true;
            this.txtMatchesFound.Size = new System.Drawing.Size(71, 21);
            this.txtMatchesFound.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Search Time";
            // 
            // txtSerchTime
            // 
            this.txtSerchTime.Location = new System.Drawing.Point(109, 88);
            this.txtSerchTime.Name = "txtSerchTime";
            this.txtSerchTime.ReadOnly = true;
            this.txtSerchTime.Size = new System.Drawing.Size(71, 21);
            this.txtSerchTime.TabIndex = 14;
            // 
            // txtSearchStateVerbus
            // 
            this.txtSearchStateVerbus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchStateVerbus.BackColor = System.Drawing.Color.White;
            this.txtSearchStateVerbus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSearchStateVerbus.Location = new System.Drawing.Point(6, 21);
            this.txtSearchStateVerbus.Multiline = true;
            this.txtSearchStateVerbus.Name = "txtSearchStateVerbus";
            this.txtSearchStateVerbus.ReadOnly = true;
            this.txtSearchStateVerbus.Size = new System.Drawing.Size(682, 131);
            this.txtSearchStateVerbus.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Results";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "State";
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.AllowUserToAddRows = false;
            this.dataGridViewResults.AllowUserToDeleteRows = false;
            this.dataGridViewResults.AllowUserToResizeRows = false;
            this.dataGridViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnChecked,
            this.ColumnType,
            this.ColumnName,
            this.ColumnPath,
            this.ColumnEmpty});
            this.dataGridViewResults.Location = new System.Drawing.Point(4, 226);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.RowHeadersVisible = false;
            this.dataGridViewResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResults.Size = new System.Drawing.Size(909, 326);
            this.dataGridViewResults.TabIndex = 19;
            // 
            // ColumnChecked
            // 
            this.ColumnChecked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnChecked.HeaderText = "";
            this.ColumnChecked.Name = "ColumnChecked";
            this.ColumnChecked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnChecked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnChecked.Width = 19;
            // 
            // ColumnType
            // 
            this.ColumnType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            this.ColumnType.Width = 60;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 65;
            // 
            // ColumnPath
            // 
            this.ColumnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnPath.HeaderText = "Path";
            this.ColumnPath.Name = "ColumnPath";
            this.ColumnPath.ReadOnly = true;
            this.ColumnPath.Width = 57;
            // 
            // ColumnEmpty
            // 
            this.ColumnEmpty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnEmpty.HeaderText = "";
            this.ColumnEmpty.Name = "ColumnEmpty";
            this.ColumnEmpty.ReadOnly = true;
            // 
            // UpdateSearchStatisticsTimer
            // 
            this.UpdateSearchStatisticsTimer.Interval = 500;
            this.UpdateSearchStatisticsTimer.Tick += new System.EventHandler(this.UpdateSearchStatisticsTimer_Tick);
            // 
            // btnDeleteChecked
            // 
            this.btnDeleteChecked.Location = new System.Drawing.Point(151, 16);
            this.btnDeleteChecked.Name = "btnDeleteChecked";
            this.btnDeleteChecked.Size = new System.Drawing.Size(136, 27);
            this.btnDeleteChecked.TabIndex = 22;
            this.btnDeleteChecked.Text = "Delete Checked";
            this.btnDeleteChecked.UseVisualStyleBackColor = true;
            this.btnDeleteChecked.Click += new System.EventHandler(this.btnDeleteChecked_Click);
            // 
            // btnDeleteHighlighted
            // 
            this.btnDeleteHighlighted.Location = new System.Drawing.Point(151, 50);
            this.btnDeleteHighlighted.Name = "btnDeleteHighlighted";
            this.btnDeleteHighlighted.Size = new System.Drawing.Size(136, 27);
            this.btnDeleteHighlighted.TabIndex = 23;
            this.btnDeleteHighlighted.Text = "Delete Highlighted";
            this.btnDeleteHighlighted.UseVisualStyleBackColor = true;
            this.btnDeleteHighlighted.Click += new System.EventHandler(this.btnDeleteHighlighted_Click);
            // 
            // tsmiOpenLocation
            // 
            this.tsmiOpenLocation.Name = "tsmiOpenLocation";
            this.tsmiOpenLocation.Size = new System.Drawing.Size(186, 22);
            this.tsmiOpenLocation.Text = "Open Location";
            this.tsmiOpenLocation.Click += new System.EventHandler(this.tsmiOpenLocation_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenLocation,
            this.tsmiSelectDeselect,
            this.toolStripSeparator2,
            this.tsmiCheckAll,
            this.tsmiUncheckAll,
            this.tsmiInvertChecked,
            this.toolStripSeparator3,
            this.tsmiHighlightAll,
            this.tsmiUnhighlightAll,
            this.tsmiInvertHiglighted,
            this.toolStripSeparator1,
            this.tsmiCheckHighlighted,
            this.tsmiUncheckHighlighted,
            this.toolStripSeparator4,
            this.tsmiRefreshResults,
            this.tsmiRemoveDeleted,
            this.tsmiClearResults});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(187, 314);
            // 
            // tsmiSelectDeselect
            // 
            this.tsmiSelectDeselect.Name = "tsmiSelectDeselect";
            this.tsmiSelectDeselect.Size = new System.Drawing.Size(186, 22);
            this.tsmiSelectDeselect.Text = "Select/Deselect";
            this.tsmiSelectDeselect.Click += new System.EventHandler(this.TsmiSelectDeselect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // tsmiCheckAll
            // 
            this.tsmiCheckAll.Name = "tsmiCheckAll";
            this.tsmiCheckAll.Size = new System.Drawing.Size(186, 22);
            this.tsmiCheckAll.Text = "Check All";
            this.tsmiCheckAll.Click += new System.EventHandler(this.tsmiCheckAll_Click);
            // 
            // tsmiUncheckAll
            // 
            this.tsmiUncheckAll.Name = "tsmiUncheckAll";
            this.tsmiUncheckAll.Size = new System.Drawing.Size(186, 22);
            this.tsmiUncheckAll.Text = "Uncheck All";
            this.tsmiUncheckAll.Click += new System.EventHandler(this.tsmiUncheckAll_Click);
            // 
            // tsmiInvertChecked
            // 
            this.tsmiInvertChecked.Name = "tsmiInvertChecked";
            this.tsmiInvertChecked.Size = new System.Drawing.Size(186, 22);
            this.tsmiInvertChecked.Text = "Invert Checked";
            this.tsmiInvertChecked.Click += new System.EventHandler(this.tsmiInvertChecked_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // tsmiHighlightAll
            // 
            this.tsmiHighlightAll.Name = "tsmiHighlightAll";
            this.tsmiHighlightAll.Size = new System.Drawing.Size(186, 22);
            this.tsmiHighlightAll.Text = "Highlight All";
            this.tsmiHighlightAll.Click += new System.EventHandler(this.tsmiHighlightAll_Click);
            // 
            // tsmiUnhighlightAll
            // 
            this.tsmiUnhighlightAll.Name = "tsmiUnhighlightAll";
            this.tsmiUnhighlightAll.Size = new System.Drawing.Size(186, 22);
            this.tsmiUnhighlightAll.Text = "Unhighlight All";
            this.tsmiUnhighlightAll.Click += new System.EventHandler(this.tsmiUnhighlightAll_Click);
            // 
            // tsmiInvertHiglighted
            // 
            this.tsmiInvertHiglighted.Name = "tsmiInvertHiglighted";
            this.tsmiInvertHiglighted.Size = new System.Drawing.Size(186, 22);
            this.tsmiInvertHiglighted.Text = "Invert Higlighted";
            this.tsmiInvertHiglighted.Click += new System.EventHandler(this.tsmiInvertHiglighted_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // tsmiCheckHighlighted
            // 
            this.tsmiCheckHighlighted.Name = "tsmiCheckHighlighted";
            this.tsmiCheckHighlighted.Size = new System.Drawing.Size(186, 22);
            this.tsmiCheckHighlighted.Text = "Check Highlighted";
            this.tsmiCheckHighlighted.Click += new System.EventHandler(this.tsmiCheckHighlighted_Click);
            // 
            // tsmiUncheckHighlighted
            // 
            this.tsmiUncheckHighlighted.Name = "tsmiUncheckHighlighted";
            this.tsmiUncheckHighlighted.Size = new System.Drawing.Size(186, 22);
            this.tsmiUncheckHighlighted.Text = "Uncheck Highlighted";
            this.tsmiUncheckHighlighted.Click += new System.EventHandler(this.tsmiUncheckHighlighted_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(183, 6);
            // 
            // tsmiRefreshResults
            // 
            this.tsmiRefreshResults.Name = "tsmiRefreshResults";
            this.tsmiRefreshResults.Size = new System.Drawing.Size(186, 22);
            this.tsmiRefreshResults.Text = "Mark Deleted";
            this.tsmiRefreshResults.Click += new System.EventHandler(this.tsmiMarkDeleted_Click);
            // 
            // tsmiRemoveDeleted
            // 
            this.tsmiRemoveDeleted.Name = "tsmiRemoveDeleted";
            this.tsmiRemoveDeleted.Size = new System.Drawing.Size(186, 22);
            this.tsmiRemoveDeleted.Text = "Remove Deleted";
            this.tsmiRemoveDeleted.Click += new System.EventHandler(this.tsmiRemoveDeleted_Click);
            // 
            // tsmiClearResults
            // 
            this.tsmiClearResults.Name = "tsmiClearResults";
            this.tsmiClearResults.Size = new System.Drawing.Size(186, 22);
            this.tsmiClearResults.Text = "Clear Results";
            this.tsmiClearResults.Click += new System.EventHandler(this.tsmiClearResults_Click);
            // 
            // btnMarkDeleted
            // 
            this.btnMarkDeleted.Location = new System.Drawing.Point(6, 16);
            this.btnMarkDeleted.Name = "btnMarkDeleted";
            this.btnMarkDeleted.Size = new System.Drawing.Size(121, 27);
            this.btnMarkDeleted.TabIndex = 26;
            this.btnMarkDeleted.Text = "Mark Deleted";
            this.btnMarkDeleted.UseVisualStyleBackColor = true;
            this.btnMarkDeleted.Click += new System.EventHandler(this.btnMarkDeleted_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSearchStateShort);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMatchesFound);
            this.groupBox1.Controls.Add(this.txtSerchTime);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 179);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // txtSearchStateShort
            // 
            this.txtSearchStateShort.Location = new System.Drawing.Point(52, 147);
            this.txtSearchStateShort.Name = "txtSearchStateShort";
            this.txtSearchStateShort.ReadOnly = true;
            this.txtSearchStateShort.Size = new System.Drawing.Size(130, 21);
            this.txtSearchStateShort.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "State";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageSearchOptions);
            this.tabControl1.Controls.Add(this.tabPageAction);
            this.tabControl1.Controls.Add(this.tabPageSearchState);
            this.tabControl1.Location = new System.Drawing.Point(211, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 186);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPageSearchOptions
            // 
            this.tabPageSearchOptions.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSearchOptions.Controls.Add(this.cbMatchCase);
            this.tabPageSearchOptions.Controls.Add(this.cbMatchWholeFileName);
            this.tabPageSearchOptions.Controls.Add(this.cbSearchFiles);
            this.tabPageSearchOptions.Controls.Add(this.cbSearchFolders);
            this.tabPageSearchOptions.Controls.Add(this.label1);
            this.tabPageSearchOptions.Controls.Add(this.btnBrowse);
            this.tabPageSearchOptions.Controls.Add(this.label3);
            this.tabPageSearchOptions.Controls.Add(this.txtParentFolderName);
            this.tabPageSearchOptions.Controls.Add(this.txtSearchPattern);
            this.tabPageSearchOptions.Location = new System.Drawing.Point(4, 24);
            this.tabPageSearchOptions.Name = "tabPageSearchOptions";
            this.tabPageSearchOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearchOptions.Size = new System.Drawing.Size(694, 158);
            this.tabPageSearchOptions.TabIndex = 0;
            this.tabPageSearchOptions.Text = "Search Options";
            // 
            // tabPageAction
            // 
            this.tabPageAction.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAction.Controls.Add(this.panel2);
            this.tabPageAction.Controls.Add(this.panel1);
            this.tabPageAction.Controls.Add(this.btnRemoveDeleted);
            this.tabPageAction.Controls.Add(this.btnClearResults);
            this.tabPageAction.Controls.Add(this.btnDeleteAll);
            this.tabPageAction.Controls.Add(this.btnMarkDeleted);
            this.tabPageAction.Controls.Add(this.btnDeleteChecked);
            this.tabPageAction.Controls.Add(this.btnDeleteHighlighted);
            this.tabPageAction.Location = new System.Drawing.Point(4, 24);
            this.tabPageAction.Name = "tabPageAction";
            this.tabPageAction.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAction.Size = new System.Drawing.Size(694, 158);
            this.tabPageAction.TabIndex = 1;
            this.tabPageAction.Text = "Action";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbMarkDeleted);
            this.panel2.Controls.Add(this.rbRemoveDeleted);
            this.panel2.Location = new System.Drawing.Point(311, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 48);
            this.panel2.TabIndex = 32;
            // 
            // rbMarkDeleted
            // 
            this.rbMarkDeleted.AutoSize = true;
            this.rbMarkDeleted.Checked = true;
            this.rbMarkDeleted.Location = new System.Drawing.Point(3, 3);
            this.rbMarkDeleted.Name = "rbMarkDeleted";
            this.rbMarkDeleted.Size = new System.Drawing.Size(101, 19);
            this.rbMarkDeleted.TabIndex = 26;
            this.rbMarkDeleted.TabStop = true;
            this.rbMarkDeleted.Text = "Mark Deleted";
            this.rbMarkDeleted.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbDeletePermanently);
            this.panel1.Controls.Add(this.rbDeleteToRecycleBin);
            this.panel1.Location = new System.Drawing.Point(311, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 48);
            this.panel1.TabIndex = 31;
            // 
            // rbDeletePermanently
            // 
            this.rbDeletePermanently.AutoSize = true;
            this.rbDeletePermanently.Location = new System.Drawing.Point(3, 25);
            this.rbDeletePermanently.Name = "rbDeletePermanently";
            this.rbDeletePermanently.Size = new System.Drawing.Size(142, 19);
            this.rbDeletePermanently.TabIndex = 25;
            this.rbDeletePermanently.Text = "Delete Permanently ";
            this.rbDeletePermanently.UseVisualStyleBackColor = true;
            // 
            // rbDeleteToRecycleBin
            // 
            this.rbDeleteToRecycleBin.AutoSize = true;
            this.rbDeleteToRecycleBin.Checked = true;
            this.rbDeleteToRecycleBin.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FileAndFolderSearch.Properties.Settings.Default, "DeleteToRecycleBin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rbDeleteToRecycleBin.Location = new System.Drawing.Point(3, 3);
            this.rbDeleteToRecycleBin.Name = "rbDeleteToRecycleBin";
            this.rbDeleteToRecycleBin.Size = new System.Drawing.Size(150, 19);
            this.rbDeleteToRecycleBin.TabIndex = 24;
            this.rbDeleteToRecycleBin.TabStop = true;
            this.rbDeleteToRecycleBin.Text = "Delete To Recycle Bin";
            this.rbDeleteToRecycleBin.UseVisualStyleBackColor = true;
            // 
            // btnRemoveDeleted
            // 
            this.btnRemoveDeleted.Location = new System.Drawing.Point(6, 50);
            this.btnRemoveDeleted.Name = "btnRemoveDeleted";
            this.btnRemoveDeleted.Size = new System.Drawing.Size(121, 27);
            this.btnRemoveDeleted.TabIndex = 30;
            this.btnRemoveDeleted.Text = "Remove Deleted";
            this.btnRemoveDeleted.UseVisualStyleBackColor = true;
            this.btnRemoveDeleted.Click += new System.EventHandler(this.btnRemoveDeleted_Click);
            // 
            // btnClearResults
            // 
            this.btnClearResults.Location = new System.Drawing.Point(6, 84);
            this.btnClearResults.Name = "btnClearResults";
            this.btnClearResults.Size = new System.Drawing.Size(121, 27);
            this.btnClearResults.TabIndex = 29;
            this.btnClearResults.Text = "Clear Results";
            this.btnClearResults.UseVisualStyleBackColor = true;
            this.btnClearResults.Click += new System.EventHandler(this.btnClearResults_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(151, 84);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(136, 27);
            this.btnDeleteAll.TabIndex = 27;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // tabPageSearchState
            // 
            this.tabPageSearchState.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSearchState.Controls.Add(this.txtSearchStateVerbus);
            this.tabPageSearchState.Controls.Add(this.label6);
            this.tabPageSearchState.Location = new System.Drawing.Point(4, 24);
            this.tabPageSearchState.Name = "tabPageSearchState";
            this.tabPageSearchState.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearchState.Size = new System.Drawing.Size(694, 158);
            this.tabPageSearchState.TabIndex = 2;
            this.tabPageSearchState.Text = "Search State";
            // 
            // cbMatchCase
            // 
            this.cbMatchCase.AutoSize = true;
            this.cbMatchCase.Checked = global::FileAndFolderSearch.Properties.Settings.Default.MatchCase;
            this.cbMatchCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMatchCase.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FileAndFolderSearch.Properties.Settings.Default, "MatchCase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbMatchCase.Location = new System.Drawing.Point(9, 97);
            this.cbMatchCase.Name = "cbMatchCase";
            this.cbMatchCase.Size = new System.Drawing.Size(89, 19);
            this.cbMatchCase.TabIndex = 12;
            this.cbMatchCase.Text = "Match case";
            this.cbMatchCase.UseVisualStyleBackColor = true;
            // 
            // cbMatchWholeFileName
            // 
            this.cbMatchWholeFileName.AutoSize = true;
            this.cbMatchWholeFileName.Checked = global::FileAndFolderSearch.Properties.Settings.Default.MatchWholeFileName;
            this.cbMatchWholeFileName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMatchWholeFileName.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FileAndFolderSearch.Properties.Settings.Default, "MatchWholeFileName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbMatchWholeFileName.Location = new System.Drawing.Point(9, 122);
            this.cbMatchWholeFileName.Name = "cbMatchWholeFileName";
            this.cbMatchWholeFileName.Size = new System.Drawing.Size(132, 19);
            this.cbMatchWholeFileName.TabIndex = 13;
            this.cbMatchWholeFileName.Text = "Match whole name";
            this.cbMatchWholeFileName.UseVisualStyleBackColor = true;
            // 
            // cbSearchFiles
            // 
            this.cbSearchFiles.AutoSize = true;
            this.cbSearchFiles.Checked = global::FileAndFolderSearch.Properties.Settings.Default.SearchFiles;
            this.cbSearchFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSearchFiles.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FileAndFolderSearch.Properties.Settings.Default, "SearchFiles", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbSearchFiles.Location = new System.Drawing.Point(153, 97);
            this.cbSearchFiles.Name = "cbSearchFiles";
            this.cbSearchFiles.Size = new System.Drawing.Size(51, 19);
            this.cbSearchFiles.TabIndex = 20;
            this.cbSearchFiles.Text = "Files";
            this.cbSearchFiles.UseVisualStyleBackColor = true;
            this.cbSearchFiles.CheckedChanged += new System.EventHandler(this.CbSearchFilesFolders_CheckedChanged);
            // 
            // cbSearchFolders
            // 
            this.cbSearchFolders.AutoSize = true;
            this.cbSearchFolders.Checked = global::FileAndFolderSearch.Properties.Settings.Default.SearchFolers;
            this.cbSearchFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSearchFolders.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FileAndFolderSearch.Properties.Settings.Default, "SearchFolers", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbSearchFolders.Location = new System.Drawing.Point(153, 122);
            this.cbSearchFolders.Name = "cbSearchFolders";
            this.cbSearchFolders.Size = new System.Drawing.Size(67, 19);
            this.cbSearchFolders.TabIndex = 21;
            this.cbSearchFolders.Text = "Folders";
            this.cbSearchFolders.UseVisualStyleBackColor = true;
            this.cbSearchFolders.CheckedChanged += new System.EventHandler(this.CbSearchFilesFolders_CheckedChanged);
            // 
            // txtParentFolderName
            // 
            this.txtParentFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParentFolderName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileAndFolderSearch.Properties.Settings.Default, "ParentFolderName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtParentFolderName.Location = new System.Drawing.Point(90, 16);
            this.txtParentFolderName.Name = "txtParentFolderName";
            this.txtParentFolderName.Size = new System.Drawing.Size(522, 21);
            this.txtParentFolderName.TabIndex = 1;
            this.txtParentFolderName.Text = global::FileAndFolderSearch.Properties.Settings.Default.ParentFolderName;
            this.txtParentFolderName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtParentFolderName_KeyDown);
            // 
            // txtSearchPattern
            // 
            this.txtSearchPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchPattern.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileAndFolderSearch.Properties.Settings.Default, "SearchPattern", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSearchPattern.Location = new System.Drawing.Point(90, 47);
            this.txtSearchPattern.Name = "txtSearchPattern";
            this.txtSearchPattern.Size = new System.Drawing.Size(522, 21);
            this.txtSearchPattern.TabIndex = 7;
            this.txtSearchPattern.Text = global::FileAndFolderSearch.Properties.Settings.Default.SearchPattern;
            this.txtSearchPattern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearchPattern_KeyDown);
            // 
            // rbRemoveDeleted
            // 
            this.rbRemoveDeleted.AutoSize = true;
            this.rbRemoveDeleted.Checked = global::FileAndFolderSearch.Properties.Settings.Default.RemoveDeleted;
            this.rbRemoveDeleted.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FileAndFolderSearch.Properties.Settings.Default, "RemoveDeleted", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rbRemoveDeleted.Location = new System.Drawing.Point(3, 25);
            this.rbRemoveDeleted.Name = "rbRemoveDeleted";
            this.rbRemoveDeleted.Size = new System.Drawing.Size(120, 19);
            this.rbRemoveDeleted.TabIndex = 25;
            this.rbRemoveDeleted.Text = "Remove Deleted";
            this.rbRemoveDeleted.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(918, 557);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "File And Folder Search";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSearchOptions.ResumeLayout(false);
            this.tabPageSearchOptions.PerformLayout();
            this.tabPageAction.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageSearchState.ResumeLayout(false);
            this.tabPageSearchState.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtParentFolderName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchPattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMatchesFound;
        private System.Windows.Forms.CheckBox cbMatchCase;
        private System.Windows.Forms.CheckBox cbMatchWholeFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSerchTime;
        private System.Windows.Forms.TextBox txtSearchStateVerbus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.CheckBox cbSearchFolders;
        private System.Windows.Forms.CheckBox cbSearchFiles;
        private System.Windows.Forms.Timer UpdateSearchStatisticsTimer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmpty;
        private System.Windows.Forms.Button btnDeleteChecked;
        private System.Windows.Forms.Button btnDeleteHighlighted;
        private System.Windows.Forms.RadioButton rbDeleteToRecycleBin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenLocation;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckHighlighted;
        private System.Windows.Forms.ToolStripMenuItem tsmiUncheckHighlighted;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiHighlightAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiUncheckAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiUnhighlightAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiInvertChecked;
        private System.Windows.Forms.ToolStripMenuItem tsmiInvertHiglighted;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveDeleted;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearResults;
        private System.Windows.Forms.Button btnMarkDeleted;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSearchOptions;
        private System.Windows.Forms.TabPage tabPageAction;
        private System.Windows.Forms.TabPage tabPageSearchState;
        private System.Windows.Forms.TextBox txtSearchStateShort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnRemoveDeleted;
        private System.Windows.Forms.Button btnClearResults;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshResults;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbDeletePermanently;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbMarkDeleted;
        private System.Windows.Forms.RadioButton rbRemoveDeleted;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectDeselect;
    }
}


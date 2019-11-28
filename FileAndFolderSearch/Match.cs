using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileAndFolderSearch
{
    public enum MatchType { File, Folder, None };

    public class Match
    {
        public string Name { get; set; }
        public MatchType MatchType { get; set; }

        public Match(string name, MatchType matchType)
        {
            Name = name;
            MatchType = matchType;
        }

        public Match() : this(null, MatchType.None) { }
    }
}

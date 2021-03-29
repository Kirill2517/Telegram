using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.DataBaseImage.Models
{
    internal class DbIndex
    {
        public string TitleTable { get; set; }
        public string TitleColumn { get; set; }
        public DbIndex(string titleTable, string titleColumn)
        {
            TitleTable = titleTable;
            TitleColumn = titleColumn;
        }
        public DbIndex()
        {

        }
    }
}

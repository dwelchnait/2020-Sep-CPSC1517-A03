using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class DDLData
    {
        public int ValueId { get; set; }
        public string DisplayText { get; set; }

        public DDLData()
        {

        }

        public DDLData(int valueid, string displaytext)
        {
            ValueId = valueid;
            DisplayText = displaytext;
        }
    }
}
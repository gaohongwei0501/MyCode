using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GHW.Test.Models.DTO
{
    public class ClassDTO
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public string CCount { get; set; }
        public string CImg { get; set; }
        public bool CIsDelete { get; set; }
        public System.DateTime CAddTime { get; set; }
    }
}
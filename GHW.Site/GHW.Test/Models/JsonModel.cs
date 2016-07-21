using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GHW.Test.Models
{
    /// <summary>
    /// json数据实体。
    /// </summary>
    public class JsonModel
    {
        public object Data { get; set; }

        public object Msg { get; set; }

        public object Statu { get; set; }

        public object BackUrl { get; set; }
    }
}
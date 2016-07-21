using GHW.Test.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GHW.Test.Models
{
    public partial class Class
    {
        public ClassDTO ToDTO()
        {
            return new ClassDTO()
            {
                CId = this.CId,
                CName = this.CName,
                CCount = this.CCount,
                CImg = this.CImg,
                CAddTime = this.CAddTime,
                CIsDelete = this.CIsDelete
            };
        }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GHW.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SurveyInfo
    {
        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        public int TmplId { get; set; }
        public int QuestionCount { get; set; }
        public int SurveyStatus { get; set; }
        public string StaticUrl { get; set; }
        public string RequiredInfos { get; set; }
        public int CreateId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<System.DateTime> UpDateTime { get; set; }
        public bool Deleted { get; set; }
        public string Remark { get; set; }
    }
}

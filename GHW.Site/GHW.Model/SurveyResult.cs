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
    
    public partial class SurveyResult
    {
        public int SurveyResultId { get; set; }
        public int SurveyId { get; set; }
        public int RespondentId { get; set; }
        public int QuestionId { get; set; }
        public string SelectedOptions { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}

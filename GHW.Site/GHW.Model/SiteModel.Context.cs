﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OptionInfo> OptionInfo { get; set; }
        public virtual DbSet<QuestionInfo> QuestionInfo { get; set; }
        public virtual DbSet<RespondentInfo> RespondentInfo { get; set; }
        public virtual DbSet<SurveyInfo> SurveyInfo { get; set; }
        public virtual DbSet<SurveyResult> SurveyResult { get; set; }
        public virtual DbSet<TemplateInfo> TemplateInfo { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
    }
}

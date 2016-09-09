﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.ProcessModule.UnitOfWork
{
    using Core.Entities.Process;
    using System.Data.Entity;
    using DataAccess.ProcessModule.UnitOfWork.Mapping;
    
    public partial class ProcessContext : Data.Common.Implementation.UnitOfWork, IProcessContext
    {
        public ProcessContext()
            : base("name=ProcessModelEntities")
        {
        Database.SetInitializer<ProcessContext>(null);
        }
    
     
    
        public virtual DbSet<Execution> Execution { get; set; }
        public virtual DbSet<ExecutionApplicant> ExecutionApplicant { get; set; }
        public virtual DbSet<ExecutionStep> ExecutionStep { get; set; }
        public virtual DbSet<ExtendedDataList> ExtendedDataList { get; set; }
        public virtual DbSet<ExtendedField> ExtendedField { get; set; }
        public virtual DbSet<ExtendedFieldValue> ExtendedFieldValue { get; set; }
        public virtual DbSet<ExtendedFile> ExtendedFile { get; set; }
        public virtual DbSet<ExtendedList> ExtendedList { get; set; }
        public virtual DbSet<FieldInSection> FieldInSection { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductProcess> ProductProcess { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Step> Step { get; set; }
        public virtual DbSet<StepSection> StepSection { get; set; }
        public virtual DbSet<WebServiceConsultation> WebServiceConsultation { get; set; }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);

    
        modelBuilder.Configurations.Add(new ExecutionMapping());
        modelBuilder.Configurations.Add(new ExecutionApplicantMapping());
        modelBuilder.Configurations.Add(new ExecutionStepMapping());
        modelBuilder.Configurations.Add(new ExtendedDataListMapping());
        modelBuilder.Configurations.Add(new ExtendedFieldMapping());
        modelBuilder.Configurations.Add(new ExtendedFieldValueMapping());
        modelBuilder.Configurations.Add(new ExtendedFileMapping());
        modelBuilder.Configurations.Add(new ExtendedListMapping());
        modelBuilder.Configurations.Add(new FieldInSectionMapping());
        modelBuilder.Configurations.Add(new PageMapping());
        modelBuilder.Configurations.Add(new ProcessMapping());
        modelBuilder.Configurations.Add(new ProductMapping());
        modelBuilder.Configurations.Add(new ProductProcessMapping());
        modelBuilder.Configurations.Add(new SectionMapping());
        modelBuilder.Configurations.Add(new StateMapping());
        modelBuilder.Configurations.Add(new StepMapping());
        modelBuilder.Configurations.Add(new StepSectionMapping());
        modelBuilder.Configurations.Add(new WebServiceConsultationMapping());
    }
    
    
    }
}

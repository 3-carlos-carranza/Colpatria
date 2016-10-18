//------------------------------------------------------------------------------
// <auto-generated>
// </auto-generated>
//------------------------------------------------------------------------------




using System.Data.Entity.ModelConfiguration;
using Core.Entities.Process;


namespace DataAccess.ProcessModule.UnitOfWork.Mapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExecutionMapping:EntityTypeConfiguration<Core.Entities.Process.Execution>
    {
        
        public ExecutionMapping()
        {
    	this.Map(s => s.MapInheritedProperties());
                // Primary Key
    			
                this.HasKey(t => t.Id);
    
    
                // Properties
     
                    this.Property(t => t.SimpleId).IsRequired()
    .HasMaxLength(50);
    
    
     
                    this.Property(t => t.ProductData).IsRequired()
    .HasMaxLength(500);
    
    
    
                this.ToTable("Execution","Process");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.ProcessId).HasColumnName("ProcessId");
        this.Property(t => t.CreateDate).HasColumnName("CreateDate");
        this.Property(t => t.SimpleId).HasColumnName("SimpleId");
        this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
        this.Property(t => t.ProductData).HasColumnName("ProductData");
        this.Property(t => t.CurrentStepId).HasColumnName("CurrentStepId");
        this.Property(t => t.State).HasColumnName("State");
        this.Property(t => t.IsActive).HasColumnName("IsActive");
        this.Property(t => t.CurrentSectionId).HasColumnName("CurrentSectionId");
        this.Property(t => t.ProductId).HasColumnName("ProductId");
    
                // Relationships
                this.HasRequired(t => t.Process)
                    .WithMany(t => t.Execution)
                    .HasForeignKey(d => d.ProcessId);
                this.HasRequired(t => t.Product)
                    .WithMany(t => t.Execution)
                    .HasForeignKey(d => d.ProductId);
                this.HasRequired(t => t.Section)
                    .WithMany(t => t.Execution)
                    .HasForeignKey(d => d.CurrentSectionId);
                this.HasRequired(t => t.Step)
                    .WithMany(t => t.Execution)
                    .HasForeignKey(d => d.CurrentStepId);
    
    
    
        }
    
        
        
        
        
        
        
        
        
        
        
        
    
        
        
        
        
        
        
        
    }
}

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
    
    public partial class FieldInSectionMapping:EntityTypeConfiguration<Core.Entities.Process.FieldInSection>
    {
        
        public FieldInSectionMapping()
        {
    	this.Map(s => s.MapInheritedProperties());
                // Primary Key
    			
                this.HasKey(t => t.Id);
    
    
                // Properties
    
                this.ToTable("FieldInSection","Process");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.ExtendedFieldId).HasColumnName("ExtendedFieldId");
        this.Property(t => t.SectionId).HasColumnName("SectionId");
        this.Property(t => t.Order).HasColumnName("Order");
        this.Property(t => t.IsVisible).HasColumnName("IsVisible");
        this.Property(t => t.IsReadOnly).HasColumnName("IsReadOnly");
        this.Property(t => t.IsRequired).HasColumnName("IsRequired");
        this.Property(t => t.Applicant).HasColumnName("Applicant");
    
                // Relationships
                this.HasRequired(t => t.ExtendedField)
                    .WithMany(t => t.FieldInSection)
                    .HasForeignKey(d => d.ExtendedFieldId);
                this.HasRequired(t => t.Section)
                    .WithMany(t => t.FieldInSection)
                    .HasForeignKey(d => d.SectionId);
    
    
    
        }
    
        
        
        
        
        
        
        
        
    
        
        
    }
}

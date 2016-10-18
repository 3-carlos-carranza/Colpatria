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
    
    public partial class ExtendedListMapping:EntityTypeConfiguration<Core.Entities.Process.ExtendedList>
    {
        
        public ExtendedListMapping()
        {
    	this.Map(s => s.MapInheritedProperties());
                // Primary Key
    			
                this.HasKey(t => t.Id);
    
    
                // Properties
     
                    this.Property(t => t.Name).IsRequired()
    .HasMaxLength(50);
    
    
     
                    this.Property(t => t.Description).IsRequired()
    .HasMaxLength(500);
    
    
    
                this.ToTable("ExtendedList","Process");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.Name).HasColumnName("Name");
        this.Property(t => t.Description).HasColumnName("Description");
        this.Property(t => t.IdListParent).HasColumnName("IdListParent");
        this.Property(t => t.IdListOriginal).HasColumnName("IdListOriginal");
    
    
        }
    
        
        
        
        
        
    
        
        
    }
}

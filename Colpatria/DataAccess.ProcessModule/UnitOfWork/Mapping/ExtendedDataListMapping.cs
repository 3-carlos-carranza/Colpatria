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
    
    public partial class ExtendedDataListMapping:EntityTypeConfiguration<Core.Entities.Process.ExtendedDataList>
    {
        
        public ExtendedDataListMapping()
        {
                // Primary Key
                this.HasKey(t => t.Id);
    
    
                // Properties
     
                    this.Property(t => t.Value).IsRequired()
    .HasMaxLength(500);
    
    
    
                this.ToTable("ExtendedDataList","Process");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.ListId).HasColumnName("ListId");
        this.Property(t => t.Value).HasColumnName("Value");
        this.Property(t => t.IdParent).HasColumnName("IdParent");
        this.Property(t => t.OriginalValue).HasColumnName("OriginalValue");
        this.Property(t => t.Order).HasColumnName("Order");
    
                // Relationships
                this.HasOptional(t => t.ExtendedList)
                    .WithMany(t => t.ExtendedDataList)
                    .HasForeignKey(d => d.ListId);
    
    
    
        }
    
        
        
        
        
        
        
    
        
    }
}

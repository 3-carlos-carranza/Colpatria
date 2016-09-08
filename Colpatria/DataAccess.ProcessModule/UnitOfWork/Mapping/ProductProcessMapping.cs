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
    
    public partial class ProductProcessMapping:EntityTypeConfiguration<Core.Entities.Process.ProductProcess>
    {
        
        public ProductProcessMapping()
        {
                // Primary Key
                this.HasKey(t => t.Id);
    
    
                // Properties
    
                this.ToTable("ProductProcess","Process");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.ProcessId).HasColumnName("ProcessId");
        this.Property(t => t.ProductId).HasColumnName("ProductId");
    
                // Relationships
                this.HasRequired(t => t.Process)
                    .WithMany(t => t.ProductProcess)
                    .HasForeignKey(d => d.ProcessId);
                this.HasRequired(t => t.Product)
                    .WithMany(t => t.ProductProcess)
                    .HasForeignKey(d => d.ProductId);
    
    
    
        }
    
        
        
        
    
        
        
    }
}

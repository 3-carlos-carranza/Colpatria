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
    
    public partial class StateMapping:EntityTypeConfiguration<Core.Entities.Process.State>
    {
        
        public StateMapping()
        {
                // Primary Key
                this.HasKey(t => t.Id);
    
    
                // Properties
     
                    this.Property(t => t.Name).IsRequired()
    .HasMaxLength(50);
    
    
     
                    this.Property(t => t.Description).HasMaxLength(500);
    
    
    
                this.ToTable("State","Process");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.Name).HasColumnName("Name");
        this.Property(t => t.Description).HasColumnName("Description");
        this.Property(t => t.NotificationEnabled).HasColumnName("NotificationEnabled");
        this.Property(t => t.IsClosed).HasColumnName("IsClosed");
        this.Property(t => t.IsRequesting).HasColumnName("IsRequesting");
    
    
        }
    
        
        
        
        
        
        
    
        
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
// </auto-generated>
//------------------------------------------------------------------------------




using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;
using Core.Entities;

namespace DataAccess.UserModule.UnitOfWork.Mapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class BaseDataListMapping:EntityTypeConfiguration<Core.Entities.User.BaseDataList>
    {
        
        public BaseDataListMapping()
        {
                // Primary Key
                this.HasKey(t => t.Id);
    
    
                // Properties
     
                    this.Property(t => t.Name).IsRequired()
    .HasMaxLength(100);
    
    
     
                    this.Property(t => t.Description).IsRequired()
    .HasMaxLength(500);
    
    
     
                    this.Property(t => t.LocationTable).HasMaxLength(512);
    
    
     
                    this.Property(t => t.Field).HasMaxLength(512);
    
    
     
                    this.Property(t => t.Filter).HasMaxLength(512);
    
    
    
                this.ToTable("BaseDataList","User");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.Name).HasColumnName("Name");
        this.Property(t => t.Description).HasColumnName("Description");
        this.Property(t => t.IdListParent).HasColumnName("IdListParent");
        this.Property(t => t.LocationTable).HasColumnName("LocationTable");
        this.Property(t => t.Field).HasColumnName("Field");
        this.Property(t => t.Filter).HasColumnName("Filter");
    
    
        }
    
        
        
        
        
        
        
        
    
        
        
    }
}

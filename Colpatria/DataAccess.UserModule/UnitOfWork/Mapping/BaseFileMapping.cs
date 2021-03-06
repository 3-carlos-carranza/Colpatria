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
    
    public partial class BaseFileMapping:EntityTypeConfiguration<Core.Entities.User.BaseFile>
    {
        
        public BaseFileMapping()
        {
                // Primary Key
                this.HasKey(t => t.Id);
    
    
                // Properties
     
                    this.Property(t => t.Data).IsRequired();
    
    
     
                    this.Property(t => t.FileName).IsRequired()
    .HasMaxLength(2048);
    
    
     
                    this.Property(t => t.Extension).IsRequired()
    .HasMaxLength(32);
    
    
     
                    this.Property(t => t.InternetMimeType).IsRequired()
    .HasMaxLength(256);
    
    
    
                this.ToTable("BaseFile","User");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.Data).HasColumnName("Data");
        this.Property(t => t.FileName).HasColumnName("FileName");
        this.Property(t => t.Extension).HasColumnName("Extension");
        this.Property(t => t.BaseFieldValueId).HasColumnName("BaseFieldValueId");
        this.Property(t => t.InternetMimeType).HasColumnName("InternetMimeType");
    
                // Relationships
                this.HasRequired(t => t.BaseFieldValue)
                    .WithMany(t => t.BaseFile)
                    .HasForeignKey(d => d.BaseFieldValueId);
    
    
    
        }
    
        
        
        
        
        
        
    
        
    }
}

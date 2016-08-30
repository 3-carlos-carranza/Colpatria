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
    
    public partial class FieldToCreateUserMapping:EntityTypeConfiguration<Core.Entities.SQL.User.FieldToCreateUser>
    {
        
        public FieldToCreateUserMapping()
        {
                // Primary Key
                this.HasKey(t => t.Id);
    
    
                // Properties
     
                    this.Property(t => t.ColumnName).IsRequired()
    .HasMaxLength(50);
    
    
     
                    this.Property(t => t.DataType).IsRequired()
    .HasMaxLength(50);
    
    
    
                this.ToTable("FieldToCreateUser","Req");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.BaseFieldId).HasColumnName("BaseFieldId");
        this.Property(t => t.ColumnName).HasColumnName("ColumnName");
        this.Property(t => t.DataType).HasColumnName("DataType");
    
                // Relationships
                this.HasRequired(t => t.BaseField)
                    .WithMany(t => t.FieldToCreateUser)
                    .HasForeignKey(d => d.BaseFieldId);
    
    
    
        }
    
        
        
        
        
    
        
    }
}

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
    
    public partial class UserRoleMapping:EntityTypeConfiguration<Core.Entities.User.UserRole>
    {
        
        public UserRoleMapping()
        {
                // Primary Key
                this.HasKey(t => t.Id);
    
    
                // Properties
    
                this.ToTable("UserRole","User");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.UserId).HasColumnName("UserId");
        this.Property(t => t.RoleId).HasColumnName("RoleId");
    
                // Relationships
                this.HasRequired(t => t.Role)
                    .WithMany(t => t.UserRole)
                    .HasForeignKey(d => d.RoleId);
                this.HasRequired(t => t.User)
                    .WithMany(t => t.UserRole)
                    .HasForeignKey(d => d.UserId);
    
    
    
        }
    
        
        
        
    
        
        
    }
}

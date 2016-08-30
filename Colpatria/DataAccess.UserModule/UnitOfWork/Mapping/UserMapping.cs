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
    
    public partial class UserMapping:EntityTypeConfiguration<Core.Entities.SQL.User.User>
    {
        
        public UserMapping()
        {
                // Primary Key
                this.HasKey(t => t.Id);
    
    
                // Properties
     
                    this.Property(t => t.Email).HasMaxLength(256);
    
    
     
                    this.Property(t => t.UserName).IsRequired()
    .HasMaxLength(256);
    
    
     
                    this.Property(t => t.FirstName).IsRequired()
    .HasMaxLength(256);
    
    
     
                    this.Property(t => t.MiddleName).HasMaxLength(256);
    
    
     
                    this.Property(t => t.LastName).IsRequired()
    .HasMaxLength(256);
    
    
     
                    this.Property(t => t.SecondLastName).HasMaxLength(256);
    
    
     
                    this.Property(t => t.Identification).IsRequired()
    .HasMaxLength(256);
    
    
    
                this.ToTable("User","Req");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.Email).HasColumnName("Email");
        this.Property(t => t.EmailConfirmed).HasColumnName("EmailConfirmed");
        this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
        this.Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");
        this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
        this.Property(t => t.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
        this.Property(t => t.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
        this.Property(t => t.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc");
        this.Property(t => t.LockoutEnabled).HasColumnName("LockoutEnabled");
        this.Property(t => t.AccessFailedCount).HasColumnName("AccessFailedCount");
        this.Property(t => t.UserName).HasColumnName("UserName");
        this.Property(t => t.FirstName).HasColumnName("FirstName");
        this.Property(t => t.MiddleName).HasColumnName("MiddleName");
        this.Property(t => t.LastName).HasColumnName("LastName");
        this.Property(t => t.SecondLastName).HasColumnName("SecondLastName");
        this.Property(t => t.Identification).HasColumnName("Identification");
        this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
        this.Property(t => t.IdentificationType).HasColumnName("IdentificationType");
        this.Property(t => t.DateOfExpedition).HasColumnName("DateOfExpedition");
    
    
        }
    
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    
        
        
    }
}

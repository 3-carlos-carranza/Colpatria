//------------------------------------------------------------------------------
// <auto-generated>
// </auto-generated>
//------------------------------------------------------------------------------




using System.Data.Entity.ModelConfiguration;
using Core.Entities.SQL;


namespace DataAccess.ProcessModule.UnitOfWork.Mapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class SectionMapping:EntityTypeConfiguration<Core.Entities.SQL.Section>
    {
        
        public SectionMapping()
        {
                // Primary Key
                this.HasKey(t => t.Id);
    
    
                // Properties
     
                    this.Property(t => t.Name).IsRequired();
    
    
     
                    this.Property(t => t.ActionMethod).IsRequired()
    .HasMaxLength(256);
    
    
     
                    this.Property(t => t.Action).IsRequired()
    .HasMaxLength(256);
    
    
     
                    this.Property(t => t.Controller).IsRequired()
    .HasMaxLength(256);
    
    
    
                this.ToTable("Section","Req");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.PageId).HasColumnName("PageId");
        this.Property(t => t.Name).HasColumnName("Name");
        this.Property(t => t.Description).HasColumnName("Description");
        this.Property(t => t.Order).HasColumnName("Order");
        this.Property(t => t.NameAlias).HasColumnName("NameAlias");
        this.Property(t => t.ReadOnly).HasColumnName("ReadOnly");
        this.Property(t => t.Type).HasColumnName("Type");
        this.Property(t => t.IsVisible).HasColumnName("IsVisible");
        this.Property(t => t.Enable).HasColumnName("Enable");
        this.Property(t => t.ActionMethod).HasColumnName("ActionMethod");
        this.Property(t => t.Action).HasColumnName("Action");
        this.Property(t => t.Controller).HasColumnName("Controller");
    
                // Relationships
                this.HasRequired(t => t.Page)
                    .WithMany(t => t.Section)
                    .HasForeignKey(d => d.PageId);
    
    
    
        }
    
        
        
        
        
        
        
        
        
        
        
        
        
        
    
        
        
        
        
    }
}

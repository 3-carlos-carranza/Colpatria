//------------------------------------------------------------------------------
// <auto-generated>
// </auto-generated>
//------------------------------------------------------------------------------




using System.Data.Entity.ModelConfiguration;


namespace DataAccess.ProcessModule.UnitOfWork.Mapping
{

    public partial class ExecutionStepMapping:EntityTypeConfiguration<Core.Entities.Process.ExecutionStep>
    {
        
        public ExecutionStepMapping()
        {
    	this.Map(s => s.MapInheritedProperties());
                // Primary Key
    			
                this.HasKey(t => t.Id);
    
    
                // Properties
    
                this.ToTable("ExecutionStep","Process");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.ExecutionId).HasColumnName("ExecutionId");
        this.Property(t => t.StepId).HasColumnName("StepId");
        this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        this.Property(t => t.UserId).HasColumnName("UserId");
    
                // Relationships
                this.HasRequired(t => t.Execution)
                    .WithMany(t => t.ExecutionStep)
                    .HasForeignKey(d => d.ExecutionId);
                this.HasRequired(t => t.Step)
                    .WithMany(t => t.ExecutionStep)
                    .HasForeignKey(d => d.StepId);
    
    
    
        }
    
        
        
        
        
        
    
        
        
    }
}

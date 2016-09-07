using Core.Entities.SQL.Process;
using Core.GlobalRepository.SQL.Process;
using DataAccess.ProcessModule.UnitOfWork;
using Data.Common.Implementation;
namespace DataAccess.ProcessModule.Repository
{
    
    
    
    public  partial class WebServiceConsultationRepository : Repository<WebServiceConsultation>, IWebServiceConsultationRepository
    {
        private IProcessContext _context;
    	
    
        public WebServiceConsultationRepository(IProcessContext uow): base(uow)
        {
    	
    	    this.SetContext();
        }
    
            private void SetContext()
            {
                this._context = UnitOfWork as IProcessContext;
            }
    
    }
}

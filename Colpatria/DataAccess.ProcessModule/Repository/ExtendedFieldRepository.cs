#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ExtendedFieldRepository.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-07 - 2:45 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using Core.Entities.SQL.Process;
using Core.GlobalRepository.SQL.Process;
using Data.Common.Implementation;
using DataAccess.ProcessModule.UnitOfWork;

#endregion

namespace DataAccess.ProcessModule.Repository
{
    public partial class ExtendedFieldRepository : Repository<ExtendedField>, IExtendedFieldRepository
    {
        private IProcessContext _context;


        public ExtendedFieldRepository(IProcessContext uow) : base(uow)
        {
            SetContext();
        }

        private void SetContext()
        {
            _context = UnitOfWork as IProcessContext;
        }
    }
}
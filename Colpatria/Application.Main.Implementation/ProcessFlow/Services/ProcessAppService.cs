#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ProcessAppService.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 3:11 p. m.</Date>
//   <Update> 2016-09-08 - 3:16 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using System.Linq;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.GlobalRepository.SQL.Process;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class ProcessAppService : IProcessAppService
    {
        private readonly IStepRepository _stepRepository;

        public ProcessAppService(IStepRepository stepRepository)
        {
            _stepRepository = stepRepository;
        }

        public IEnumerable<Core.Entities.Process.Step> GetAllStepsEnablesByProduct(long productId)
        {
            return _stepRepository.GetAllStepsEnablesByProduct(productId);
        }
    }
}
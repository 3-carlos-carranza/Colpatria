#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=AccountController.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-12  - 5:37 p. m.</Date>
//   <Update> 2016-09-12 - 5:38 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Web.Mvc;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;

#endregion

namespace Presentation.Web.Colpatria.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        public AccountController(IProcessFlowArgument processFlowArgument, IProcessFlowManager processFlowManager)
            : base(processFlowArgument, processFlowManager)
        {
        }

        public ActionResult LogOff()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
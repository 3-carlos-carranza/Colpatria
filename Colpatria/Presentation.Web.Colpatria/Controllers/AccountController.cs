//   -----------------------------------------------------------------------
//   <copyright file=AccountController.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

#region

using System.Web.Mvc;
using Application.Main.Definition.MyCustomProcessFlow;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;

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
#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=DataController.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-05  - 11:34 a. m.</Date>
//   <Update> 2016-09-12 - 5:37 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Linq;
using System.Web.Mvc;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;

#endregion

namespace Presentation.Web.Colpatria.Controllers
{
    public class DataController : Controller
    {
        private readonly IDynamicAppService _dynamicFormAppService;

        public DataController(IDynamicAppService dynamicFormAppService)
        {
            _dynamicFormAppService = dynamicFormAppService;
        }

        [AllowAnonymous]
        [OutputCache(Duration = int.MaxValue, VaryByParam = "self")]
        public ActionResult GetDataListValues(int self, bool isLabel = false)
        {
            var reqfield = _dynamicFormAppService.GetRequestFieldByUserAndProccess(self, 1);
            if (reqfield?.ListId != null)
            {
                var results =
                    _dynamicFormAppService.GetDataListValues(reqfield.ListId.Value)
                        .OrderBy(dlv => dlv.Order)
                        .Select(v => new
                        {
                            value = v.OriginalValue.ToString(),
                            text = v.Value
                        }).ToList();
                if (isLabel)
                {
                    results.Insert(0, new
                    {
                        value = "0",
                        text = "Seleccione..."
                    });
                }
                return Json(results, JsonRequestBehavior.AllowGet);
            }

            return Json(new {});
        }



        [AllowAnonymous]
     
        public ActionResult GetDataListFilterValue(int self, string filterself, bool isLabel = false)
        {
            var reqfield = _dynamicFormAppService.GetRequestFieldByUserAndProccess(self, 1);
            if (reqfield?.ListId != null)
            {
                var results =
                    _dynamicFormAppService.GetDataListFilterValues(reqfield.ListId.Value, filterself)
                        .OrderBy(dlv => dlv.Order)
                        .Select(v => new
                        {
                            value = v.OriginalValue.ToString(),
                            text = v.Value
                        }).ToList();
                if (isLabel)
                {
                    results.Insert(0, new
                    {
                        value = "0",
                        text = "Seleccione..."
                    });
                }
                return Json(results, JsonRequestBehavior.AllowGet);
            }

            return Json(new { });
        }
    }
}
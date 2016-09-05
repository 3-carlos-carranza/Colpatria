using System.Linq;
using System.Web.Mvc;
using Application.Main.Definition;

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

            return Json(new { });
        }
    }
}
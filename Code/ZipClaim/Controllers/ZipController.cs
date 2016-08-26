using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZipClaim.Db.Services;

namespace ZipClaim.Controllers
{
    public class ZipController : Controller
    {
        // GET: Zip
        public ActionResult Index(int? page, int? psize, string erphandled, string claimnum, string catnum)
        {
            if (!page.HasValue)page = 1;
            if (!psize.HasValue) psize = 30;
            bool? isErpHandled = null;
            if (erphandled == "1") isErpHandled = true;
            else if (erphandled == "0") isErpHandled = false;
            else if (erphandled == "-1") isErpHandled = null;
            else isErpHandled = false;

            int totalCount;
            var list = ZipService.Instance().ClaimUnitGetList(out totalCount, page.Value, psize.Value, isErpHandled, claimnum, catnum);
            ViewBag.TotalCount = totalCount;

            return View(list);
        }

        [HttpPost]
        public ActionResult SetErpHandled(int id)
        {
            int userId;
            int.TryParse(Session["UserId"].ToString(), out userId);
            int[] ids = ZipService.Instance().ClaimUnitSetErpHandled(id, userId);
            
            return Json(ids);
        }

        [HttpPost]
        public ActionResult ZipDataItem(int id)
        {
            var model = ZipService.Instance().ClaimUnitGet(id);
            return View(model);
        }
    }
}
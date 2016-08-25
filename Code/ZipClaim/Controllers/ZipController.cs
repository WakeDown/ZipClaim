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
        public ActionResult Index(int? page, int? psize, string erphandled)
        {
            if (!page.HasValue) page = 1;
            if (!psize.HasValue) psize = 30;
            bool? isErpHandled = null;
            if (erphandled == "1") isErpHandled = true;
            else if (erphandled == "0") isErpHandled = false;
            else if (erphandled == "-1") isErpHandled = null;
            else isErpHandled = false;


            var list = ZipService.Instance().ClaimUnitGetList(page.Value, psize.Value, isErpHandled);

            return View(list);
        }
    }
}
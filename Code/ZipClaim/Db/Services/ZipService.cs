using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZipClaim.Db.Models;

namespace ZipClaim.Db.Services
{
    public class ZipService
    {
        unit_progEntities Db;
        public ZipService()
        {
            Db = new unit_progEntities();
        }

        public static ZipService Instance()
        {
            return new ZipService();
        }

        public IEnumerable<claim_unit_zip_data> ClaimUnitGetList(int page, int pageRows, bool? isErpHandled = null)
        {
            int skip = (page-1)*pageRows;

            var list = Db.claim_unit_zip_data.Where(x => x.enabled
            && (!isErpHandled.HasValue || (isErpHandled.HasValue && x.erp_handled == isErpHandled))
            ).OrderByDescending(x=>x.id_claim).ThenByDescending(x => x.id_claim_unit).Skip(skip).Take(pageRows)
                .ToList();
            return list;
        }   
    }
}
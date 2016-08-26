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

        public IEnumerable<claim_unit_zip_data> ClaimUnitGetList(out int totalCount, int page, int pageRows, bool? isErpHandled = null, string claimnum=null, string catnum = null)
        {
            int skip = (page-1)*pageRows;

            var list = Db.claim_unit_zip_data.Where(x => x.enabled
            && (!isErpHandled.HasValue || (isErpHandled.HasValue && x.erp_handled == isErpHandled))
            && (String.IsNullOrEmpty(catnum) || (!String.IsNullOrEmpty(catnum) && x.catalog_num.ToLower().Contains(catnum.ToLower())))
            && (String.IsNullOrEmpty(claimnum) || (!String.IsNullOrEmpty(claimnum) && x.id_claim.ToString().Contains(claimnum.ToLower())))
            ).OrderByDescending(x=>x.id_claim).ThenByDescending(x => x.id_claim_unit);

            totalCount = list.Count();

            var pageList = list.Skip(skip).Take(pageRows)
                .ToList();
            return pageList;
        }

        public claim_unit_zip_data ClaimUnitGet(int id)
        {
            var item = Db.claim_unit_zip_data.Single(x => x.id_claim_unit == id);
            return item;
        }

        public int[] ClaimUnitSetErpHandled(int claimUnitId, int userId)
        {
            var unit = Db.zipcl_claim_units.Single(x => x.id_claim_unit == claimUnitId);

            unit.erp_handled = true;
            unit.date_erp_handle = DateTime.Now;
            unit.system_handle = false;
            unit.erp_handled_user_id = userId;

            var items =
                Db.zipcl_claim_units.Where(x => x.catalog_num.Trim().ToLower() == unit.catalog_num.Trim().ToLower() && x.id_claim_unit!=unit.id_claim_unit);

            foreach (var item in items)
            {
                item.erp_handled = true;
                item.date_erp_handle = DateTime.Now;
                item.system_handle = true;
                item.erp_handled_user_id = null;
            }
            
            Db.SaveChanges();

            var result = items.Select(x => x.id_claim_unit).ToList();
            result.Add(unit.id_claim_unit);

            return result.ToArray();
        }
    }
}
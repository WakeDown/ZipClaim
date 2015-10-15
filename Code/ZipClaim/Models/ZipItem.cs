using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZipClaim.Models
{
    public class ZipItem
    {
        public int Id { get; set; }
        public int ServiceSheetId { get; set; }
        public string PartNum { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
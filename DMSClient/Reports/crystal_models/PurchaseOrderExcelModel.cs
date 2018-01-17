using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMSClient.Reports.crystal_models
{
    public class PurchaseOrderExcelModel
    {
        public string order_no { get; set; }
        public string order_date { get; set; }
        public string product_name { get; set; }
        public string color_name { get; set; }
        public int quantity { get; set; }
    }
}
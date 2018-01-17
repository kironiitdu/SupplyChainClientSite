using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMSClient.Reports.crystal_models
{
    public class ModelWiseSummaryReport
    {
        public string product_name { get; set; }
        public int product_id { get; set; }
        public int general { get; set; }
        public int doa_others { get; set; }
        public int gift { get; set; }
        public int total_sales { get; set; }
        public decimal rebate_quantity { get; set; }
        public decimal rebate_amount { get; set; }
        public int live_dummy { get; set; }
        public decimal live_dummy_amount { get; set; }
        public int adjustment_qty { get; set; }
        public decimal adjustment { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMSClient.Reports.crystal_models
{
    public class InventoryStockModel
    {
        public long warehouse_id { get; set; }
        public string warehouse_name { get; set; }
        public string transaction_type { get; set; }
        public string party_name { get; set; }
        public long party_id { get; set; }
        public string transaction_date { get; set; }
        public string document_code { get; set; }
        public string product_name { get; set; }
        public string color_name { get; set; }
        public string unit_name { get; set; }
        public decimal stock_quantity { get; set; }
        public string update_date { get; set; }
        public string to_date { get; set; }
        public string current_user_full_name { get; set; }
    }
}
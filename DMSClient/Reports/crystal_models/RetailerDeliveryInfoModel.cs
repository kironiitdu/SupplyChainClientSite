using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMSClient.Reports.crystal_models
{
    public class RetailerDeliveryInfoModel
    {
        public string retailer_delivery_code { get; set; }
        public string created_date { get; set; }
        public string product_name { get; set; }
        public string color_name { get; set; }
        public string imei_no { get; set; }
    }
}
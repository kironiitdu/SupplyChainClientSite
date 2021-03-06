﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMSClient.Reports.crystal_models
{
    public class InternalInvoiceReportModel
    {
        public string invoice_no { get; set; }
        public DateTime invoice_date { get; set; }
        public string full_name { get; set; }
        public string customar_name { get; set; }
        public string mobile_no { get; set; }
        public string internal_requisition_no { get; set; }
        public string payment_type { get; set; }
        public string department_name { get; set; }
        public string product_name { get; set; }
        public string product_category_name { get; set; }
        public string color_name { get; set; }
        public string unit_name { get; set; }
        public string brand_name { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal line_total { get; set; }
        public string billing_address { get; set; }
        public DateTime requisition_code { get; set; }
        public long invoice_master_id { get; set; }
        public bool is_gift { get; set; }
    }
}
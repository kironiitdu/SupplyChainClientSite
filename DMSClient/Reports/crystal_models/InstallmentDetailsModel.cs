using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMSClient.Reports.crystal_models
{
    public class InstallmentDetailsModel
    {
        public string installment_no { get; set; }
        public DateTime installment_date { get; set; }
        public decimal installment_amount { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMSClient.Reports.crystal_models
{
    public class InternalEmiCombinedInvoiceReportModel
    {
        public List<InternalInvoiceReportModel> InternalInvoiceReportModel { get; set; }
        public List<InstallmentDetailsModel> InstallmentDetailsModel { get; set; }
    }
}
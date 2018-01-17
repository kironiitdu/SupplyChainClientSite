using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMSClient.Models
{
    public class Confirmation
    {
        //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=rpac_erp;User ID=sa;Password=sa@admin");
        public string output { get; set; }
        public string msg { get; set; }

        public string return_object { get; set; }
    }
}
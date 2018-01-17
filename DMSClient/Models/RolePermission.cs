using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMSClient.Models
{
    public class RolePermission
    {
        public int user_permission_id { get; set; }
        public int control_id { get; set; }
        public string control_name { get; set; }
        public int control_parent_id { get; set; }
        public int control_type_id { get; set; }
        public string control_controller { get; set; }
        public string control_status { get; set; }
        public string control_action { get; set; }
    }
}
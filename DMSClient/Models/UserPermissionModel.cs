using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMSClient.Models
{
    public class UserPermissionModel
    {
        public int user_permission_id { get; set; }
        public Nullable<int> user_au_id { get; set; }
        public Nullable<int> user_control_id { get; set; }
        public Nullable<int> user_permission_status { get; set; }
        public Nullable<int> user_role_id { get; set; }

        public int control_id { get; set; }
        public string control_name { get; set; }
        public Nullable<int> control_parent_id { get; set; }
        public Nullable<int> control_type_id { get; set; }
        public Nullable<int> control_sort { get; set; }
        public string control_alias { get; set; }
        public string control_controller { get; set; }
        public Nullable<int> Level { get; set; }
        public bool control_status { get; set; }
        public List<string> permissions { get; set; }
    }
}
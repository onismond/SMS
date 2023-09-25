using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Model.Responses
{
    public class IndexResponse
    {
        public bool isSuccessful { get; set; }
        public Featured[] featured { get; set; }
    }

    public class Featured
    {
        public int id { get; set; }
        public string name { get; set; }
        public string amount { get; set; }
        public string image { get; set; }
        public int?[] images { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string owner_name { get; set; }
        public string owner_image { get; set; }
        public string owner_contact { get; set; }
        public string owner_id { get; set; }
        public string open_time { get; set; }
        public string close_time { get; set; }
        public bool is_store { get; set; }
        public int views { get; set; }
    }
}

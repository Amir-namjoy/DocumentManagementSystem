using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaliArchive
{
    public class User
    {

        public string uid { get; set; }
        public  string username { get; set; }
        public  string name { get; set; }
        public  string family { get; set; }
        public string semat { get; set; }
        public string gender { get; set; }
        public string personalid { get; set; }
        public  bool addNew { get; set; }
        public  bool editdoc { get; set; }
        public  bool showdoc { get; set; }
        public  bool gozaresh { get; set; }
        public bool manageUsers { get; set; }
        public  bool addUser { get; set; }
        public  bool editUser { get; set; }
        public bool manageAshkas { get; set; }
        public  bool viewLog { get; set; }
        public  bool allowLogin { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaliArchive
{
    static class cUser
    {

        internal static string uid { get; set; }
        public static string username { get; set; }
        public static string name { get; set; }
        public static string family { get; set; }

        public static bool addNew { get; set; }
        public static bool editdoc { get; set; }
        public static bool showdoc { get; set; }
        public static bool gozaresh { get; set; }
        public static bool manageUsers { get; set; }
        public static bool addUser { get; set; }
        public static bool editUser { get; set; }
        public static bool manageAshkas { get; set; }
        public static bool viewLog { get; set; }
        public static bool allowLogin { get; set; }
    }
}

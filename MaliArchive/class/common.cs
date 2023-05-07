using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.Data;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Data.OleDb;
using System.Drawing;
using System.Net;
using System.Net.Sockets;


using System.Security.Cryptography;

namespace MaliArchive
{
 
    class common
    {
        
        public static string ProgramName="بايگاني امور مالي";

        public static string pRootFolder = "MaliArchive";
        public static string TempFolder = "Temporary";
        public static bool inLoad = false;

        public static string GetTempFolderPath(string folderName)
        {
            try
            {
                // The folder for the roaming current user 
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                // Combine the base folder with your specific folder....
               //.net 4.5 string specificFolder = Path.Combine(folder, pRootFolder, TempFolder, folderName);
                // .net 3.5
                string specificFolder = folder + "\\" +pRootFolder +"\\"+ TempFolder +"\\"+ folderName;

                // Check if folder exists and if not, create it
                if (!Directory.Exists(specificFolder))
                    Directory.CreateDirectory(specificFolder);

                /* if (!Directory.Exists(TempFolder))
                 {
                     Directory.CreateDirectory(TempFolder);
                 }
                 if (!Directory.Exists(TempFolder + "\\" + folderName))
                 {
                     Directory.CreateDirectory(TempFolder + "\\" + folderName);
                 }*/
                return specificFolder;
            }
            catch
            {
                return "";
            }

        }

        public static bool DeleteTempFolder(string folderName)
        {
            try
            {
                string df = GetTempFolderPath(folderName);
                if (Directory.Exists(df))
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(df);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    di.Delete(true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Doc TempDoc = new Doc();
        public static User TempUser = new User();
        public static shaks TempShaks = new shaks();

        public static string GetHashedPassword(string password) 
        { 
            var hasher = System.Security.Cryptography.SHA1.Create(); 
            var bytes = System.Text.Encoding.UTF8.GetBytes(password); 
            return Convert.ToBase64String(hasher.ComputeHash(bytes));
        }

        public static void writelog(int logcode, string roydad, string logtozihat, string userid, string pid)
        {

            /*
             *  1 ورود كاربر به سيستم
             *  2 ورود رمز اشتباه 
             *  3 افزودن كاربر جديد
             *  4 ويرايش اطلاعات و دسترسي هاي كاربر
             *  5 تغيير رمز عبور كاربر
             *  6 تغيير رمز عبور كاربر جاري
             *  7  تغيير رمز عبور كاربر جاري - ورود رمز اشتباه 
             *  8 تهيه گزارش
             *  9 افزودن پرونده جديد
             *  10 ويرايش پرونده
             *  11 خروج كاربر از سيستم
             *  12 مشاهده پرونده
             *  13 مشاهده پرونده از طريق ويرايش
             *  14 افزودن شخص جديد
             *  15 تغيير مشخصات شخص
             *  16 گزارش رويدادنگاري
             *  17 عدم اجازه ورود به سيستم
             *  18 تبت امانت
             *  19 تحويل امانت
             */

            DA.run_Query("insert into userslog values('" + logcode + "', GETDATE() ,'" + roydad + "','" + logtozihat + "','" + userid + "','" + pid + "')");
 
        }


        public static string persian_date(DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime thisDate = dt;

            return (Convert.ToString(pc.GetYear(dt) + "/" + pc.GetMonth(thisDate) + "/" + pc.GetDayOfMonth(thisDate)));

        }

        public static string persian_datetime(DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime thisDate = dt;

            return (Convert.ToString(pc.GetYear(dt) + "/" + pc.GetMonth(thisDate) + "/" + pc.GetDayOfMonth(thisDate) + " " + pc.GetHour(thisDate) + ":" + pc.GetMinute(thisDate) + ":" + pc.GetSecond(thisDate)));

        }

        public static void setLanguageToFarsi()
        {

            InputLanguage currentInputLanguage = InputLanguage.CurrentInputLanguage;
            foreach (InputLanguage language2 in InputLanguage.InstalledInputLanguages)
            {
                if ((((language2.Culture.EnglishName.LastIndexOf("Farsi") != -1) || (language2.Culture.EnglishName.LastIndexOf("farsi") != -1)) || ((language2.Culture.EnglishName.LastIndexOf("FARSI") != -1) || (language2.Culture.EnglishName.LastIndexOf("Persian") != -1))) || (((language2.Culture.EnglishName.LastIndexOf("persian") != -1) || (language2.Culture.EnglishName.LastIndexOf("Iran") != -1)) || (language2.Culture.EnglishName.LastIndexOf("iran") != -1)))
                {
                    currentInputLanguage = language2;
                    break;
                }
            }
            InputLanguage.CurrentInputLanguage = currentInputLanguage;
        }

        public static bool GetResolvedConnecionIPAddress(string serverNameOrURL,
                   out IPAddress resolvedIPAddress)
        {
            bool isResolved = false;
            IPHostEntry hostEntry = null;
            IPAddress resolvIP = null;
            try
            {
                if (!IPAddress.TryParse(serverNameOrURL, out resolvIP))
                {
                    hostEntry = Dns.GetHostEntry(serverNameOrURL);

                    if (hostEntry != null && hostEntry.AddressList != null
                                 && hostEntry.AddressList.Length > 0)
                    {
                        if (hostEntry.AddressList.Length == 1)
                        {
                            resolvIP = hostEntry.AddressList[0];
                            isResolved = true;
                        }
                        else
                        {
                            foreach (IPAddress var in hostEntry.AddressList)
                            {
                                if (var.AddressFamily == AddressFamily.InterNetwork)
                                {
                                    resolvIP = var;
                                    isResolved = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    isResolved = true;
                }
            }
            catch (Exception)
            {
                isResolved = false;
                resolvIP = null;
            }
            finally
            {
                resolvedIPAddress = resolvIP;
            }

            return isResolved;
        }

        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n2} {1}", adjustedSize, SizeSuffixes[mag]);
        }
    }

     

    public class Functions
    {
        public static string filename = "";

        public static string GetDefaultBackupPath()
        {
            DataSet set = null;
            if (File.Exists(filename))
            {
                try
                {
                    DataTable table;
                    set = DataPacker.UnpackData(File.ReadAllBytes(filename));
                    table = table = set.Tables["Setting"];
                    if (table == null)
                    {
                        return "";
                    }
                    return table.Rows[0]["BackupPath"].ToString();
                }
                catch
                {
                    return "";
                }
            }
            return "";
        }

        public static int GetHashId(string str)
        {
            str = "spx" + str + "coVasta";
            return str.GetHashCode();
        }

        public static void SaveDefaultBackupPath(string path)
        {
            DataTable table;
            DataRow row;
            DataSet ds = DataPacker.UnpackData(File.ReadAllBytes(filename));
            table = table = ds.Tables["Setting"];
            if (table == null)
            {
                table = new DataTable("Setting");
                table.Columns.Add("BackupPath");
                row = table.NewRow();
                row["BackupPath"] = path;
                table.Rows.Add(row);
                ds.Tables.Add(table);
            }
            row = table.Rows[0];
            row["BackupPath"] = path;
            File.WriteAllBytes(filename, DataPacker.PackDataSet(ds));
        }
    }

    public class DataPacker
    {
        private static readonly int CHECK_SUM_LENGTH;
        private static readonly int CHECK_SUM_OFFSET;
        private static readonly string DATA_FILE_NAME;
        private static readonly int DATA_OFFSET;
        private static readonly string SCHEMA_FILE_NAME;
        private static readonly byte[] VERSION;
        private static readonly int VERSION_LENGTH;
        private static readonly int VERSION_OFFSET;

        static DataPacker()
        {
            byte[] buffer = new byte[3];
            buffer[0] = 1;
            VERSION = buffer;
            VERSION_OFFSET = 0;
            VERSION_LENGTH = 3;
            CHECK_SUM_OFFSET = 3;
            CHECK_SUM_LENGTH = 0x40;
            DATA_OFFSET = VERSION_LENGTH + CHECK_SUM_LENGTH;
            DATA_FILE_NAME = "Vasta.xml";
            SCHEMA_FILE_NAME = "Vasta.xsd";
        }

        private static byte[] CalculateCheckSum(MemoryStream ms)
        {
            new SHA512Managed();
            return CalculateCheckSum(ms.ToArray(), 0, (int)ms.Length);
        }

        private static byte[] CalculateCheckSum(byte[] buf, int offset, int count)
        {
            SHA512 sha = new SHA512Managed();
            return sha.ComputeHash(buf, offset, count);
        }

        public static byte[] PackDataSet(DataSet ds)
        {
            MemoryStream baseOutputStream = new MemoryStream();
            ZipOutputStream stream = new ZipOutputStream(baseOutputStream);
            stream.SetLevel(9);
            MemoryStream stream3 = new MemoryStream();
            ds.WriteXmlSchema(stream3);
            stream3 = XorData(stream3);
            ZipEntry entry = new ZipEntry(SCHEMA_FILE_NAME)
            {
                DateTime = DateTime.Now
            };
            stream.PutNextEntry(entry);
            stream3.Position = 0L;
            stream3.WriteTo(stream);
            MemoryStream stream4 = new MemoryStream();
            ds.WriteXml(stream4);
            stream4 = XorData(stream4);
            ZipEntry entry2 = new ZipEntry(DATA_FILE_NAME)
            {
                DateTime = DateTime.Now
            };
            stream.PutNextEntry(entry2);
            stream4.Position = 0L;
            stream4.WriteTo(stream);
            stream.Finish();
            MemoryStream stream5 = new MemoryStream();
            stream5.Write(VERSION, 0, VERSION.Length);
            byte[] buffer = CalculateCheckSum(baseOutputStream);
            stream5.Write(buffer, 0, buffer.Length);
            baseOutputStream.WriteTo(stream5);
            return XorData(stream5).ToArray();
        }

        public static DataSet UnpackData(byte[] data)
        {
            DataSet set2;
            data = XorData(data);
            try
            {
                for (int i = 0; i < VERSION_LENGTH; i++)
                {
                    int index = VERSION_OFFSET + i;
                    if (VERSION[i] != data[index])
                    {
                        throw new ArgumentException("نسخه اطلاعات صحیح نمی‌باشد.");
                    }
                }
            }
            catch
            {
                throw new ArgumentException("خطا در کنترل نسخه اطلاعات");
            }
            try
            {
                byte[] buffer = CalculateCheckSum(data, DATA_OFFSET, data.Length - DATA_OFFSET);
                for (int j = 0; j < CHECK_SUM_LENGTH; j++)
                {
                    int num4 = CHECK_SUM_OFFSET + j;
                    if (buffer[j] != data[num4])
                    {
                        throw new ArgumentException("ساختار اطلاعات صحیح نمی‌باشد.");
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            try
            {
                ZipEntry entry;
                DataSet set = new DataSet();
                MemoryStream baseInputStream = new MemoryStream(data, DATA_OFFSET, data.Length - DATA_OFFSET)
                {
                    Position = 0L
                };
                ZipInputStream stream2 = new ZipInputStream(baseInputStream);
                while ((entry = stream2.GetNextEntry()) != null)
                {
                    if (entry.Name == SCHEMA_FILE_NAME)
                    {
                        MemoryStream ms = new MemoryStream();
                        int count = 0x800;
                        byte[] buffer2 = new byte[0x800];
                        while (true)
                        {
                            count = stream2.Read(buffer2, 0, buffer2.Length);
                            if (count <= 0)
                            {
                                break;
                            }
                            ms.Write(buffer2, 0, count);
                        }
                        ms.Position = 0L;
                        ms = XorData(ms);
                        set.ReadXmlSchema(ms);
                        continue;
                    }
                    if (entry.Name == DATA_FILE_NAME)
                    {
                        MemoryStream stream4 = new MemoryStream();
                        int num6 = 0x800;
                        byte[] buffer3 = new byte[0x800];
                        while (true)
                        {
                            num6 = stream2.Read(buffer3, 0, buffer3.Length);
                            if (num6 <= 0)
                            {
                                break;
                            }
                            stream4.Write(buffer3, 0, num6);
                        }
                        stream4.Position = 0L;
                        stream4 = XorData(stream4);
                        set.ReadXml(stream4);
                    }
                }
                set2 = set;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            return set2;
        }

        private static MemoryStream XorData(MemoryStream ms)
        {
            ms.Position = 0L;
            byte[] buffer = ms.ToArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)(buffer[i] ^ 0xff);
            }
            return new MemoryStream(buffer);
        }

        private static byte[] XorData(byte[] buf)
        {
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = (byte)(buf[i] ^ 0xff);
            }
            return buf;
        }
    }

    public class ConnectionManager
    {
        private string filename = "";

        public ConnectionManager(string filename)
        {
            this.filename = filename;
        }

        public String GetConnectionString()
        {

            if (ConnectionSetting.SQLServerUsername.Equals(""))
            {
                return "Data Source=" + ConnectionSetting.SQLServerName + ";Initial Catalog=" + ConnectionSetting.DatabaseName + ";Integrated Security=SSPI;";
            }
            else
            {
                return "Data Source=" + ConnectionSetting.SQLServerName + ";Initial Catalog=" + ConnectionSetting.DatabaseName + 
                    ";Persist Security Info=True;User ID=" +
                    ConnectionSetting.SQLServerUsername + ";Password=" + ConnectionSetting.SQLServerPassword;
            }
        }
 
        public bool LoadSetting()
        {
            try
            {
                DataRow row = DataPacker.UnpackData(File.ReadAllBytes(this.filename)).Tables["connection"].Rows[0];
                ConnectionSetting.SQLServerName = row["SQLServerName"].ToString();
                ConnectionSetting.DatabaseName = row["DatabaseName"].ToString();
                ConnectionSetting.SQLServerUsername = row["SQLServerUsername"].ToString();
                ConnectionSetting.SQLServerPassword = row["SQLServerPassword"].ToString();
                ConnectionSetting.CurrentDatabaseType = (DatabaseType)Convert.ToInt32(row["CurrentDatabaseType"].ToString());
                DA.ConnectionString = GetConnectionString();
                return true;
            }
            catch
            {
 
                ConnectionSetting.SQLServerName = "";
                ConnectionSetting.DatabaseName = "";
                ConnectionSetting.SQLServerUsername = "";
                ConnectionSetting.SQLServerPassword = "";
                ConnectionSetting.CurrentDatabaseType = DatabaseType.SQLExpress;
                return false;
            }
        }

        public bool SaveSetting()
        {
            DataSet ds = null;
            if (File.Exists(this.filename))
            {
                try
                {
                    ds = DataPacker.UnpackData(File.ReadAllBytes(this.filename));
                }
                catch
                {
                }
            }
            DataRow row = null;
            bool flag = false;
            if (ds == null)
            {
                ds = new DataSet();
                flag = true;
            }
            else
            {
                try
                {
                    row = ds.Tables["connection"].Rows[0];
                }
                catch
                {
                    flag = true;
                }
            }
            if (flag)
            {
                DataTable table = new DataTable("connection");
                 table.Columns.Add("SQLServerName");
                table.Columns.Add("DatabaseName");
                table.Columns.Add("SQLServerUsername");
                table.Columns.Add("SQLServerPassword");
                table.Columns.Add("CurrentDatabaseType");
                row = table.NewRow();
                table.Rows.Add(row);
                ds.Tables.Add(table);
            }
            try
            {
                row["SQLServerName"] = ConnectionSetting.SQLServerName;
                row["DatabaseName"] = ConnectionSetting.DatabaseName;
                row["SQLServerUsername"] = ConnectionSetting.SQLServerUsername;
                row["SQLServerPassword"] = ConnectionSetting.SQLServerPassword;
                if (ConnectionSetting.CurrentDatabaseType == DatabaseType.SQLExpress)
                {
                    row["CurrentDatabaseType"] = "2";
                }
                else if (ConnectionSetting.CurrentDatabaseType == DatabaseType.SqlServer)
                {
                    row["CurrentDatabaseType"] = "3";
                }
                File.WriteAllBytes(this.filename, DataPacker.PackDataSet(ds));
 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TestConnection()
        {
            try
            {
                if (File.Exists(this.filename))
                {

                    if (ConnectionSetting.SQLServerName == null)
                    {
                        return false;
                    }
                    if (ConnectionSetting.SQLServerName.Equals(""))
                    {
                        return false;
                    }
                    SqlConnection Testconnection = new SqlConnection();
                    string TestConnectionString = this.GetConnectionString();
                    if (TestConnectionString.Equals(""))
                    {
                        return false;
                    }
                    Testconnection.ConnectionString = TestConnectionString;
                    Testconnection.Open();
                    Testconnection.Close();
                    return true;
                    
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }

    public class ConnectionSetting
    {
        public static DatabaseType CurrentDatabaseType = DatabaseType.SQLExpress;
        public static string DatabaseName = "MaliArchiveDB";
        public static string SQLServerName = "";
        public static string SQLServerPassword = "";
        public static string SQLServerUsername = "";
    }

     public class commonFunction
    {

  
        private static string getDahgan(int dahgan, int yekan)
        {
            switch (dahgan)
            {
                case 1:
                    switch (yekan)
                    {
                        case 1:
                            return "یازده";

                        case 2:
                            return "دوازده";

                        case 3:
                            return "سيزده";

                        case 4:
                            return "چهارده";

                        case 5:
                            return "پانزده";

                        case 6:
                            return "شانزده";

                        case 7:
                            return "هفده";

                        case 8:
                            return "هجده";

                        case 9:
                            return "نوزده";
                    }
                    return "ده";

                case 2:
                    return "بيست";

                case 3:
                    return "سي";

                case 4:
                    return "چهل";

                case 5:
                    return "پنجاه";

                case 6:
                    return "شصت";

                case 7:
                    return "هفتاد";

                case 8:
                    return "هشتاد";

                case 9:
                    return "نود";
            }
            return "";
        }

        public static string getFarsiText(string instr)
        {
            if (instr == null)
            {
                return null;
            }
            string[] strArray = new string[] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            string str = "";
            for (int i = 0; i < instr.Length; i++)
            {
                switch (instr.Substring(i, 1))
                {
                    case "0":
                        str = str + strArray[0];
                        break;

                    case "1":
                        str = str + strArray[1];
                        break;

                    case "2":
                        str = str + strArray[2];
                        break;

                    case "3":
                        str = str + strArray[3];
                        break;

                    case "4":
                        str = str + strArray[4];
                        break;

                    case "5":
                        str = str + strArray[5];
                        break;

                    case "6":
                        str = str + strArray[6];
                        break;

                    case "7":
                        str = str + strArray[7];
                        break;

                    case "8":
                        str = str + strArray[8];
                        break;

                    case "9":
                        str = str + strArray[9];
                        break;

                    default:
                        str = str + instr.Substring(i, 1);
                        break;
                }
            }
            return str;
        }

        public static string GetHashString(byte[] bytes)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(bytes).Replace("'", " ");
        }

        public static string getInstallPath()
        {
            if (vars.InstallPath.Equals(""))
            {
                try
                {
                    string[] strArray = File.ReadAllLines("projectoptions.txt");
                    if (strArray == null)
                    {
                        return null;
                    }
                    foreach (string str in strArray)
                    {
                        if (str.IndexOf("path=") >= 0)
                        {
                            vars.InstallPath = str.Substring(str.IndexOf("=") + 1, str.Length - 5);
                        }
                    }
                }
                catch
                {
                    return Directory.GetCurrentDirectory();
                }
            }
            return vars.InstallPath;
        }

        private static string getSadgan(int sadgan)
        {
            switch (sadgan)
            {
                case 1:
                    return "يکصد";

                case 2:
                    return "دويست";

                case 3:
                    return "سيصد";

                case 4:
                    return "چهارصد";

                case 5:
                    return "پانصد";

                case 6:
                    return "ششصد";

                case 7:
                    return "هفتصد";

                case 8:
                    return "هشتصد";

                case 9:
                    return "نهصد";
            }
            return "";
        }
 
        public static bool isDataSetEmpty(DataSet ds)
        {
            return ((ds == null) || ((ds.Tables == null) || ((ds.Tables.Count == 0) || ((ds.Tables[0] == null) || ((ds.Tables[0].Rows == null) || (ds.Tables[0].Rows.Count == 0))))));
        }
  
        public static void setLanguageToFarsi()
        {
            InputLanguage currentInputLanguage = InputLanguage.CurrentInputLanguage;
            foreach (InputLanguage language2 in InputLanguage.InstalledInputLanguages)
            {
                if ((((language2.Culture.EnglishName.LastIndexOf("Farsi") != -1) || (language2.Culture.EnglishName.LastIndexOf("farsi") != -1)) || ((language2.Culture.EnglishName.LastIndexOf("FARSI") != -1) || (language2.Culture.EnglishName.LastIndexOf("Persian") != -1))) || (((language2.Culture.EnglishName.LastIndexOf("persian") != -1) || (language2.Culture.EnglishName.LastIndexOf("Iran") != -1)) || (language2.Culture.EnglishName.LastIndexOf("iran") != -1)))
                {
                    currentInputLanguage = language2;
                    break;
                }
            }
            InputLanguage.CurrentInputLanguage = currentInputLanguage;
        }

    }

     public class vars
    {
        public static string BACKUP_FILE_EXTENTION = "";
        public static string BACKUP_PATH = "";
        public static int CANCEL_STATE = 2;
       
        public static string dbFileName = "";
        public static bool DontChangeScreenSize = false;
        public static string FONT_NAME = "Arial";
        public static int FONT_SIZE_0 = 14;
        public static int FONT_SIZE_1 = 12;
        public static int FONT_SIZE_2 = 12;
        public static int FONT_SIZE_3 = 10;
        public static int FONT_SIZE_4 = 10;
        public static int FONT_SIZE_5 = 10;
        public static int FONT_SIZE_6 = 8;
        public static Color FORM_BACK_COLOR = Color.LightSteelBlue;
        public static Color GRID_BACK_COLOR = Color.LemonChiffon;
        public static string InstallPath = "";
        public static bool IS_LANDSCAPE = false;
        public static int LATEST_MAIN_MENU_INDEX = 0;
        //public static MainPage MAIN_FORM = null;
        public static int mainFormHeight = 0x300;
        public static int mainFormWidth = 0x400;
        public static int NEXT_STATE = 1;
        public static int PAPER_HEIGHT = 0x491;
        public static int PAPER_WIDTH = 0x33b;
        public static int PRINT_LEFT_MARGIN = 50;
        public static string PRINTER_NAME = "";
        public static Color REQUIRE_BACK_COLOR = Color.MistyRose;
        public static string SEND_DATA_PATH = "";
        public static bool SHOW_PRINT_PREVIEW = true;
        public static int SUB_MENU_TYPE = 1;
        public static int SYSTEM_VERSION = 0xd6fec;
        public static string systemName = "";
        public static string systemTitle = "";
        public static int tableLayoutWidth = 230;
        public static Label textLable = new Label();
        public static ToolTip TOOL_TIP = new ToolTip();
        public static int toolBarHeight = 0x35;
        public static int userKind = 2;
        public static string username = "";
        public static string WINDOW_FONT_NAME = "Arial";
        public static int WINDOW_FONT_SIZE = 12;
        public static int ZOOM_PERCENT = 100;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class DatabaseConnection
    {
        // SQLiteConnection.CreateFile("database.db");
        private static string ConnectionString = "Data Source=./database.db; Version=3";

       public static SQLiteConnection QLiteConnection = new SQLiteConnection(ConnectionString);

        private static bool OpenOrClose
        {
            get
            {
                if (QLiteConnection.State == ConnectionState.Open)
                    return true;//true = Bağlantı açık
                else
                    return false;// false = Bağlantı kapalı
            }
        }
        
        public static void OpenConnection()
        {
            if (OpenOrClose==false)
            {
                QLiteConnection.Open();
                //MessageBox.Show("Bağlantı Açıldı");
            }
            else
            {
               // MessageBox.Show("Bağlantı Zaten Açık");
            }
        }

        public static void CloseConnection()
        {
            if (OpenOrClose==true)
            {
                QLiteConnection.Close();
                //MessageBox.Show("Bağlantı Kapandı");
            }
            else
            {
                //MessageBox.Show("Bağlantı Zaten Kapalı");
            }
        }
    }
}
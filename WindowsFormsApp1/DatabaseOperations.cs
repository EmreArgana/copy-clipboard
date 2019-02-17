using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class DatabaseOperations
    {

        /* public static List<string> numara = new List<string>();
         public static List<string> icerik = new List<string>();*/
        //string Command = "SELECT * FROM TableCopiedData  ";/*Where id Like '" + id + "'";*/
        //string Command = "SELECT * FROM TableCopiedData LIMIT 0,'" + 10 + "'";

        public static void AddData(string CopiedText,string Category)
        {
            DatabaseConnection.OpenConnection();
            string Command = "INSERT INTO TableCopiedData (CopiedText,Category) VALUES (@CopiedText,@Category)";
            SQLiteCommand QLiteCommand = new SQLiteCommand(Command, DatabaseConnection.QLiteConnection);
            QLiteCommand.Parameters.AddWithValue("@CopiedText", CopiedText);
            QLiteCommand.Parameters.AddWithValue("@Category", Category);
            QLiteCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
        public static void GetData(int id, DataGridView dataGridView)
        {
            string Value = null;
            DatabaseConnection.OpenConnection();
            string Command = "SELECT * FROM TableCopiedData ORDER BY id DESC LIMIT '"+10+"'";
            SQLiteCommand QLiteCommand = new SQLiteCommand(Command, DatabaseConnection.QLiteConnection);
            SQLiteDataAdapter QLiteDataAdapter = new SQLiteDataAdapter(QLiteCommand);
            DataTable dataTable = new DataTable();
            QLiteDataAdapter.Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DatabaseConnection.CloseConnection();
            //return Value = dataTable.Rows[id]["CopiedText"].ToString();
        }
    }
}
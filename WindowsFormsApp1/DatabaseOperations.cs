using System.Data.SQLite;
using System.Data;
using System;

namespace WindowsFormsApp1
{
    public class DatabaseOperations
    {

        public static void AddData(string CopiedText,string Category, string Date)
        {
            DatabaseConnection.OpenConnection();
            string Command = "INSERT INTO TableCopiedData (CopiedText,Category,Date) VALUES (@CopiedText,@Category,@Date)";
            SQLiteCommand QLiteCommand = new SQLiteCommand(Command, DatabaseConnection.QLiteConnection);
            QLiteCommand.Parameters.AddWithValue("@CopiedText", CopiedText);
            QLiteCommand.Parameters.AddWithValue("@Category", Category);
            QLiteCommand.Parameters.AddWithValue("@Date", Date);
            QLiteCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
        public static string GetData(int id)
        {
            DatabaseConnection.OpenConnection();
            string Command = "SELECT DISTINCT CopiedText FROM TableCopiedData ORDER BY id ASC;";// DESC ters sıralar
            SQLiteCommand QLiteCommand = new SQLiteCommand(Command, DatabaseConnection.QLiteConnection);
            SQLiteDataAdapter QLiteDataAdapter = new SQLiteDataAdapter(QLiteCommand);
            DataTable dataTable = new DataTable();
            QLiteDataAdapter.Fill(dataTable);
            DatabaseConnection.CloseConnection();
            return dataTable.Rows[id]["CopiedText"].ToString();
        }
        public static int GetDataCount()
        {
            DatabaseConnection.OpenConnection();
            string Command = "SELECT count(DISTINCT CopiedText)  FROM TableCopiedData";
            SQLiteCommand QLiteCommand = new SQLiteCommand(Command, DatabaseConnection.QLiteConnection);
            SQLiteDataAdapter QLiteDataAdapter = new SQLiteDataAdapter(QLiteCommand);
            DataTable dataTable = new DataTable();
            QLiteDataAdapter.Fill(dataTable);
            DatabaseConnection.CloseConnection();
            return Convert.ToInt32(dataTable.Rows[0]["count(DISTINCT CopiedText)"]);
        }
        public static string GetLastData()
        {
            DatabaseConnection.OpenConnection();
            string Command = "SELECT * FROM TableCopiedData ORDER BY id DESC LIMIT 1";
            SQLiteCommand QLiteCommand = new SQLiteCommand(Command, DatabaseConnection.QLiteConnection);
            SQLiteDataAdapter QLiteDataAdapter = new SQLiteDataAdapter(QLiteCommand);
            DataTable dataTable = new DataTable();
            QLiteDataAdapter.Fill(dataTable);
            DatabaseConnection.CloseConnection();
            return dataTable.Rows[0]["CopiedText"].ToString();
        }

    }
}
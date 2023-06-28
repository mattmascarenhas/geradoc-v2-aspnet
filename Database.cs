using System.Data;
using System.Data.SqlClient;

namespace geradoc_v2 {
    public class Database {
        public Database() {
            try {
                Connection = new SqlConnection(Settings.StringConnection);
                Connection.Open();
                Console.WriteLine("Connected!");
            } catch (Exception ex) {
                Console.WriteLine($"Failed to connect to the database: {ex.Message}");
            }  
        }

        public SqlConnection Connection { get; set; }

        public void Dispose() {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }

    }
}

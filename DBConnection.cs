using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Gestion_Taller {
    public sealed class DBConnection {
        private static readonly DBConnection instance = new DBConnection();
        private SQLiteConnection sqliteConnection;
        private static String dbFileName = "database.sqlite";

        private DBConnection() {

        }

        public static DBConnection Instance {
            get {
                return instance;
            }
        }

        public String GetAdministratorPassword() {
            return "pape";
        }
    }
}

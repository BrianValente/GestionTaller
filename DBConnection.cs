using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Taller {
    public sealed class DBConnection {
        private static readonly DBConnection instance = new DBConnection();

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

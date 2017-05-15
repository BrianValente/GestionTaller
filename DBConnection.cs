using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Gestion_Taller {
    public sealed class DBConnection {
        private static readonly DBConnection instance = new DBConnection();
        private SQLiteConnection sqliteConnection;
        private static String dbFileName = "database.sqlite";

        private DBConnection() {
            bool dbExists = File.Exists("database.sqlite");

            if (!dbExists) 
                SQLiteConnection.CreateFile("database.sqlite");

            sqliteConnection = new SQLiteConnection("Data Source=database.sqlite;Version=3;");
            sqliteConnection.Open();

            if (!dbExists)
                createTables();
        }

        private void createTables() {
            String sqlCreateTeachersTable = "CREATE TABLE teachers (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, firstname TEXT NOT NULL, lastname TEXT NOT NULL);";
            String sqlCreateInventoryTable = "CREATE TABLE inventory (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, description TEXT NOT NULL, user_using INTEGER, icon_id INTEGER);";
            String sqlCreateTransactionsTable = "CREATE TABLE transactions (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, inventory_type_id INTEGER NOT NULL, teacher_id INTEGER);";

            String sqlInsertBrianXd = "INSERT INTO teachers (firstname, lastname) VALUES ('Brian', 'Valente');";
            String sqlInsertCristianXd = "INSERT INTO teachers (firstname, lastname) VALUES ('Cristian', 'De Leon');";


            String query = sqlCreateTeachersTable + sqlCreateInventoryTable + sqlCreateTransactionsTable + sqlInsertBrianXd + sqlInsertCristianXd;

            SQLiteCommand command = new SQLiteCommand(query, sqliteConnection);
            command.ExecuteNonQuery();
        }

        public static DBConnection Instance {
            get {
                return instance;
            }
        }

        public String GetAdministratorPassword() {
            return "";
        }


        // Teachers

        public void changeTeacherFirstName(int teacherId, String firstName) {
            String query = "UPDATE teachers SET firstname = '" + firstName + "' WHERE id=" + teacherId;
            new SQLiteCommand(query, sqliteConnection).ExecuteNonQuery();
        }

        public void changeTeacherLastName(int teacherId, String lastName) {
            String query = "UPDATE teachers SET lastname = '" + lastName + "' WHERE id=" + teacherId;
            new SQLiteCommand(query, sqliteConnection).ExecuteNonQuery();
        }

        public Teacher AddTeacher(String firstname, String lastname) {
            String query = "INSERT INTO teachers (firstname, lastname) VALUES ('" + firstname + "', '" + lastname + "');";

            new SQLiteCommand(query, sqliteConnection).ExecuteNonQuery();

            return new Teacher((int)sqliteConnection.LastInsertRowId, firstname, lastname);
        }

        public List<Teacher> GetTeachers() {
            List<Teacher> teachers = new List<Teacher>();

            String query = "SELECT * FROM teachers";

            SQLiteCommand command = new SQLiteCommand(query, sqliteConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
                teachers.Add(new Teacher(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));

            return teachers;
        }

        public Teacher GetTeacherById(int id) {
            String query = "SELECT * FROM teachers WHERE id=" + id;
            SQLiteDataReader reader = new SQLiteCommand(query, sqliteConnection).ExecuteReader();

            if (!reader.Read())
                return null;

            return new Teacher(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
        }

        public bool DeleteTeacherById(int id) {
            String query = "DELETE FROM teachers WHERE id=" + id;
            new SQLiteCommand(query, sqliteConnection).ExecuteNonQuery();
            return true;
        }




        // Inventory
        public InventoryItem AddInventoryItem(String name, String description, int icon_id) {
            String query = "INSERT INTO Inventory (name, description, user_using, icon_id) VALUES ('" + name + "', '" + description + "', 0, '" + icon_id + "');";

           new SQLiteCommand(query, sqliteConnection).ExecuteNonQuery();

           return new InventoryItem((int)sqliteConnection.LastInsertRowId, name, description, 0, icon_id);
        }

        public List<InventoryItem> GetInventoryItems() {
            List<InventoryItem> tools = new List<InventoryItem>();

            String query = "SELECT * FROM inventory";

            SQLiteCommand command = new SQLiteCommand(query, sqliteConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
                tools.Add(new InventoryItem(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4)));

            return tools;
        }

        public List<InventoryItem> GetInventoryItemsBeingUsedByUserId(int userId) {
            List<InventoryItem> inventoryItems = new List<InventoryItem>();
            String query = "SELECT * FROM inventory WHERE user_using=" + userId;
            SQLiteDataReader reader = new SQLiteCommand(query, sqliteConnection).ExecuteReader();

            while (reader.Read())
                inventoryItems.Add(new InventoryItem(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4)));

            return inventoryItems;
        }
    }
}

    

    public class InventoryItem {
        public int Id { get; private set; }
        public String Name { get; private set; }
        public String Description { get; private set; }
        public int Icon_id { get; private set; }
        public int UserIdUsing { get; private set; }

        public InventoryItem(int id, String name, String description, int userIdUsing, int icon_id) {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.UserIdUsing = userIdUsing;
            this.Icon_id = icon_id;
        }
    }


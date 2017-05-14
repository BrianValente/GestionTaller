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
            String sqlCreateInventoryTable = "CREATE TABLE inventory (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, description TEXT NOT NULL, icon_id INTEGER);";
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
            return "pape";
        }


        // Teachers

        private void changeTeacherFirstName(int teacherId, String firstName) {
            String query = "UPDATE teachers SET firstname = '" + firstName + "' WHERE id=" + teacherId;
        }

        private void changeTeacherLastName(int teacherId, String lastName) {
            String query = "UPDATE teachers SET lastname = '" + lastName + "' WHERE id=" + teacherId;
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




        // Inventory

        public List<InventoryItem> GetInventoryItems() {
            List<InventoryItem> tools = new List<InventoryItem>();

            String query = "SELECT * FROM inventory";

            SQLiteCommand command = new SQLiteCommand(query, sqliteConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
                tools.Add(new InventoryItem(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));

            return tools;
        }
    }
}

    public class Teacher {
        public int Id;
        public String FirstName;
        public String LastName;
        public String FullName;

        public Teacher(int id, String firstname, String lastname) {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            FullName = firstname + " " + lastname;
        }
    }

    public class InventoryItem {
        public int Id;
        public String Name;
        public String Description;
        public int Icon_id;

        public InventoryItem(int id, String name, String description, int icon_id) {
            Id = id;
            Name = name;
            Description = description;
            Icon_id = icon_id;
        }
    }


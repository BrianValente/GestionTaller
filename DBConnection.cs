﻿using System;
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
            String sqlCreateToolsTable = "CREATE TABLE tools (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, description TEXT NOT NULL, icon_id INTEGER);";
            String sqlCreateTransactionsTable = "CREATE TABLE transactions (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, tool_type_id INTEGER NOT NULL, teacher_id INTEGER);";

            String sqlInsertBrianXd = "INSERT INTO teachers (firstname, lastname) VALUES ('Brian', 'Valente');";
            String sqlInsertCristianXd = "INSERT INTO teachers (firstname, lastname) VALUES ('Cristian', 'De Leon');";


            String query = sqlCreateTeachersTable + sqlCreateToolsTable + sqlCreateTransactionsTable + sqlInsertBrianXd + sqlInsertCristianXd;

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

        private void setTeacherFirstName(int teacherId, String firstName) {
            String query = "UPDATE teachers SET firstname = '" + firstName + "' WHERE id=" + teacherId;
        }


        // Teachers

        public Teacher AddTeacher(String firstname, String lastname) {
            String query = "INSERT INTO teachers (firstname, lastname) VALUES ('" + firstname + "', '" + lastname + "');";

            SQLiteCommand command = new SQLiteCommand(query, sqliteConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            return new Teacher((int)sqliteConnection.LastInsertRowId, firstname, lastname);
        }

        public List<Teacher> GetTeachers() {
            List<Teacher> teachers = new List<Teacher>();

            String query = "SELECT * FROM teachers";

            SQLiteCommand command = new SQLiteCommand(query, sqliteConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                teachers.Add(new Teacher(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }

            return teachers;
        }

        public Teacher GetTeacherById(int id) {
            String query = "SELECT * FROM teachers WHERE id=" + id;
            SQLiteDataReader reader = new SQLiteCommand(query, sqliteConnection).ExecuteReader();

            if (!reader.Read())
                return null;

            return new Teacher(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
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
}

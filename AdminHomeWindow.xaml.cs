﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gestion_Taller {
    public partial class AdminHomeWindow : Window {
        public AdminHomeWindow() {
            InitializeComponent();

            UITeacherInfoTotalValue.Content = DBConnection.Instance.GetTeachers().Count;
        }

        private void openAdminTeacherAddWindow(object sender, RoutedEventArgs e) {
            AdminTeacherAddWindow adminTeacherAddWindow = new AdminTeacherAddWindow();
            adminTeacherAddWindow.Show();
        }

        private void openAdminTeacherDeleteWindow(object sender, RoutedEventArgs e) {
            AdminTeacherDeleteWindow adminTeacherDeleteWindow = new AdminTeacherDeleteWindow();
            adminTeacherDeleteWindow.Show();
            this.Close();
        }

        private void openAdminTeacherEditWindow(object sender, RoutedEventArgs e) {
            AdminTeacherEditWindow adminTeacherEditWindow = new AdminTeacherEditWindow();
            adminTeacherEditWindow.Show();
            this.Close();
        }

        private void goBack(object sender, RoutedEventArgs e) {
            LauncherWindow launcherWindow = new LauncherWindow();
            launcherWindow.Show();
            this.Close();
        }

        private void ShowTeachers(object sender, RoutedEventArgs e) {
            List<Teacher> teachers = DBConnection.Instance.GetTeachers();

            String message = "";

            foreach (Teacher teacher in teachers) {
                message += "Id: " + teacher.Id + " First name: " + teacher.FirstName + "; Last name: " + teacher.LastName + Environment.NewLine;
            }

            MessageBox.Show(message);
        }
    }
}

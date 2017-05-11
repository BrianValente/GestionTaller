using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestion_Taller {
    public partial class LauncherWindow : Window {
        public LauncherWindow() {
            InitializeComponent();
        }

        private void OpenTeacherHomeWindow(object sender, RoutedEventArgs e) {
            TeacherHomeWindow teacherHomeWindow = new TeacherHomeWindow();
            teacherHomeWindow.Show();
            this.Close();
        }

        private void OpenAdminHomeWindow(object sender, RoutedEventArgs e) {
            String password = UIAdminPasswordBox.Password;

            if (!password.Equals(DBConnection.Instance.GetAdministratorPassword())) {
                MessageBox.Show("Incorrect password");
                return;
            }

            AdminHomeWindow adminHomeWindow = new AdminHomeWindow();
            adminHomeWindow.Show();
            this.Close();
        }
    }
}

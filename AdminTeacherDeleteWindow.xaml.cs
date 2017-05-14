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
using System.Windows.Shapes;

namespace Gestion_Taller {
    public partial class AdminTeacherDeleteWindow : Window
    {
        public AdminTeacherDeleteWindow() {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            AdminHomeWindow adminHomeWindow = new AdminHomeWindow();
            adminHomeWindow.Show();
            this.Close();
        }

        private void Delete(object sender, RoutedEventArgs e) {
            int teacherId;
            String message;

            int.TryParse(UIIdTextBox.Text, out teacherId);

            if (DBConnection.Instance.DeleteTeacherById(teacherId)) {
                message = "Eliminado con exito";
            } else {
                message = "El usuario no existe";
            }

            MessageBox.Show(message);
        }
    }
}

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
    /// <summary>
    /// Interaction logic for AdminTeacherAddWindow.xaml
    /// </summary>
    public partial class AdminTeacherAddWindow : Window {
        public AdminTeacherAddWindow() {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void AddTeacher(object sender, RoutedEventArgs e) {
            Teacher teacher = DBConnection.Instance.AddTeacher(UITeacherFirstNameTextBox.Text, UITeacherLastNameTextBox.Text);
            MessageBox.Show("Profesor " + teacher.FullName + " agregado exitosamente.");
            this.Close();
        }
    }
}

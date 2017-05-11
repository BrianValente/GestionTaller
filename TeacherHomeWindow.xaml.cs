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
    /// Interaction logic for TeacherHomeWindow.xaml
    /// </summary>
    public partial class TeacherHomeWindow : Window {
        public TeacherHomeWindow() {
            InitializeComponent();
        }

        private void goBack(object sender, RoutedEventArgs e) {
            LauncherWindow LW = new LauncherWindow();
            LW.Show();
            this.Close();
        }

        private void openWithdrawWindow(object sender, RoutedEventArgs e) {
            WithdrawReturnWindow withdrawWindow = WithdrawReturnWindow.GetWithdrawWindow();
            withdrawWindow.Show();
            this.Close();
        }

        private void openReturnWindow(object sender, RoutedEventArgs e) {
            WithdrawReturnWindow returnWindow = WithdrawReturnWindow.GetReturnWindow();
            returnWindow.Show();
            this.Close();
        }
    }
}

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
    /// Interaction logic for WithdrawReturnWindow.xaml
    /// </summary>
    public partial class WithdrawReturnWindow : Window {
        public WithdrawReturnWindow() {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            TeacherHomeWindow THW = new TeacherHomeWindow();
            THW.Show();
            this.Close();
        }
    }
}

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

namespace Gestion_Taller
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AdminAddTeacherWindow AATW = new AdminAddTeacherWindow();
            AATW.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            AdminDeleteTeacherWindow ADTW = new AdminDeleteTeacherWindow();
            ADTW.Show();
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            AdminEditTeacherWindow AETW = new AdminEditTeacherWindow();
            AETW.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            LauncherWindow LW = new LauncherWindow();
            LW.Show();
            this.Close();
        }
    }
}

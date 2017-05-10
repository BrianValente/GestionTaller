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
    /// Interaction logic for AdminDeleteTeacherWindow.xaml
    /// </summary>
    public partial class AdminDeleteTeacherWindow : Window
    {
        public AdminDeleteTeacherWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 AHW = new Window1();
            AHW.Show();
            this.Close();
        }
    }
}

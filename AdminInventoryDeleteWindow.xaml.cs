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
    /// Lógica de interacción para AdminInventoryDeleteWindow.xaml
    /// </summary>
    public partial class AdminInventoryDeleteWindow : Window
    {
        public AdminInventoryDeleteWindow()
        {
            InitializeComponent();
        }

        private void ReturnButton(object sender, RoutedEventArgs e)
        {
            AdminHomeWindow adminHomeWindow = new AdminHomeWindow();
            adminHomeWindow.Show();
            this.Close();
        }

        private void DeleteInventoryItemButton(object sender, RoutedEventArgs e)
        {
            int inventoryItemId;
            String msg;

            int.TryParse(UIInventoryItemTextBox.Text, out inventoryItemId);

            if (DBConnection.Instance.DeleteInventoryItemById(inventoryItemId)) {
                msg= "Eliminado con exito";
            } else {
                msg = "El usuario no existe";
            }

            MessageBox.Show(msg);
        }
    }
}

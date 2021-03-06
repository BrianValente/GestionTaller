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

namespace Gestion_Taller
{
    /// <summary>
    /// Lógica de interacción para AdminInventoryAddWindow.xaml
    /// </summary>
    public partial class AdminInventoryAddWindow : Window
    {
        public AdminInventoryAddWindow()
        {
            InitializeComponent();
        }

        private void ReturnButton(object sender, RoutedEventArgs e)
        {
            AdminHomeWindow adminHomeWindow = new AdminHomeWindow();
            adminHomeWindow.Show();
            this.Close();
        }

        private void AddInventoryItemButton(object sender, RoutedEventArgs e)
        {
            int numero;
            int.TryParse(UIInventoryIconIDTextBox.Text, out numero);
            InventoryItem inventoryItem = DBConnection.Instance.AddInventoryItem(UIInventoryNameTextBox.Text, UIInventoryDescTextBox.Text, numero);
            MessageBox.Show("Herramienta " + inventoryItem.Name + " agregado exitosamente.");
        }
    }
}

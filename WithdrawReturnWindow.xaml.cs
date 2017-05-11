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
    /// <summary>
    /// Interaction logic for WithdrawReturnWindow.xaml
    /// </summary>
    public partial class WithdrawReturnWindow : Window {
        private bool withdraw = false;

        private WithdrawReturnWindow(bool withdraw) {
            InitializeComponent();
            this.withdraw = withdraw;

            String status = "Status: ";

            if (withdraw)
                status += "withdraw (retirar)";
            else
                status += "return (devolver)";

            UIStatusLabel.Content = status;
        }

        private void goBack(object sender, RoutedEventArgs e) {
            TeacherHomeWindow THW = new TeacherHomeWindow();
            THW.Show();
            this.Close();
        }

        private static WithdrawReturnWindow getWindow(bool withdraw) {
            WithdrawReturnWindow withdrawReturnWindow = new WithdrawReturnWindow(withdraw);
            return withdrawReturnWindow;
        }

        public static WithdrawReturnWindow getReturnWindow() {
            return getWindow(false);
        }

        public static WithdrawReturnWindow getWithdrawWindow() {
            return getWindow(true);
        }
    }
}
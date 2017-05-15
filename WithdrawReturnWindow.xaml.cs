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
    public partial class WithdrawReturnWindow : Window {
        private bool withdraw = false;

        private WithdrawReturnWindow(bool withdraw) {
            InitializeComponent();
            this.withdraw = withdraw;

            if (withdraw)
                UIWithdrawReturnButton.Content = "Retirar";
            else
                UIWithdrawReturnButton.Content = "Devolver";

            List<Teacher> teachers = DBConnection.Instance.GetTeachers();

            UITeacherComboBox.ItemsSource = teachers;
            UITeacherComboBox.DisplayMemberPath = "FullName";
        }

        private void GoBack(object sender, RoutedEventArgs e) {
            TeacherHomeWindow THW = new TeacherHomeWindow();
            THW.Show();
            this.Close();
        }

        private static WithdrawReturnWindow GetWindow(bool withdraw) {
            WithdrawReturnWindow withdrawReturnWindow = new WithdrawReturnWindow(withdraw);
            return withdrawReturnWindow;
        }

        public static WithdrawReturnWindow GetReturnWindow() {
            return GetWindow(false);
        }

        public static WithdrawReturnWindow GetWithdrawWindow() {
            return GetWindow(true);
        }

        private void WithdrawReturnAction(object sender, RoutedEventArgs e) {
            MessageBox.Show("tu vieja");
        }

        private void OnTeacherSelectionChange(object sender, SelectionChangedEventArgs e) {
            Teacher selectedTeacher = (Teacher)UITeacherComboBox.SelectedItem;
            List<InventoryItem> itemsUsedByTeacher = DBConnection.Instance.GetInventoryItemsBeingUsedByUserId(selectedTeacher.Id);

            UIMainDataGrid.ItemsSource = itemsUsedByTeacher;
            UIMainDataGrid.Columns[0].Header = "ID";
            UIMainDataGrid.Columns[1].Header = "Nombre";
            UIMainDataGrid.Columns[2].Header = "Descripción";
            UIMainDataGrid.Columns[3].Visibility = Visibility.Hidden;
            UIMainDataGrid.Columns[4].Visibility = Visibility.Hidden;
        }
    }
}
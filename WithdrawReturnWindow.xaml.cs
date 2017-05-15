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
            /*String message = "";

            if (itemsUsedByTeacher.Count > 0) {
                foreach (InventoryItem item in itemsUsedByTeacher)
                    message += "Id: " + item.Id + ", " + item.Name;
            } else {
                message = "Este profesor no esta utilizando ningun item del inventario.";
            }

            MessageBox.Show(message);*/

            UIMainDataGrid.ItemsSource = itemsUsedByTeacher;
        }
    }
}
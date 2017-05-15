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
        private bool Return {
            get {
                return !withdraw;
            } set {
                withdraw = !value;
            }
        }
        private Teacher selectedTeacher;

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

            // Show a checkbox on every row
            DataGridCheckBoxColumn withdrawCheckboxColumn = new DataGridCheckBoxColumn();
            withdrawCheckboxColumn.DisplayIndex = 0;
            withdrawCheckboxColumn.Header = Return? "Devolver?" : "Retirar?";
            UIMainDataGrid.Columns.Add(withdrawCheckboxColumn);

            // Hide dumb row
            UIInventorySearchGridRow.Visibility = Visibility.Hidden;
            UIGrid.RowDefinitions[2].Height = new GridLength(0);

            // ??
            UIMainDataGrid.EnableRowVirtualization = true;
            UIMainDataGrid.EnableColumnVirtualization = true;
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

        private void OnTeacherSelectionChange(object sender, SelectionChangedEventArgs e) {
            selectedTeacher = (Teacher)UITeacherComboBox.SelectedItem;
            reloadDataGrid();
        }

        private void reloadDataGrid() {
            List<InventoryItem> items;
            if (Return) {
                if (selectedTeacher == null) {
                    return;
                }
                items = DBConnection.Instance.GetInventoryItemsBeingUsedByUserId(selectedTeacher.Id);
            } else {
                items = DBConnection.Instance.GetInventoryAvailableItems();
            }
                
            UIMainDataGrid.ItemsSource = items;

            UIMainDataGrid.Columns[1].Header = "ID";
            UIMainDataGrid.Columns[2].Header = "Nombre";
            UIMainDataGrid.Columns[3].Header = "Descripción";
            UIMainDataGrid.Columns[4].Visibility = Visibility.Hidden;
            UIMainDataGrid.Columns[5].Visibility = Visibility.Hidden;
        }

        private void OnSend(object sender, RoutedEventArgs e) {
            List<InventoryItem> selectedItems = new List<InventoryItem>();

            for (int i=0; i<UIMainDataGrid.Items.Count; i++) {
                DataGridRow row = (DataGridRow)UIMainDataGrid.ItemContainerGenerator.ContainerFromIndex(i);
                bool? returnBool = ((CheckBox) UIMainDataGrid.Columns[0].GetCellContent(row)).IsChecked;
                if ((bool)returnBool) {
                    selectedItems.Add((InventoryItem)row.Item);
                }
            }

            int userId = Return ? 0 : selectedTeacher.Id;

            foreach (InventoryItem item in selectedItems)
                item.UserIdUsing = userId;

            reloadDataGrid();
            
        }
    }
}
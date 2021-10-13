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

namespace QuanLyKho
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
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UserControl usc = null;
            //GridMain.Children.Clear();

            //switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            //{
            //    case "ItemHome":
            //        usc = new InputWindow();
            //        GridMain.Children.Add(usc);
            //        break;
            //    case "ItemCreate":
            //        usc = new UserControlCreate();
            //        GridMain.Children.Add(usc);
            //        break;
            //    default:
            //        break;
            //}
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow w = new LoginWindow();
            w.ShowDialog();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            UserWindow w = new UserWindow();
            w.ShowDialog();
        }

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            InputWindow w = new InputWindow();
            w.ShowDialog();
        }

        private void btnAddBill_Click(object sender, RoutedEventArgs e)
        {
            CustomWindow1 w = new CustomWindow1();
            w.ShowDialog();
        }
        private void btnAddbillroom_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow w = new DetailWindow();
            w.ShowDialog();
        }

        private void btnAddsupplier_Click(object sender, RoutedEventArgs e)
        {
            SuplierWindow w = new SuplierWindow();
            w.ShowDialog();
        }

        private void btnAddcustomer_Click(object sender, RoutedEventArgs e)
        {
            UnitWindow w = new UnitWindow();
            w.ShowDialog();
        }

        private void btnAddImportbill_Click(object sender, RoutedEventArgs e)
        {
            OutputWindow w = new OutputWindow();
            w.ShowDialog();
        }

        private void btnAddimport_Click(object sender, RoutedEventArgs e)
        {
            ImportBill w = new ImportBill();
            w.ShowDialog();
        }

        private void btnAdditems_Click(object sender, RoutedEventArgs e)
        {
            ObjectWindow w = new ObjectWindow();
            w.ShowDialog();
        }
    }
}

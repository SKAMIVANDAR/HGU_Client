using HGU_Client.Classes;
using HGU_Client.Pages.Lists.TypeOfGraphicsAcceleratorPages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HGU_Client.Pages.Lists.TypeDataDrivesPages
{
    /// <summary>
    /// Логика взаимодействия для listTypeDataDrives.xaml
    /// </summary>
    public partial class listTypeDataDrives : Page
    {
        public listTypeDataDrives()
        {
            InitializeComponent();
            LB.ItemsSource = AppConnect.modeldb.TypeDataDrives.ToList();
        }


        private void LB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HGU_Client.TypeDataDrives p = LB.SelectedItem as HGU_Client.TypeDataDrives;
            AppFrame.frameRight.Navigate(new redactTypeDataDrives(p));
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addTypeDataDrives());
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addTypeDataDrives());
            if (LB.SelectedItems.Count > 0)
            {
                for (int i = 0; i < LB.SelectedItems.Count; i++)
                {
                    HGU_Client.TypeDataDrives graphic = LB.SelectedItems[i] as HGU_Client.TypeDataDrives;
                    if (AppConnect.modeldb.DataDrives.Any(x => x.id_TypeDataDrives == graphic.ID))
                    {
                        MessageBox.Show("Элемент " + graphic.Name + " нельзя удалить, так как на него есть ссылки в других таблицах!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        AppConnect.modeldb.TypeDataDrives.Remove(graphic);
                    }
                }
                AppConnect.modeldb.SaveChanges();
                LB.ItemsSource = AppConnect.modeldb.TypeDataDrives.ToList();
            }
            else
            {
                MessageBox.Show("В списке нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
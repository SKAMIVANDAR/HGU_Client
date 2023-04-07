using HGU_Client.Classes;
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

namespace HGU_Client.Pages.Lists.TypeRamPages
{
    /// <summary>
    /// Логика взаимодействия для lTypeRam.xaml
    /// </summary>
    public partial class lTypeRam : Page
    {
        public lTypeRam()
        {
            InitializeComponent();
            //DataContext = AppConnect.modeldb.Ram.ToList();
            LB.ItemsSource = AppConnect.modeldb.RamType.ToList();
        }


        private void LB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HGU_Client.RamType p = LB.SelectedItem as HGU_Client.RamType;
            AppFrame.frameRight.Navigate(new rTypePage(p));
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new Pages.Lists.TypeRamPages.aTypePage());
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new Pages.Lists.TypeRamPages.aTypePage());
            if (LB.SelectedItems.Count > 0)
            {
                for (int i = 0; i < LB.SelectedItems.Count; i++)
                {
                    HGU_Client.RamType ramType = LB.SelectedItems[i] as HGU_Client.RamType;
                    if (AppConnect.modeldb.Ram.Any(x => x.id_RamType == ramType.ID))
                    {
                        MessageBox.Show("Элемент " + ramType.Name + " нельзя удалить, так как на него есть ссылки в других таблицах!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        AppConnect.modeldb.RamType.Remove(ramType);
                    }
                }
                AppConnect.modeldb.SaveChanges();
                LB.ItemsSource = AppConnect.modeldb.RamType.ToList();
            }
            else
            {
                MessageBox.Show("В списке нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

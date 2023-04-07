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

namespace HGU_Client.Pages.Lists.TypeVideoMemoryPages
{
    /// <summary>
    /// Логика взаимодействия для listTypeVideoMemory.xaml
    /// </summary>
    public partial class listTypeVideoMemory : Page
    {
        public listTypeVideoMemory()
        {
            InitializeComponent();
            LB.ItemsSource = AppConnect.modeldb.TypeVideoMemory.ToList();
        }


        private void LB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HGU_Client.TypeVideoMemory p = LB.SelectedItem as HGU_Client.TypeVideoMemory;
            AppFrame.frameRight.Navigate(new redactTypeVideoMemory(p));
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addTypeVideoMemory());
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addTypeVideoMemory());
            if (LB.SelectedItems.Count > 0)
            {
                for (int i = 0; i < LB.SelectedItems.Count; i++)
                {
                    HGU_Client.TypeVideoMemory graphic = LB.SelectedItems[i] as HGU_Client.TypeVideoMemory;
                    if (AppConnect.modeldb.GraphicsAccelerator.Any(x => x.id_TypeVideoMemory == graphic.ID))
                    {
                        MessageBox.Show("Элемент " + graphic.Name + " нельзя удалить, так как на него есть ссылки в других таблицах!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        AppConnect.modeldb.TypeVideoMemory.Remove(graphic);
                    }
                }
                AppConnect.modeldb.SaveChanges();
                LB.ItemsSource = AppConnect.modeldb.TypeVideoMemory.ToList();
            }
            else
            {
                MessageBox.Show("В списке нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

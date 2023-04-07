using HGU_Client.Classes;
using HGU_Client.Pages.Lists.TypeDataDrivesPages;
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

namespace HGU_Client.Pages.Category
{
    /// <summary>
    /// Логика взаимодействия для listCategory.xaml
    /// </summary>
    public partial class listCategory : Page
    {
        public listCategory()
        {
            InitializeComponent();
            LB.ItemsSource = AppConnect.modeldb.Categorys.ToList();
        }


        private void LB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HGU_Client.Categorys p = LB.SelectedItem as HGU_Client.Categorys;
            AppFrame.frameRight.Navigate(new redactCategory(p));
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addCategory());
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addCategory());
            if (LB.SelectedItems.Count > 0)
            {
                for (int i = 0; i < LB.SelectedItems.Count; i++)
                {
                    HGU_Client.Categorys graphic = LB.SelectedItems[i] as HGU_Client.Categorys;
                    if (AppConnect.modeldb.Сonsumable.Any(x => x.id_Category == graphic.ID))
                    {
                        MessageBox.Show("Элемент " + graphic.Name + " нельзя удалить, так как на него есть ссылки в других таблицах!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        AppConnect.modeldb.Categorys.Remove(graphic);
                    }
                }
                AppConnect.modeldb.SaveChanges();
                LB.ItemsSource = AppConnect.modeldb.Categorys.ToList();
            }
            else
            {
                MessageBox.Show("В списке нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txt_find_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_find.Text != "" && txt_find.Text != "введите значение поиска")
            {
                LB.ItemsSource = AppConnect.modeldb.Сonsumable.Where(x => x.Name.ToLower().Contains(txt_find.Text.ToLower())).ToList();
            }
            else
            {
                LB.ItemsSource = AppConnect.modeldb.Сonsumable.ToList();
            }
        }
        private void txt_find_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (txt_find.Text != null)
            {
                // Вызов команды SelectAll
                txt_find.SelectAll();
            }
        }
    }
}

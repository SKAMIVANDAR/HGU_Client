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

namespace HGU_Client.Pages.Lists.SpecPages
{
    /// <summary>
    /// Логика взаимодействия для listSpec.xaml
    /// </summary>
    public partial class listSpec : Page
    {
        public listSpec()
        {
            InitializeComponent();
            LB.ItemsSource = AppConnect.modeldb.Specification.ToList();
            cb_Category.ItemsSource = AppConnect.modeldb.GraphicsAccelerator.ToList();
            cb_Category.SelectedValuePath = "ID";
            cb_Category.DisplayMemberPath = "Name";
        }


        private void LB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HGU_Client.Specification p = LB.SelectedItem as HGU_Client.Specification;
            AppFrame.frameRight.Navigate(new redactSpec(p));
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addSpec());
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addSpec());
            if (LB.SelectedItems.Count > 0)
            {
                for (int i = 0; i < LB.SelectedItems.Count; i++)
                {
                    HGU_Client.Specification specification = LB.SelectedItems[i] as HGU_Client.Specification;
                    if (AppConnect.modeldb.Computers.Any(x => x.id_Specification == specification.ID))
                    {
                        MessageBox.Show("Элемент " + specification.Name + " нельзя удалить, так как на него есть ссылки в других таблицах!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        AppConnect.modeldb.Specification.Remove(specification);
                    }
                }
                AppConnect.modeldb.SaveChanges();
                LB.ItemsSource = AppConnect.modeldb.Specification.ToList();
            }
            else
            {
                MessageBox.Show("В списке нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void cb_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int type = Convert.ToInt32(cb_Category.SelectedValue);
            LB.ItemsSource = AppConnect.modeldb.Specification.Where(x => x.id_GraphicsAccelerator == type).ToList();
        }

        private void txt_find_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_find.Text != "" && txt_find.Text != "введите значение поиска")
            {
                LB.ItemsSource = AppConnect.modeldb.Specification.Where(x => x.Name.ToLower().Contains(txt_find.Text.ToLower())).ToList();
            }
            else
            {
                LB.ItemsSource = AppConnect.modeldb.Specification.ToList();
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

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            LB.ItemsSource = AppConnect.modeldb.Specification.ToList();
        }
    }
}

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

namespace HGU_Client.Pages.ConsunablePages
{
    /// <summary>
    /// Логика взаимодействия для addConsunable.xaml
    /// </summary>
    public partial class addConsunable : Page
    {
        public addConsunable()
        {
            InitializeComponent();
            AppConnect.modeldb.Сonsumable.ToList();

            cb_id_Category.ItemsSource = AppConnect.modeldb.Categorys.ToList();
            cb_id_Category.SelectedValuePath = "ID";
            cb_id_Category.DisplayMemberPath = "Name";
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addConsunable());

            if (!string.IsNullOrEmpty(txt_ID.Text) && !string.IsNullOrEmpty(txt_name.Text)
            && !string.IsNullOrEmpty(txt_Description.Text) && !string.IsNullOrEmpty(txt_count.Text)
            && !string.IsNullOrEmpty(txt_money.Text) && !string.IsNullOrEmpty(dp_date.Text)
            && cb_id_Category.SelectedValue != null
            && int.TryParse(txt_count.Text, out int count) && int.TryParse(txt_money.Text, out int money)
            && int.TryParse(cb_id_Category.SelectedValue.ToString(), out int categoryId))
            {
                HGU_Client.Сonsumable сonsumable = new HGU_Client.Сonsumable();

            сonsumable.ID = txt_ID.Text;
                сonsumable.Name = txt_name.Text;
                сonsumable.Description = txt_Description.Text;
                сonsumable.Count = count;
                сonsumable.Money = money;
                сonsumable.DateBay = dp_date.Text;
                сonsumable.note = txt_note.Text;
                сonsumable.id_Category = categoryId;

                AppConnect.modeldb.Сonsumable.Add(сonsumable);
                try
                {
                    AppConnect.modeldb.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                AppFrame.frameMain.Navigate(new listConsunable());
            }
            else
            {
                MessageBox.Show("Заполните все поля и выберите категорию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

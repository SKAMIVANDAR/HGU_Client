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
    /// Логика взаимодействия для redactConsunable.xaml
    /// </summary>
    public partial class redactConsunable : Page
    {
        public string N;
        public redactConsunable(Сonsumable consumable)
        {
            InitializeComponent();
            AppConnect.modeldb.Сonsumable.ToList();

            cb_id_Category.ItemsSource = AppConnect.modeldb.Categorys.ToList();
            cb_id_Category.SelectedValuePath = "ID";
            cb_id_Category.DisplayMemberPath = "Name";

            N = consumable.ID;
            txt_name.Text = Convert.ToString(consumable.Name);
            cb_id_Category.SelectedValue = consumable.id_Category;
            txt_Description.Text = consumable.Description;
            txt_count.Text = consumable.Count.ToString();
            dp_date.Text = consumable.DateBay.ToString();
            txt_money.Text = consumable.Money.ToString();
            txt_note.Text = consumable.note.ToString();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addConsunable());
            if (string.IsNullOrEmpty(txt_name.Text) || cb_id_Category.SelectedValue == null ||
    string.IsNullOrEmpty(txt_Description.Text) || string.IsNullOrEmpty(txt_count.Text) ||
    string.IsNullOrEmpty(dp_date.Text) || string.IsNullOrEmpty(txt_money.Text) ||
    !int.TryParse(txt_count.Text, out int count) ||
    !int.TryParse(txt_money.Text, out int money))
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                HGU_Client.Сonsumable p = AppConnect.modeldb.Сonsumable.FirstOrDefault(x => x.ID == N);
                if (p != null)
                {
                    p.Name = txt_name.Text;
                    p.id_Category = int.Parse(cb_id_Category.SelectedValue.ToString());
                    p.Description = txt_Description.Text;
                    p.Count = int.Parse(txt_count.Text);
                    p.DateBay = dp_date.Text;
                    p.Money = int.Parse(txt_money.Text);
                    p.note = txt_note.Text;

                    AppConnect.modeldb.SaveChanges();
                    AppFrame.frameMain.Navigate(new listConsunable());
                }
            }
        }
    }
}

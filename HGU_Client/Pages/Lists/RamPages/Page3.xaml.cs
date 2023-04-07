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

namespace HGU_Client.Pages.Lists.Ram
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
            AppConnect.modeldb.Ram.ToList();

            txt_RamType.ItemsSource = AppConnect.modeldb.RamType.ToList();
            txt_RamType.SelectedValuePath = "ID";
            txt_RamType.DisplayMemberPath = "Name";
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_model.Text))
            {
                MessageBox.Show("Введите модель");
                return;
            }

            if (txt_RamType.SelectedItem == null || !int.TryParse(txt_RamType.SelectedValue.ToString(), out _))
            {
                MessageBox.Show("Выберите тип RAM");
                return;
            }

            if (!int.TryParse(txt_Vram.Text, out _) || !double.TryParse(txt_RamFrequency.Text, out _))
            {
                MessageBox.Show("Введите корректное значение для объема RAM и частоты RAM");
                return;
            }
            AppFrame.frameRight.Navigate(new Pages.Lists.Ram.Page3());
            HGU_Client.Ram ram = new HGU_Client.Ram();
            {
                ram.Model = txt_model.Text;
                ram.id_RamType = int.Parse(txt_RamType.SelectedValue.ToString());
                ram.RAMFrequency = double.Parse(txt_RamFrequency.Text);
                ram.VRam = int.Parse(txt_Vram.Text);

                AppConnect.modeldb.Ram.Add(ram);

                try
                {
                    AppConnect.modeldb.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                AppFrame.frameMain.Navigate(new Pages.Lists.Page1());
            };

        }
    }
}

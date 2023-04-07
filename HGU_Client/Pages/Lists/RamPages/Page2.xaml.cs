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

namespace HGU_Client.Pages.Lists
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public int N;
        public Page2(HGU_Client.Ram ram)
        {
            InitializeComponent();
            AppConnect.modeldb.Ram.ToList();

            txt_RamType.ItemsSource = AppConnect.modeldb.RamType.ToList();
            txt_RamType.SelectedValuePath = "ID";
            txt_RamType.DisplayMemberPath = "Name";

            N = ram.ID;
            txt_model.Text = Convert.ToString(ram.Model);
            txt_RamType.SelectedValue = ram.id_RamType;
            txt_Vram.Text = Convert.ToString(ram.VRam);
            txt_RamFrequency.Text = Convert.ToString(ram.RAMFrequency);
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_model.Text) || txt_RamType.SelectedValue == null || string.IsNullOrEmpty(txt_Vram.Text) || string.IsNullOrEmpty(txt_RamFrequency.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if (!int.TryParse(txt_RamType.SelectedValue.ToString(), out int ramTypeId))
            {
                MessageBox.Show("Выберите корректный тип RAM");
                return;
            }

            if (!int.TryParse(txt_Vram.Text, out int vRam))
            {
                MessageBox.Show("Введите корректный объем RAM");
                return;
            }

            if (!int.TryParse(txt_RamFrequency.Text, out int ramFrequency))
            {
                MessageBox.Show("Введите корректную частоту RAM");
                return;
            }
            AppFrame.frameRight.Navigate(new Pages.Lists.Ram.Page3());
            HGU_Client.Ram p = AppConnect.modeldb.Ram.FirstOrDefault(x => x.ID == N);

            p.ID = N;
            p.Model = txt_model.Text;
            p.id_RamType = ramTypeId;
            p.VRam = vRam;
            p.RAMFrequency = ramFrequency;

            AppConnect.modeldb.SaveChanges();
            AppFrame.frameMain.Navigate(new Pages.Lists.Page1());
        }
    }
}

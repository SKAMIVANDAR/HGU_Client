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

namespace HGU_Client.Pages.Lists.DataDriversPages
{
    /// <summary>
    /// Логика взаимодействия для addDataDrives.xaml
    /// </summary>
    public partial class addDataDrives : Page
    {
        public addDataDrives()
        {
            InitializeComponent();
            AppConnect.modeldb.DataDrives.ToList();

            cb_idTypeDataDrives.ItemsSource = AppConnect.modeldb.TypeDataDrives.ToList();
            cb_idTypeDataDrives.SelectedValuePath = "ID";
            cb_idTypeDataDrives.DisplayMemberPath = "Name";
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txt_model.Text) || cb_idTypeDataDrives.SelectedValue == null || string.IsNullOrEmpty(txt_VDataDrives.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            int idTypeDataDrives;
            if (!int.TryParse(cb_idTypeDataDrives.SelectedValue.ToString(), out idTypeDataDrives))
            {
                MessageBox.Show("Выберите корректный тип накопителя");
                return;
            }

            int vDataDrives;
            if (!int.TryParse(txt_VDataDrives.Text, out vDataDrives))
            {
                MessageBox.Show("Введите корректный объем накопителя");
                return;
            }
            AppFrame.frameRight.Navigate(new addDataDrives());
            HGU_Client.DataDrives DataDrives = new HGU_Client.DataDrives();
            {
                DataDrives.Name = txt_model.Text;
                DataDrives.id_TypeDataDrives = idTypeDataDrives;
                DataDrives.VDataDrives = vDataDrives;

                AppConnect.modeldb.DataDrives.Add(DataDrives);

                try
                {
                    AppConnect.modeldb.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                AppFrame.frameMain.Navigate(new listDataDrives());
            };
        }
    }
}

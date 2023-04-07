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
    /// Логика взаимодействия для redactDataDrives.xaml
    /// </summary>
    public partial class redactDataDrives : Page
    {
        public int N;
        public redactDataDrives(DataDrives dataDrives)
        {
            InitializeComponent();
            AppConnect.modeldb.DataDrives.ToList();

            cb_idTypeDataDrives.ItemsSource = AppConnect.modeldb.TypeDataDrives.ToList();
            cb_idTypeDataDrives.SelectedValuePath = "ID";
            cb_idTypeDataDrives.DisplayMemberPath = "Name";

            N = dataDrives.ID;
            txt_model.Text = Convert.ToString(dataDrives.Name);
            cb_idTypeDataDrives.SelectedValue = dataDrives.id_TypeDataDrives;
            txt_VDataDrives.Text = Convert.ToString(dataDrives.VDataDrives);
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, что все поля заполнены
            if (string.IsNullOrEmpty(txt_model.Text) || string.IsNullOrEmpty(txt_VDataDrives.Text) || cb_idTypeDataDrives.SelectedValue == null)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            // Проверка, что значение объема дисков является числом
            if (!int.TryParse(txt_VDataDrives.Text, out int volume))
            {
                MessageBox.Show("Объем дисков должен быть числом");
                return;
            }

            // Проверка, что значение выбранного типа является числом
            if (!int.TryParse(cb_idTypeDataDrives.SelectedValue.ToString(), out int typeId))
            {
                MessageBox.Show("Выберите корректный тип дисков");
                return;
            }

            // Все проверки пройдены успешно, можно сохранять данные
            AppFrame.frameRight.Navigate(new addDataDrives());
            HGU_Client.DataDrives p = AppConnect.modeldb.DataDrives.FirstOrDefault(x => x.ID == N);

            p.ID = N;
            p.Name = txt_model.Text;
            p.id_TypeDataDrives = typeId;
            p.VDataDrives = volume;

            AppConnect.modeldb.SaveChanges();
            AppFrame.frameMain.Navigate(new listDataDrives());

        }
    }
}

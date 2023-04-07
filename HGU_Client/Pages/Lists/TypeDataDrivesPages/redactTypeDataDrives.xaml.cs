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

namespace HGU_Client.Pages.Lists.TypeDataDrivesPages
{
    /// <summary>
    /// Логика взаимодействия для redactTypeDataDrives.xaml
    /// </summary>
    public partial class redactTypeDataDrives : Page
    {
        public int N;
        public redactTypeDataDrives(TypeDataDrives typeDataDrives)
        {
            InitializeComponent();
            N = typeDataDrives.ID;
            txt_model.Text = Convert.ToString(typeDataDrives.Name);

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_model.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }
            else
            {
                AppFrame.frameRight.Navigate(new addTypeDataDrives());
                HGU_Client.TypeDataDrives p = AppConnect.modeldb.TypeDataDrives.FirstOrDefault(x => x.ID == N);

                p.ID = N;
                p.Name = txt_model.Text;


                AppConnect.modeldb.SaveChanges();
                AppFrame.frameMain.Navigate(new listTypeDataDrives());
            }

        }
    }
}

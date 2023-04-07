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
    /// Логика взаимодействия для addTypeDataDrives.xaml
    /// </summary>
    public partial class addTypeDataDrives : Page
    {
        public addTypeDataDrives()
        {
            InitializeComponent();
            AppConnect.modeldb.TypeDataDrives.ToList();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_model.Text))
            {
                MessageBox.Show("Введите название типа видеоускорителя");
                return;
            }
            else
            {
                AppFrame.frameRight.Navigate(new addTypeDataDrives());
                HGU_Client.TypeDataDrives ramType = new HGU_Client.TypeDataDrives();
                {
                    ramType.Name = txt_model.Text;


                    AppConnect.modeldb.TypeDataDrives.Add(ramType);


                    try
                    {
                        AppConnect.modeldb.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    AppFrame.frameMain.Navigate(new listTypeDataDrives());
                };
            }
        }
    }
}

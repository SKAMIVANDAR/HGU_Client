using HGU_Client.Classes;
using HGU_Client.Pages.Lists.GraphicManufacturerPages;
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

namespace HGU_Client.Pages.Lists.TypeOfGraphicsAcceleratorPages
{
    /// <summary>
    /// Логика взаимодействия для addTypeOfGraphicsAccelerator.xaml
    /// </summary>
    public partial class addTypeOfGraphicsAccelerator : Page
    {
        public addTypeOfGraphicsAccelerator()
        {
            InitializeComponent();
            AppConnect.modeldb.TypeOfGraphicsAccelerator.ToList();
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
                AppFrame.frameRight.Navigate(new addTypeOfGraphicsAccelerator());
                HGU_Client.TypeOfGraphicsAccelerator ramType = new HGU_Client.TypeOfGraphicsAccelerator();
                {
                    ramType.Name = txt_model.Text;


                    AppConnect.modeldb.TypeOfGraphicsAccelerator.Add(ramType);


                    try
                    {
                        AppConnect.modeldb.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    AppFrame.frameMain.Navigate(new listTypeOfGraphicsAccelerator());
                };
            }

        }
    }
}

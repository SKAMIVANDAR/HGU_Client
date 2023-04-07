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

namespace HGU_Client.Pages.Lists.GraphicManufacturerPages
{
    /// <summary>
    /// Логика взаимодействия для addGraphicManufacturer.xaml
    /// </summary>
    public partial class addGraphicManufacturer : Page
    {
        public addGraphicManufacturer()
        {
            InitializeComponent();
            AppConnect.modeldb.GraphicManufacturer.ToList();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_model.Text))
            {
                MessageBox.Show("Введите название производителя");
                return;
            }
            else
            {
                AppFrame.frameRight.Navigate(new addGraphicManufacturer());
                HGU_Client.GraphicManufacturer ramType = new HGU_Client.GraphicManufacturer();
                {
                    ramType.Name = txt_model.Text;


                    AppConnect.modeldb.GraphicManufacturer.Add(ramType);


                    try
                    {
                        AppConnect.modeldb.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    AppFrame.frameMain.Navigate(new listGraphicManufacturer());
                };
            }

        }
    }
}

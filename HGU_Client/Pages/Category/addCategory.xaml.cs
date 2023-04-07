using HGU_Client.Classes;
using HGU_Client.Pages.Lists.TypeDataDrivesPages;
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

namespace HGU_Client.Pages.Category
{
    /// <summary>
    /// Логика взаимодействия для addCategory.xaml
    /// </summary>
    public partial class addCategory : Page
    {
        public addCategory()
        {
            InitializeComponent();
            AppConnect.modeldb.Categorys.ToList();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_model.Text))
            {
                MessageBox.Show("Введите название категории");
                return;
            }
            else
            {
                AppFrame.frameRight.Navigate(new addCategory());
                HGU_Client.Categorys ramType = new HGU_Client.Categorys();
                {
                    ramType.Name = txt_model.Text;


                    AppConnect.modeldb.Categorys.Add(ramType);


                    try
                    {
                        AppConnect.modeldb.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    AppFrame.frameMain.Navigate(new listCategory());
                };
            }
        }
    }
}

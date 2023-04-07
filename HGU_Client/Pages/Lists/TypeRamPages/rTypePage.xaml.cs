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

namespace HGU_Client.Pages.Lists.TypeRamPages
{
    /// <summary>
    /// Логика взаимодействия для rTypePage.xaml
    /// </summary>
    public partial class rTypePage : Page
    {
        public int N;
        public rTypePage(RamType ramType)
        {
            InitializeComponent();
           //AppConnect.modeldb.RamType.ToList();


            N = ramType.ID;
            txt_model.Text = Convert.ToString(ramType.Name);
            
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
                AppFrame.frameRight.Navigate(new aTypePage());
                HGU_Client.RamType p = AppConnect.modeldb.RamType.FirstOrDefault(x => x.ID == N);

                p.ID = N;
                p.Name = txt_model.Text;


                AppConnect.modeldb.SaveChanges();
                AppFrame.frameMain.Navigate(new Pages.Lists.Page1());
            }
            
        }
    }
}

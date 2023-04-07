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

namespace HGU_Client.Pages.Lists.PCPages
{
    /// <summary>
    /// Логика взаимодействия для redactPC.xaml
    /// </summary>
    public partial class redactPC : Page
    {
        public int N;
        public redactPC(Computers computers)
        {
            InitializeComponent();
            AppConnect.modeldb.Computers.ToList();

            cb_spec.ItemsSource = AppConnect.modeldb.Specification.ToList();
            cb_spec.SelectedValuePath = "ID";
            cb_spec.DisplayMemberPath = "Name";

            N = computers.ID;
            txt_model.Text = Convert.ToString(computers.Name);
            cb_spec.SelectedValue = computers.id_Specification;
            txt_Count.Text = Convert.ToString(computers.Count);
            txt_Office.Text = Convert.ToString(computers.Office);
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            HGU_Client.Computers p = AppConnect.modeldb.Computers.FirstOrDefault(x => x.ID == N);
            {
                if (!string.IsNullOrEmpty(txt_model.Text) && cb_spec.SelectedItem != null && !string.IsNullOrEmpty(txt_Count.Text) && !string.IsNullOrEmpty(txt_Office.Text))
                {
                    if (int.TryParse(cb_spec.SelectedValue.ToString(), out int id_Specification) && int.TryParse(txt_Count.Text, out int count))
                    {
                        AppFrame.frameRight.Navigate(new addPC());
                        p.ID = N;
                        p.Name = txt_model.Text;
                        p.id_Specification = id_Specification;
                        p.Count = count;
                        p.Office = txt_Office.Text.ToString();

                        AppConnect.modeldb.SaveChanges();
                        AppFrame.frameMain.Navigate(new listPC());
                    }
                    else
                    {
                        MessageBox.Show("Некоторые поля содержат неправильный тип данных!");
                    }
                }
                else
                {
                    MessageBox.Show("Некоторые поля не заполнены!");
                }
            };

        }
    }
}

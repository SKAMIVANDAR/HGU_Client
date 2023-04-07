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
    /// Логика взаимодействия для addPC.xaml
    /// </summary>
    public partial class addPC : Page
    {
        public addPC()
        {
            InitializeComponent();
            AppConnect.modeldb.Computers.ToList();

            cb_spec.ItemsSource = AppConnect.modeldb.Specification.ToList();
            cb_spec.SelectedValuePath = "ID";
            cb_spec.DisplayMemberPath = "Name";
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            HGU_Client.Computers computers = new HGU_Client.Computers();
            {
                if (!string.IsNullOrEmpty(txt_model.Text) && cb_spec.SelectedItem != null && !string.IsNullOrEmpty(txt_Count.Text) && !string.IsNullOrEmpty(txt_Office.Text))
                {
                    if (int.TryParse(cb_spec.SelectedValue.ToString(), out int id_Specification) && int.TryParse(txt_Count.Text, out int count))
                    {
                        
                        try
                        {
                            // код для обновления записей
                            AppFrame.frameRight.Navigate(new addPC());
                            computers.Name = txt_model.Text;
                            computers.id_Specification = id_Specification;
                            computers.Count = count;
                            computers.Office = txt_Office.Text;

                            AppConnect.modeldb.Computers.Add(computers);
                            AppConnect.modeldb.SaveChanges();
                            AppFrame.frameMain.Navigate(new listPC());
                        }
                        catch (Exception ex)
                        {
                            // выводим сообщение об ошибке в консоль
                            MessageBox.Show("Произошла ошибка: " + ex.Message);

                            // выводим подробности об ошибке в консоль
                            MessageBox.Show("Подробности ошибки: " + ex.InnerException);
                        }
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

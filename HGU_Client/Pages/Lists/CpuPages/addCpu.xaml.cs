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

namespace HGU_Client.Pages.Lists.CpuPages
{
    /// <summary>
    /// Логика взаимодействия для addCpu.xaml
    /// </summary>
    public partial class addCpu : Page
    {
        public addCpu()
        {
            InitializeComponent();
            AppConnect.modeldb.Cpu.ToList();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            HGU_Client.Cpu cpu = new HGU_Client.Cpu();

            if (!string.IsNullOrEmpty(txt_model.Text) && !string.IsNullOrEmpty(txt_NumberOfCores.Text) && !string.IsNullOrEmpty(txt_CpuFrequency.Text) && !string.IsNullOrEmpty(txt_Count.Text))
            {
                if (int.TryParse(txt_NumberOfCores.Text, out int numberOfCores) && double.TryParse(txt_CpuFrequency.Text, out double cpuFrequency) && int.TryParse(txt_Count.Text, out int count))
                {
                    AppFrame.frameRight.Navigate(new addCpu());
                    cpu.Model = txt_model.Text;
                    cpu.NumberOfCores = numberOfCores;
                    cpu.CPUFrequency = cpuFrequency;
                    cpu.Count = count;

                    AppConnect.modeldb.Cpu.Add(cpu);

                    try
                    {
                        AppConnect.modeldb.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    AppFrame.frameMain.Navigate(new listCpu());
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

        }


    }
}

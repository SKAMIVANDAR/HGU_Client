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
    /// Логика взаимодействия для redactCpu.xaml
    /// </summary>
    public partial class redactCpu : Page
    {
        public int N;
        public redactCpu(Cpu cpu)
        {
            InitializeComponent();
            AppConnect.modeldb.Cpu.ToList();

            N = cpu.ID;
            txt_model.Text = Convert.ToString(cpu.Model);
            txt_NumberOfCores.Text = Convert.ToString(cpu.NumberOfCores);
            txt_CpuFrequency.Text = Convert.ToString(cpu.CPUFrequency);
            txt_Count.Text = Convert.ToString(cpu.Count);
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            HGU_Client.Cpu p = AppConnect.modeldb.Cpu.FirstOrDefault(x => x.ID == N);

            if (p != null && !string.IsNullOrEmpty(txt_model.Text) && !string.IsNullOrEmpty(txt_NumberOfCores.Text) && !string.IsNullOrEmpty(txt_CpuFrequency.Text) && !string.IsNullOrEmpty(txt_Count.Text))
            {
                if (int.TryParse(txt_NumberOfCores.Text, out int numberOfCores) && double.TryParse(txt_CpuFrequency.Text, out double cpuFrequency) && int.TryParse(txt_Count.Text, out int count))
                {
                    AppFrame.frameRight.Navigate(new addCpu());
                    p.Model = txt_model.Text;
                    p.NumberOfCores = numberOfCores;
                    p.CPUFrequency = cpuFrequency;
                    p.Count = count;

                    AppConnect.modeldb.SaveChanges();
                    AppFrame.frameMain.Navigate(new listCpu());
                }
                else
                {
                    MessageBox.Show("Некоторые поля содержат неправильный тип данных!");
                }
            }
            else
            {
                MessageBox.Show("Некоторые поля не заполнены или запись не найдена!");
            }
        }
    }
}

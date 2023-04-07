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

namespace HGU_Client.Pages.Lists.SpecPages
{
    /// <summary>
    /// Логика взаимодействия для redactSpec.xaml
    /// </summary>
    public partial class redactSpec : Page
    {
        public int N;
        public redactSpec(Specification specification)
        {
            InitializeComponent();
            AppConnect.modeldb.Specification.ToList();

            cb_Cpu.ItemsSource = AppConnect.modeldb.Cpu.ToList();
            cb_Cpu.SelectedValuePath = "ID";
            cb_Cpu.DisplayMemberPath = "Model";

            cb_Datadrives.ItemsSource = AppConnect.modeldb.DataDrives.ToList();
            cb_Datadrives.SelectedValuePath = "ID";
            cb_Datadrives.DisplayMemberPath = "Name";

            cb_Graphic.ItemsSource = AppConnect.modeldb.GraphicsAccelerator.ToList();
            cb_Graphic.SelectedValuePath = "ID";
            cb_Graphic.DisplayMemberPath = "Model";

            cb_Ram.ItemsSource = AppConnect.modeldb.Ram.ToList();
            cb_Ram.SelectedValuePath = "ID";
            cb_Ram.DisplayMemberPath = "Model";

            N = specification.ID;
            txt_model.Text = Convert.ToString(specification.Name);
            cb_Cpu.SelectedValue = specification.id_Cpu;
            cb_Datadrives.SelectedValue = specification.id_DataDrives;
            cb_Graphic.SelectedValue = specification.id_GraphicsAccelerator;
            cb_Ram.SelectedValue = specification.id_Ram;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

            int idCpu;
            if (!int.TryParse(cb_Cpu.SelectedValue.ToString(), out idCpu))
            {
                MessageBox.Show("Выберите корректный процессор");
                return;
            }

            int idRam;
            if (!int.TryParse(cb_Ram.SelectedValue.ToString(), out idRam))
            {
                MessageBox.Show("Выберите корректную оперативную память");
                return;
            }

            int idGraphicsAccelerator;
            if (!int.TryParse(cb_Graphic.SelectedValue.ToString(), out idGraphicsAccelerator))
            {
                MessageBox.Show("Выберите корректную графическую карту");
                return;
            }

            int idDataDrives;
            if (!int.TryParse(cb_Datadrives.SelectedValue.ToString(), out idDataDrives))
            {
                MessageBox.Show("Выберите корректный накопитель данных");
                return;
            }

            if (string.IsNullOrEmpty(txt_model.Text))
            {
                MessageBox.Show("Введите название Сбоки");
                return;
            }
            AppFrame.frameRight.Navigate(new addSpec());
            HGU_Client.Specification p = AppConnect.modeldb.Specification.FirstOrDefault(x => x.ID == N);
            p.ID = N;
            p.Name = txt_model.Text;
            p.id_Cpu = idCpu;
            p.id_Ram = idRam;
            p.id_GraphicsAccelerator = idGraphicsAccelerator;
            p.id_DataDrives = idDataDrives;

            AppConnect.modeldb.SaveChanges();
            AppFrame.frameMain.Navigate(new listSpec());
        }
    }
}

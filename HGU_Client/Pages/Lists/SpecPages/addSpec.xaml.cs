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
    /// Логика взаимодействия для addSpec.xaml
    /// </summary>
    public partial class addSpec : Page
    {
        public addSpec()
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
            cb_Ram.SelectedValuePath= "ID";
            cb_Ram.DisplayMemberPath= "Model";
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            HGU_Client.Specification specification = new HGU_Client.Specification();
            {
                if (!string.IsNullOrEmpty(txt_model.Text) && cb_Cpu.SelectedItem != null && cb_Ram.SelectedItem != null && cb_Graphic.SelectedItem != null && cb_Datadrives.SelectedItem != null)
                {
                    if (int.TryParse(cb_Cpu.SelectedValue.ToString(), out int id_Cpu) && int.TryParse(cb_Ram.SelectedValue.ToString(), out int id_Ram) && int.TryParse(cb_Graphic.SelectedValue.ToString(), out int id_GraphicsAccelerator) && int.TryParse(cb_Datadrives.SelectedValue.ToString(), out int id_DataDrives))
                    {
                        AppFrame.frameRight.Navigate(new addSpec());
                        specification.Name = txt_model.Text;
                        specification.id_Cpu = id_Cpu;
                        specification.id_Ram = id_Ram;
                        specification.id_GraphicsAccelerator = id_GraphicsAccelerator;
                        specification.id_DataDrives = id_DataDrives;

                        AppConnect.modeldb.Specification.Add(specification);
                        AppConnect.modeldb.SaveChanges();
                        AppFrame.frameMain.Navigate(new listSpec());
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

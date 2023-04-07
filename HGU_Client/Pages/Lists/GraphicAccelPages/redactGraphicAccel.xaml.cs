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

namespace HGU_Client.Pages.Lists.GraphicAccelPages
{
    /// <summary>
    /// Логика взаимодействия для redactGraphicAccel.xaml
    /// </summary>
    public partial class redactGraphicAccel : Page
    {
        public int N;
        public redactGraphicAccel(GraphicsAccelerator graphicsAccelerator)
        {
            InitializeComponent();
            AppConnect.modeldb.GraphicsAccelerator.ToList();

            cb_idGraphicManufacturer.ItemsSource = AppConnect.modeldb.GraphicManufacturer.ToList();
            cb_idGraphicManufacturer.SelectedValuePath = "ID";
            cb_idGraphicManufacturer.DisplayMemberPath = "Name";

            cb_idtypeOfGraphicsAccel.ItemsSource = AppConnect.modeldb.TypeOfGraphicsAccelerator.ToList();
            cb_idtypeOfGraphicsAccel.SelectedValuePath = "ID";
            cb_idtypeOfGraphicsAccel.DisplayMemberPath = "Name";

            cb_idTypeVideoMemory.ItemsSource = AppConnect.modeldb.TypeVideoMemory.ToList();
            cb_idTypeVideoMemory.SelectedValuePath = "ID";
            cb_idTypeVideoMemory.DisplayMemberPath = "Name";

            N = graphicsAccelerator.ID;
            txt_model.Text = Convert.ToString(graphicsAccelerator.Model);
            cb_idGraphicManufacturer.SelectedValue = graphicsAccelerator.id_GraphicManufacturer;
            cb_idtypeOfGraphicsAccel.SelectedValue = graphicsAccelerator.id_TypeOfGraphicsAccelerator;
            cb_idTypeVideoMemory.SelectedValue = graphicsAccelerator.id_TypeVideoMemory;
            txt_VideoMemorySize.Text = graphicsAccelerator.VideoMemorySize.ToString();
            txt_Count.Text = graphicsAccelerator.Count.ToString();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            HGU_Client.GraphicsAccelerator p = AppConnect.modeldb.GraphicsAccelerator.FirstOrDefault(x => x.ID == N);

            if (p != null && !string.IsNullOrEmpty(txt_model.Text) && cb_idGraphicManufacturer.SelectedItem != null && cb_idtypeOfGraphicsAccel.SelectedItem != null && cb_idTypeVideoMemory.SelectedItem != null && !string.IsNullOrEmpty(txt_VideoMemorySize.Text) && !string.IsNullOrEmpty(txt_Count.Text))
            {
                if (int.TryParse(cb_idGraphicManufacturer.SelectedValue.ToString(), out int id_GraphicManufacturer) && int.TryParse(cb_idtypeOfGraphicsAccel.SelectedValue.ToString(), out int id_TypeOfGraphicsAccelerator) && int.TryParse(cb_idTypeVideoMemory.SelectedValue.ToString(), out int id_TypeVideoMemory) && double.TryParse(txt_VideoMemorySize.Text, out double videoMemorySize) && int.TryParse(txt_Count.Text, out int count))
                {
                    AppFrame.frameRight.Navigate(new addGraphicAccel());
                    p.Model = txt_model.Text;
                    p.id_GraphicManufacturer = id_GraphicManufacturer;
                    p.id_TypeOfGraphicsAccelerator = id_TypeOfGraphicsAccelerator;
                    p.id_TypeVideoMemory = id_TypeVideoMemory;
                    p.VideoMemorySize = videoMemorySize;
                    p.Count = count;

                    AppConnect.modeldb.SaveChanges();
                    AppFrame.frameMain.Navigate(new listGraphicAccel());
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

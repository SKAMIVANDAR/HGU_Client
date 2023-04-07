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
    /// Логика взаимодействия для addGraphicAccel.xaml
    /// </summary>
    public partial class addGraphicAccel : Page
    {
        public addGraphicAccel()
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
            cb_idTypeVideoMemory.DisplayMemberPath= "Name";
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_model.Text) ||
            cb_idGraphicManufacturer.SelectedValue == null ||
            cb_idtypeOfGraphicsAccel.SelectedValue == null ||
            cb_idTypeVideoMemory.SelectedValue == null ||
            string.IsNullOrEmpty(txt_VideoMemorySize.Text) ||
            string.IsNullOrEmpty(txt_Count.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверяем, что поля, которые должны быть целочисленными, действительно являются целочисленными
            int id_GraphicManufacturer, id_TypeOfGraphicsAccelerator, id_TypeVideoMemory, count;
            if (!int.TryParse(cb_idGraphicManufacturer.SelectedValue.ToString(), out id_GraphicManufacturer) ||
                !int.TryParse(cb_idtypeOfGraphicsAccel.SelectedValue.ToString(), out id_TypeOfGraphicsAccelerator) ||
                !int.TryParse(cb_idTypeVideoMemory.SelectedValue.ToString(), out id_TypeVideoMemory) ||
                !int.TryParse(txt_Count.Text, out count))
            {
                MessageBox.Show("Пожалуйста, введите корректные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверяем, что поле VideoMemorySize имеет корректный формат числа с плавающей точкой
            double VideoMemorySize;
            if (!double.TryParse(txt_VideoMemorySize.Text, out VideoMemorySize))
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для Объема видеопамяти.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Если все проверки пройдены успешно, то продолжаем выполнение операции
            AppFrame.frameRight.Navigate(new addGraphicAccel());
            HGU_Client.GraphicsAccelerator graphicsAccelerator = new HGU_Client.GraphicsAccelerator();
            {
                
                graphicsAccelerator.Model = txt_model.Text;
                    graphicsAccelerator.id_GraphicManufacturer = int.Parse(cb_idGraphicManufacturer.SelectedValue.ToString());
                    graphicsAccelerator.id_TypeOfGraphicsAccelerator = int.Parse(cb_idTypeVideoMemory.SelectedValue.ToString());
                    graphicsAccelerator.id_TypeVideoMemory = int.Parse(cb_idTypeVideoMemory.SelectedValue.ToString());
                    graphicsAccelerator.VideoMemorySize = Convert.ToDouble(txt_VideoMemorySize.Text);
                    graphicsAccelerator.Count = Convert.ToInt32(txt_Count.Text);
                
                AppConnect.modeldb.GraphicsAccelerator.Add(graphicsAccelerator);


                try
                {
                    AppConnect.modeldb.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                AppFrame.frameMain.Navigate(new listGraphicAccel());
            };
        }
    }
}

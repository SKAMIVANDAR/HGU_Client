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

namespace HGU_Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppFrame.frameMain = FrmMain;
            AppFrame.frameRight = FrmRight;
            AppConnect.modeldb = new HGUEntities1();
            //DataContext = new ApplicationViewModel();
            
            //AppFrame.frameRight.Navigate(new Pages.Lists.Page2));
        }

        private void Ram_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Lists.Page1());
            AppFrame.frameRight.Navigate(new Pages.Lists.Ram.Page3());
        }

        private void RamType_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Lists.TypeRamPages.lTypeRam());
            AppFrame.frameRight.Navigate(new Pages.Lists.TypeRamPages.aTypePage());
        }


        private void btn_PC_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Lists.PCPages.listPC());
            AppFrame.frameRight.Navigate(new Pages.Lists.PCPages.addPC());
        }

        private void btn_spec_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Lists.SpecPages.listSpec());
            AppFrame.frameRight.Navigate(new Pages.Lists.SpecPages.addSpec());
        }

        private void btn_Cpu_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Lists.CpuPages.listCpu());
            AppFrame.frameRight.Navigate(new Pages.Lists.CpuPages.addCpu());
        }

        private void btn_graphicAccelerator_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Lists.GraphicAccelPages.listGraphicAccel());
            AppFrame.frameRight.Navigate(new Pages.Lists.GraphicAccelPages.addGraphicAccel());
        }

        private void btn_graphicmanufacturer_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Lists.GraphicManufacturerPages.listGraphicManufacturer());
            AppFrame.frameRight.Navigate(new Pages.Lists.GraphicManufacturerPages.addGraphicManufacturer());
        }

        private void btn_TypeOfGraphicsAccelerator_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Lists.TypeOfGraphicsAcceleratorPages.listTypeOfGraphicsAccelerator());
            AppFrame.frameRight.Navigate(new Pages.Lists.TypeOfGraphicsAcceleratorPages.addTypeOfGraphicsAccelerator());
        }

        private void byn_TypeVideoMemory_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Lists.TypeVideoMemoryPages.listTypeVideoMemory());
            AppFrame.frameRight.Navigate(new Pages.Lists.TypeVideoMemoryPages.addTypeVideoMemory());
        }

        private void btn_dataDrives_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Lists.DataDriversPages.listDataDrives());
            AppFrame.frameRight.Navigate(new Pages.Lists.DataDriversPages.addDataDrives());
        }

        private void btn_TypeDataDrives_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Lists.TypeDataDrivesPages.listTypeDataDrives());
            AppFrame.frameRight.Navigate(new Pages.Lists.TypeDataDrivesPages.addTypeDataDrives());
        }

        private void btn_consumable_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.ConsunablePages.listConsunable());
            AppFrame.frameRight.Navigate(new Pages.ConsunablePages.addConsunable());
        }

        private void btn_TypeConsunable_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Pages.Category.listCategory());
            AppFrame.frameRight.Navigate(new Pages.Category.addCategory());
        }
    }
}

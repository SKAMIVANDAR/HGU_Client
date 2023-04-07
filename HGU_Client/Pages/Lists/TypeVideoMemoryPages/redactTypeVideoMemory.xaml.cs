﻿using HGU_Client.Classes;
using HGU_Client.Pages.Lists.TypeOfGraphicsAcceleratorPages;
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

namespace HGU_Client.Pages.Lists.TypeVideoMemoryPages
{
    /// <summary>
    /// Логика взаимодействия для redactTypeVideoMemory.xaml
    /// </summary>
    public partial class redactTypeVideoMemory : Page
    {
        public int N;
        public redactTypeVideoMemory(TypeVideoMemory graphic)
        {
            InitializeComponent();
            N = graphic.ID;
            txt_model.Text = Convert.ToString(graphic.Name);

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
                AppFrame.frameRight.Navigate(new addTypeVideoMemory());
                HGU_Client.TypeVideoMemory p = AppConnect.modeldb.TypeVideoMemory.FirstOrDefault(x => x.ID == N);

                p.ID = N;
                p.Name = txt_model.Text;


                AppConnect.modeldb.SaveChanges();
                AppFrame.frameMain.Navigate(new listTypeVideoMemory());
            }

        }
    }
}

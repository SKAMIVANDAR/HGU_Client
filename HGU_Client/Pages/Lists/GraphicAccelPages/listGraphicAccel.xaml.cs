using HGU_Client.Classes;
using Microsoft.Office.Interop.Word;
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
using Word = Microsoft.Office.Interop.Word;

namespace HGU_Client.Pages.Lists.GraphicAccelPages
{
    /// <summary>
    /// Логика взаимодействия для listGraphicAccel.xaml
    /// </summary>
    public partial class listGraphicAccel : System.Windows.Controls.Page
    {
        public listGraphicAccel()
        {
            InitializeComponent();
            LB.ItemsSource = AppConnect.modeldb.GraphicsAccelerator.ToList();
            cb_Category.ItemsSource = AppConnect.modeldb.TypeOfGraphicsAccelerator.ToList();
            cb_Category.SelectedValuePath = "ID";
            cb_Category.DisplayMemberPath = "Name";
        }


        private void LB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HGU_Client.GraphicsAccelerator p = LB.SelectedItem as HGU_Client.GraphicsAccelerator;
            AppFrame.frameRight.Navigate(new redactGraphicAccel(p));
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addGraphicAccel());
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addGraphicAccel());
            if (LB.SelectedItems.Count > 0)
            {
                for (int i = 0; i < LB.SelectedItems.Count; i++)
                {
                    HGU_Client.GraphicsAccelerator graphicsAccelerator = LB.SelectedItems[i] as HGU_Client.GraphicsAccelerator;
                    if (AppConnect.modeldb.Specification.Any(x => x.id_GraphicsAccelerator == graphicsAccelerator.ID))
                    {
                        MessageBox.Show("Элемент " + graphicsAccelerator.Model + " нельзя удалить, так как на него есть ссылки в других таблицах!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        AppConnect.modeldb.GraphicsAccelerator.Remove(graphicsAccelerator);
                    }
                }
                AppConnect.modeldb.SaveChanges();
                LB.ItemsSource = AppConnect.modeldb.GraphicsAccelerator.ToList();
            }
            else
            {
                MessageBox.Show("В списке нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_expt_Click(object sender, RoutedEventArgs e)
        {
            var allPc = AppConnect.modeldb.GraphicsAccelerator.ToList();
            var application = new Word.Application();
            Word.Document doc = application.Documents.Add();
            Word.Range range = doc.Range();

            Word.Table pcTable = doc.Tables.Add(range, allPc.Count + 2, 6); // добавляем еще одну строку для заголовка
            pcTable.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            pcTable.Borders.Enable = 1;
            pcTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            pcTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            // Добавляем заголовок таблицы на первую строку таблицы
            Word.Row headerRow = pcTable.Rows[1];
            headerRow.Cells[1].Range.Text = "Список видеоускорителей " + DateTime.Now.ToString();
            headerRow.Cells.Merge(); // объединяем ячейки заголовка

            // Добавляем заголовки столбцов на вторую строку таблицы
            Word.Row columnHeadersRow = pcTable.Rows[2];
            columnHeadersRow.Cells[1].Range.Text = "Модель";
            columnHeadersRow.Cells[2].Range.Text = "Производитель";
            columnHeadersRow.Cells[3].Range.Text = "Тип видеокскорителя";
            columnHeadersRow.Cells[4].Range.Text = "Тип памяти";
            columnHeadersRow.Cells[5].Range.Text = "Объем памяти";
            columnHeadersRow.Cells[6].Range.Text = "Колличество";

            // заполняем таблицу данными из списка компьютеров
            for (int i = 0; i < allPc.Count; i++)
            {
                var pc = allPc[i];

                // добавляем новую строку в таблицу
                var tableRow = pcTable.Rows[i + 3]; // начинаем с третьей строки, чтобы пропустить заголовок и заголовки столбцов

                // заполняем ячейки таблицы данными из объекта компьютера
                tableRow.Cells[1].Range.Text = pc.Model;
                tableRow.Cells[2].Range.Text = pc.GraphicManufacturer.Name.ToString();
                tableRow.Cells[3].Range.Text = pc.TypeOfGraphicsAccelerator.Name.ToString();
                tableRow.Cells[4].Range.Text = pc.TypeVideoMemory.Name.ToString();
                tableRow.Cells[5].Range.Text = pc.VideoMemorySize.ToString();
                tableRow.Cells[6].Range.Text = pc.Count.ToString();

                // проверяем, нужно ли закрасить ячейку в красный
                int count;
                if (int.TryParse(pc.Count.ToString(), out count) && count < 5)
                {
                    tableRow.Cells[6].Shading.BackgroundPatternColor = Word.WdColor.wdColorRed;
                }
            }
            application.Visible = true;
        }
        private void cb_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int type = Convert.ToInt32(cb_Category.SelectedValue);
            LB.ItemsSource = AppConnect.modeldb.GraphicsAccelerator.Where(x => x.id_TypeOfGraphicsAccelerator == type).ToList();
        }

        private void txt_find_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_find.Text != "" && txt_find.Text != "введите значение поиска")
            {
                LB.ItemsSource = AppConnect.modeldb.GraphicsAccelerator.Where(x => x.Model.ToLower().Contains(txt_find.Text.ToLower())).ToList();
            }
            else
            {
                LB.ItemsSource = AppConnect.modeldb.GraphicsAccelerator.ToList();
            }
        }

        private void txt_find_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (txt_find.Text != null)
            {
                // Вызов команды SelectAll
                txt_find.SelectAll();
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            LB.ItemsSource = AppConnect.modeldb.GraphicsAccelerator.ToList();
        }
    }
}

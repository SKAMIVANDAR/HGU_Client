using HGU_Client.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
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

namespace HGU_Client.Pages.Lists.PCPages
{
    /// <summary>
    /// Логика взаимодействия для listPC.xaml
    /// </summary>
    public partial class listPC : Page
    {
        public listPC()
        {
            InitializeComponent();
            LB.ItemsSource = AppConnect.modeldb.Computers.ToList();
            cb_Category.ItemsSource = AppConnect.modeldb.Specification.ToList();
            cb_Category.SelectedValuePath = "ID";
            cb_Category.DisplayMemberPath = "Name";
        }


        private void LB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HGU_Client.Computers p = LB.SelectedItem as HGU_Client.Computers;
            AppFrame.frameRight.Navigate(new redactPC(p));
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addPC());
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameRight.Navigate(new addPC());
            if (LB.SelectedItems.Count > 0)
            {
                for (int i = 0; i < LB.SelectedItems.Count; i++)
                {
                    HGU_Client.Computers computers = LB.SelectedItems[i] as HGU_Client.Computers;
                    AppConnect.modeldb.Computers.Remove(computers);
                }
                AppConnect.modeldb.SaveChanges();
                LB.ItemsSource = AppConnect.modeldb.Computers.ToList();
            }
            else
            {
                MessageBox.Show("В списке нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_exp_Click(object sender, RoutedEventArgs e)
        {
            var allPc = AppConnect.modeldb.Computers.ToList();
            var spec = AppConnect.modeldb.Specification.ToList();
            var application = new Word.Application();
            Word.Document doc = application.Documents.Add();
            Word.Range range = doc.Range();

            Word.Paragraph paragraph = doc.Paragraphs.Add();
            Word.Range range1 = paragraph.Range;
            range1.Text = "Компьютеры";
            range1.InsertParagraphAfter();

            // Добавление заголовка
            Word.Paragraph header = doc.Paragraphs.Add();
            Word.Range headerRange = header.Range;
            headerRange.Text = "Список компьютеров";
            headerRange.Font.Bold = 1;
            headerRange.Font.Size = 14;
            header.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            header.Range.InsertParagraphAfter();

            Word.Table pcTable = doc.Tables.Add(range, allPc.Count + 2, 4); // добавляем еще одну строку для заголовка
            pcTable.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            pcTable.Borders.Enable = 1;
            pcTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            pcTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            // Добавляем заголовок таблицы на первую строку таблицы
            Word.Row headerRow = pcTable.Rows[1];
            headerRow.Cells[1].Range.Text = "Список компьютеров " + DateTime.Now.ToString();
            headerRow.Cells.Merge(); // объединяем ячейки заголовка

            // Добавляем заголовки столбцов на вторую строку таблицы
            Word.Row columnHeadersRow = pcTable.Rows[2];
            columnHeadersRow.Cells[1].Range.Text = "Наименование";
            columnHeadersRow.Cells[2].Range.Text = "Наименование сборки";
            columnHeadersRow.Cells[3].Range.Text = "Кабинет";
            columnHeadersRow.Cells[4].Range.Text = "Количество";

            // заполняем таблицу данными из списка компьютеров
            for (int i = 0; i < allPc.Count; i++)
            {
                var pc = allPc[i];

                // добавляем новую строку в таблицу
                var tableRow = pcTable.Rows[i + 3]; // начинаем с третьей строки, чтобы пропустить заголовок и заголовки столбцов

                // заполняем ячейки таблицы данными из объекта компьютера
                tableRow.Cells[1].Range.Text = pc.Name;
                tableRow.Cells[2].Range.Text = pc.Specification.Name.ToString();
                tableRow.Cells[3].Range.Text = pc.Office;
                tableRow.Cells[4].Range.Text = pc.Count.ToString();

                // проверяем, нужно ли закрасить ячейку в красный
                int count;
                if (int.TryParse(pc.Count.ToString(), out count) && count < 5)
                {
                    tableRow.Cells[4].Shading.BackgroundPatternColor = Word.WdColor.wdColorRed;
                }
            }
            application.Visible = true;
            //doc.SaveAs(@"C:\Documents\example.docx");
            //Process.Start(@"C:\Documents\example.docx");
        }
        private void cb_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int type = Convert.ToInt32(cb_Category.SelectedValue);
            LB.ItemsSource = AppConnect.modeldb.Computers.Where(x => x.id_Specification == type).ToList();
        }

        private void txt_find_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_find.Text != "" && txt_find.Text != "введите значение поиска")
            {
                LB.ItemsSource = AppConnect.modeldb.Computers.Where(x => x.Name.ToLower().Contains(txt_find.Text.ToLower())).ToList();
            }
            else
            {
                LB.ItemsSource = AppConnect.modeldb.Computers.ToList();
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
            LB.ItemsSource = AppConnect.modeldb.Computers.ToList();
        }
    }

}

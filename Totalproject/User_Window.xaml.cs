using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using Totalproject.DataSet1TableAdapters;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;

namespace Totalproject
{
    /// <summary>
    /// Логика взаимодействия для User_Window.xaml
    /// </summary>
    public partial class User_Window : Window
    {
        VoucherTableAdapter tableAdapter = new VoucherTableAdapter();
        GoodsTableAdapter goods = new GoodsTableAdapter();
        Type_of_goodTableAdapter type_of_good = new Type_of_goodTableAdapter();
        public string good { get; set; }
        public User_Window()
        {
            InitializeComponent();
            
            Checks.ItemsSource = tableAdapter.GetData();
            Products.ItemsSource = goods.GetData(); 
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            
            var alltypes = type_of_good.GetData().Rows;
            if (Validation.validMoney(Input.Text)) { return; }
            for (int i = 0; i < alltypes.Count; i++)
            {
                if (alltypes[i][0].ToString() == Convert.ToString((Products.SelectedItem as DataRowView).Row[1]))
                {
                    good = alltypes[i][1].ToString();

                }
                else
                {
                    MessageBox.Show("Не найдено");
                   
                }
                

            }
            
           if (Convert.ToDecimal(Input.Text ) <= Convert.ToDecimal((Products.SelectedItem as DataRowView).Row[6]))
            {
                MessageBox.Show("Недостаточно средств");
                return;
            }
            decimal cashback = Convert.ToDecimal(Input.Text) - Convert.ToDecimal((Products.SelectedItem as DataRowView).Row[6]);

            tableAdapter.InsertQuery(good, MainWindow.name, Convert.ToDecimal((Products.SelectedItem as DataRowView).Row[6]), Convert.ToDecimal(Input.Text), cashback);
            Checks.ItemsSource = tableAdapter.GetData();

        }

        private void Print_Click(object sender, RoutedEventArgs e)
            
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = $" {Convert.ToString((Checks.SelectedItem as DataRowView).Row[0])}buy.txt";
            Stream myStream  = File.Create(desktop + "\\" +path);
            myStream.Close();
           
            string text = $"Vanya.Co \nКассовый чек: № {Convert.ToString((Checks.SelectedItem as DataRowView).Row[0])} \n {Convert.ToString((Checks.SelectedItem as DataRowView).Row[1])} - {Convert.ToString((Checks.SelectedItem as DataRowView).Row[3])} \nЗаказ оформил: {Convert.ToString((Checks.SelectedItem as DataRowView).Row[2])} \n Общая сумма: {Convert.ToString((Checks.SelectedItem as DataRowView).Row[3])} \nВнесено: {Convert.ToString((Checks.SelectedItem as DataRowView).Row[4])}\nСдача: {Convert.ToString((Checks.SelectedItem as DataRowView).Row[5])}";
           

           File.AppendAllText(desktop + "\\" + path, text);
           Process.Start(desktop + "\\" + path);    
        }
    }
}

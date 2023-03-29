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
using System.Windows.Shapes;
using Totalproject.DataSet1TableAdapters;
using Totalproject.Pages;
using Totalproject.Pages_Facility;
using Totalproject.Pages_Products;
using Totalproject.Pages_User;
using Totalproject.Pages_Workers;

namespace Totalproject
{
    /// <summary>
    /// Логика взаимодействия для Admin_window.xaml
    /// </summary>
    /// 
   
    public partial class Admin_window : Window
    {
        BrigadeTableAdapter brigadeTableAdapter = new BrigadeTableAdapter();

        public List<string> Products = new List<string>() { "Товары", "Типы товара", "Чеки",  };
        public List<string> Facility  = new List<string>() { "Объекты","Обекты_Бригады", "Объекты_материалы","Материалы", "Тип объекта" };
        public List<string> Workers_List = new List<string>() { "Работники", "Должности", "Бригады" };
        public List<string> Users = new List<string>() { "Пользователи","Роли","Логины" };
        public Admin_window()
        {
            InitializeComponent();
        }

        private void Materials_Click(object sender, RoutedEventArgs e)
        {
           
            Pages.ItemsSource = Users;
            Pages.SelectedIndex = 0;

        }

        private void Goods_Click(object sender, RoutedEventArgs e)
        {
            
            Pages.ItemsSource = Products;
            Pages.SelectedIndex = 0;

        }

        private void Facilities_Click(object sender, RoutedEventArgs e)
        {
            Pages.ItemsSource = Facility;
            Pages.SelectedIndex = 0;

        }

        private void Workers_Click(object sender, RoutedEventArgs e)
        {
            Pages.ItemsSource = Workers_List;
            Pages.SelectedIndex = 0;

        }

        private void Pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Pages.SelectedItem)
            {
                case "Товары":
                    {
                        Framik.Content = new Goods_Page();
                        break;
                    }
                case "Типы товара":
                    {
                        Framik.Content = new Type_of_good_Page();
                        break;
                    }
                case "Чеки":
                    {
                        Framik.Content = new Voucher_Page();
                        break;
                    }
                case "Объекты":
                    {
                        Framik.Content = new Facility_Page();
                        break;
                    }
                case "Обекты_Бригады":
                    {
                        Framik.Content = new Facility_Brigade_Page();
                        break;
                    }
                case "Объекты_материалы":
                    {
                        Framik.Content = new Facility_Materials_Page();
                        break;
                    }
                case "Тип объекта":
                    {
                        Framik.Content = new Type_Page();
                        break;
                    }
                case "Работники":
                    {
                        Framik.Content = new Worker_Page();
                        break;
                    }
                case "Должности":
                    {
                        Framik.Content = new Post_Page();
                        break;
                    }
                case "Бригады":
                    {
                        Framik.Content = new Brigade_Page();
                        break;
                    }
                case "Материалы":
                    {
                        Framik.Content = new Materials_Page();
                        break;
                    }
                case "Пользователи":
                    {
                        Framik.Content = new User_Page();
                        break;
                    }
                case "Роли":
                    {
                        Framik.Content = new Role_Page();
                        break;
                    }
                case "Логины":
                    {
                        Framik.Content = new Login_Password_Page();
                        break;
                    }




            }

        }

        private void Jsonchik_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}

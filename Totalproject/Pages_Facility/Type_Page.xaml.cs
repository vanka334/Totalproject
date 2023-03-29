using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using Totalproject.DataSet1TableAdapters;
namespace Totalproject.Pages_Facility
{
    /// <summary>
    /// Логика взаимодействия для Type_Page.xaml
    /// </summary>
    public partial class Type_Page : Page
    {
        TypeTableAdapter tableAdapter = new TypeTableAdapter();
        public Type_Page()
        {
            InitializeComponent();
            Type_Grid.ItemsSource = tableAdapter.GetData();
        }
        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            string id = NJame.Text;
            
            if (Validation.validString(id)) { return; }
            tableAdapter.InsertQuery(id);
            Type_Grid.ItemsSource = tableAdapter.GetData();

        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Type_Grid.SelectedItem != null)
            {
                string id1 = NJame.Text;
                if (Validation.validString(id1)) { return; }
                int id = (int)(Type_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.UpdateQuery(id1, id);
                Type_Grid.ItemsSource = tableAdapter.GetData();


            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Type_Grid.SelectedItem != null)
            {
                int id = (int)(Type_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                Type_Grid.ItemsSource = tableAdapter.GetData();
            }

        }

        private void Type_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Type_Grid.SelectedItem != null)
            {
               
               NJame.Text = (string)(Type_Grid.SelectedItem as DataRowView).Row[1];
               
               


            }

        }
    }
}

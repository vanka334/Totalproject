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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Totalproject.DataSet1TableAdapters;
using Totalproject.Model;

namespace Totalproject.Pages_Workers
{
    /// <summary>
    /// Логика взаимодействия для Brigade_Page.xaml
    /// </summary>
    public partial class Brigade_Page : Page
    {
        BrigadeTableAdapter tableAdapter = new BrigadeTableAdapter();
        public Brigade_Page()
        {
            InitializeComponent();
            Brigade_Grid.ItemsSource = tableAdapter.GetData();
        }
        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            string id = Name.Text;
            if (Validation.validString(id)) { return; }
            tableAdapter.InsertQuery(id);
            Brigade_Grid.ItemsSource = tableAdapter.GetData();


        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Brigade_Grid.SelectedItem != null)
            {
                string id1 = Name.Text;
                if (Validation.validString(id1)) { return; }
                int id = (int)(Brigade_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.UpdateQuery(id1, id);
                Brigade_Grid.ItemsSource = tableAdapter.GetData();


            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Brigade_Grid.SelectedItem != null)
            {
                int id = (int)(Brigade_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                Brigade_Grid.ItemsSource = tableAdapter.GetData();
            }
        }

        private void Brigade_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            if (Brigade_Grid.SelectedItem != null)
            {

                Name.Text = (string)(Brigade_Grid.SelectedItem as DataRowView).Row[1];


            }
        }

        private void Jsonchik_Click(object sender, RoutedEventArgs e)
        {
            List<brigade_model> forimport = Deser.Deserializeobject<List<brigade_model>>();
            foreach (var item in forimport)
            {
                tableAdapter.InsertQuery(item.name_brigade);
            }
            Brigade_Grid.ItemsSource = null;
            Brigade_Grid.ItemsSource = tableAdapter.GetData();

        }
    }
}

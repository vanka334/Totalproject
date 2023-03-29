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

namespace Totalproject.Pages
{
    /// <summary>
    /// Логика взаимодействия для Role.xaml
    /// </summary>
    public partial class Role_Page : Page
    {
        RoleTableAdapter tableAdapter = new RoleTableAdapter();
        public Role_Page()
        {
            InitializeComponent();
            Role_Grid.ItemsSource = tableAdapter.GetData();
        }
        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            string id = Name.Text;
            if (Validation.validString(id)) { return; }

            tableAdapter.InsertQuery(id);
            Role_Grid.ItemsSource = tableAdapter.GetData();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Role_Grid.SelectedItem != null)
            {
                string id1 = Name.Text;
                if (Validation.validString(id1)) { return; }
                int id = (int)(Role_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.UpdateQuery(id1, id);
                Role_Grid.ItemsSource = tableAdapter.GetData();


            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {

            if (Role_Grid.SelectedItem != null)
            {
                int id = (int)(Role_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                Role_Grid.ItemsSource = tableAdapter.GetData();
            }
        }

        private void Role_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Role_Grid.SelectedItem != null)
            {

                Name.Text = (string)(Role_Grid.SelectedItem as DataRowView).Row[1];


            }

        }

        private void Jsonchik_Click(object sender, RoutedEventArgs e)
        {
            List<Role_model> forimport = Deser.Deserializeobject<List<Role_model>>();
            foreach (var item in forimport)
            {
                tableAdapter.InsertQuery(item.name_role);
            }
            Role_Grid.ItemsSource = null;
            Role_Grid.ItemsSource = tableAdapter.GetData();

        }
    }
}

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
    /// Логика взаимодействия для Post_Page.xaml
    /// </summary>
    public partial class Post_Page : Page
    {
        PostTableAdapter tableAdapter  = new PostTableAdapter();
        public Post_Page()
        {
            InitializeComponent();
            Post_Grid.ItemsSource = tableAdapter.GetData();
        }
        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            string id = Name.Text;
            if (Validation.validString(id)) { return; }

            tableAdapter.InsertQuery(id);
            Post_Grid.ItemsSource = tableAdapter.GetData();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Post_Grid.SelectedItem != null)
            {
                string id1 = Name.Text;
                if (Validation.validString(id1)) { return; }
                int id = (int)(Post_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.UpdateQuery(id1, id);
                Post_Grid.ItemsSource = tableAdapter.GetData();
            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Post_Grid.SelectedItem != null)
            {
                int id = (int)(Post_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                Post_Grid.ItemsSource = tableAdapter.GetData();
            }
        }

        private void Post_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Post_Grid.SelectedItem != null)
            {

                Name.Text = (string)(Post_Grid.SelectedItem as DataRowView).Row[1];


            }
        }

        private void Jsonchik_Click(object sender, RoutedEventArgs e)
        {
            List<post_model> forimport = Deser.Deserializeobject<List<post_model>>();
            foreach(var item in forimport)
            {
                tableAdapter.InsertQuery(item.name_post);
            }
            Post_Grid.ItemsSource = null;
            Post_Grid.ItemsSource = tableAdapter.GetData();

        }
    }
}

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
namespace Totalproject.Pages
{
    /// <summary>
    /// Логика взаимодействия для User_page.xaml
    /// </summary>
    public partial class User_Page : Page
    {
        UserTableAdapter tableAdapter = new UserTableAdapter();
        RoleTableAdapter role = new RoleTableAdapter();
        public User_Page()
        {
            InitializeComponent();
            User_Grid.ItemsSource = tableAdapter.GetData();

            Type_of_Role.ItemsSource = role.GetData();

            Type_of_Role.SelectedValuePath = "Id";
            Type_of_Role.DisplayMemberPath = "Name";
        }
        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {

            string id1 = Name_Tbx.Text;
            if (Validation.validString(id1)) { return; }
            string id2 = Surname_Tbx.Text;
            if (Validation.validString(id2)) { return; }
            string id3 = Second_Name_Tbx.Text;
            if (Validation.validString(id3)) { return; }

            int id4 = Convert.ToInt32(Type_of_Role.SelectedValue);
            tableAdapter.InsertQuery(id1, id2, id3,id4);
            User_Grid.ItemsSource = tableAdapter.GetData();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (User_Grid.SelectedValue != null)
            {
                int id = (int)(User_Grid.SelectedItem as DataRowView).Row[0];

                string id1 = Name_Tbx.Text;
                if (Validation.validString(id1)) { return; }
                string id2 = Surname_Tbx.Text;
                if (Validation.validString(id2)) { return; }
                string id3 = Second_Name_Tbx.Text;
                if (Validation.validString(id3)) { return; }

                int id4 = Convert.ToInt32(Type_of_Role.SelectedValue);
                tableAdapter.UpdateQuery(id1, id2, id3, id4, id);
                User_Grid.ItemsSource = tableAdapter.GetData();


            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (User_Grid.SelectedItem != null)
            {
                int id = (int)(User_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                User_Grid.ItemsSource = tableAdapter.GetData();
            }

        }

        private void User_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (User_Grid.SelectedItem != null)
            {

                Name_Tbx.Text = Convert.ToString((User_Grid.SelectedItem as DataRowView).Row[1]);
                Surname_Tbx.Text = Convert.ToString((User_Grid.SelectedItem as DataRowView).Row[2]);
                Second_Name_Tbx.Text = Convert.ToString((User_Grid.SelectedItem as DataRowView).Row[3]);
                Type_of_Role.SelectedValue = Convert.ToString((User_Grid.SelectedItem as DataRowView).Row[4]);


            }


        }
    }
}

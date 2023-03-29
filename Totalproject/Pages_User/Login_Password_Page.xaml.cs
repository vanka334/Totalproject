using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
namespace Totalproject.Pages_User
{
    /// <summary>
    /// Логика взаимодействия для Login_Password_Page.xaml
    /// </summary>
    public partial class Login_Password_Page : Page
    {
        Login1TableAdapter tableAdapter = new Login1TableAdapter();
        UserTableAdapter tableAdapter2 = new UserTableAdapter();  
        RoleTableAdapter roleAdapter = new RoleTableAdapter();
        public Login_Password_Page()
        {
            InitializeComponent();
            Login_Password_Grid.ItemsSource = tableAdapter.GetData();
    
           User_Id_Cbx.ItemsSource = tableAdapter2.GetData();
            Role_Id_Cbx.ItemsSource = roleAdapter.GetData();    
            User_Id_Cbx.SelectedValuePath = "Id";
            User_Id_Cbx.DisplayMemberPath = "Name";
            Role_Id_Cbx.SelectedValuePath = "Id";
            Role_Id_Cbx.DisplayMemberPath = "Name";
        }
        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            string id1 = Login_Tbx.Text;
            if (Validation.validString(id1)) { return; }
            string id2 = Password_Tbx.Text;
            if (Validation.validString(id2)) { return; }
            int id3 = (int)User_Id_Cbx.SelectedValue;
            if(User_Id_Cbx.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
            int id4 = (int)Role_Id_Cbx.SelectedValue;
            if (Role_Id_Cbx.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }

            tableAdapter.InsertQuery(id1,id2,id3,id4);
            Login_Password_Grid.ItemsSource = tableAdapter.GetData();

        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Login_Password_Grid.SelectedValue != null)
            {
                int id = (int)(Login_Password_Grid.SelectedItem as DataRowView).Row[0];

                string id1 = Login_Tbx.Text;
                if (Validation.validString(id1)) { return; }
                string id2 = Password_Tbx.Text;
                if (Validation.validString(id2)) { return; }
                int id3 = (int)User_Id_Cbx.SelectedValue;
                if (User_Id_Cbx.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
                int id4 = (int)Role_Id_Cbx.SelectedValue;
                if (Role_Id_Cbx.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
                tableAdapter.UpdateQuery( id1,id2,id3,id4,id);
                Login_Password_Grid.ItemsSource = tableAdapter.GetData();


            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Login_Password_Grid.SelectedItem != null)
            {

                int id = (int)(Login_Password_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                Login_Password_Grid.ItemsSource = tableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
            }

        }

        private void Login_Password_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Login_Password_Grid.SelectedItem != null)
            {

                Login_Tbx.Text = (string)(Login_Password_Grid.SelectedItem as DataRowView).Row[1];
                Password_Tbx.Text = (string)(Login_Password_Grid.SelectedItem as DataRowView).Row[2];
                User_Id_Cbx.SelectedValue =(Login_Password_Grid.SelectedItem as DataRowView).Row[3];
                Role_Id_Cbx.SelectedValue = (Login_Password_Grid.SelectedItem as DataRowView).Row[4];

        


            }
        }
    }
}

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
namespace Totalproject.Pages_Workers
{
    /// <summary>
    /// Логика взаимодействия для Worker_Page.xaml
    /// </summary>
    public partial class Worker_Page : Page
    {
        WorkersTableAdapter tableAdapter = new WorkersTableAdapter();
        BrigadeTableAdapter brigade = new BrigadeTableAdapter();
        PostTableAdapter post = new PostTableAdapter(); 
        public Worker_Page()
        {
            InitializeComponent();
            Worker_Grid.ItemsSource = tableAdapter.GetData();
            Post.ItemsSource = post.GetData();
            Brigade.ItemsSource = brigade.GetData();
            Brigade.SelectedValuePath = "Id";
            Brigade.DisplayMemberPath = "Name";
            Post.SelectedValuePath = "Id";
            Post.DisplayMemberPath = "Name";
        }
        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            string id1 = Name_tbx.Text;
            if (Validation.validString(id1)) { return; }
            string id2 = Surname_tbx.Text;
            if (Validation.validString(id2)) { return; }
            string id3 = Second_Name_tbx.Text;
            if (Validation.validString(id3)) { return; }

            if (Post.SelectedValue == null) { MessageBox.Show("Введите комбобокс"); return; }
            int id4 = Convert.ToInt32(Post.SelectedValue);
            decimal id5 = Convert.ToDecimal(Salary.Text);
            if (Validation.validInt(id5.ToString())) { MessageBox.Show("Введите комбобокс"); return; }
            if (Brigade.SelectedValue == null) { return; }
            int id6 = Convert.ToInt32(Brigade.SelectedValue);
            tableAdapter.InsertQuery(id1, id2, id3, id4,id5,id6);
            Worker_Grid.ItemsSource = tableAdapter.GetData();

        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Worker_Grid.SelectedValue != null)
            {
                int id = (int)(Worker_Grid.SelectedItem as DataRowView).Row[0];

                string id1 = Name_tbx.Text;
                if (Validation.validString(id1)) { return; }
                string id2 = Surname_tbx.Text;
                if (Validation.validString(id2)) { return; }
                string id3 = Second_Name_tbx.Text;
                if (Validation.validString(id3)) { return; }
                if(Post.SelectedValue == null) {  MessageBox.Show("Введите комбобокс"); return;  }
                int id4 = Convert.ToInt32(Post.SelectedValue);
                
                if (Validation.validInt(Salary.ToString())) { return; }
                decimal id5 = Convert.ToDecimal(Salary.Text);
               
                int id6 = Convert.ToInt32(Brigade.SelectedValue);

                tableAdapter.UpdateQuery(id1, id2, id3, id4, id5, id6, id);
                Worker_Grid.ItemsSource = tableAdapter.GetData();


            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Worker_Grid.SelectedItem != null)
            {
                int id = (int)(Worker_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                Worker_Grid.ItemsSource = tableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
            }

        }

        private void Worker_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Worker_Grid.SelectedItem != null)
            {

                Name_tbx.Text = Convert.ToString((Worker_Grid.SelectedItem as DataRowView).Row[1]);
                Surname_tbx.Text = Convert.ToString((Worker_Grid.SelectedItem as DataRowView).Row[2]);
                Second_Name_tbx.Text = Convert.ToString((Worker_Grid.SelectedItem as DataRowView).Row[3]);
                Post.SelectedValue = Convert.ToString((Worker_Grid.SelectedItem as DataRowView).Row[4]);
                Salary.Text = Convert.ToString((Worker_Grid.SelectedItem as DataRowView).Row[5]);
                Brigade.Text = Convert.ToString((Worker_Grid.SelectedItem as DataRowView).Row[6]);


            }

        }
    }
}

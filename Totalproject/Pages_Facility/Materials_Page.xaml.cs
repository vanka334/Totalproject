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

namespace Totalproject
{
    /// <summary>
    /// Логика взаимодействия для Materials_Page.xaml
    /// </summary>
    public partial class Materials_Page : Page
    {
        MaterialsTableAdapter tableAdapter = new MaterialsTableAdapter();
        public Materials_Page()
        {
            InitializeComponent();
            Materials_Grid.ItemsSource = tableAdapter.GetData();
        }

        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            string id1 = Name_Tbx.Text;
            if (Validation.validString(id1)) { return; }

            if (Validation.validInt(Price_Tbx.Text.ToString())) { return; }
            decimal id2 = Convert.ToDecimal(Price_Tbx.Text);
            if (Validation.validInt(Amount_Tbx.Text.ToString())) { return; }
            decimal id3 = Convert.ToDecimal(Amount_Tbx.Text);

            string id4 = Status.Text;
           
            if (Validation.validString(id4)) { return; }
            tableAdapter.InsertQuery(id1, id2, id3, id4);
            Materials_Grid.ItemsSource = tableAdapter.GetData();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Materials_Grid.SelectedValue != null)
            {
                int id = (int)(Materials_Grid.SelectedItem as DataRowView).Row[0];
                string id1 = Name_Tbx.Text;
                if (Validation.validString(id1)) { return; }
                if (Validation.validInt(Price_Tbx.Text.ToString())) { return; }
                decimal id2 = Convert.ToDecimal(Price_Tbx.Text);
                if (Validation.validInt(Amount_Tbx.Text.ToString())) { return; }
                decimal id3 = Convert.ToDecimal(Amount_Tbx.Text);
             
                string id4 = Status.Text;
                if (Validation.validString(id4)) { return; }

                tableAdapter.UpdateQuery(id1, id2, id3, id4,  id);
                Materials_Grid.ItemsSource = tableAdapter.GetData();


            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Materials_Grid.SelectedItem != null)
            {
                int id = (int)(Materials_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                Materials_Grid.ItemsSource = tableAdapter.GetData();
            }


        }

        private void Materials_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Materials_Grid.SelectedItem != null)
            {

                Name_Tbx.Text = Convert.ToString((Materials_Grid.SelectedItem as DataRowView).Row[1]);
                Price_Tbx.Text = Convert.ToString((Materials_Grid.SelectedItem as DataRowView).Row[2]);
                Amount_Tbx.Text = Convert.ToString((Materials_Grid.SelectedItem as DataRowView).Row[3]);
                Status.Text = Convert.ToString((Materials_Grid.SelectedItem as DataRowView).Row[4]);

               


            }

        }
    }
}

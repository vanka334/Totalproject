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
using System.Xml.Linq;
using Totalproject.DataSet1TableAdapters;
namespace Totalproject.Pages_Facility
{
    
    /// <summary>
    /// Логика взаимодействия для Facility_Brigade_Page.xaml
    /// </summary>
    public partial class Facility_Brigade_Page : Page
    {
        Brigade_FacilityTableAdapter tableAdapter = new Brigade_FacilityTableAdapter();
        FacilityTableAdapter facility = new FacilityTableAdapter();
        BrigadeTableAdapter brigade = new BrigadeTableAdapter();
        public Facility_Brigade_Page()
        {
            InitializeComponent();
            Brigade_Facility_Grid.ItemsSource = tableAdapter.GetData();
            Id_Facility.ItemsSource = facility.GetData();  
            Id_Brigade.ItemsSource = brigade.GetData();
            Id_Facility.SelectedValuePath = "Id";
            Id_Facility.DisplayMemberPath = "Name";
            Id_Brigade.SelectedValuePath = "Id";
            Id_Brigade.DisplayMemberPath = "Name";

        }

        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Id_Facility.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
            int id = (int)Id_Facility.SelectedValue;

            if (Id_Brigade.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
            int id1 = (int)Id_Brigade.SelectedValue;
            tableAdapter.InsertQuery(id, id1);
            Brigade_Facility_Grid.ItemsSource = tableAdapter.GetData();

        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Brigade_Facility_Grid.SelectedItem != null)
            {
                int id = (int)(Brigade_Facility_Grid.SelectedItem as DataRowView).Row[0];
                if (Id_Facility.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
                if (Id_Brigade.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
                tableAdapter.UpdateQuery(Convert.ToInt32(Id_Facility.SelectedValue), Convert.ToInt32(Id_Brigade.SelectedValue), Convert.ToInt32(id));
                Brigade_Facility_Grid.ItemsSource = tableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
                return;
            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Brigade_Facility_Grid.SelectedItem != null)
            {

                int id = (int)(Brigade_Facility_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                Brigade_Facility_Grid.ItemsSource = tableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
                return;
            }

        }

        private void Brigade_Facility_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Brigade_Facility_Grid.SelectedItem != null)
            {
                Id_Brigade.SelectedValue = Convert.ToString((Brigade_Facility_Grid.SelectedItem as DataRowView).Row[2]);
                Id_Facility.SelectedValue = Convert.ToString((Brigade_Facility_Grid.SelectedItem as DataRowView).Row[1]);
            }


        }
    }
}

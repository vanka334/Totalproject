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
namespace Totalproject.Pages_Facility
{
    /// <summary>
    /// Логика взаимодействия для Facility_Materials_Page.xaml
    /// </summary>
    public partial class Facility_Materials_Page : Page
    {
        Facility_MaterialsTableAdapter tableAdapter = new Facility_MaterialsTableAdapter();
        FacilityTableAdapter facility = new FacilityTableAdapter();
        MaterialsTableAdapter materials = new MaterialsTableAdapter();

        public Facility_Materials_Page()
        {
            InitializeComponent();
            Facility_Materials_Grid.ItemsSource = tableAdapter.GetData();
            Id_Facility.ItemsSource = facility.GetData();
            Id_Materials.ItemsSource = materials.GetData();
            Id_Facility.SelectedValuePath = "Id";
            Id_Facility.DisplayMemberPath = "Name";
            Id_Materials.SelectedValuePath = "Id";
            Id_Materials.DisplayMemberPath = "Name";
        }
        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Id_Facility.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
            int id = (int)Id_Facility.SelectedValue;
            if (Id_Materials.SelectedValue == null)
            {
                MessageBox.Show("Вы не вырали комбобокс");
                return;
            }
            int id1 = (int)Id_Materials.SelectedValue;
                tableAdapter.InsertQuery(id, id1);
            Facility_Materials_Grid.ItemsSource = tableAdapter.GetData();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Facility_Materials_Grid.SelectedItem != null)
            {
                int id = (int)(Facility_Materials_Grid.SelectedItem as DataRowView).Row[0];
                if (Id_Facility.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
                if (Id_Materials.SelectedValue == null)
                {
                    MessageBox.Show("Вы не вырали комбобокс");
                    return;
                }
                tableAdapter.UpdateQuery(Convert.ToInt32(Id_Facility.SelectedValue), Convert.ToInt32(Id_Materials.SelectedValue), Convert.ToInt32(id));
                Facility_Materials_Grid.ItemsSource = tableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
                return;
            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Facility_Materials_Grid.SelectedItem != null)
            {
                int id = (int)(Facility_Materials_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                Facility_Materials_Grid.ItemsSource = tableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
                return;
            }
        }

        private void Facility_Materials_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (Facility_Materials_Grid.SelectedItem != null)
            {
                Id_Materials.SelectedValue = Convert.ToString((Facility_Materials_Grid.SelectedItem as DataRowView).Row[2]);
                Id_Facility.SelectedValue = Convert.ToString((Facility_Materials_Grid.SelectedItem as DataRowView).Row[1]);
            }


        }
    }
}

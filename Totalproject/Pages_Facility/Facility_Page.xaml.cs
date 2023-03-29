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
    /// Логика взаимодействия для Facility_Page.xaml
    /// </summary>
    /// 
    
    public partial class Facility_Page : Page
    {
        FacilityTableAdapter tableAdapter = new FacilityTableAdapter();
        
        TypeTableAdapter type = new TypeTableAdapter();
        public Facility_Page()
        {
            InitializeComponent();
            Facility_Grid.ItemsSource = tableAdapter.GetData();
            Type_of_Facility.ItemsSource = type.GetData();

            Type_of_Facility.SelectedValuePath = "Id";
            Type_of_Facility.DisplayMemberPath = "Type";
        }
        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            string id = Name_tbx.Text;
            if (Validation.validString(id)) { return; }

            if (Type_of_Facility.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
            int id2 = (int)Type_of_Facility.SelectedValue;
            string id3 = Adress.Text;
            if (Validation.validAdress(id3)) { return; }

            if (Validation.validInt(Price.Text.ToString())) { return; }
            decimal id4 = Convert.ToDecimal(Price.Text);

            string id5 = Region.Text;
            if (Validation.validString(id5)) { return; }
            if (Validation.validInt(FloorAmount.Text.ToString())) { return; }
            int id6= Convert.ToInt32(FloorAmount.Text);



            tableAdapter.InsertQuery(id, id2,id3,id4,id5,id6);
            Facility_Grid.ItemsSource = tableAdapter.GetData();

        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        { if (Facility_Grid.SelectedItem != null)
            {
                string id1 = Name_tbx.Text;
                if (Validation.validString(id1)) { return; }
                if (Type_of_Facility == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
                int id2 = Convert.ToInt32(Type_of_Facility.SelectedValue);
                string id3 = Adress.Text;
                if (Validation.validString(id3)) { return; }
                decimal id4 = Convert.ToDecimal(Price.Text);
                if (Validation.validInt(id4.ToString())) { return; }

                string id5 = Region.Text;
                if (Validation.validString(id5)) { return; }

                int id6 = Convert.ToInt32(FloorAmount.Text);
                if (Validation.validInt(id6.ToString())) { return; }


                int id = (int)(Facility_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.UpdateQuery(id1,id2,id3,id4,id5,id6,id);
                Facility_Grid.ItemsSource = tableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
                return;
            }



        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Facility_Grid.SelectedItem != null)
            {
                int id = (int)(Facility_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                Facility_Grid.ItemsSource = tableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
                return;
            }

        }

        private void Facility_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Facility_Grid.SelectedItem != null)
            {
               Type_of_Facility.SelectedValue = Convert.ToString((Facility_Grid.SelectedItem as DataRowView).Row[2]);
               Name_tbx.Text = Convert.ToString((Facility_Grid.SelectedItem as DataRowView).Row[1]);
                Adress.Text = Convert.ToString((Facility_Grid.SelectedItem as DataRowView).Row[3]);
                Price.Text = Convert.ToString((Facility_Grid.SelectedItem as DataRowView).Row[4]);
                Region.Text = Convert.ToString((Facility_Grid.SelectedItem as DataRowView).Row[5]);
                FloorAmount.Text = Convert.ToString((Facility_Grid.SelectedItem as DataRowView).Row[6]);

            }

        }
    }
}

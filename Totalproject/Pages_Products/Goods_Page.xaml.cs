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
namespace Totalproject.Pages_Products
{
    /// <summary>
    /// Логика взаимодействия для Goods_Page.xaml
    /// </summary>
    public partial class Goods_Page : Page
    {
        GoodsTableAdapter tableAdapter = new GoodsTableAdapter();
        Type_of_goodTableAdapter type = new Type_of_goodTableAdapter();
        FacilityTableAdapter facilityTableAdapter = new FacilityTableAdapter(); 

        public Goods_Page()

        {
            
            InitializeComponent();
            Goods_Grid.ItemsSource = tableAdapter.GetData();
            Object_Cbx.ItemsSource = facilityTableAdapter.GetData();
            Type_of_Good.ItemsSource = type.GetData();
            Type_of_Good.SelectedValuePath = "Id";
            Type_of_Good.DisplayMemberPath = "Name";
            Object_Cbx.SelectedValuePath = "Id";
            Object_Cbx.DisplayMemberPath = "Name";
        }
        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Type_of_Good.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
            int id1 = Convert.ToInt32(Type_of_Good.SelectedValue);
            if (Object_Cbx.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
            int id2 = Convert.ToInt32(Object_Cbx.SelectedValue);

            if (Validation.validInt(Space.Text.ToString())) { return; }
            decimal id3 = Convert.ToDecimal(Space.Text);
            if (Validation.validInt(Rooms_tbx.Text.ToString())) { return; }
            int id4 = Convert.ToInt32(Rooms_tbx.Text);
            if (Validation.validInt(Floor_Tbx.Text.ToString())) { return; }
            int id5 = Convert.ToInt32(Floor_Tbx.Text);
            if (Validation.validInt(Price_tbx.Text.ToString())) { return; }
            decimal id6 = Convert.ToDecimal(Price_tbx.Text);
            tableAdapter.InsertQuery(id1, id2, id3, id4, id5, id6);
            Goods_Grid.ItemsSource = tableAdapter.GetData();

        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Goods_Grid.SelectedValue != null)
            {
                int id = (int)(Goods_Grid.SelectedItem as DataRowView).Row[0];
                if(Type_of_Good.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
                int id1 = Convert.ToInt32(Type_of_Good.SelectedValue);
                if (Object_Cbx.SelectedValue == null) { MessageBox.Show("Вы не вырали комбобокс"); return; }
                int id2 = Convert.ToInt32(Object_Cbx.SelectedValue);
                if (Validation.validInt(Space.Text.ToString())) { return; }
                decimal id3 = Convert.ToDecimal(Space.Text);
                if (Validation.validInt(Rooms_tbx.Text.ToString())) { return; }
                int id4 = Convert.ToInt32(Rooms_tbx.Text);
                if (Validation.validInt(Floor_Tbx.Text.ToString())) { return; }
                int id5 = Convert.ToInt32(Floor_Tbx.Text);
                if (Validation.validInt(Price_tbx.Text.ToString())) { return; }
                decimal id6 = Convert.ToDecimal(Price_tbx.Text);
               
                tableAdapter.UpdateQuery(id1, id2, id3, id4, id5, id6, id);
                Goods_Grid.ItemsSource = tableAdapter.GetData();


            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Goods_Grid.SelectedValue != null)
            {
                int id = (int)(Goods_Grid.SelectedItem as DataRowView).Row[0];
                tableAdapter.DeleteQuery(id);
                Goods_Grid.ItemsSource = tableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент");
            }
        }

        private void Goods_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Goods_Grid.SelectedValue != null)
            {
                Type_of_Good.SelectedValue = Convert.ToString((Goods_Grid.SelectedItem as DataRowView).Row[1]);
                Object_Cbx.SelectedValue = Convert.ToString((Goods_Grid.SelectedItem as DataRowView).Row[2]);
                Space.Text = Convert.ToString((Goods_Grid.SelectedItem as DataRowView).Row[3]);
                Rooms_tbx.Text = Convert.ToString((Goods_Grid.SelectedItem as DataRowView).Row[4]);
                Floor_Tbx.Text = Convert.ToString((Goods_Grid.SelectedItem as DataRowView).Row[5]);
                Price_tbx.Text = Convert.ToString((Goods_Grid.SelectedItem as DataRowView).Row[6]);
                

            }
        }
    }
}

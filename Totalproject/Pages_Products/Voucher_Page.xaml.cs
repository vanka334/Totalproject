using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Voucher_Page.xaml
    /// </summary>
    public partial class Voucher_Page : Page
    {
        VoucherTableAdapter tableAdapter  = new VoucherTableAdapter();  
        public Voucher_Page()
        {
            InitializeComponent();
            Voucher_DG.ItemsSource = tableAdapter.GetData();
        }
       
    }
}

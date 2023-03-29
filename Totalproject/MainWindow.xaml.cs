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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Login1TableAdapter adapter = new Login1TableAdapter();
        UserTableAdapter user = new UserTableAdapter();
        public static string name;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = adapter.GetData().Rows;
            if(Validation.validLogin(Login.Text)) { return; }
            var allusers = user.GetData().Rows;
            
           
            bool log = false;
            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][1].ToString() == Login.Text)
                {
                    log = true;

                    if (log == true && allLogins[i][2].ToString() == Password.Password)
                    {
                        int roleId = (int)allLogins[i][4];
                       
                        for (int j = 0; j < allusers.Count; j++)
                        {
                            if (allLogins[i][3].ToString() == allusers[j][0].ToString())
                            {
                                name = allusers[j][1].ToString() + " " + allusers[j][2].ToString() + " " + allusers[j][3].ToString();
                            }
                        }
                        switch (roleId)
                        {
                            case 1:
                                Admin_window window = new Admin_window();
                                window.Show();
                                Close();
                                break;
                            case 2:
                                User_Window windiw = new User_Window();
                                windiw.Show();
                                Close();
                                break;
                        }
                        return;

                    }
                    else
                    {
                        MessageBox.Show(" Неверный пароль");
                        return;
                    }

                }

            }
            MessageBox.Show("Неверный логин");


        }
    }
}

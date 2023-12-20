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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (TestEntities db = new TestEntities())
            {
                List<Users> user = (from us in db.Users where us.login == LoginInput.Text && us.password == PasswordInput.Password select us).ToList();

                if(user.Count != 0)
                {
                    if (user[0].role == "Администратор")
                    {
                        Admin admin = new Admin();
                        admin.Show();
                        this.Close();
                    }
                    if (user[0].role == "Менеджер")
                    {

                    }
                } else
                {
                    MessageBox.Show("Нет такого");
                }
            }
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            MessageBox.Show("Абоба");
            this.Close();
        }
    }
}

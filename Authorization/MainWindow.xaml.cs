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

namespace Authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Window;
        public static User UserWindow;
        List<UserBD> users;
        public MainWindow()
        {
            InitializeComponent();
            users = new List<UserBD>();
            users.Add(new UserBD("admin", "1111"));
        }

        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            string login_enter = loginBoxEnter.Text.Trim();
            string pass_enter = passBoxEnter.Password.Trim();

            if (login_enter.Length < 4)
            {
                loginBoxEnter.ToolTip = "Некорректный ввод данных";
                loginBoxEnter.Background = Brushes.LemonChiffon;
            }
            else if (pass_enter.Length < 4)
            {
                passBoxEnter.ToolTip = "Некорректный ввод данных";
                passBoxEnter.Background = Brushes.LemonChiffon;
            }
            else
            {
                loginBoxEnter.ToolTip = "";
                passBoxEnter.ToolTip = "";
            }
            if (loginBoxEnter.Text != null && passBoxEnter.Password != null)
            {
                foreach (UserBD user in users)
                {
                    if (user.login.Equals(login_enter) && user.password.Equals(pass_enter))
                    {
                        UserWindow = new User();
                        UserWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        loginBoxEnter.ToolTip = "Некорректный ввод данных";
                        loginBoxEnter.Background = Brushes.LemonChiffon;
                        passBoxEnter.ToolTip = "Некорректный ввод данных";
                        passBoxEnter.Background = Brushes.LemonChiffon;
                    }
                }
            }
            else if(loginBoxEnter.Text == null)
            {
                loginBoxEnter.ToolTip = "Некорректный ввод данных";
                loginBoxEnter.Background = Brushes.LemonChiffon;
            }
            else if(passBoxEnter.Password == null)
            {
                passBoxEnter.ToolTip = "Некорректный ввод данных";
                passBoxEnter.Background = Brushes.LemonChiffon;
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login_reg = loginBoxReg.Text.Trim();
            string email = emailBox.Text.Trim().ToLower();
            string pass_reg = passBoxReg1.Password.Trim();
            string pass_reg2 = passBoxReg2.Password.Trim();

            if (login_reg.Length < 4)
            {
                loginBoxReg.ToolTip = "Некорректный ввод данных";
                loginBoxReg.Background = Brushes.LemonChiffon;
            }
            else if (pass_reg.Length < 4)
            {
                passBoxReg1.ToolTip = "Некорректный ввод данных";
                passBoxReg1.Background = Brushes.LemonChiffon;
            }
            else if(pass_reg2.Length < 4)
            {
                passBoxReg2.ToolTip = "Некорректный ввод данных";
                passBoxReg2.Background = Brushes.LemonChiffon;
            }
            else if(pass_reg != pass_reg2)
            {
                passBoxReg2.ToolTip = "Некорректный ввод данных";
                passBoxReg2.Background = Brushes.LemonChiffon;
            }
            else if(email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                emailBox.ToolTip = "Некорректный ввод данных";
                emailBox.Background = Brushes.LemonChiffon;
            }
            else
            {
                loginBoxReg.ToolTip = "";
                passBoxReg1.ToolTip = "";
                passBoxReg2.ToolTip = "";
                emailBox.ToolTip = "";

                MessageBox.Show("Регистрация прошла успешно!");
                users.Add(new UserBD(login_reg, pass_reg2));

                loginBoxReg.Text = "";
                emailBox.Text = "";
                passBoxReg1.Password = "";
                passBoxReg2.Password = "";
                enterTab.IsSelected = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
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

namespace Moon_Lighter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            SignInButton.Focus();
        }

        private const string pathToData = @"Data";

        private static string userName = ""; // Ім'я користувача яке береться з текст боксу login
        public static string UserPassword = ""; // Пароль користувача яке береться з текст боксу login

        public static string UserName { get => userName; set => userName = value; }

        

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
                if (!Directory.Exists(pathToData + "\\Users"))
                {
                    Directory.CreateDirectory(pathToData + "\\Users");
                }

                UserName = txtbLogin.Text;

                if (UserName.Length == 0)
                {
                    MessageBox.Show("Логін не може бути пустий");
                    return;
                }

                UserPassword = pswbPassword.Password;

                if (UserPassword.Length == 0)
                {
                    MessageBox.Show("Пароль не може бути пустий");
                    return;
                }

                if (!Directory.Exists(pathToData + "\\Users\\" + UserName))
                {
                    MessageBox.Show("Такого користувача не існує");

                    Button WayInRegisterWindow = new Button();

                    WayInRegisterWindow.Height = 30;

                    WayInRegisterWindow.Width = 115;

                    WayInRegisterWindow.Content = "Register";

                    WayInRegisterWindow.Name = "WayToRegisterButton";

                    WayInRegisterWindow.BorderBrush = new SolidColorBrush(Colors.DimGray);

                    WayInRegisterWindow.Background = new SolidColorBrush(Colors.Transparent);

                    WayInRegisterWindow.Foreground = new SolidColorBrush(Colors.White);

                    WayInRegisterWindow.HorizontalAlignment = HorizontalAlignment.Right;

                    WayInRegisterWindow.VerticalAlignment = VerticalAlignment.Bottom;

                    StackPanelforButton.Children.Add(WayInRegisterWindow);

                    WayInRegisterWindow.Click += WayInRegisterWindow_Click;

                    return;
                }
            try
            {
                string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + UserName + "\\" + "Info.txt");

                string hashOfPassword = BCrypt.Net.BCrypt.HashPassword(UserPassword);

                if (BCrypt.Net.BCrypt.Verify(UserPassword, tmpStringArray[0]) == true)
                {
                    Data.IsLogin = true;
                    MessageBox.Show("Авторизація успішна");
                    StartGameWindow.score = Convert.ToInt32(tmpStringArray[1]);
                    MainMenuWindow mainMenu = new MainMenuWindow();
                    mainMenu.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Не вірний логін або пароль");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проблеми з автризацією");
            }

        }

        private void WayInRegisterWindow_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow regestration = new RegistrationWindow();
            regestration.Show();
            Close();
        }

        private void SignInButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SignInButton.Click += SignInButton_Click;
            }
        }

        private void txtbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SignInButton_Click(sender, e);
            }
            
        }

        private void pswbPassword_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.Key == Key.Enter)
             {
                SignInButton_Click(sender, e);
             }
        }
    }
}

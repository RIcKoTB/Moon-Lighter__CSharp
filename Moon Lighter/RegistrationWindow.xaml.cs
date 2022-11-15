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
using System.Windows.Shapes;

namespace Moon_Lighter
{
    /// <summary>
    /// Логика взаимодействия для Regestration.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private const string pathToData = @"Data";

        public static string UserName = ""; // Ім'я користувача яке береться з текст боксу login
        public static string UserPassword = ""; // Пароль користувача яке береться з текст боксу login

        private void WayInSignInButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizathion = new AuthorizationWindow();
            authorizathion.Show();
            Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if(!Directory.Exists(pathToData + "\\Users"))
            {
                Directory.CreateDirectory(pathToData + "\\Users");
            }

            UserName = txtbLogin.Text;

            if (UserName.Length == 0) // Перевірка на пустий текст бокс
            {
                MessageBox.Show("Логін не може бути пустий");
                return;
            }

            UserPassword = pswbPassword.Password;

            if (UserPassword.Length == 0) // Перевірка на пустий текст бокс
            {
                MessageBox.Show("Пароль не може бути пустий");
                return;
            }

            string UserPasswordConfirm = pswbConfirmPassword.Password;
            if (UserPasswordConfirm.Length == 0) // Перевірка на пустий текст бокс
            {
                MessageBox.Show("Введіть пароль ще раз");
                return;
            }

            if (UserPassword != UserPasswordConfirm) // Перевірка на співпадіння паролів
            {
                MessageBox.Show("Паролі не співпадають");
                return;
            }

            for (int i = 0; i < UserName.Length; i++)
            {
                if (UserName[i] >= 'A' && UserName[i] <= 'Z' || UserName[i] >= 'a' && UserName[i] <= 'z')
                {
                    break;
                }
                if (i == UserName.Length - 1)
                {
                    MessageBox.Show("Логін не може складатися тільки з цифр");
                    return;
                }
            }


            if(Directory.Exists(pathToData + "\\Users\\" + UserName))
            {
                MessageBox.Show("Користувач вже інсує");
                return;
            }

            Directory.CreateDirectory(pathToData + "\\Users\\" + UserName);

            string hashOfPassword = BCrypt.Net.BCrypt.HashPassword(UserPassword);

            File.WriteAllText(pathToData + "\\Users\\" + UserName + "\\Info.txt", hashOfPassword + "\n" + 0 + "\n" + 0 + "\n" + "\n" + "\n" + "\n");

            MessageBox.Show("Реєстрація успішна");
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            Close();

        }

        private void txtbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterButton_Click(sender, e);
            }
        }

        private void pswbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterButton_Click(sender, e);
            }
        }

        private void pswbConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterButton_Click(sender, e);
            }
        }
    }
}

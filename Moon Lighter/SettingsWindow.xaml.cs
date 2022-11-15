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
using System.Windows.Shapes;

namespace Moon_Lighter
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow auth = new AuthorizationWindow();
            auth.Show();
            Close();
            MessageBox.Show("Ви вийшли з аккаунту: " + AuthorizationWindow.UserName);
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenu = new MainMenuWindow();
            mainMenu.Show();
            Close();
        }

        private void BlackTheme_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"BlackThemes.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void WhiteTheme_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"WhitheTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void OffMusicInGame_Click(object sender, RoutedEventArgs e)
        {
            Music.MusicForGame = false;
            MainMenuWindow.MusicInGame.Stop();
            MessageBox.Show("Музика в грі вимкнена");
        }

        private void OnMusicInGame_Click(object sender, RoutedEventArgs e)
        {
            Music.MusicForGame = true;
            MessageBox.Show("Музика в грі увімкнута");
        }
    }
}

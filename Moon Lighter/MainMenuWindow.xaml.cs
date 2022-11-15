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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public static System.Media.SoundPlayer MusicInGame = new System.Media.SoundPlayer(Properties.Resources.MusicForMainMenu);

        public MainMenuWindow()
        {
            InitializeComponent();
            if (Data.IsLogin == true)
            {
                LabelLoginUser.Visibility = Visibility.Visible;
                LabelLoginUser.Text = "You are logged in as: " + AuthorizationWindow.UserName;
            }

            if (Music.MusicForGame == true)
            {
                MusicInGame.Play();
            }

        }

        private const string pathToData = @"Data";

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
            Close();
        }

        private void ShopPageButton_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow shop = new ShopWindow();
            shop.Show();
            Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StartPageButton_Click(object sender, RoutedEventArgs e)
        {
            LevelSelectionWindow levelSelectionWindow = new LevelSelectionWindow(); 
            levelSelectionWindow.Show();
            Close();


            //StartGameWindow startGameWindow = new StartGameWindow();
            //startGameWindow.Show();
            //Close();
        }
    }
}

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
    /// Логика взаимодействия для LevelSelectionWindow.xaml
    /// </summary>
    public partial class LevelSelectionWindow : Window
    {
        private const string pathToData = @"Data";

        string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt");

        public LevelSelectionWindow()
        {
            InitializeComponent();
        }

        private void FirstLevel_Click(object sender, RoutedEventArgs e)
        {
            StartGameWindow startGameWindow = new StartGameWindow();
            startGameWindow.Show();
            Close();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenu = new MainMenuWindow();
            mainMenu.Show();
            Close();
        }

        private void Level2Button_Click(object sender, RoutedEventArgs e)
        {
            if (tmpStringArray[4].Contains("1"))
            {
                Level2Window Level2 = new Level2Window();
                Level2.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вам поки не доступний цей рівень, пройдіть попередній");
            }
        }

        private void Level3Button_Click(object sender, RoutedEventArgs e)
        {
            if (tmpStringArray[4].Contains("2"))
            {
                Level3Window Level3 = new Level3Window();
                Level3.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вам поки не доступний цей рівень, пройдіть попередній");
            }
        }

        private void Level4Button_Click(object sender, RoutedEventArgs e)
        {
            if (tmpStringArray[4].Contains("3"))
            {
                Level4Window Level4 = new Level4Window();
                Level4.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вам поки не доступний цей рівень, пройдіть попередній");
            }
        }

        private void Level5Button_Click(object sender, RoutedEventArgs e)
        {
            if (tmpStringArray[4].Contains("4"))
            {
                Level5Window Level5 = new Level5Window();
                Level5.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вам поки не доступний цей рівень, пройдіть попередній");
            }
        }

        private void Level6Button_Click(object sender, RoutedEventArgs e)
        {
            if (tmpStringArray[4].Contains("5"))
            {
                Level6Window Level6 = new Level6Window();
                Level6.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вам поки не доступний цей рівень, пройдіть попередній");
            }
        }

        private void Level7Button_Click(object sender, RoutedEventArgs e)
        {
            if (tmpStringArray[4].Contains("6"))
            {
                Level7Window Level7 = new Level7Window();
                Level7.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вам поки не доступний цей рівень, пройдіть попередній");
            }
        }

        private void Level8Button_Click(object sender, RoutedEventArgs e)
        {
            if (tmpStringArray[4].Contains("7"))
            {
                Level8Window Level8 = new Level8Window();
                Level8.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вам поки не доступний цей рівень, пройдіть попередній");
            }
        }

        private void Level9Button_Click(object sender, RoutedEventArgs e)
        {
            if (tmpStringArray[4].Contains("8"))
            {
                Level9Window Level9 = new Level9Window();
                Level9.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вам поки не доступний цей рівень, пройдіть попередній");
            }
        }

        private void Level10Button_Click(object sender, RoutedEventArgs e)
        {
            if (tmpStringArray[4].Contains("9"))
            {
                Level10Window Level10 = new Level10Window();
                Level10.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вам поки не доступний цей рівень, пройдіть попередній");
            }
        }
    }
}

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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Moon_Lighter
{
    /// <summary>
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        private const string pathToData = @"Data";

        public static int score = 0;

        public ShopWindow()
        {
            InitializeComponent();
        }

        private void SkinsButton_Click(object sender, RoutedEventArgs e) // При натисканні появляється список магазину
        {
            FirstItemsBuy.Visibility = Visibility.Visible;
            DownFirstItemsBuy.Visibility = Visibility.Visible;
            TxtFirstItemsBuy.Visibility = Visibility.Visible;
            TextBlockPrice1Item.Visibility = Visibility.Visible;
            
            SecondItemsBuy.Visibility = Visibility.Visible;
            DownSecondItemsBuy.Visibility = Visibility.Visible;
            TextBlockNameHero2Item.Visibility = Visibility.Visible;
            TextBlockPrice2Item.Visibility = Visibility.Visible;

            ThreeItemsBuy.Visibility = Visibility.Visible;
            DownThreeItemsBuy.Visibility = Visibility.Visible;
            TextBlockNameHero3Item.Visibility = Visibility.Visible;
            TextBlockPrice3Item.Visibility = Visibility.Visible;

            FourItemsBuy.Visibility = Visibility.Visible;
            DownFourItemsBuy.Visibility = Visibility.Visible;
            FourItemsName.Visibility = Visibility.Visible;
            TextBlockPrice4Item.Visibility = Visibility.Visible;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenu = new MainMenuWindow();
            mainMenu.Show();
            Close();
        }

        private void FirsSkinBuy_Click(object sender, RoutedEventArgs e)
        {
            string message = "Ви хочете купити цей скін?";
            string title = "Ember | Rare";
            string price = TextBlockPrice1Item.Text;

            string messageSelect = "Цей скін вже куплено, хочте його одягнути?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            DialogResult result2 = MessageBox.Show(messageSelect, title, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes) // Повідомлення чи хочете купити скін
            {
                int a = StartGameWindow.score;
                int b = Convert.ToInt32(price);

                string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt");

                if(tmpStringArray[3].Contains("1")) // Чи куплений вже скін
                {
                    if (result2 == System.Windows.Forms.DialogResult.Yes)
                    {
                        tmpStringArray[2] = "1";
                    }
                }
                else
                {
                    if (a < b) // Перевірка на достатню кількість монет
                    {
                        MessageBox.Show("У вас не хватає монет");
                        return;
                    }

                    int c = a - b;

                    tmpStringArray[1] = c.ToString(); // Запис в текстовий документ поточні монети

                    tmpStringArray[3] += "1"; // Запис в текстовий документ наявність скіна
                }



                File.WriteAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", string.Empty);

                for (int i = 0; i < 5; i++)
                {
                    File.AppendAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", tmpStringArray[i] + "\n");
                    
                }

            }
        }

        private void SecondItemsBuy_Click(object sender, RoutedEventArgs e)
        {
            string message = "Ви хочете купити цей скін?";
            string title = "Axel | Legendary";
            string price = TextBlockPrice2Item.Text;

            string messageSelect = "Цей скін вже куплено, хочте його одягнути?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            DialogResult result2 = MessageBox.Show(messageSelect, title, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int a = StartGameWindow.score;
                int b = Convert.ToInt32(price);

                string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt");

                if (tmpStringArray[3].Contains("2"))
                {
                    if (result2 == System.Windows.Forms.DialogResult.Yes)
                    {
                        tmpStringArray[2] = "2";
                    }
                }
                else
                {
                    if (a < b)
                    {
                        MessageBox.Show("У вас не хватає монет");
                        return;
                    }

                    int c = a - b;

                    tmpStringArray[1] = c.ToString();
                    tmpStringArray[3] += "2";
                }

                File.WriteAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", string.Empty);

                for (int i = 0; i < 5; i++)
                {
                    File.AppendAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", tmpStringArray[i] + "\n");

                }

            }
        }

        private void ThreeItemsBuy_Click(object sender, RoutedEventArgs e)
        {
            string message = "Ви хочете купити цей скін?";
            string title = "Meshka | Legendary";
            string price = TextBlockPrice3Item.Text;
            MessageBox.Show(TextBlockPrice3Item.Text);

            string messageSelect = "Ви хочете вибрати цей скін?";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            DialogResult result2 = MessageBox.Show(messageSelect, title, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int a = StartGameWindow.score;
                int b = Convert.ToInt32(price);

                string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt");

                if (tmpStringArray[3].Contains("3"))
                {
                    if (result2 == System.Windows.Forms.DialogResult.Yes)
                    {
                        tmpStringArray[2] = "3";
                    }
                }
                else
                {
                    if (a < b)
                    {
                        MessageBox.Show("У вас не хватає монет");
                        return;
                    }

                    int c = a - b;

                    tmpStringArray[1] = c.ToString();
                    tmpStringArray[3] += "3";
                }

                File.WriteAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", string.Empty);

                for (int i = 0; i < 5; i++)
                {
                    File.AppendAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", tmpStringArray[i] + "\n");

                }
            }
        }

        private void FourItemsBuy_Click(object sender, RoutedEventArgs e)
        {
            string message = "Ви хочете купити цей скін?";
            string title = "Dock | Rare";
            string price = TextBlockPrice4Item.Text;

            string messageSelect = "Ви хочете вибрати цей скін?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            DialogResult result2 = MessageBox.Show(messageSelect, title, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int a = StartGameWindow.score;
                int b = Convert.ToInt32(price);

                string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt");

                if (tmpStringArray[3].Contains("4"))
                {
                    if (result2 == System.Windows.Forms.DialogResult.Yes)
                    {
                        tmpStringArray[2] = "4";
                    }
                }
                else
                {
                    if (a < b)
                    {
                        MessageBox.Show("У вас не хватає монет");
                        return;
                    }

                    int c = a - b;

                    tmpStringArray[1] = c.ToString();
                    tmpStringArray[3] += "4";
                }


                File.WriteAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", string.Empty);

                for (int i = 0; i < 5; i++)
                {
                    File.AppendAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", tmpStringArray[i] + "\n");

                }

            }
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt");

            txtScore.Text = tmpStringArray[1];
        }

        private void DefaultSkin_Click(object sender, RoutedEventArgs e)
        {
            string message = "Ви хочете вибрати звичайний скін?";
            string title = "Robot Gerry";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt");

                tmpStringArray[2] = "0";

                File.WriteAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", string.Empty);

                File.AppendAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", tmpStringArray);
            }

            
        }
    }
}

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
using System.IO;
using System.Windows.Threading;

namespace Moon_Lighter
{
    public partial class Level10Window : Window
    {
        private const string pathToData = @"Data";

        public string[,] Map = new string[20, 20];

        int x = 0;
        int y = 0;

        int SizeWidth = 25;

        DispatcherTimer gameTimer = new DispatcherTimer();

        System.Media.SoundPlayer MusicInGame = new System.Media.SoundPlayer(Properties.Resources.MusicFor10Level);

        Rect MainHeroHitBox;

        int speed = 25; // Швидкість руху

        string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt");

        public static int score;

        public Level10Window()
        {
            InitializeComponent();
            MapСreate();
            GameSetUp();
            score = Convert.ToInt32(tmpStringArray[1]); // Кількість зібраних монет

            if (Music.MusicForGame == true)
            {
                MusicInGame.Play();
            }
        }

        Rectangle HeroPix;
        Rectangle FinishPix;
        Rectangle CoinPix;
        Rectangle Empy;
        Rectangle BreakeWall;
        Rectangle WallPix;

        private void FirstLevelGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SizeWidth = Convert.ToInt32(this.Width / 40);

            SizeObject();
        }

        private void FirstLevelGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = 1000;
        }

        /// <summary>
        /// Ініціалізація карти та всіх об'єктів на ній
        /// </summary>
        public void MapСreate()
        {
            const string pathToData = "Data";

            StreamReader SR1 = new StreamReader(pathToData + "\\Maps\\Map10.txt", Encoding.Default);
            string[] sInputFile = SR1.ReadToEnd().Split('\n');

            for (int i = 0; i < 20; i++)
            {
                string[] ArrayStr = sInputFile[i].Split(' ');
                for (int j = 0; j < 20; j++)
                {
                    Map[i, j] = ArrayStr[j];

                    if (ArrayStr[j] == "p")
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            string[] MainFile = File.ReadAllText(pathToData + "\\Maps\\Map10.txt").Split('\r');

            foreach (string tmpString in MainFile)
            {
                int i = 0;
                int j = 0;

                string[] tmpStringArray2 = tmpString.Split(' ');

                foreach (string tmpString2 in tmpStringArray2)
                {
                    if (tmpString2.TrimStart() == "1")
                    {
                        WallPix = new Rectangle();

                        WallPix.Fill = Brushes.Transparent;
                        WallPix.Stroke = Brushes.Aqua;
                        WallPix.StrokeThickness = 3;
                        WallPix.Tag = "wall";
                        WallPix.Name = "WallPix";

                        MyCanvas.Children.Add(WallPix);

                    }

                    if (tmpString2 == "0")
                    {
                        Empy = new Rectangle();

                        Empy.Tag = "Empy";

                        MyCanvas.Children.Add(Empy);
                    }

                    if (tmpString2 == "p")
                    {
                        HeroPix = new Rectangle();
                        HeroPix.Fill = Brushes.Gold;
                        HeroPix.Tag = "MainHero";

                        MyCanvas.Children.Add(HeroPix);
                    }

                    if (tmpString2 == "f")
                    {
                        FinishPix = new Rectangle();

                        FinishPix.Tag = "Finish";
                        FinishPix.Fill = Brushes.Red;

                        MyCanvas.Children.Add(FinishPix);
                    }

                    if (tmpString2 == "3")
                    {
                        CoinPix = new Rectangle();

                        CoinPix.Tag = "coin";

                        MyCanvas.Children.Add(CoinPix);
                    }

                    if (tmpString2 == "5")
                    {
                        BreakeWall = new Rectangle();

                        BreakeWall.Fill = Brushes.Red;
                        BreakeWall.Stroke = Brushes.Black;
                        BreakeWall.StrokeThickness = 3;
                        BreakeWall.Tag = "BreakWall";

                        MyCanvas.Children.Add(BreakeWall);
                    }
                    j++;
                }
                i++;
            }
            MyCanvas.KeyDown += new System.Windows.Input.KeyEventHandler(MyCanvas_KeyDown);
        }

        /// <summary>
        /// Функція для переміщення героя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MyCanvas_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                if (Map[x, y - 1] == "0" || Map[x, y - 1] == "3" || Map[x, y - 1] == "f")
                {
                    if (Map[x, y - 1] == "3")
                    {
                        CoinPix.Visibility = Visibility.Hidden;
                        score++;
                        tmpStringArray[1] = score.ToString();
                    }

                    if (Map[x, y - 1] == "f")
                    {
                        GameOver();
                    }

                    Map[x, y] = "0";
                    Map[x, y - 1] = "p";
                    y = y - 1;

                    HeroPix.RenderTransform = new RotateTransform(-180, HeroPix.Width / 2, HeroPix.Height / 2);

                    Canvas.SetLeft(HeroPix, Canvas.GetLeft(HeroPix) - speed);
                }
            }

            if (e.Key == Key.Right)
            {
                if (Map[x, y + 1] == "0" || Map[x, y + 1] == "3" || Map[x, y + 1] == "f")
                {
                    if (Map[x, y + 1] == "3")
                    {
                        CoinPix.Visibility = Visibility.Hidden;
                        score++;
                        tmpStringArray[1] = score.ToString();
                    }

                    if (Map[x, y + 1] == "f")
                    {
                        GameOver();
                    }

                    Map[x, y] = "0";
                    Map[x, y + 1] = "p";
                    y = y + 1;

                    HeroPix.RenderTransform = new RotateTransform(0, HeroPix.Width / 2, HeroPix.Height / 2);

                    Canvas.SetLeft(HeroPix, Canvas.GetLeft(HeroPix) + speed);
                }
            }

            if (e.Key == Key.Up)
            {
                if (Map[x - 1, y] == "0" || Map[x - 1, y] == "3" || Map[x - 1, y] == "f")
                {
                    if (Map[x - 1, y] == "3")
                    {
                        CoinPix.Visibility = Visibility.Hidden;
                        score++;
                        tmpStringArray[1] = score.ToString();
                    }

                    if (Map[x - 1, y] == "f")
                    {
                        GameOver();
                    }

                    Map[x, y] = "0";
                    Map[x - 1, y] = "p";
                    x = x - 1;

                    HeroPix.RenderTransform = new RotateTransform(-90, HeroPix.Width / 2, HeroPix.Height / 2);

                    Canvas.SetTop(HeroPix, Canvas.GetTop(HeroPix) - speed);
                }
            }

            if (e.Key == Key.Down)
            {
                if (Map[x + 1, y] == "0" || Map[x + 1, y] == "3" || Map[x + 1, y] == "f")
                {
                    if (Map[x + 1, y] == "3")
                    {
                        CoinPix.Visibility = Visibility.Hidden;
                        score++;
                        tmpStringArray[1] = score.ToString();
                    }

                    if (Map[x + 1, y] == "f")
                    {
                        GameOver();
                    }

                    Map[x, y] = "0";
                    Map[x + 1, y] = "p";
                    x = x + 1;

                    HeroPix.RenderTransform = new RotateTransform(90, HeroPix.Width / 2, HeroPix.Height / 2);

                    Canvas.SetTop(HeroPix, Canvas.GetTop(HeroPix) + speed);
                }
            }

            if (e.Key == Key.Escape)
            {
                MainMenuWindow mainMenuWindow = new MainMenuWindow();
                mainMenuWindow.Show();
                Close();

                MusicInGame.Stop();
                MessageBox.Show("Ви вийшли з гри");
                MainMenuWindow.MusicInGame.Play();
                return;
            }
        }

        private void GameSetUp()
        {
            MyCanvas.Focus();

            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();

            LoadSkinInGame();
        }

        /// <summary>
        /// Основна логіка гри
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameLoop(object sender, EventArgs e)
        {
            string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt");

            txtScore.Text = tmpStringArray[1].ToString(); // Накопичення монет

            MainHeroHitBox = new Rect(Canvas.GetLeft(HeroPix), Canvas.GetTop(HeroPix), HeroPix.Width, HeroPix.Height);

            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                Rect hitbox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                if ((string)x.Tag == "coin")
                {
                    ImageBrush Coin = new ImageBrush();
                    Coin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Photo/Coin.png"));

                    x.Fill = Coin;

                    if (MainHeroHitBox.IntersectsWith(hitbox) && x.Visibility == Visibility.Visible)
                    {
                        x.Visibility = Visibility.Hidden;
                        tmpStringArray[1] = score.ToString();

                        File.WriteAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", string.Empty);

                        File.AppendAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", tmpStringArray);
                    }
                }

                if ((string)x.Tag == "BreakWall")
                {
                    if (MainHeroHitBox.IntersectsWith(hitbox))
                    {
                        LossGame();
                    }
                }
            }
        }

        private void GameOver()
        {
            string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt");

            tmpStringArray[1] = score.ToString(); // Запис монет в файл

            File.WriteAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", string.Empty);

            File.AppendAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", tmpStringArray);

            gameTimer.Stop();
            MusicInGame.Stop();
            MessageBox.Show("Ви дійшли до фінішу");
            MainMenuWindow.MusicInGame.Play();

            tmpStringArray[4] += "10"; // Запис 10 як пройденого рівня в файл для перевірки на пройденість

            File.WriteAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", string.Empty);

            for (int i = 0; i < 5; i++)
            {
                File.AppendAllText(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt", tmpStringArray[i] + "\n");
            }

            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            Close();
        }

        private void LossGame()
        {
            gameTimer.Stop();
            MusicInGame.Stop();
            MessageBox.Show("Ви програли");
            MainMenuWindow.MusicInGame.Play();

            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            Close();
        }

        /// <summary>
        /// Функція для адаптивності ігрового поля
        /// </summary>
        private void SizeObject()
        {
            int i = 0;
            int j = 0;

            foreach (var v in MyCanvas.Children.OfType<Rectangle>())
            {

                if ((string)v.Tag == "Finish")
                {
                    v.Width = SizeWidth;
                    v.Height = SizeWidth;

                    Canvas.SetLeft(v, j * SizeWidth / 5 * 5);
                    Canvas.SetTop(v, i * SizeWidth / 5 * 5);
                }

                if ((string)v.Tag == "BreakWall")
                {
                    v.Width = SizeWidth;
                    v.Height = SizeWidth;

                    Canvas.SetLeft(v, j * SizeWidth / 5 * 5);
                    Canvas.SetTop(v, i * SizeWidth / 5 * 5);
                }

                if ((string)v.Tag == "MainHero")
                {
                    StreamReader SR1 = new StreamReader(pathToData + "\\Maps\\Map10.txt", Encoding.Default);
                    string[] sInputFile = SR1.ReadToEnd().Split('\n');

                    for (int b = 0; b < 20; b++)
                    {
                        string[] ArrayStr = sInputFile[b].Split(' ');
                        for (int n = 0; n < 20; n++)
                        {
                            Map[b, n] = ArrayStr[n];

                            if (ArrayStr[n] == "p")
                            {
                                x = 10;
                                y = 8;
                            }
                        }
                    }

                    v.Width = SizeWidth / 5 * 3;
                    v.Height = SizeWidth / 5 * 3;

                    Canvas.SetLeft(v, j * SizeWidth / 5 * 5.2);
                    Canvas.SetTop(v, i * SizeWidth / 5 * 5);
                }

                if ((string)v.Tag == "coin")
                {
                    v.Width = SizeWidth;
                    v.Height = SizeWidth;

                    Canvas.SetLeft(v, j * SizeWidth / 5 * 5);
                    Canvas.SetTop(v, i * SizeWidth / 5 * 5);
                }

                if ((string)v.Tag == "wall")
                {
                    v.Width = SizeWidth;
                    v.Height = SizeWidth;

                    Canvas.SetLeft(v, j * SizeWidth / 5 * 5);
                    Canvas.SetTop(v, i * SizeWidth / 5 * 5);
                }

                j++;
                if (j == 20)
                {
                    i++;
                    j = 0;
                }
            }
        }

        /// <summary>
        /// Функція для підгрузки скінів в гру
        /// </summary>
        private void LoadSkinInGame()
        {
            string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + AuthorizationWindow.UserName + "\\" + "Info.txt");

            if (tmpStringArray[2] == "0")
            {
                ImageBrush myHeroImage = new ImageBrush();
                myHeroImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Photo/Hero.png")); // Ініціалізація картинки героя
                HeroPix.Width = 17;
                HeroPix.Height = 17;
                HeroPix.Fill = myHeroImage; // Встроєння картинки головного героя в гру
            }

            if (tmpStringArray[2] == "1")
            {
                ImageBrush myHeroImage = new ImageBrush();
                myHeroImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Photo/Hero2.png")); // Ініціалізація картинки героя
                HeroPix.Width = SizeWidth / 5 * 5;
                HeroPix.Height = SizeWidth / 5 * 5;
                HeroPix.Fill = myHeroImage; // Встроєння картинки головного героя в гру
            }

            if (tmpStringArray[2] == "2")
            {
                ImageBrush myHeroImage = new ImageBrush();
                myHeroImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Photo/Hero3.png")); // Ініціалізація картинки героя
                HeroPix.Width = SizeWidth / 5 * 7;
                HeroPix.Height = SizeWidth / 5 * 7;
                HeroPix.Fill = myHeroImage; // Встроєння картинки головного героя в гру
            }

            if (tmpStringArray[2] == "3")
            {
                ImageBrush myHeroImage = new ImageBrush();
                myHeroImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Photo/Hero4.png")); // Ініціалізація картинки героя
                HeroPix.Width = SizeWidth / 5 * 8;
                HeroPix.Height = SizeWidth / 5 * 8;
                HeroPix.Fill = myHeroImage; // Встроєння картинки головного героя в гру
            }

            if (tmpStringArray[2] == "4")
            {
                ImageBrush myHeroImage = new ImageBrush();
                myHeroImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Photo/Hero5.png")); // Ініціалізація картинки героя
                HeroPix.Width = SizeWidth / 5 * 5;
                HeroPix.Height = SizeWidth / 5 * 6;
                HeroPix.Fill = myHeroImage; // Встроєння картинки головного героя в гру
            }

            ImageBrush Finishing = new ImageBrush();
            Finishing.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Photo/Exit.png"));
            FinishPix.Fill = Finishing;
        }
    }
}

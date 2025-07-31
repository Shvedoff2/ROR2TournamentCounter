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
using System.IO;
using System.Windows.Threading;
using WpfAnimatedGif;
using System.Windows.Media.Animation;

namespace ROR2TournamentCounter
{
    public partial class MainWindow : Window
    {
        private const double BaseFontSize = 50;
        private const int BaseCharLimit = 8;
        public MainWindow()
        {
            InitializeComponent();
            Survivor.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation moveMaskAnimation = new DoubleAnimation
            {
                From = 0,
                To = 2460,
                Duration = TimeSpan.FromSeconds(15000),
                RepeatBehavior = RepeatBehavior.Forever,
                AutoReverse = false
            };

            MaskTranslateTransform.BeginAnimation(TranslateTransform.XProperty, moveMaskAnimation);
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Navigation_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Nickname1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Nickname1Player.Text = Nickname1.Text;
        }

        private void Nickname2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Nickname2Player.Text = Nickname2.Text;
        }

        private void TournamentName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TournamentNameTB.Text = TournamentName.Text;
        }

        private void Seed_TextChanged(object sender, TextChangedEventArgs e)
        {
            SeedTB.Text = $"Сид:{Seed.Text}";
        }

        private void DecrementButton1_Click(object sender, RoutedEventArgs e)
        {
            int currentValue = int.Parse(Count1.Text);
            if (currentValue > 0)
            {
                Count1.Text = (currentValue - 1).ToString();
            }
        }

        private void IncrementButton1_Click(object sender, RoutedEventArgs e)
        {
            int currentValue = int.Parse(Count1.Text);
            if (currentValue < 5)
            {
                Count1.Text = (currentValue + 1).ToString();
            }
        }

        private void DecrementButton2_Click(object sender, RoutedEventArgs e)
        {
            int currentValue = int.Parse(Count2.Text);
            if (currentValue > 0)
            {
                Count2.Text = (currentValue - 1).ToString();
            }
        }

        private void IncrementButton2_Click(object sender, RoutedEventArgs e)
        {
            int currentValue = int.Parse(Count2.Text);
            if (currentValue < 5)
            {
                Count2.Text = (currentValue + 1).ToString();
            }
        }

        private void Count1_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountPlayer1.Text = Count1.Text;
        }

        private void Count2_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountPlayer2.Text = Count2.Text;
        }

        private void Nickname1Player_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            int textLength = textBox.Text.Length;

            if (textLength <= BaseCharLimit)
            {
                textBox.FontSize = BaseFontSize;
            }
            else
            {
                double scaleFactor = (double)BaseCharLimit / textLength;
                double newFontSize = BaseFontSize * scaleFactor;
                textBox.FontSize = Math.Max(newFontSize, 27);
            }
        }

        private void Nickname2Player_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            int textLength = textBox.Text.Length;

            if (textLength <= BaseCharLimit)
            {
                textBox.FontSize = BaseFontSize;
            }
            else
            {
                double scaleFactor = (double)BaseCharLimit / textLength;
                double newFontSize = BaseFontSize * scaleFactor;
                textBox.FontSize = Math.Max(newFontSize, 27);
            }
        }

        private void Survivor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox?.SelectedItem == null) return;

            string selectedSurvivor = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            System.Windows.Media.Color survivorColor = Colors.Gray;

            switch (selectedSurvivor)
            {
                case "Acrid":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Acrid.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#962e7b");
                    break;
                case "Artificer":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Artificer.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#ffffff");
                    break;
                case "Bandit":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Bandit.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#29d7d6");
                    break;
                case "Captain":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Captain.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#213c73");
                    break;
                case "CHEF":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/CHEF.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#94a3e7");
                    break;
                case "Commando":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Commando.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#e7b44a");
                    break;
                case "Engineer":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Engineer.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#650ee9");
                    break;
                case "False Son":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/False_Son.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#7c73b2");
                    break;
                case "Heretic":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Heretic.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#7b0008");
                    break;
                case "Huntress":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Huntress.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#d61d63");
                    break;
                case "Loader":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Loader.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#035ac6");
                    break;
                case "Mercenary":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Mercenary.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#00ecf8");
                    break;
                case "MUL-T":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/MUL-T.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#d8d984");
                    break;
                case "Railgunner":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Railgunner.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#63569d");
                    break;
                case "REX":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/REX.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#a5ff21");
                    break;
                case "Seeker":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Seeker.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#54c3ad");
                    break;
                case "Void Fiend":
                    SurvivorPic.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Void_Fiend.png"));
                    survivorColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#ca4add");
                    break;
                default:
                    SurvivorPic.Source = null;
                    survivorColor = Colors.Gray;
                    break;
            }
            // Применяем цвет к рамке
            SurvivorRect.Stroke = new SolidColorBrush(survivorColor);
            SurvivorPolygonMask.Fill = new SolidColorBrush(survivorColor);
        }
    }

}
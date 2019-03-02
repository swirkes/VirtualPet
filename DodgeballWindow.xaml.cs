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
using System.Windows.Threading;
using Tamagotchis;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//Image i = new Image();
//in Main Window: i.Source = new BitmapImage();


namespace Dodgeball
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Games.Game game = new Games.Game();
        private DispatcherTimer dispatcherTimer;
        private Random random = new Random();

        private Uri ImageUri = new Uri("Resources/Memetchi.png", UriKind.Relative);
        public Image TamagotchiImage = new Image();

        private bool[] visualMoves = new bool[9];
        private List<Button> buttons = new List<Button>();

        public int points;
        public int misses;

        public Tamagotchis.Tamagotchi t;
        //private string fileName = @"C:\Users\swirk\source\repos\TamagotchiUserInterface\bin\Debug\Dodgeball.dat";
        private string fileName = @"../../TamagotchiUserInterface\bin\Debug\Dodgeball.dat";





        public MainWindow()
        {
            InitializeComponent();

            if (!File.Exists(fileName))
            {
                game.Init();
            } else
            {
                Stream stream = File.Open("Dodgeball.dat", FileMode.Open);

                BinaryFormatter bf = new BinaryFormatter();

                game = (Games.Game)bf.Deserialize(stream);

                stream.Close();
            }
            
            
            DataContext = this;
            //DispatcherTimer settings and Dispatcher start
            dispatcherTimer = new DispatcherTimer();
            //adding event
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1500);
            dispatcherTimer.Start();
            buttons.AddRange(new[] { SquareZero, SquareOne, SquareTwo, SquareThree, SquareFour, SquareFive,
            SquareSix, SquareSeven, SquareEight});
            TamagotchiImage.Source = new BitmapImage(ImageUri);
            MissesText.Text = "Misses: " + game.Misses;
            HitsText.Text = "Hits: " + game.Points;


        }

        
        private void Dodgeball_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Stream stream = File.Open("Dodgeball.dat", FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, game);

            stream.Close();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            int n = game.Move();
            foreach (Button btn in buttons)
            {
                btn.Content = "";
            }
            buttons[n].Content = TamagotchiImage;
            CommandManager.InvalidateRequerySuggested();
        }
        
        

        private void SquareZero_Click(object sender, RoutedEventArgs e)
        {

            Update(1);

        }

        private void SquareOne_Click(object sender, RoutedEventArgs e)
        {

            Update(2);

        }

        private void SquareTwo_Click(object sender, RoutedEventArgs e)
        {

            Update(3);


        }

        private void SquareThree_Click(object sender, RoutedEventArgs e)
        {
            Update(4);


        }

        private void SquareFour_Click(object sender, RoutedEventArgs e)
        {
            Update(5);



        }

        private void SquareFive_Click(object sender, RoutedEventArgs e)
        {

            Update(6);

        }

        private void SquareSix_Click(object sender, RoutedEventArgs e)
        {

            Update(7);

        }

        private void SquareSeven_Click(object sender, RoutedEventArgs e)
        {

            Update(8);

        }

        private void SquareEight_Click(object sender, RoutedEventArgs e)
        {
            Update(9);


        }

        private void Update(int square)
        {
            game.IsHit(square);

            if(game.Points % 10 == 0 && game.Points != 0)
            {
                t.AddHappiness(1);
                dispatcherTimer.Interval.Subtract(new TimeSpan(0, 0, 0, 0, 50));
            }

            if (game.IsReady())
            {
                MissesText.Text = "Misses: " + game.Misses;
                MessageBox.Show("Game Over!");
                t.AddHappiness(-10);
                this.Close();
                game.Init();
            }

            MissesText.Text = "Misses: " + game.Misses;
            HitsText.Text = "Hits: " + game.Points;

        }
    }
}

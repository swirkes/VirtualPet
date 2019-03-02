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
using Pets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace TamagotchiUserInterface
{
    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Tamagotchi> tamagotchis = new List<Tamagotchi>();
        public List<Image> tamagotchiImages = new List<Image>();
        public List<Button> tamagotchiButtons = new List<Button>();
        public Tamagotchi windowTamagotchi;
        private DispatcherTimer dispatcherTimer;
        private Random random = new Random();
        private int tick;
        private int feedCount1;
        private int feedCount2;
        private int feedCount3;
        private bool isSleeping1;
        private bool isSleeping2;
        private bool isSleeping3;
        private int sleepClick1;
        private int sleepClick2;
        private int sleepClick3;
        //private string fileName = @"C:\Users\swirk\source\repos\TamagotchiUserInterface\bin\Debug\tamagotchi2.dat";
        private string fileName = @"../../TamagotchiUserInterface\bin\Debug\tamagotchi2.dat";
        public MainWindow()
        {

            
            InitializeComponent();
            if (!File.Exists(fileName))
            {
                for (int i = 1; i <= 3; i++)
                {
                    tamagotchis.Add(new Dino("Tamagotchi" + i.ToString()));
                    tamagotchis[i - 1].Pace = random.Next(50, 500);
                }
            } else
            {
                Stream stream = File.Open("Tamagotchi2.dat", FileMode.Open);

                BinaryFormatter bf = new BinaryFormatter();

                tamagotchis = (List<Tamagotchi>)bf.Deserialize(stream);

                stream.Close();
            }

            SetImage();
            SetButton();
            
            //DispatcherTimer settings and Dispatcher start
            dispatcherTimer = new DispatcherTimer();
            //adding event
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);

            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            dispatcherTimer.Start();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Stream stream = File.Open("Tamagotchi2.dat", FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, tamagotchis);

            stream.Close();

        }

        

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            tick++;
            UpdateLabels();
            IsDead();

            if (tamagotchis[0].Act(tick))
            {
                if (tamagotchis[0].HappinessIndex > 0)
                {
                    if (tamagotchis[0].IsHungry && !isSleeping1)
                    {
                        Tamagotchi1btn.Content = FindResource("T1Hungry");
                        tamagotchis[0].AddHappiness(-1);
                    }
                    else if (tamagotchis[0].IsSleepy && !isSleeping1)
                    {
                        MessageBox.Show("T1 is Sleepy!");
                    }
                } else if (tamagotchis[0].HappinessIndex <= 0)
                {
                    Tamagotchi1btn.Content = FindResource("T1Dead");
                }

            }

            if (tamagotchis[1].Act(tick))
            {
                if (tamagotchis[1].HappinessIndex > 0)
                {
                    if (tamagotchis[1].IsHungry && !isSleeping2)
                    {
                        Tamagotchi2btn.Content = FindResource("T2Hungry");
                        tamagotchis[1].AddHappiness(-1);
                    }
                    else if (tamagotchis[1].IsSleepy && !isSleeping2)
                    {
                        MessageBox.Show("T2 is Sleepy!");
                    }
                }
                else if (tamagotchis[1].HappinessIndex <= 0)
                {
                    Tamagotchi2btn.Content = FindResource("T2Dead");
                }
            }

                if (tamagotchis[2].Act(tick))
                {

                    if (tamagotchis[2].HappinessIndex > 0)
                    {
                        if (tamagotchis[2].IsHungry && !isSleeping3)
                        {
                            Tamagotchi3btn.Content = FindResource("T3Hungry");
                            tamagotchis[2].AddHappiness(-1);
                        } else if (tamagotchis[2].IsSleepy && !isSleeping3)
                        {
                            MessageBox.Show("T3 is Sleepy!");
                        }
                    } else if (tamagotchis[2].HappinessIndex <= 0)
                    {
                        Tamagotchi3btn.Content = FindResource("T3Dead");
                    }
                }
            }

        private void SetButton()
        {
            tamagotchiButtons.Add(Tamagotchi1btn);
            tamagotchiButtons.Add(Tamagotchi2btn);
            tamagotchiButtons.Add(Tamagotchi3btn);

        }

        private void SetImage()
        {

            tamagotchiImages.Clear();
            for (int i = 1; i <= 3; i++)
            {


                tamagotchiImages.Add(new Image());

                Uri ImageUri = new Uri("Tamagotchi" + i.ToString() + ".png", UriKind.Relative);
                tamagotchiImages[i - 1].Source = new BitmapImage(ImageUri);



            }
            Tamagotchi1btn.Content = FindResource("T1Normal");
            Tamagotchi2btn.Content = FindResource("T2Normal");
            Tamagotchi3btn.Content = FindResource("T3Normal");
        }

        

        private void Tamagotchi1_Click(object sender, RoutedEventArgs e)
        {
            if(tamagotchis[0].HappinessIndex > 0)
            {
                if (!isSleeping1)
                {
                    if (tamagotchis[0].IsSleepy)
                    {
                        MessageBox.Show("I'm too tired to play.");
                    } else if (Tamagotchi1btn.Content.ToString() == "T1Hungry")
                    {
                        MessageBox.Show("FEED ME!!!");
                    } else 
                    {
                        ShowDodgeball(0);
                    }
                    
                }
                
            }
            
        }

        private void Tamagotchi2_Click(object sender, RoutedEventArgs e)
        {
            if (!isSleeping2)
            {
                if (tamagotchis[1].IsSleepy)
                {
                    MessageBox.Show("I'm too tired to play.");
                } else if (Tamagotchi2btn.Content.ToString() == "T2Hungry")
                {
                    MessageBox.Show("FEED ME!!!");
                } else
                {
                    ShowDodgeball(1);
                }
                
            }
            
        }

        private void Tamagotchi3_Click(object sender, RoutedEventArgs e)
        {
            if (!isSleeping3)
            {
                if (tamagotchis[2].IsSleepy)
                {
                    MessageBox.Show("I'm too tired to play.");
                } else if (Tamagotchi3btn.Content.ToString() == "T3Hungry")
                {
                    MessageBox.Show("FEED ME!!!");
                } else
                {
                    ShowDodgeball(2);
                }
                
            }
            
        }
        private void ShowDodgeball(int num)
        {
            Dodgeball.MainWindow window = new Dodgeball.MainWindow();
            window.Owner = this;

            window.TamagotchiImage = tamagotchiImages[num];
            window.t = tamagotchis[num];


            window.ShowDialog();
            //window.Closed += On_Game_Window_Closed;
            SetImage();
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            lblHappiness1.Content = "Happiness Index: " + tamagotchis[0].HappinessIndex;
            lblHappiness2.Content = "Happiness Index: " + tamagotchis[1].HappinessIndex;
            lblHappiness3.Content = "Happiness Index: " + tamagotchis[2].HappinessIndex;
            
        }

        private void IsDead()
        {
            for (int i = 0; i < 3; i++)
            {
                if (tamagotchis[i].HappinessIndex <= 0)
                {
                    tamagotchiButtons[i].Content = FindResource($"T" + (i + 1) + "Dead");
                }
            }
            
        }

        
        private void Feed1_Click(object sender, RoutedEventArgs e)
        {
            feedCount1++;
            if (tamagotchis[0].HappinessIndex > 0)
            {
                if (!isSleeping1)
                {
                    if (feedCount1 <= 3)
                    {
                        tamagotchis[0].Eat();
                    }
                    else
                    {
                        MessageBox.Show("I'm Not Hungry Anymore!");
                        Tamagotchi1btn.Content = FindResource("T1Normal");
                        feedCount1 = 0;
                    }
                    UpdateLabels();
                }
            } 
            UpdateLabels();
        }
        
        private void Sleep1_Click(object sender, RoutedEventArgs e)
        {
            
            if (tamagotchis[0].HappinessIndex > 0)
            {
                sleepClick1++;
                if (sleepClick1 % 2 != 0)
                {
                    isSleeping1 = true;
                    tamagotchis[0].Sleep();
                    Tamagotchi1btn.Content = FindResource("T1Sleep");
                    Sleep1.Content = "Take Pillow";
                    UpdateLabels();
                } else
                {
                    isSleeping1 = false;
                    if(tamagotchis[0].HappinessIndex > 0)
                    {
                        Tamagotchi1btn.Content = FindResource("T1Normal");
                    }
                    
                    Sleep1.Content = "Give Pillow";
                    UpdateLabels();
                } 
                
            }
            
        }

        
        private void Feed2_Click(object sender, RoutedEventArgs e)
        {
            feedCount2++;
            if (tamagotchis[1].HappinessIndex > 0)
            {
                if (!isSleeping2)
                {
                    if (feedCount2 <= 3)
                    {
                        tamagotchis[1].Eat();
                    }
                    else
                    {
                        MessageBox.Show("I'm Not Hungry Anymore!");
                        Tamagotchi2btn.Content = FindResource("T2Normal");
                        feedCount2 = 0;
                    }
                    UpdateLabels();
                }
            }

            UpdateLabels();
        }

        private void Sleep2_Click(object sender, RoutedEventArgs e)
        {
            if (tamagotchis[1].HappinessIndex > 0)
            {
                sleepClick2++;
                if (sleepClick2 % 2 != 0)
                {
                    isSleeping2 = true;
                    tamagotchis[1].Sleep();
                    Tamagotchi2btn.Content = FindResource("T2Sleep");
                    Sleep2.Content = "Take Pillow";
                    UpdateLabels();
                }
                else
                {
                    isSleeping2 = false;
                    if (tamagotchis[1].HappinessIndex > 0)
                    {
                        Tamagotchi2btn.Content = FindResource("T2Normal");
                    }

                    Sleep2.Content = "Give Pillow";
                    UpdateLabels();
                }

            }
        }

        
        private void Feed3_Click(object sender, RoutedEventArgs e)
        {
            feedCount3++;
            if (tamagotchis[2].HappinessIndex > 0)
            {
                if (!isSleeping3)
                {
                    if (feedCount3 <= 3)
                    {
                        tamagotchis[2].Eat();
                    }
                    else
                    {
                        MessageBox.Show("I'm Not Hungry Anymore!");
                        Tamagotchi3btn.Content = FindResource("T3Normal");
                        feedCount3 = 0;
                    }
                    UpdateLabels();
                }
            }

            UpdateLabels();
        }

        private void Sleep3_Click(object sender, RoutedEventArgs e)
        {
            if (tamagotchis[2].HappinessIndex > 0)
            {
                sleepClick3++;
                if (sleepClick3 % 2 != 0)
                {
                    isSleeping3 = true;
                    tamagotchis[2].Sleep();
                    Tamagotchi3btn.Content = FindResource("T3Sleep");
                    Sleep3.Content = "Take Pillow!";
                    UpdateLabels();
                }
                else
                {
                    isSleeping3 = false;
                    if (tamagotchis[2].HappinessIndex > 0)
                    {
                        Tamagotchi3btn.Content = FindResource("T3Normal");
                    }

                    Sleep3.Content = "Give Pillow";
                    UpdateLabels();
                }

            }
        }

       

        
    }
}

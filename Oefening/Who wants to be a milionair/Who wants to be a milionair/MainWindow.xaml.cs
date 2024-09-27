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

namespace Who_wants_to_be_a_milionair
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        string[,] vragen = new string[,]
{
            { "100", "In the UK, the abbreviation NHS stands for National what Service?", "Humanity", "Health", "Honour", "Household", "2" },
            { "200", "Which Disney character famously leaves a glass slipper behind at a royal ball?", "Pocahontas", "Sleeping Beauty", "Cinderella", "Elsa", "3" },
            { "300", "What name is given to the revolving belt machinery in an airport that delivers checked luggage from the plane to baggage reclaim?", "Hangar", "Terminal", "Concourse", "Carousel", "4" },
            { "500", "Which of these brands was chiefly associated with the manufacture of household locks?" , "Phillips", "Flymo", "Chubb", "Ronseal", "3" },
            { "1000", "The hammer and sickle is one of the most recognisable symbols of which political ideology?", "Republicanism", "Communism", "Conservatism", "Liberalism", "2" },
            { "2000", "Which toys have been marketed with the phrase 'robots in disguise'?", "Bratz Dolls", "Sylvanian Families", "Hatchimals", "Transformers" , "4" },
            { "4000", "What does the word loquacious mean?", "Angry", "Chatty", "Beautiful", "Shy", "2" },
            { "8000", "Obstetrics is a branch of medicine particularly concerned with what?", "Childbirth", "Broken bones", "Heart conditions", "Old age", "1" },
            { "16000", "In Doctor Who, what was the signature look of the fourth Doctor, as portrayed by Tom Baker?", "Bow-tie, braces and tweed jacket", "Wide-brimmed hat and extra long scarf", "Pinstripe suit and trainers", "Cape, velvet jacket and frilly shirt", "2" },
            { "32000", "Which of these religious observances lasts for the shortest period of time during the calendar year?", "Ramadan", "Diwali", "Lent", "Hanukkah", "2" },
            { "64000", "At the closest point, which island group is only 50 miles south-east of the coast of Florida?", "Bahamas", "US Virgin Islands", "Turks and Caicos Islands", "Bermuda", "1"},
            { "125000", "Construction of which of these famous landmarks was completed first?" , "Empire State Building", "Royal Albert Hall", "Eiffel Tower", "Big Ben Clock Tower", "4" },
            { "250000", "Which of these cetaceans is classified as a 'toothed whale'?", "Gray whale", "Minke whale", "Sperm whale", "Humpback whale", "3" },
            { "500000", "Who is the only British politician to have held all four 'Great Offices of State' at some point during their career?" , "David Lloyd George", "Harold Wilson", "James Callaghan", "John Major", "3" },
            { "1 million", "In 1718, which pirate died in battle off the coast of what is now North Carolina?" , "Calico Jack", "Blackbeard", "Bartholomew Roberts", "Captain Kidd", "2" }
};
        private DispatcherTimer klok = new DispatcherTimer();
        StringBuilder sbVragen = new StringBuilder();
        int levelUP;
        int som;
        string antwoord;
        StringBuilder bonus = new StringBuilder();
        List<CheckBox> gebruikteChekcboxen = new List<CheckBox>();
        List<RadioButton> radioButtons = new List<RadioButton>();
        List<CheckBox> checkBoxes = new List<CheckBox>();
        string message;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            klok.Tick += new EventHandler(KlokAfgelopen);
            klok.Interval = new TimeSpan(0, 0, 1);
            klok.Start();
            ShowTime();

            //initialiseren radiobuttons
            foreach (var child in spRechtsOnder.Children)
            {
                if (child is RadioButton)
                {
                    radioButtons.Add((RadioButton)child);
                }
            }

            //initialiseren checkboxen
            foreach (var child in spLinksOnder.Children)
            {
                if (child is CheckBox)
                {
                    checkBoxes.Add((CheckBox)child);
                }
            }


            DeVragen();
        }



        private void KlokAfgelopen(object sender, EventArgs e)
        {
            if (cbTijd.SelectedIndex == 1)
            {
                lbDeTijd.Content = DateTime.Now.ToShortDateString();
            }
            else if (cbTijd.SelectedIndex == 2)
            {
                lbDeTijd.Content = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToShortDateString();
            }
            else
                ShowTime();
        }

        private void ShowTime()
        {
            lbDeTijd.Content = DateTime.Now.ToLongTimeString();
        }

        private void DeVragen()
        {
            //eerste vraag
            sbVragen.Append(vragen[levelUP, 1]);
            txtVragen.TextWrapping = TextWrapping.Wrap;
            txtVragen.Text = Convert.ToString(sbVragen);





            //eerste antwoorden
            for (int i = 0; i < radioButtons.Count; i++)
            {
                radioButtons[i].Content = vragen[levelUP, i + 2];
            }


            ////eerste antwoorden
            //rbEerste.Content = vragen[levelUP, 2];
            //rbTweede.Content = vragen[levelUP, 3];
            //rbDerde.Content = vragen[levelUP, 4];
            //rbVierde.Content = vragen[levelUP, 5];



        }

        private void FinalAnswer(object sender, RoutedEventArgs e)
        {
            bonus.Clear();
            lbAntwoorden.Items.Clear();




            foreach (var checkbox in checkBoxes)
            {
                if (checkbox.IsChecked == true)
                {
                    gebruikteChekcboxen.Add(checkbox);
                }
            }


            ////checkboxen
            //if (ckbEen.IsChecked == true)
            //{
            //    gebruikteChekcboxen.Add("ckbEen");
            //}
            //if (ckbTwee.IsChecked == true)
            //{
            //    gebruikteChekcboxen.Add("ckbTwee");
            //}
            //if (ckbDrie.IsChecked == true)
            //{
            //    gebruikteChekcboxen.Add("ckbDrie");
            //}




            int arrayIndex = Convert.ToInt32(vragen[levelUP, 6]);
            string correctAntwoord = vragen[levelUP, 1 + arrayIndex];

            if (correctAntwoord == antwoord)
            {
                foreach (var radio in radioButtons)
                {
                    radio.IsChecked= false;
                }

                //rbEerste.IsChecked = false;
                //rbTweede.IsChecked = false;
                //rbDerde.IsChecked = false;
                //rbVierde.IsChecked = false;

                LevelUp();
            }

            else
            {
                MessageBox.Show("Je bent verloren", "Fout antwoord");
                Verloren();
            }
        }

        private void LevelUp()
        {
            foreach(var checkbox in checkBoxes)
            {
                if (gebruikteChekcboxen.Contains(checkbox) == true)
                {
                    checkbox.IsChecked = false;
                    checkbox.IsEnabled = false;
                }
                else checkbox.IsEnabled = true;
            }

            //if (gebruikteChekcboxen.Contains(ckbEen.Name) == true)
            //{
            //    ckbEen.IsEnabled = false;
            //    ckbEen.IsChecked = false;
            //}
            //else
            //    ckbEen.IsEnabled = true;

            //if (gebruikteChekcboxen.Contains(ckbTwee.Name) == true)
            //{
            //    ckbTwee.IsEnabled = false;
            //    ckbTwee.IsChecked = false;
            //}
            //else
            //    ckbTwee.IsEnabled = true;

            //if (gebruikteChekcboxen.Contains(ckbDrie.Name) == true)
            //{
            //    ckbDrie.IsEnabled = false;
            //    ckbDrie.IsChecked = false;
            //}
            //else
            //    ckbDrie.IsEnabled = true;


            //level up
            if (levelUP != 14)
            {
                //verhoog som
                som += Convert.ToInt32(vragen[levelUP, 0]); ;

                //schrijf som
                txtBedrag.Text = Convert.ToString(som);

                //haal content van radio button op
                levelUP++;
                sbVragen.Clear();
                DeVragen();
            }
            else
                Gewonnen();
        }

        private void Verloren()
        {
            gridInhoud.Background = Brushes.Red;
            txtBedrag.Text = "FOUT ANTWOORD";
            message = "Helaas, je bent al het geld kwijt";
            StandVanZaken(message);
            spRechtsOnder.IsEnabled = false;
            spRechtsBoven.IsEnabled = false;
            spLinksBoven.IsEnabled = false;
            spLinksOnder.IsEnabled = false;
        }

        private void Gewonnen()
        {
            gridInhoud.Background = Brushes.Green;
            txtBedrag.Text = "1,000,000 gewonnen";
            message = "Proficiat je bent een miljonair!";
            StandVanZaken(message);
            spRechtsOnder.IsEnabled = false;
            spRechtsBoven.IsEnabled = false;
            spLinksBoven.IsEnabled = false;
            spLinksOnder.IsEnabled = false;
        }

        private void TijdFormaat(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StandVanZaken(object sender)
        {
            StringBuilder sbResultaat= new StringBuilder();
            for (int i = 0; i < message.Length+2; i++)
            {
                sbResultaat.Append("$");
            }

            sbResultaat.Append("\n" + $"${message}$" + "\n");

            for (int i = 0; i < message.Length+2; i++)
            {
                sbResultaat.Append("$");
            }


            txtVragen.Text = sbResultaat.ToString();
        }

        private void RadioButtonSelection(object sender, RoutedEventArgs e)
        {
            foreach(var radio in radioButtons)
            {
                if (radio.IsChecked == true)
                {
                    antwoord = Convert.ToString(radio.Content);
                }

            }

            //if (rbEerste.IsChecked == true)
            //{
            //    antwoord = Convert.ToString(rbEerste.Content);
            //}

            //if (rbTweede.IsChecked == true)
            //{
            //    antwoord = Convert.ToString(rbTweede.Content);
            //}

            //if (rbDerde.IsChecked == true)
            //{
            //    antwoord = Convert.ToString(rbDerde.Content);
            //}

            //if (rbVierde.IsChecked == true)
            //{
            //    antwoord = Convert.ToString(rbVierde.Content);
            //}
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var checkbox in checkBoxes)
            {
                if (checkbox.IsChecked == true)
                {
                    foreach (var cb2 in checkBoxes)
                    {
                        if (cb2 != checkbox)
                        {
                            cb2.IsEnabled = false;
                        }
                    }
                    break;
                }
            }


            //if (ckbEen.IsChecked == true)
            //{
            //    ckbTwee.IsEnabled = false;
            //    ckbDrie.IsEnabled = false;
            //}

            //if (ckbTwee.IsChecked == true)
            //{
            //    ckbEen.IsEnabled = false;
            //    ckbDrie.IsEnabled = false;
            //}

            //if (ckbDrie.IsChecked == true)
            //{
            //    ckbEen.IsEnabled = false;
            //    ckbTwee.IsEnabled = false;
            //}



            Random willekeurig = new Random();
            int bonusAntwoord1 = willekeurig.Next(1, 4);
            int bonusAntwoord2 = willekeurig.Next(1, 4);

            while (bonusAntwoord1 == Convert.ToInt32(vragen[levelUP, 6]))
            {
                bonusAntwoord1 = willekeurig.Next(1, 4);
            }

            while ((bonusAntwoord2 == Convert.ToInt32(vragen[levelUP, 6])) || (bonusAntwoord2 == bonusAntwoord1))
            {
                bonusAntwoord2 = willekeurig.Next(1, 4);
            }

            bonus.Append($"Bonus voor {vragen[levelUP, 0]}: {vragen[levelUP, bonusAntwoord1 +1]} {vragen[levelUP, bonusAntwoord2 +1]}");
            lbAntwoorden.Items.Add(bonus);

        }
    }
}

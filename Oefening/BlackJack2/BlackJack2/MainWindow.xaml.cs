using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BlackJack
{
    /// <summary>
    /// 19/12/2022
    /// Jasper Orens
    /// Beschrijving: BlackJack spel. 
    /// </summary>
    /// 


    //berekening maken en geef getallen mee Method(meegeven, meegeven;
    //private int (meegeven, meegeven) return uitkomst;

    


    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        StringBuilder handBuilderPlayer = new StringBuilder();
        StringBuilder handBuilderBank = new StringBuilder();
        int scoreSpeler;
        int scoreBank;
        int verborgenKaardWaarde;
        int gekozenKaart;
        List<string> standaardDeckList = new List<string>{
            "Diamonds 1", "Hearts 1", "Clover 1", "Spades 1",
            "Diamonds 2", "Hearts 2", "Clover 2", "Spades 2",
            "Diamonds 3", "Hearts 3", "Clover 3", "Spades 3",
            "Diamonds 4", "Hearts 4", "Clover 4", "Spades 4",
            "Diamonds 5", "Hearts 5", "Clover 5", "Spades 5",
            "Diamonds 6", "Hearts 6", "Clover 6", "Spades 6",
            "Diamonds 7", "Hearts 7", "Clover 7", "Spades 7",
            "Diamonds 8", "Hearts 8", "Clover 8", "Spades 8",
            "Diamonds 9", "Hearts 9", "Clover 9", "Spades 9",
            "Diamonds 10", "Hearts 10", "Clover 10", "Spades 10",
            "Diamonds Jack", "Hearts Jack", "Clover Jack", "Spades Jack",
            "Diamonds Queen", "Hearts Queen", "Clover Queen", "Spades Queen",
            "Diamonds King", "Hearts King", "Clover King", "Spades King",};
        List<int> gebruikteKaartenLijst = new List<int> { };
        List<int> kaartenOpTafel = new List<int>();
        List<int> historiekHand = new List<int>();
        List<string> historiekLijst = new List<string>();
        int KaardWaarde;
        bool speelBeurt;
        bool eersteKaart;
        string verborgenKaart;
        int teller;
        int kapitaal;
        int inzet;
        int counter;
        Image kaart1 = new Image();
        Image kaart2 = new Image();
        Image kaart3 = new Image();
        Image kaart4 = new Image();
        Image kaart5 = new Image();
        int eersteKaartImage;
        int tweedeKaartImage;
        int derdeKaartImage;
        int vierdeKaartImage;
        int vijfdeKaartImage;
        int overloadAceSpeler;
        int overloadAceBank;
        int resterendeKaarten;
        private DispatcherTimer klok = new DispatcherTimer();
        bool doublePlayed = false;
        System.Media.SoundPlayer clickSound = new System.Media.SoundPlayer($@"..\..\click.wav");
        MediaPlayer muziek = new MediaPlayer();
        string wieWint;
        string laatsteHand;
        bool isgedraaid;

        public object RotateFlipType { get; private set; }
        bool isGekliktGeluid;
        bool isGekliktMuziek;




        public MainWindow()
        {
            InitializeComponent();
            //bij iedere tick voer de event uit
            klok.Tick += new EventHandler(klokAfgelopen);
            //de klok zet een nieuwe interval op 1 seconde
            klok.Interval = new TimeSpan(0, 0, 1);
            klok.Start();
            //open bron bestand van het geluid
            muziek.Open(new System.Uri(@"..\..\muziek.wav", UriKind.RelativeOrAbsolute));

            //speel muziek af
            muziek.Play();
            //wanneer de muziek gedaan is, ga na het event.
            muziek.MediaEnded += new EventHandler(Media_Ended);


        }




        private void Media_Ended(object sender, EventArgs e)
        {
            //zet de speelband terug op het begin
            muziek.Position = TimeSpan.Zero;
            //speel de muziek af
            muziek.Play();
        }

            private void klokAfgelopen(object sender, EventArgs e)
        {
            //schrijf tijd text uit
            txtTimeShow.Text = DateTime.Now.ToLongTimeString();
            
        }

        private void DeckSchudden()
        {
            MessageBox.Show("Hang on! We need to shuffle the deck!");
            //lijst gebruikte kaarten wissen (de kaarten die op tafel liggen worden opnieuw erbij geteld)
            gebruikteKaartenLijst.Clear();

            //voeg kaarten op tafel toe aan list gebruikteKaartenLijst
            gebruikteKaartenLijst = kaartenOpTafel.ToList();

            //lijst aantal moet afgetrokken worden van getoonde kaarten
            resterendeKaarten = (52 - kaartenOpTafel.Count);
        }

        private void LaatstGespeeldeHand()
        {
            //kleur van text veranderen afhankelijk van wie wint
            if (wieWint == "speler")
            {
                txtLaatsteHand.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (wieWint == "bank")
            {
                txtLaatsteHand.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (wieWint == "gelijkspel")
            {
                txtLaatsteHand.Foreground = new SolidColorBrush(Colors.Orange);
            }

            //controle of de lijst omgedraaid was, zodat we terug op de correcte positie schrijven
            if (isgedraaid == true)
            {
                //zet het meest recente item vanboven
                historiekLijst.Reverse();
                isgedraaid = false;
            }


            //inhoud van laatste hand in een string plaatsen
            laatsteHand = $"{inzet:c} - {kapitaal:c} / {800 - kapitaal:c}";
            //string schrijven
            txtLaatsteHand.Text = laatsteHand;
            //string toevoegen aan lijst met gespeelde handen
            historiekLijst.Add(Convert.ToString(laatsteHand));

            //controle of er max 10 rijen in de lijst zitten
            if (historiekLijst.Count > 10)
            {
                historiekLijst.RemoveAt(0);
            }

        }

        private void KaartDelen()
        {
            //kies random nummer uit deck
            gekozenKaart = rnd.Next(1, 52);

            //indien de gekozenkaart al gebruikt was, kies een nieuwe
            if (gebruikteKaartenLijst.Contains(gekozenKaart))
            {
                gekozenKaart = rnd.Next(1, 52);
            }

            //voeg gekozen nummer toe aan lijst met kaarten die op tafel liggen.
            kaartenOpTafel.Add(gekozenKaart);

            //voeg random nummer toe aan array gekozenKaarten
            gebruikteKaartenLijst.Add(gekozenKaart);

            //Ik heb hier 40 genomen omdat beide spelers maximum 6 kaarten in hun handen kunnen houden en dan net aan 21 komen.
            if (gebruikteKaartenLijst.Count > 40) 
            {
                DeckSchudden();
            }
            else
            {
                //lijst aantal moet afgetrokken worden van GEBRUIKTE kaarten
                resterendeKaarten = (52 - gebruikteKaartenLijst.Count);
            }

            //schrijf resterende kaarten
            lblResterendeKaarten.Content = resterendeKaarten;



            KaartWaarde();
            BeurtAan();
        }


        private void KaartWaarde()
        {
            //waarde koppelen aan kaart
            switch (gekozenKaart)
            {
                //Aas
                case 1:
                case 2:
                case 3:
                case 4:
                    //indien het de beurt is aan de bank en we trekken de eerste tot de 4de kaart geef een waarde 11
                    if ((speelBeurt == true) && (scoreBank <= 10))
                    {
                        KaardWaarde = 11;
                        overloadAceBank = +10;
                    }
                    //indien het de beurt is aan de speler en we trekken de eerste tot de 4de kaart geef een waarde 11
                    if ((speelBeurt == false) && (scoreSpeler <= 10))
                    {
                        KaardWaarde = 11;
                        overloadAceSpeler = +10;
                    }
                    //kijken of het de beurt is aan de bank of de speler, geef een waarde 1 aan de kaart
                    else if (((scoreBank > 10) && (speelBeurt == true)) || ((scoreSpeler > 10) && (speelBeurt == false)))
                    {
                        KaardWaarde = 1;
                    }
                    break;

                //Kaart 2
                case 5:
                case 6:
                case 7:
                case 8:
                    KaardWaarde = 2;
                    break;

                //Kaart 3
                case 9:
                case 10:
                case 11:
                case 12:
                    KaardWaarde = 3;
                    break;
                //Kaart 4
                case 13:
                case 14:
                case 15:
                case 16:
                    KaardWaarde = 4;
                    break;

                //Kaart 5
                case 17:
                case 18:
                case 19:
                case 20:
                    KaardWaarde = 5;
                    break;

                //Kaart 6
                case 21:
                case 22:
                case 23:
                case 24:
                    KaardWaarde = 6;
                    break;

                //Kaart 7
                case 25:
                case 26:
                case 27:
                case 28:
                    KaardWaarde = 7;
                    break;

                //Kaart 8
                case 29:
                case 30:
                case 31:
                case 32:
                    KaardWaarde = 8;
                    break;

                //Kaart 9
                case 33:
                case 34:
                case 35:
                case 36:
                    KaardWaarde = 9;
                    break;

                //Kaart 10
                case 37:
                case 38:
                case 39:
                case 40:

                //Kaart Boer
                case 41:
                case 42:
                case 43:
                case 44:

                //Kaart Dame
                case 45:
                case 46:
                case 47:
                case 48:

                //Kaart Koning
                case 49:
                case 50:
                case 51:
                case 52:
                    KaardWaarde = 10;
                    break;
            }
        }
        private void BeurtAan()
        {
            #region Beurt aan Speler
            if (speelBeurt == false)
            {
                //bovenstaande toevoegen aan string
                handBuilderPlayer.AppendLine($"{standaardDeckList[gekozenKaart - 1]}");
                //string schrijven op textveld
                txtRstSpeler.Text = handBuilderPlayer.ToString();
                //score verhogen met de kaartwaarde
                scoreSpeler = scoreSpeler + KaardWaarde;
                txtScoreSpeler.Text = Convert.ToString(scoreSpeler);



                //vijfde kaart
                if (counter > 3)
                {
                    //nieuwe kaart tonen
                    imgKaart5de.Visibility = Visibility.Visible;
                    //kaarten bron veranderen
                    kaart5.Source = new BitmapImage(new Uri($@"{eersteKaartImage - 1}.png", UriKind.Relative));
                    vijfdeKaartImage = gekozenKaart;
                    kaart4.Source = new BitmapImage(new Uri($@"{tweedeKaartImage - 1}.png", UriKind.Relative));
                    kaart3.Source = new BitmapImage(new Uri($@"{derdeKaartImage - 1}.png", UriKind.Relative));
                    kaart2.Source = new BitmapImage(new Uri($@"{vierdeKaartImage - 1}.png", UriKind.Relative));
                    kaart1.Source = new BitmapImage(new Uri($@"{vijfdeKaartImage - 1}.png", UriKind.Relative));
                    //zet kaarten op source
                    imgKaart5de.Source = kaart5.Source;
                    imgKaart4de.Source = kaart4.Source;
                    imgKaart3de.Source = kaart3.Source;
                    imgKaart2de.Source = kaart2.Source;
                    imgKaart1ste.Source = kaart1.Source;
                    counter++;
                }

                //vierde kaart
                if (counter == 3)
                {
                    //nieuwe kaart tonen
                    imgKaart4de.Visibility = Visibility.Visible;
                    //kaarten bron veranderen
                    kaart4.Source = new BitmapImage(new Uri($@"{eersteKaartImage - 1}.png", UriKind.Relative));
                    vierdeKaartImage = gekozenKaart;
                    kaart3.Source = new BitmapImage(new Uri($@"{tweedeKaartImage - 1}.png", UriKind.Relative));
                    kaart2.Source = new BitmapImage(new Uri($@"{derdeKaartImage - 1}.png", UriKind.Relative));
                    kaart1.Source = new BitmapImage(new Uri($@"{vierdeKaartImage - 1}.png", UriKind.Relative));
                    //zet kaarten op source
                    imgKaart4de.Source = kaart4.Source;
                    imgKaart3de.Source = kaart3.Source;
                    imgKaart2de.Source = kaart2.Source;
                    imgKaart1ste.Source = kaart1.Source;
                    counter++;
                }

                //derde kaart
                if (counter == 2)
                {
                    //nieuwe kaart tonen
                    imgKaart3de.Visibility = Visibility.Visible;
                    //kaarten bron veranderen
                    kaart3.Source = new BitmapImage(new Uri($@"{eersteKaartImage - 1}.png", UriKind.Relative));
                    derdeKaartImage = gekozenKaart;
                    kaart2.Source = new BitmapImage(new Uri($@"{tweedeKaartImage - 1}.png", UriKind.Relative));
                    kaart1.Source = new BitmapImage(new Uri($@"{derdeKaartImage - 1}.png", UriKind.Relative));
                    //zet kaarten op source
                    imgKaart3de.Source = kaart3.Source;
                    imgKaart2de.Source = kaart2.Source;
                    imgKaart1ste.Source = kaart1.Source;
                    counter++;
                }
                //tweede kaart
                if (counter == 1)
                {
                    //nieuwe kaart tonen
                    imgKaart2de.Visibility = Visibility.Visible;
                    //kaarten bron veranderen
                    kaart2.Source = new BitmapImage(new Uri($@"{eersteKaartImage - 1}.png", UriKind.Relative));
                    tweedeKaartImage = gekozenKaart;
                    kaart1.Source = new BitmapImage(new Uri($@"{tweedeKaartImage - 1}.png", UriKind.Relative));
                    //zet kaarten op source
                    imgKaart2de.Source = kaart2.Source;
                    imgKaart1ste.Source = kaart1.Source;
                    counter++;
                }
                //eerste kaart
                if (counter == 0)
                {
                    imgKaart1ste.Visibility = Visibility.Visible;
                    eersteKaartImage = gekozenKaart;
                    kaart1.Source = new BitmapImage(new Uri($@"{eersteKaartImage - 1}.png", UriKind.Relative));
                    imgKaart1ste.Source = kaart1.Source;
                    //counter gaat iedere keer omhoog om zo naar de volgende stap te gaan
                    counter++;
                }
                speelBeurt = true;
            }
            #endregion
            #region Beurt aan Bank
            else
            {
                //na eerste beurt bank
                if (eersteKaart == true)
                {
                    //zet de gekozen kaart in de lijst
                    handBuilderBank.AppendLine($"{standaardDeckList[gekozenKaart - 1]}");
                    //zet de string met gekozenkaart op het text veld
                    txtRstBank.Text = handBuilderBank.ToString();
                    //verandere de score met de nieuwe kaart waarde
                    scoreBank = scoreBank + KaardWaarde;
                    //toon de score van de bank
                    txtScoreBank.Text = Convert.ToString(scoreBank);
                    //wijzig de beurt naar die van de speler
                    speelBeurt = false;
                }

                //eerste beurt bank
                else if (eersteKaart == false)
                {
                    //plaats de eerst getrokkenkaart in de verborgenkaart variabele
                    verborgenKaart = Convert.ToString(standaardDeckList[gekozenKaart - 1]);
                    //stop de waarde van de eerst getrokke kaart in een verborgen variabele
                    verborgenKaardWaarde = KaardWaarde;
                    //gezien hier enkel in gekomen word als 'eersteKaart' op false staat zetten we deze nu op true
                    eersteKaart = true;
                    //verander de beurt naar de speler
                    speelBeurt = false;
                }
            }
            #endregion
        }

        private async void btnDeel_Click(object sender, RoutedEventArgs e)
        {
            //speel klik geluid
            if (isGekliktGeluid == false)
            {
                clickSound.Play();
            }

            //er komen nieuwe kaarten op tafel dus we wissen de vorige lijst
            kaartenOpTafel.Clear();

            //als er double down gespeeld is geweest, voer dit uit.
            if (doublePlayed == true)
            {
                //Width terug op originele waarde zetten indien veranderd, (deze veranderd als de kaart plat ligt)
                imgKaart1ste.SetValue(Grid.ColumnSpanProperty, 4);
            }

            //verstop de image locaties van de vorige gedeelde kaarten
            imgKaart5de.Visibility = Visibility.Hidden;
            imgKaart4de.Visibility = Visibility.Hidden;
            imgKaart3de.Visibility = Visibility.Hidden;
            imgKaart2de.Visibility = Visibility.Hidden;
            imgKaart1ste.Visibility = Visibility.Hidden;
            //zet de counter terug op nul zodat we terug beginnen met de eerste kaart positie voor kaarten images te tonen (onder andere)
            counter = 0;
            //er zit geen aas meer in het spel, dus geen dilema of het een 1 of 11 moet zijn, hier word dit reset
            overloadAceSpeler = 0;    
            try
            {
                inzet = Convert.ToInt32(txtInzet.Text);
                while (inzet > kapitaal)
                {
                    MessageBox.Show("Bedrag mag niet boven je kapitaal gaan");
                    txtInzet.Clear();
                    inzet = 0;
                }
                int minimumInzet = kapitaal / 10;
                while (inzet < minimumInzet)
                {
                    MessageBox.Show("Er is een minimum inzet van 10%");
                    txtInzet.Clear();
                    inzet = 0;
                    minimumInzet = 0;
                }

                //indien de input van inzet correct verloopt voer onderstaande uit
                if ((inzet <= kapitaal) && (inzet != 0))
                {
                    //controle of wij een double down kunnen doen
                    if ((inzet * 2) <= kapitaal)
                    {
                        btnDouble.IsEnabled = true;
                    }

                    //inzet kan niet meer veranderd worden
                    txtInzet.IsReadOnly = true;
                    //kapitaal aanpassen met afgetrokken inzet
                    kapitaal = kapitaal - inzet;
                    //schrijf nieuwe inzet met een €
                    txtInzet.Text = Convert.ToString($"{inzet:c}");
                    //schrijf nieuwe kapitaal met een €
                    txtKapitaal.Text = Convert.ToString($"{kapitaal:c}");


                    //in deze method ruimen we alles op
                    Cleaning();
                    btnHit.IsEnabled = true;
                    btnStand.IsEnabled = true;
                    btnDeel.IsEnabled = false;


                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    await Task.Delay(500);
                    KaartDelen();
                    await Task.Delay(500);
                    KaartDelen();
                    await Task.Delay(500);
                    KaartDelen();
                    await Task.Delay(500);
                    KaartDelen();
                    Winnaar();

                }
            }

            //catch dat er niets staat ingevuld
            catch (FormatException)
            {
                MessageBox.Show("Voer een bedrag in");
            }

           //catch dat er geen nummer staat
            catch (Exception)
            {
                MessageBox.Show("Input is niet correct");
            }
        }

        private void ClearButtons()
        {
            btnDeel.IsEnabled = true;
            btnHit.IsEnabled = false;
            btnStand.IsEnabled = false;
            btnDouble.IsEnabled = false;
            speelBeurt = false;

            txtInzet.Clear();
            txtInzet.IsReadOnly = false;
        }

        private void Cleaning()
        {
            eersteKaart = false;

            //ruim de string met getrokken kaarten op (speler)
            handBuilderPlayer.Clear();

            //lege string schrijven op textveld
            txtRstSpeler.Text = handBuilderPlayer.ToString();

            //ruim de string met getrokken kaarten op (bank)
            handBuilderBank.Clear();

            //lege string schrijven op textveld
            txtRstBank.Text = handBuilderBank.ToString();

            imgKaart5de.Visibility = Visibility.Hidden;
            imgKaart4de.Visibility = Visibility.Hidden;
            imgKaart3de.Visibility = Visibility.Hidden;
            imgKaart2de.Visibility = Visibility.Hidden;
            imgKaart1ste.Visibility = Visibility.Hidden;


            scoreBank = 0;
            //toon de score van de bank
            txtScoreBank.Text = Convert.ToString(scoreBank);

            scoreSpeler = 0;
            //toon de score van de speler
            txtScoreSpeler.Text = Convert.ToString(scoreSpeler);

            //er is geen kaart gekozen dus dit word reset
            gekozenKaart = 0;

            //de teller die ervoor zorgt dat enkel de verborgenkaart word uitgeschreven, word hier reset
            teller = 0;
            //er is geen (verborgen)kaart meer dus dit reset
            verborgenKaardWaarde = 0;
            KaardWaarde = 0;
            verborgenKaart = null;

        }




        private void Winnaar()
        {

            if ((scoreBank > 21) && (scoreSpeler > 21))
            {
                wieWint = "gelijkspel";
                MessageBox.Show($"BUST! niemand wint!");

                txtKapitaal.Text = Convert.ToString($"{kapitaal:c}");



                LaatstGespeeldeHand();
                Blut();
                Cleaning();
                ClearButtons();
            }



            else
            {
                if (scoreBank > 21)
                {
                    if (overloadAceBank == 0)
                    {
                        wieWint = "speler";
                        MessageBox.Show($"BUST! Speler wint!");


                        LaatstGespeeldeHand();

                        inzet = inzet * 2;
                        kapitaal = kapitaal + inzet;
                        txtInzet.Text = Convert.ToString($"{inzet:c}");
                        txtKapitaal.Text = Convert.ToString($"{kapitaal:c}");
                
                        Cleaning();
                        ClearButtons();
                    }

                    //indien de score van de BANK over de 21 gaat, controleer of we de Aas van 11 naar 1 kunnen veranderen
                    while (overloadAceBank >= 10)
                    {
                        wieWint = "speler";
                        MessageBox.Show($"BUST! Speler wint!");
                        LaatstGespeeldeHand();
                        scoreBank = scoreBank - 10;
                        overloadAceBank = overloadAceBank - 10;
                        Cleaning();
                        ClearButtons();
                    }
                }

                if (scoreSpeler > 21)
                {
                    if (overloadAceSpeler == 0)
                    {
                        wieWint = "bank";
                        MessageBox.Show($"BUST! Bank wint!");

                        LaatstGespeeldeHand();

                        Blut();

                        inzet = 0;
                        Cleaning();
                        ClearButtons();
                    }

                    while (overloadAceSpeler >= 10)
                    {
                        scoreSpeler = scoreSpeler - 10;
                        overloadAceSpeler = overloadAceSpeler - 10;
                        txtScoreSpeler.Text = Convert.ToString(scoreSpeler);
                    }
                }
            }





            if (scoreBank >= 17)
            {
                if ((scoreSpeler > 21) || (scoreBank == scoreSpeler))
                {
                    wieWint = "gelijkspel";
                    LaatstGespeeldeHand();
                    MessageBox.Show($"Push!");
                    kapitaal = inzet + kapitaal;
                    txtKapitaal.Text = Convert.ToString($"{kapitaal:c}");

                    Blut();
                }

                if ((scoreBank > 21) || (scoreSpeler > scoreBank))
                {
                    wieWint = "speler";
                    MessageBox.Show($"Speler wint!");
                    LaatstGespeeldeHand();

                    inzet = inzet * 2;
                    kapitaal = kapitaal + inzet;
                    txtInzet.Text = Convert.ToString($"{inzet:c}");
                    txtKapitaal.Text = Convert.ToString($"{kapitaal:c}");
                }

                if ((scoreSpeler > 21) || (scoreBank > scoreSpeler))
                {
                    wieWint = "bank";
                    MessageBox.Show($"Bank wint!");
                    LaatstGespeeldeHand();

                    inzet = 0;
                    Blut();
                }
                
                Cleaning();
                ClearButtons();
            }
        }

        private void Blut()
        {
            if (kapitaal == 0)
            {
                MessageBox.Show("Je bent blut!");
                btnNieuw.IsEnabled = true;
                txtInzet.IsEnabled = false;
                txtKapitaal.IsEnabled = false;
                LaatstGespeeldeHand();
                Cleaning();
                ClearButtons();
                btnDeel.IsEnabled = false;
            }
        }

        private async void btnHit_Click(object sender, RoutedEventArgs e)
        {
            //speel klik geluid
            if (isGekliktGeluid == false)
            {
                clickSound.Play();
            }

            btnStand.IsEnabled = true;
            btnDeel.IsEnabled = false;
            //speelBeurt veranderen zodat het de speler zijn beurt is
            speelBeurt = false;
            await Task.Delay(500);
            KaartDelen();
            Winnaar();
        }

        private async void btnStand_Click(object sender, RoutedEventArgs e)
        {
            //speel klik geluid
            if (isGekliktGeluid == false)
            {
                clickSound.Play();
            }

            //schrijf hier het verborgen getal
            if (teller == 0)
            {
                handBuilderBank.AppendLine($"{verborgenKaart}");
                txtRstBank.Text = handBuilderBank.ToString();
                scoreBank = scoreBank + verborgenKaardWaarde;
                txtScoreBank.Text = Convert.ToString(scoreBank);
                verborgenKaardWaarde = 0;

                teller = 1;

                //while loop (not 17 draw a card)
                while (scoreBank < 17)
                {
                    speelBeurt = true;
                    await Task.Delay(500);
                    KaartDelen();

                }
                Winnaar();
                btnHit.IsEnabled = false;
            }





            if (teller == 1)
            {

                Winnaar();
                teller = 0;
            }
        }

        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {

            //wis de historiek van het vorige spel
            historiekLijst.Clear();


            //speel klik geluid
            if (isGekliktGeluid == false)
            {
                clickSound.Play();
            }

            DeckSchudden();

            txtInzet.Focus();
            btnDeel.IsEnabled = true;
            kapitaal = 100;
            txtKapitaal.Text = Convert.ToString($"{kapitaal:c}");
            txtInzet.Clear();
            txtInzet.IsReadOnly = false;
            txtInzet.IsEnabled = true;
            txtKapitaal.IsEnabled = true;
            btnNieuw.IsEnabled = false;
            overloadAceSpeler = 0;
            overloadAceBank = 0;


            Cleaning();


        }

        private async void btnDouble_Click(object sender, RoutedEventArgs e)
        {
            //speel klik geluid
            if (isGekliktGeluid == false)
            {
                clickSound.Play();
            }

            kapitaal = kapitaal - inzet;
            txtKapitaal.Text = Convert.ToString($"{kapitaal:c}");
            inzet = inzet * 2;
            txtInzet.Text = Convert.ToString($"{inzet:c}");

            btnHit.IsEnabled = false;
            btnStand.IsEnabled = false;
            btnDouble.IsEnabled = false;
            speelBeurt = false;
            await Task.Delay(500);
            KaartDelen();
            doublePlayed = true;


            //////kaart draaien
            //Bitmap Image aanmaken voor rotatie door te geven aan image source
            BitmapImage bitmapkaart1 = new BitmapImage();

            //Ik begrijp dit deel niet, maar het moet er in staan
            bitmapkaart1.BeginInit();
            bitmapkaart1.UriSource = new Uri($@"{gekozenKaart - 1}.png", UriKind.Relative);

            //Rotation instellen
            bitmapkaart1.Rotation = Rotation.Rotate90;
            bitmapkaart1.EndInit();
            
            //width aanpassen voor landscape mode
            imgKaart1ste.SetValue(Grid.ColumnSpanProperty, 5);

            //set image source
            imgKaart1ste.Source = bitmapkaart1;

            //geen kaarten meer voor speler, dus voer stand uit
            btnStand_Click(sender, e);

            //schrijf kapitaal opnieuw
            txtKapitaal.Text = Convert.ToString($"{kapitaal:c}");



        }

        private void MenuItemAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private void Geluid_Click(object sender, RoutedEventArgs e)
        {
            switch (isGekliktGeluid)
            {
                //Aas
                case true:
                    isGekliktGeluid = false;
                    break;

                case false:
                    isGekliktGeluid = true;
                    break;
            }
        }

        private void Muziek_Click(object sender, RoutedEventArgs e)
        {
            switch (isGekliktMuziek)
            {
                //Aas
                case true:
                    muziek.Play();
                    isGekliktMuziek = false;
                    break;

                case false:
                    muziek.Stop();
                    isGekliktMuziek = true;
                    break;
            }
        }

        private void Historiek_Click(object sender, RoutedEventArgs e)
        {
            //zet het meest recente item vanboven
            historiekLijst.Reverse();

            //variabelen om door te geven dat de lijst was omgedraait
            isgedraaid = true;

            //////////////////////////////////
            var message = string.Join("\n", historiekLijst);
 
            MessageBox.Show(message);

            

        }





    }
}

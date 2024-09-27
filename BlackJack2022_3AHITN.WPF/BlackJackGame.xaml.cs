using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using BlackJack2022_3AHITN.Lib;

namespace BlackJack2022_3AHITN.WPF
{
    public partial class BlackJackGame
    {
        #region instancevariables
        GameDesigner _gameDesigner = null!;
        int _playerBalance;
        int _playerBet;
        Table _table = null!;
        #endregion

        #region properties
        /// <summary>
        /// Liefert den Namen des Spielers zurück
        /// </summary>
        internal string PlayerName
        {
            get
            {
                string playerName = TbxPlayerName.Text;
                return playerName;
            }
        }

        /// <summary>
        /// Liefert die Wette des Spielers zurück
        /// </summary>
        internal int PlayerBet
        {
            get
            {
                int bet = Convert.ToInt32(TbxPlayerBet.Text);
                return bet;
            }
        }

        /// <summary>
        /// Tisch wird zurückgeliefert
        /// </summary>
        internal Table Table => _table;

        /// <summary>
        /// Ausgewählte Strategie vom Spieler wird ausgegeben
        /// </summary>
        internal string Strategy
        {
            get
            {
                string strategy = CbxStrategy.Text;
                return strategy;
            }
        }
        #endregion

        #region constructor
        public BlackJackGame()
        {
            DataContext = this;
            InitializeComponent();
            _playerBalance = Convert.ToInt32(((string)LblPlayerBet.Content).Split(' ')[2]);
        }
        #endregion

        #region methods
        private async void imgCoin10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TblPlaceHolderPlayerBet.Visibility = Visibility.Hidden;

            if (_playerBalance >= _playerBet + 10)
            {
                ImgCoin10.Source = new BitmapImage(new Uri("Resources/coins/coin-status-added.png", UriKind.Relative));
                await Task.Delay(200);
                ImgCoin10.Source = new BitmapImage(new Uri("Resources/coins/coin-10.png", UriKind.Relative));
                TbxPlayerBet.Text = Convert.ToString(_playerBet + 10);
            }
            else
            {
                MessageBox.Show("Sie dürfen nicht mehr als Ihr ganzes Kapital wetten.", "WENIG GUTHABEN" , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void imgCoin20_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TblPlaceHolderPlayerBet.Visibility = Visibility.Hidden;

            if (_playerBalance >= _playerBet + 20)
            {
                ImgCoin20.Source = new BitmapImage(new Uri("Resources/coins/coin-status-added.png", UriKind.Relative));
                await Task.Delay(200);
                ImgCoin20.Source = new BitmapImage(new Uri("Resources/coins/coin-20.png", UriKind.Relative));
                TbxPlayerBet.Text = Convert.ToString(_playerBet + 20);
            }
            else
            {
                MessageBox.Show("Sie dürfen nicht mehr als Ihr ganzes Kapital wetten.", "WENIG GUTHABEN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void imgCoin50_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TblPlaceHolderPlayerBet.Visibility = Visibility.Hidden;

            if (_playerBalance >= _playerBet + 50)
            {
                ImgCoin50.Source = new BitmapImage(new Uri("Resources/coins/coin-status-added.png", UriKind.Relative));
                await Task.Delay(200);
                ImgCoin50.Source = new BitmapImage(new Uri("Resources/coins/coin-50.png", UriKind.Relative));
                TbxPlayerBet.Text = Convert.ToString(_playerBet + 50);
            }
            else
            {
                MessageBox.Show("Sie dürfen nicht mehr als Ihr ganzes Kapital wetten.", "WENIG GUTHABEN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void imgCoin100_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TblPlaceHolderPlayerBet.Visibility = Visibility.Hidden;

            if (_playerBalance >= _playerBet + 100)
            {
                ImgCoin100.Source = new BitmapImage(new Uri("Resources/coins/coin-status-added.png", UriKind.Relative));
                await Task.Delay(200);
                ImgCoin100.Source = new BitmapImage(new Uri("Resources/coins/coin-100.png", UriKind.Relative));
                TbxPlayerBet.Text = Convert.ToString(_playerBet + 100);
            }
            else
            {
                MessageBox.Show("Sie dürfen nicht mehr als Ihr ganzes Kapital wetten.", "WENIG GUTHABEN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void imgCoin200_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TblPlaceHolderPlayerBet.Visibility = Visibility.Hidden;

            if (_playerBalance >= _playerBet + 200)
            {
                ImgCoin200.Source = new BitmapImage(new Uri("Resources/coins/coin-status-added.png", UriKind.Relative));
                await Task.Delay(200);
                ImgCoin200.Source = new BitmapImage(new Uri("Resources/coins/coin-200.png", UriKind.Relative));
                TbxPlayerBet.Text = Convert.ToString(_playerBet + 200);
            }
            else
            {
                MessageBox.Show("Sie dürfen nicht mehr als Ihr ganzes Kapital wetten.", "WENIG GUTHABEN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void imgCoin500_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TblPlaceHolderPlayerBet.Visibility = Visibility.Hidden;

            if (_playerBalance >= _playerBet + 500)
            {
                ImgCoin500.Source = new BitmapImage(new Uri("Resources/coins/coin-status-added.png", UriKind.Relative));
                await Task.Delay(200);
                ImgCoin500.Source = new BitmapImage(new Uri("Resources/coins/coin-500.png", UriKind.Relative));
                TbxPlayerBet.Text = Convert.ToString(_playerBet + 500);
            }
            else
            {
                MessageBox.Show("Sie dürfen nicht mehr als Ihr ganzes Kapital wetten.", "WENIG GUTHABEN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClearPlayerName_Click(object sender, RoutedEventArgs e)
        {
            TbxPlayerName.Text = "";
            TbxPlayerName.Focus();
            TblPlaceHolderNameOfPlayer.Visibility = Visibility.Visible;
        }

        private void btnClearTableName_Click(object sender, RoutedEventArgs e)
        {
            TbxTableName.Text = "";
            TbxTableName.Focus();
            TblPlaceHolderNameOfTable.Visibility = Visibility.Visible;
        }

        private void btnClearPlayerBet_Click(object sender, RoutedEventArgs e)
        {
            TbxPlayerBet.Text = "";
            _playerBet = 0;
            TbxPlayerBet.Focus();
            TblPlaceHolderPlayerBet.Visibility = Visibility.Visible;
        }

        private void tbxPlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TbxPlayerName.Text))
            {
                TblPlaceHolderNameOfPlayer.Visibility = Visibility.Hidden;
                if (File.Exists($"{PlayerName}.json"))
                {
                    using Stream stream = new FileStream($"{PlayerName}.json", FileMode.Open, FileAccess.Read);
                    Player player = Player.ReadJson(stream);
                    player.CardSource = _table;
                    LblPlayerBet.Content = $"Einsatz (Kapital: {player.Balance} €)";
                    stream.Close();
                }
                else
                {
                    LblPlayerBet.Content = "Einsatz (Kapital: 1000 €)";
                }

                _playerBalance = Convert.ToInt32(((string)LblPlayerBet.Content).Split(' ')[2]);
            }
            else
            {
                TblPlaceHolderNameOfPlayer.Visibility = Visibility.Visible;
            }
        }

        private void tbxTableName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TblPlaceHolderNameOfTable.Visibility = !string.IsNullOrEmpty(TbxTableName.Text) ? Visibility.Hidden : Visibility.Visible;
        }

        private void tbxPlayerBet_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbxPlayerBet.Text != "")
            {
                TblPlaceHolderPlayerBet.Visibility = Visibility.Hidden;

                if (int.TryParse(TbxPlayerBet.Text, out _))
                {
                    _playerBet = Convert.ToInt32(TbxPlayerBet.Text);

                    //Es wird überprüft, ob die Wette des Spielers mehr als sein Kapital ist
                    if (_playerBalance >= _playerBet)
                    {
                        LblPlayerBet.Content = $"Einsatz (Kapital: {_playerBalance - _playerBet} €)";
                    }
                    else
                    {
                        MessageBox.Show("Sie dürfen nicht mehr als Ihr ganzes Kapital wetten.", "WENIG GUTHABEN", MessageBoxButton.OK, MessageBoxImage.Error);
                        TbxPlayerBet.Text = Convert.ToString(_playerBalance);
                    }
                }
                else
                {
                    MessageBox.Show("Bitte geben Sie eine Zahl ein!!!", "EINGABE ZAHL", MessageBoxButton.OK, MessageBoxImage.Error);

                    TbxPlayerBet.Text = "";
                }
            }
            else
            {
                TblPlaceHolderPlayerBet.Visibility = Visibility.Visible;

                LblPlayerBet.Content = $"Einsatz (Kapital: {_playerBalance} €)";

                _playerBet = 0;
            }
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            //Es wird überprüft, ob der Spieler seinen Namen überhaupt eingegeben hat
            if (TbxPlayerName.Text != "")
            {
                //Es wird überprüft, ob der Spieler den Namen des Tischs eingegeben hat
                if (!string.IsNullOrEmpty(TbxTableName.Text))
                {
                    //Es wird überprüft, ob der Spieler sein Wetteinsatz eingegeben hat
                    if (TbxPlayerBet.Text != "")
                    {
                        _playerBet = Convert.ToInt32(TbxPlayerBet.Text);

                        //Es wird überprüft, ob der Spieler mindestens 5 Euro gewettet hat oder nicht
                        if (_playerBet >= 5)
                        {
                            _table = new Table(TbxTableName.Text);
                            _gameDesigner = new GameDesigner(this);
                            this.Hide();
                            _gameDesigner.ShowDialog();
                            TbxTableName.Text = "";
                            LblPlayerBet.Content = $"Einsatz (Budget: {_gameDesigner.Player.Balance} €)";
                            _playerBalance = Convert.ToInt32(((string)LblPlayerBet.Content).Split(' ')[2]);
                            TbxPlayerBet.Text = "";
                            _playerBet = 0;
                        }
                        else
                        {
                            MessageBox.Show("Sie müssen mindestens 5 € wetten!!!", "MINDESTEINSATZ 5 Euro", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bitte geben Sie Ihren Einsatz ein!!!", "WETTEINSATZ", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Bitte geben Sie den Namen des Tischs ein!!!", "NAME DES TISCHS", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie unbedingt Ihren Namen ein!!!", "NAME DES SPIELERS", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
    }
}

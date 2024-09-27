using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using BlackJack2022_3AHITN.Lib;
using NAudio.Wave;

namespace BlackJack2022_3AHITN.WPF
{
    public partial class GameDesigner
    {
        #region instancevariables
        readonly BlackJackGame _blackJackGame = null!;
        readonly WaveOut _casinoAudio = new WaveOut();
        readonly Mp3FileReader _fileReader = new Mp3FileReader(@"..\..\..\..\casino audio.mp3");
        readonly WaveOut _win = new WaveOut();
        readonly WaveOut _lose = new WaveOut();
        readonly PlayerFactory _playerFactory = new PlayerFactory();
        readonly GameFactory _gameFactory = new GameFactory();
        IPlayerStrategy _playerStrategy = new PlayerStrategyHardHands();
        Player _player = null!;
        readonly Hand _hand = new Hand();
        readonly Hand _playerHand = new Hand();
        readonly Hand _dealerHand = new Hand();
        IGame _game = null!;
        Card _firstCard = null!;
        List<Card> _playerCards = new List<Card>();
        List<Card> _splittedCards = new List<Card>();
        int _countStandClick;
        #endregion

        #region property
        /// <summary>
        /// Spieler wird zurückgeliefert
        /// </summary>
        internal Player Player => _player;

        #endregion

        #region constructors
        public GameDesigner()
        {
            InitializeComponent();
        }

        public GameDesigner(BlackJackGame blackJackGame)
        {
            _blackJackGame = blackJackGame;
            InitializeComponent();
            InitializeData();
        }
        #endregion

        #region methods
        private void InitializeData()
        {
            //Es wird überprüft, welche Strategie vom Spieler ausgewählt wurde
            if (_blackJackGame.Strategy == "Hard hands")
            {
                _playerStrategy = new PlayerStrategyHardHands();
            }
            else if (_blackJackGame.Strategy == "Soft hands")
            {
                _playerStrategy = new PlayerStrategySoftHands();
            }

            //Instanzvariablen werden initialisiert
            if (!File.Exists($"{_blackJackGame.PlayerName}.json"))
            {
                _player = (Player)_playerFactory.CreatePlayer(_blackJackGame.PlayerName, _blackJackGame.Table, _playerStrategy);
            }
            else
            {
                //Liest das Guthaben des Spielers von der Datei ab
                using Stream stream = new FileStream($"{_blackJackGame.PlayerName}.json", FileMode.Open, FileAccess.Read);
                _player = Player.ReadJson(stream);
                _player.CardSource = new SevenCardSource();
                _player.SetPlayerStrategy(_playerStrategy);
                stream.Close();
            }

            _game = _gameFactory.CreateGame(_blackJackGame.Table, _player);

            //Felder werden mit passenden Werten befüllt
            LblPlayer.Content = _blackJackGame.PlayerName;
            TbxTableName.Text = _blackJackGame.Table.Name;
            TbxStrategy.Text = _blackJackGame.Strategy;

            //Audio im Casino wird im Hintergrund abgespielt
            _casinoAudio.Init(_fileReader);
            _casinoAudio.Play();

            //Spiel wird gestartet …
            _game.StartGame();

            //Spieler macht seine Wette
            _player.Bet(_blackJackGame.PlayerBet);

            TbxPlayerBet.Text = _blackJackGame.PlayerBet + " €";
            TblPlayerBalance.Text = "Budget: " + _player.Balance;

            //Karten des Spielers werden angezeigt
            _playerCards = _game.Player.Cards.ToList();
            foreach (Card card in _playerCards)
            {
                Image cardImage = CreateCardImage(card, 40 * GrdPlayerCards.Children.Count);
                GrdPlayerCards.Children.Add(cardImage);

                if (_game.Player.GetHandStatus() != HandStatus.BlackJack && card.Value == CardValue.Ace)
                {
                    int playerCardValue = _game.Player.GetHandValue();
                    TbxPlayerPoints.Text = $"{playerCardValue - 10}/{playerCardValue}";
                    TbxPlayerPoints.FontSize = 55;
                    TbxPlayerPoints.Margin = new Thickness(74, 181, 80, 53);
                }
            }
            _hand.AddCard(_playerCards.First());

            //Status und Punkte des Spielers werden aktualisiert
            LblPlayerStatus.Content = _game.Player.GetHandStatus().ToString();
            if (TbxPlayerPoints.Text == "0")
            {
                TbxPlayerPoints.Text = _game.Player.GetHandValue().ToString();
            }

            //Erste Karte des Dealers wird angezeigt
            _firstCard = _game.Dealer.FirstCard;
            _dealerHand.AddCard(_firstCard);
            GrdDealerCards.Children.Add(CreateCardImage(_firstCard, 40 * GrdDealerCards.Children.Count));

            //Zweite Karte des Dealers ist zuerst unsichtbar
            GrdDealerCards.Children.Add(CreateCardImage(_firstCard, 40 * GrdDealerCards.Children.Count, "Resources/cards/Card-Skin-Red.png"));

            //Punkte der ersten Karte des Dealers wird angezeigt
            if (_firstCard.Value == CardValue.Ace)
            {
                TbxDealerPoints.Text = $"{_dealerHand.Sum - 10}/{_dealerHand.Sum}";
                TbxDealerPoints.FontSize = 55;
                TbxDealerPoints.Margin = new Thickness(74, 181, 80, 53);
            }
            else
            {
                TbxDealerPoints.Text = _dealerHand.Sum.ToString();
            }

            //Wenn der Spieler schon am Anfang des Spiels den Status BlackJack hat, dann kann er nicht mehr eine Karte ziehen
            if (_game.Player.GetHandStatus() == HandStatus.BlackJack)
            {
                BtnAutoAction.IsEnabled = false;
                BtnHit.IsEnabled = false;
                BtnDouble.IsEnabled = false;
            }

            if (_hand.Sum != (_player.GetHandValue() - _hand.Sum))
            {
                BtnSplit.IsEnabled = false;
            }
        }

        private void btnAutoAction_Click(object sender, RoutedEventArgs e)
        {
            //Automatische Aktion wird ausgeführt
            _game.Play();

            //Karten des Spielers werden aktualisiert
            List<Card> cards = _game.Player.Cards.ToList();
            if (cards.Count > GrdPlayerCards.Children.Count)
            {
                Image cardImage = CreateCardImage(cards[^1], 40 * GrdPlayerCards.Children.Count);
                GrdPlayerCards.Children.Add(cardImage);
            }

            //Es wird überprüft, ob der Spieler die Karte Ass in seiner Hand einmal hat
            if (_game.Player.NumberOfAceCards == 1)
            {
                foreach (Card card in cards)
                {
                    if (card.Value != CardValue.Ace)
                    {
                        _playerHand.AddCard(card);
                    }
                }
            }

            //Status und Punkte des Spielers werden aktualisiert
            LblPlayerStatus.Content = _game.Player.GetHandStatus().ToString();

            if (_playerHand.Sum is > 0 and <= 9)
            {
                TbxPlayerPoints.Text = $"{_game.Player.GetHandValue() - 10}/{_game.Player.GetHandValue()}";
                TbxPlayerPoints.FontSize = 55;
                TbxPlayerPoints.Margin = new Thickness(74, 181, 80, 53);
            }
            else
            {
                TbxPlayerPoints.Text = _game.Player.GetHandValue().ToString();
                TbxPlayerPoints.FontSize = 75;
                TbxPlayerPoints.Margin = new Thickness(74, 158, 80, 53);
            }

            //Wenn der Spieler den Wert 21 hat, dann kann er nicht mehr Karten ziehen oder automatische Aktion ausführen
            if (_game.Player.GetHandValue() == 21)
            {
                BtnAutoAction.IsEnabled = false;
                BtnHit.IsEnabled = false;
                BtnDouble.IsEnabled = false;
                BtnSplit.IsEnabled = false;
            }

            //Wenn die Anzahl der Karten weniger oder mehr als 2 ist, dann kann der Spieler nicht mehr verdoppeln
            BtnDouble.IsEnabled = GrdPlayerCards.Children.Count == 2;

            if (_game.Player.HasFinished)
            {
                btnStand_Click(sender, e);
            }

            BtnSplit.IsEnabled = false;
        }

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            if (GrdPlayerCards.Children.Count == _game.Player.Cards.ToList().Count && GrdPlayerCards.Children.Count != _game.Player.SecondHandCards.ToList().Count)
            {
                //Aktion des Spielers wird ausgeführt
                _game.Play(PlayerAction.Hit, false);

                //Karten des Spielers werden aktualisiert
                List<Card> cards = _game.Player.Cards.ToList();
                Image cardImage = CreateCardImage(cards[^1], 40 * GrdPlayerCards.Children.Count);
                GrdPlayerCards.Children.Add(cardImage);

                //Es wird überprüft, ob der Spieler die Karte Ass in seiner Hand einmal hat
                if (_game.Player.NumberOfAceCards == 1)
                {
                    foreach (Card card in cards)
                    {
                        if (card.Value != CardValue.Ace)
                        {
                            _playerHand.AddCard(card);
                        }
                    }
                }

                //Status und Punkte des Spielers werden aktualisiert
                LblPlayerStatus.Content = _game.Player.GetHandStatus().ToString();

                if (_playerHand.Sum is > 0 and <= 9)
                {
                    TbxPlayerPoints.Text = $"{_game.Player.GetHandValue() - 10}/{_game.Player.GetHandValue()}";
                    TbxPlayerPoints.FontSize = 55;
                    TbxPlayerPoints.Margin = new Thickness(74, 181, 80, 53);
                }
                else
                {
                    TbxPlayerPoints.Text = _game.Player.GetHandValue().ToString();
                    TbxPlayerPoints.FontSize = 75;
                    TbxPlayerPoints.Margin = new Thickness(74, 158, 80, 53);
                }

                //Wenn der Spieler den Wert 21 hat, dann kann er nicht mehr Karten ziehen oder automatische Aktion ausführen
                if (_game.Player.GetHandValue() == 21)
                {
                    BtnAutoAction.IsEnabled = false;
                    BtnHit.IsEnabled = false;
                    BtnDouble.IsEnabled = false;
                    BtnSplit.IsEnabled = false;
                }

                //Wenn die Anzahl der Karten weniger oder mehr als 2 ist, dann kann der Spieler nicht mehr verdoppeln
                BtnDouble.IsEnabled = GrdPlayerCards.Children.Count == 2;

                //Wenn der Spieler den Status Bust hat, dann ist das Spiel zu Ende (ohne dass der Dealer Karten ziehen muss)
                if (_game.Player.HasFinished)
                {
                    btnStand_Click(sender, e);
                }
            }
            else
            {
                //Wenn der Spieler auf Hit klickt, dann wird diese Aktion ausgeführt
                _game.Play(PlayerAction.Hit, true);

                //Karten des Spielers werden aktualisiert
                List<Card> cards = _game.Player.SecondHandCards.ToList();
                Image cardImage = CreateCardImage(cards[^1], 40 * GrdPlayerCards.Children.Count);
                GrdPlayerCards.Children.Add(cardImage);

                //Es wird überprüft, ob der Spieler die Karte Ass in seiner Hand einmal hat
                if (_game.Player.NumberOfAceCards == 1)
                {
                    foreach (Card card in cards)
                    {
                        if (card.Value != CardValue.Ace)
                        {
                            _playerHand.AddCard(card);
                        }
                    }
                }

                //Status und Punkte des Spielers werden aktualisiert
                LblPlayerStatus.Content = _game.Player.GetSecondHandStatus().ToString();

                if (_playerHand.Sum is > 0 and <= 9)
                {
                    TbxPlayerPoints.Text = $"{_game.Player.GetSecondHandValue() - 10}/{_game.Player.GetSecondHandValue()}";
                    TbxPlayerPoints.FontSize = 55;
                    TbxPlayerPoints.Margin = new Thickness(74, 181, 80, 53);
                }
                else
                {
                    TbxPlayerPoints.Text = _game.Player.GetSecondHandValue().ToString();
                    TbxPlayerPoints.FontSize = 75;
                    TbxPlayerPoints.Margin = new Thickness(74, 158, 80, 53);
                }

                //Wenn der Spieler den Wert 21 hat, dann kann er nicht mehr Karten ziehen oder automatische Aktion ausführen
                if (_game.Player.GetSecondHandValue() == 21)
                {
                    BtnAutoAction.IsEnabled = false;
                    BtnHit.IsEnabled = false;
                    BtnDouble.IsEnabled = false;
                    BtnSplit.IsEnabled = false;
                }

                //Wenn die Anzahl der Karten weniger oder mehr als 2 ist, dann kann der Spieler nicht mehr verdoppeln
                BtnDouble.IsEnabled = GrdPlayerCards.Children.Count == 2;

                //Wenn der Spieler den Status Bust hat, dann ist das Spiel zu Ende (ohne dass der Dealer Karten ziehen muss)
                if (_game.Player.GetSecondHandStatus() == HandStatus.Bust)
                {
                    btnStand_Click(sender, e);
                }
            }

            BtnSplit.IsEnabled = false;
        }

        private async void btnStand_Click(object sender, RoutedEventArgs e)
        {
            if (_game.Player.SecondHandCards.ToList().Count > 0 && _countStandClick == 0)
            {
                _playerCards = _game.Player.Cards.ToList();
                _splittedCards = _game.Player.SecondHandCards.ToList();

                GrdPlayerCards.Children.Clear();
                GrdPlayerSecondHandCards.Children.Clear();

                foreach (var allSecondHandCards in _splittedCards.Select(t => CreateCardImage(t, 40 * GrdPlayerCards.Children.Count)))
                {
                    GrdPlayerCards.Children.Add(allSecondHandCards);
                }

                foreach (var allFirstHandCards in _playerCards.Select(t => CreateCardImage(t, 40 * GrdPlayerSecondHandCards.Children.Count)))
                {
                    GrdPlayerSecondHandCards.Children.Add(allFirstHandCards);
                }

                //Status und Punkte des Spielers werden aktualisiert
                LblPlayerStatus.Content = _game.Player.GetSecondHandStatus().ToString();
                TbxPlayerPoints.Text = _game.Player.GetSecondHandValue().ToString();

                BtnAutoAction.IsEnabled = false;
                BtnHit.IsEnabled = true;
                BtnDouble.IsEnabled = false;

                _countStandClick++;
            }
            else
            {
                if (_game.Player.SecondHandCards.ToList().Count > 0 && _countStandClick > 0)
                {
                    //Spieler kann nicht mehr Karten ziehen oder das Spiel beenden
                    BtnAutoAction.Visibility = Visibility.Hidden;
                    BtnHit.Visibility = Visibility.Hidden;
                    BtnStand.Visibility = Visibility.Hidden;
                    BtnDouble.Visibility = Visibility.Hidden;
                    BtnSplit.Visibility = Visibility.Hidden;

                    //Audio im Hintergrund wird pausiert, da das Spiel bereits zu Ende ist
                    _casinoAudio.Pause();

                    //Wenn der Spieler weder den Status BlackJack, noch Bust hat, dann wird die Aktion Stand ausgeführt
                    if (_game.Player.GetSecondHandStatus() != HandStatus.BlackJack && _game.Player.GetSecondHandStatus() != HandStatus.Bust)
                    {
                        _game.Play(PlayerAction.Stand, true);
                    }

                    _game.PlayGameToEnd();

                    //Alle Karten des Dealers werden angezeigt
                    GrdDealerCards.Children.RemoveAt(1);

                    List<Card> cards = _game.Dealer.Cards.ToList();
                    for (int i = 1; i < cards.Count; i++)
                    {
                        Image cardImage = CreateCardImage(cards[i], 40 * GrdDealerCards.Children.Count);
                        GrdDealerCards.Children.Add(cardImage);
                    }

                    //Status und Punkte des Dealers werden aktualisiert
                    LblDealerStatus.Content = _game.Dealer.GetHandStatus() == HandStatus.TripleSeven ? "Normal" : _game.Dealer.GetHandStatus().ToString();

                    TbxDealerPoints.Text = _game.Dealer.GetHandValue().ToString();
                    TbxDealerPoints.FontSize = 75;
                    TbxDealerPoints.Margin = new Thickness(74, 158, 80, 53);

                    //Überprüfungen werden durchgeführt, damit man weiß, wer das Spiel gewonnen hat
                    if (_game.GetSecondHandWinner() == GameWinner.Player)
                    {
                        if (_game.Player.GetSecondHandStatus() == HandStatus.BlackJack)
                        {
                            ImgBlackJack.Visibility = Visibility.Visible;
                            await Task.Delay(1500);
                            ImgBlackJack.Visibility = Visibility.Hidden;
                        }

                        //Es wird gezeigt, dass der Spieler gewonnen hat
                        LblPlayerWins.Visibility = Visibility.Visible;

                        //Wenn der Spieler gewinnt, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\playerWin.mp3");
                        _win.Init(fileReader);
                        _win.Play();

                        //Wenn der Spieler gewinnt, dann wird sein Guthaben mehr
                        _player.Payout(_game.GetSecondHandWinRatio());

                        await Task.Delay(5500);

                        LblPlayerWins.Visibility = Visibility.Hidden;
                    }
                    else if (_game.GetSecondHandWinner() == GameWinner.Dealer)
                    {
                        //Wenn der Spieler den Status Bust hat, dann wird ihm gezeigt, dass er schon verloren hat
                        if (_game.Player.GetSecondHandStatus() == HandStatus.Bust)
                        {
                            ImgBusted.Visibility = Visibility.Visible;
                            await Task.Delay(1500);
                            ImgBusted.Visibility = Visibility.Hidden;
                        }

                        //Es wird gezeigt, dass der Dealer gewonnen hat
                        LblDealerWins.Visibility = Visibility.Visible;

                        //Wenn der Spieler verliert, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\playerLose.mp3");
                        _lose.Init(fileReader);
                        _lose.Play();

                        //Wenn der Spieler verliert, dann wird sein Guthaben geringer
                        _player.Payout(_game.GetSecondHandWinRatio());

                        await Task.Delay(5000);

                        LblDealerWins.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        //Wenn es unentschieden ist, dann wird auch diese Information dem Spieler mitgeteilt
                        LblNobodyWins.Visibility = Visibility.Visible;

                        _player.Payout(_game.GetSecondHandWinRatio());

                        await Task.Delay(2000);

                        LblNobodyWins.Visibility = Visibility.Hidden;
                    }

                    _player.Bet(_blackJackGame.PlayerBet / 2);

                    GrdPlayerCards.Children.Clear();
                    GrdPlayerSecondHandCards.Children.Clear();

                    LblSecondHand.Visibility = Visibility.Hidden;

                    foreach (var card in _playerCards.Select(t => CreateCardImage(t, 40 * GrdPlayerCards.Children.Count)))
                    {
                        GrdPlayerCards.Children.Add(card);
                    }

                    //Status und Punkte des Spielers werden aktualisiert
                    LblPlayerStatus.Content = _game.Player.GetHandStatus().ToString();
                    TbxPlayerPoints.Text = _game.Player.GetHandValue().ToString();
                    TbxPlayerPoints.FontSize = 75;
                    TbxPlayerPoints.Margin = new Thickness(74, 158, 80, 53);

                    //Wenn der Spieler weder den Status BlackJack, noch Bust hat, dann wird die Aktion Stand ausgeführt
                    if (_game.Player.GetHandStatus() != HandStatus.BlackJack && _game.Player.GetHandStatus() != HandStatus.Bust)
                    {
                        _game.Play(PlayerAction.Stand, false);
                    }

                    _game.PlayGameToEnd();

                    //Überprüfungen werden durchgeführt, damit man weiß, wer das Spiel gewonnen hat
                    if (_game.GetWinner() == GameWinner.Player)
                    {
                        if (_game.Player.GetHandStatus() == HandStatus.BlackJack)
                        {
                            ImgBlackJack.Visibility = Visibility.Visible;
                            await Task.Delay(1500);
                            ImgBlackJack.Visibility = Visibility.Hidden;
                        }

                        //Es wird gezeigt, dass der Spieler gewonnen hat
                        LblPlayerWins.Visibility = Visibility.Visible;

                        //Wenn der Spieler gewinnt, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\playerWin.mp3");
                        _win.Init(fileReader);
                        _win.Play();

                        //Wenn der Spieler gewinnt, dann wird sein Guthaben mehr
                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(5500);

                        LblPlayerWins.Visibility = Visibility.Hidden;
                    }
                    else if (_game.GetWinner() == GameWinner.Dealer)
                    {
                        //Wenn der Spieler den Status Bust hat, dann wird ihm gezeigt, dass er schon verloren hat
                        if (_game.Player.GetHandStatus() == HandStatus.Bust)
                        {
                            ImgBusted.Visibility = Visibility.Visible;
                            await Task.Delay(1500);
                            ImgBusted.Visibility = Visibility.Hidden;
                        }

                        //Es wird gezeigt, dass der Dealer gewonnen hat
                        LblDealerWins.Visibility = Visibility.Visible;

                        //Wenn der Spieler verliert, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\playerLose.mp3");
                        _lose.Init(fileReader);
                        _lose.Play();

                        //Wenn der Spieler verliert, dann wird sein Guthaben geringer
                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(5000);

                        LblDealerWins.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        //Wenn es unentschieden ist, dann wird auch diese Information dem Spieler mitgeteilt
                        LblNobodyWins.Visibility = Visibility.Visible;

                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(2000);

                        LblNobodyWins.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    //Spieler kann nicht mehr Karten ziehen oder das Spiel beenden
                    BtnAutoAction.Visibility = Visibility.Hidden;
                    BtnHit.Visibility = Visibility.Hidden;
                    BtnStand.Visibility = Visibility.Hidden;
                    BtnDouble.Visibility = Visibility.Hidden;
                    BtnSplit.Visibility = Visibility.Hidden;

                    //Audio im Hintergrund wird pausiert, da das Spiel bereits zu Ende ist
                    _casinoAudio.Pause();

                    //Wenn der Spieler weder den Status BlackJack, noch Bust hat, dann wird die Aktion Stand ausgeführt
                    if (_game.Player.GetHandStatus() != HandStatus.BlackJack && _game.Player.GetHandStatus() != HandStatus.Bust)
                    {
                        _game.Play(PlayerAction.Stand, false);
                    }

                    _game.PlayGameToEnd();

                    //Karten des Dealers werden angezeigt
                    GrdDealerCards.Children.RemoveAt(1);

                    List<Card> cards = _game.Dealer.Cards.ToList();
                    for (int i = 1; i < cards.Count; i++)
                    {
                        Image cardImage = CreateCardImage(cards[i], 40 * GrdDealerCards.Children.Count);
                        GrdDealerCards.Children.Add(cardImage);
                    }

                    //Punkte des Spielers wird aktualisiert
                    TbxPlayerPoints.Text = _game.Player.GetHandValue().ToString();
                    TbxPlayerPoints.FontSize = 75;
                    TbxPlayerPoints.Margin = new Thickness(74, 158, 80, 53);

                    //Status und Punkte des Dealers werden aktualisiert
                    LblDealerStatus.Content = _game.Dealer.GetHandStatus() == HandStatus.TripleSeven ? "Normal" : _game.Dealer.GetHandStatus().ToString();

                    TbxDealerPoints.Text = _game.Dealer.GetHandValue().ToString();
                    TbxDealerPoints.FontSize = 75;
                    TbxDealerPoints.Margin = new Thickness(74, 158, 80, 53);

                    //Überprüfungen werden durchgeführt, damit man weiß, wer das Spiel gewonnen hat
                    if (_game.GetWinner() == GameWinner.Player)
                    {
                        if (_game.Player.GetHandStatus() == HandStatus.BlackJack)
                        {
                            ImgBlackJack.Visibility = Visibility.Visible;
                            await Task.Delay(1500);
                            ImgBlackJack.Visibility = Visibility.Hidden;
                        }

                        //Es wird gezeigt, dass der Spieler gewonnen hat
                        LblPlayerWins.Visibility = Visibility.Visible;

                        //Wenn der Spieler gewinnt, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\playerWin.mp3");
                        _win.Init(fileReader);
                        _win.Play();

                        //Wenn der Spieler gewinnt, dann wird sein Guthaben mehr
                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(5500);

                        LblPlayerWins.Visibility = Visibility.Hidden;
                    }
                    else if (_game.GetWinner() == GameWinner.Dealer)
                    {
                        //Wenn der Spieler den Status Bust hat, dann wird ihm gezeigt, dass er schon verloren hat
                        if (_game.Player.GetHandStatus() == HandStatus.Bust)
                        {
                            ImgBusted.Visibility = Visibility.Visible;
                            await Task.Delay(1500);
                            ImgBusted.Visibility = Visibility.Hidden;
                        }

                        //Es wird gezeigt, dass der Dealer gewonnen hat
                        LblDealerWins.Visibility = Visibility.Visible;

                        //Wenn der Spieler verliert, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\playerLose.mp3");
                        _lose.Init(fileReader);
                        _lose.Play();

                        //Wenn der Spieler verliert, dann wird sein Guthaben geringer
                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(5000);

                        LblDealerWins.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        //Wenn es unentschieden ist, dann wird auch diese Information dem Spieler mitgeteilt
                        LblNobodyWins.Visibility = Visibility.Visible;

                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(2000);

                        LblNobodyWins.Visibility = Visibility.Hidden;
                    }
                }

                //Spieler kann entweder ein neues Spiel starten oder die Seite schließen
                BtnNewGame.Visibility = Visibility.Visible;
                BtnExit.Visibility = Visibility.Visible;

                if (_player.Balance < _blackJackGame.PlayerBet)
                {
                    BtnNewGame.IsEnabled = false;
                }

                //Spieler und Dealer haben keine Punkte mehr
                TbxPlayerPoints.Text = "0";
                TbxDealerPoints.Text = "0";

                //Karten des Spielers und Dealers werden wieder zurückgesammelt
                GrdPlayerCards.Children.Clear();
                GrdDealerCards.Children.Clear();

                //Status von Spieler und Dealer werden auf Normal gesetzt 
                LblPlayerStatus.Content = "Normal";
                LblDealerStatus.Content = "Normal";

                //Aktuelles Guthaben des Spielers wird angezeigt
                TbxPlayerBet.Text = _blackJackGame.PlayerBet + " €";
                TblPlayerBalance.Text = "Budget: " + _player.Balance;

                //Schreibt das Kapital des Spielers in eine Datei rein
                await using Stream stream = new FileStream($"{_player.GetName()}.json", FileMode.Create, FileAccess.Write);
                _player.WriteJson(stream);
                stream.Close();
            }
        }

        private void btnDouble_Click(object sender, RoutedEventArgs e)
        {
            //Wette des Spielers wird verdoppelt und angezeigt
            int playerBet = Convert.ToInt32(TbxPlayerBet.Text.Split(' ')[0]);

            _player.Bet(_blackJackGame.PlayerBet);

            TbxPlayerBet.Text = playerBet * 2 + " €";
            TblPlayerBalance.Text = "Budget: " + _player.Balance;

            if (GrdPlayerCards.Children.Count == _game.Player.Cards.ToList().Count && GrdPlayerCards.Children.Count != _game.Player.SecondHandCards.ToList().Count)
            {
                //Wenn der Spieler auf Double klickt, dann wird diese Aktion ausgeführt
                _game.Play(PlayerAction.Double, false);

                //Karten des Spielers werden aktualisiert
                List<Card> cards = _game.Player.Cards.ToList();
                Image cardImage = CreateCardImage(cards[^1], 40 * GrdPlayerCards.Children.Count);
                GrdPlayerCards.Children.Add(cardImage);

                //Status und Punkte des Spielers werden aktualisiert
                LblPlayerStatus.Content = _game.Player.GetHandStatus().ToString();
                TbxPlayerPoints.Text = _game.Player.GetHandValue().ToString();
            }
            else
            {
                //Wenn der Spieler auf Double klickt, dann wird diese Aktion ausgeführt
                _game.Play(PlayerAction.Double, true);

                //Karten des Spielers werden aktualisiert
                List<Card> cards = _game.Player.SecondHandCards.ToList();
                Image cardImage = CreateCardImage(cards[^1], 40 * GrdPlayerCards.Children.Count);
                GrdPlayerCards.Children.Add(cardImage);

                //Status und Punkte des Spielers werden aktualisiert
                LblPlayerStatus.Content = _game.Player.GetSecondHandStatus().ToString();
                TbxPlayerPoints.Text = _game.Player.GetSecondHandValue().ToString();
            }

            btnStand_Click(sender, e);
        }

        private void btnSplit_Click(object sender, RoutedEventArgs e)
        {
            //Wenn der Spieler auf Split klickt, dann wird diese Aktion ausgeführt
            _game.Play(PlayerAction.Split, true);

            _game.Play(PlayerAction.Hit, false);

            _player.Bet((_blackJackGame.PlayerBet / 2) * (-1));

            LblSecondHand.Visibility = Visibility.Visible;

            TbxPlayerBet.Text = _blackJackGame.PlayerBet / 2 + " €";

            GrdPlayerCards.Children.RemoveAt(1);

            //Alle Karten und die Punkte des Spielers werden aktualisiert und angezeigt
            List<Card> cards = _game.Player.Cards.ToList();
            Image cardImage = CreateCardImage(cards[^1], 40 * GrdPlayerCards.Children.Count);
            GrdPlayerCards.Children.Add(cardImage);

            TbxPlayerPoints.Text = _game.Player.GetHandValue().ToString();

            //Karte in der zweiten Hand des Spielers wird angezeigt
            _splittedCards = _game.Player.SecondHandCards.ToList();
            Image allCards = CreateCardImage(_splittedCards.First(), 40 * GrdPlayerSecondHandCards.Children.Count);
            GrdPlayerSecondHandCards.Children.Add(allCards);

            if (_game.Player.GetHandStatus() == HandStatus.BlackJack)
            {
                BtnAutoAction.IsEnabled = false;
                BtnHit.IsEnabled = false;
                BtnDouble.IsEnabled = false;
            }

            BtnSplit.IsEnabled = false;
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            //Neues Spiel kann nicht mehr gestartet werden
            BtnNewGame.Visibility = Visibility.Hidden;
            BtnExit.Visibility = Visibility.Hidden;

            //Wenn der Spieler ein neues Spiel startet, dann kann er wieder Karten ziehen oder auf Stand drücken
            BtnAutoAction.Visibility = Visibility.Visible;
            BtnAutoAction.IsEnabled = true;
            BtnHit.Visibility = Visibility.Visible;
            BtnHit.IsEnabled = true;
            BtnStand.Visibility = Visibility.Visible;
            BtnDouble.Visibility = Visibility.Visible;
            BtnDouble.IsEnabled = true;
            BtnSplit.Visibility = Visibility.Visible;
            BtnSplit.IsEnabled = true;

            //Audio wird weiter abgespielt
            _casinoAudio.PlaybackStopped += (_, _) =>
            {
                // Reset the position to the beginning when playback stops
                if (_fileReader.Position >= _fileReader.Length)
                {
                    _fileReader.Position = 0;
                    _casinoAudio.Play();
                }
            };

            _casinoAudio.Play();

            //Anzahl der Klicke auf Stand-Button wird wieder auf 0 gesetzt
            _countStandClick = 0;

            //Hand der Spieler wird geleert
            _hand.RemoveCards();
            _playerHand.RemoveCards();
            _dealerHand.RemoveCards();

            //Spiel wird gestartet …
            _game = _gameFactory.CreateGame(_blackJackGame.Table, _player);
            _game.StartGame();

            //Spieler macht seine Wette
            _player.Bet(_blackJackGame.PlayerBet);

            TblPlayerBalance.Text = "Budget: " + _player.Balance;

            //Karten des Spielers werden angezeigt
            List<Card> playerCards = _game.Player.Cards.ToList();
            foreach (Card card in playerCards)
            {
                Image cardImage = CreateCardImage(card, 40 * GrdPlayerCards.Children.Count);
                GrdPlayerCards.Children.Add(cardImage);

                if (_game.Player.GetHandStatus() != HandStatus.BlackJack && card.Value == CardValue.Ace)
                {
                    int playerCardValue = _game.Player.GetHandValue();
                    TbxPlayerPoints.Text = $"{playerCardValue - 10}/{playerCardValue}";
                    TbxPlayerPoints.FontSize = 55;
                    TbxPlayerPoints.Margin = new Thickness(74, 181, 80, 53);
                }
            }
            _hand.AddCard(playerCards.First());

            //Status und Punkte des Spielers werden aktualisiert
            LblPlayerStatus.Content = _game.Player.GetHandStatus().ToString();
            if (TbxPlayerPoints.Text == "0")
            {
                TbxPlayerPoints.Text = _game.Player.GetHandValue().ToString();
            }

            //Erste Karte des Dealers wird angezeigt
            _firstCard = _game.Dealer.FirstCard;
            _dealerHand.AddCard(_firstCard);
            GrdDealerCards.Children.Add(CreateCardImage(_firstCard, 40 * GrdDealerCards.Children.Count));

            //Zweite Karte des Dealers ist zuerst unsichtbar
            GrdDealerCards.Children.Add(CreateCardImage(_firstCard, 40 * GrdDealerCards.Children.Count, "Resources/cards/Card-Skin-Red.png"));

            //Punkte der ersten Karte des Dealers wird angezeigt
            if (_firstCard.Value == CardValue.Ace)
            {
                TbxDealerPoints.Text = $"{_dealerHand.Sum - 10}/{_dealerHand.Sum}";
                TbxDealerPoints.FontSize = 55;
                TbxDealerPoints.Margin = new Thickness(74, 181, 80, 53);
            }
            else
            {
                TbxDealerPoints.Text = _dealerHand.Sum.ToString();
            }

            //Wenn der Spieler schon am Anfang des Spiels den Status BlackJack hat, dann kann er nicht mehr eine Karte ziehen
            if (_game.Player.GetHandStatus() == HandStatus.BlackJack)
            {
                BtnAutoAction.IsEnabled = false;
                BtnHit.IsEnabled = false;
                BtnDouble.IsEnabled = false;
            }

            if (_hand.Sum != (_player.GetHandValue() - _hand.Sum))
            {
                BtnSplit.IsEnabled = false;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            _blackJackGame.Show();
        }

        /// <summary>
        /// Erstellt Image von der Karte und liefert es zurück
        /// </summary>
        /// <param name="card">Karte</param>
        /// <param name="offset">Abstand der Karten zueinander</param>
        /// /// <param name="path">Pfad für die Karte</param>
        /// <returns></returns>
        private Image CreateCardImage(Card card, double offset, string path = "")
        {
            Image image = new Image
            {
                Source = path == "" ? new BitmapImage(new Uri($"Resources/cards/{card.Color}s-{card.Value}.png", UriKind.Relative)) : new BitmapImage(new Uri(path, UriKind.Relative)),
                Width = 195,
                Height = 220
            };

            var storyboard = new Storyboard();
            var rotateAnimation = new DoubleAnimation
            {
                From = 0,
                To = 358 + (offset / 35),
                Duration = new Duration(TimeSpan.FromSeconds(0.7))
            };
            var rotateTransform = new RotateTransform();
            image.RenderTransform = rotateTransform;
            rotateTransform.CenterX = image.Width / 2;
            rotateTransform.CenterY = image.Height / 2;
            storyboard.Children.Add(rotateAnimation);
            Storyboard.SetTarget(rotateAnimation, image);
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
            storyboard.Begin();

            Grid.SetColumn(image, (int)(offset / 40));
            return image;
        }
        #endregion
    }
}

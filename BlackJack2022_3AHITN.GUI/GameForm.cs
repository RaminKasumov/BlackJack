using System.Drawing.Drawing2D;
using System.Reflection;
using System.Resources;
using BlackJack2022_3AHITN.Lib;
using NAudio.Wave;

namespace BlackJack2022_3AHITN.GUI
{
    public partial class GameForm : Form
    {
        #region instancevariables
        readonly BlackJackForm _blackJackForm = null!;
        readonly WaveOut _casinoAudio = new WaveOut();
        readonly WaveOut _win = new WaveOut();
        readonly WaveOut _lose = new WaveOut();
        readonly PlayerFactory _playerFactory = new PlayerFactory();
        readonly GameFactory _gameFactory = new GameFactory();
        ResourceManager _resourceManager = null!;
        Player _player = null!;
        readonly Hand _playerHand = new Hand();
        readonly Hand _dealerHand = new Hand();
        IGame _game = null!;
        Card _card = null!;
        List<Card> _playerCards = new List<Card>();
        List<Card> _splittedCards = new List<Card>();
        int _countStandClick;
        readonly int _cardWidth = 90;
        IPlayerStrategy _playerStrategy = null!;
        #endregion

        #region property
        /// <summary>
        /// Spieler wird ausgegeben
        /// </summary>
        internal Player Player => _player;

        #endregion

        #region constructors
        public GameForm()
        {
            InitializeComponent();
        }

        public GameForm(BlackJackForm blackJackForm)
        {
            _blackJackForm = blackJackForm;
            InitializeComponent();
            InitializeData();
        }
        #endregion

        #region methods
        private async void InitializeData()
        {
            //Form von Buttons wird kreisförmig gemacht
            GraphicsPath gpDouble = new GraphicsPath();
            gpDouble.AddEllipse(0, 0, btnDouble.Width, btnDouble.Height);
            btnDouble.Region = new Region(gpDouble);

            GraphicsPath gpSplit = new GraphicsPath();
            gpSplit.AddEllipse(0, 0, btnSplit.Width, btnSplit.Height);
            btnSplit.Region = new Region(gpSplit);

            GraphicsPath gpHit = new GraphicsPath();
            gpHit.AddEllipse(0, 0, btnHit.Width, btnHit.Height);
            btnHit.Region = new Region(gpHit);

            GraphicsPath gpStand = new GraphicsPath();
            gpStand.AddEllipse(0, 0, btnStand.Width, btnStand.Height);
            btnStand.Region = new Region(gpStand);

            GraphicsPath gpAuto = new GraphicsPath();
            gpAuto.AddEllipse(0, 0, btnAutoAction.Width, btnAutoAction.Height);
            btnAutoAction.Region = new Region(gpAuto);

            //Es wird überprüft, welche Strategie vom Spieler ausgewählt wurde
            if (_blackJackForm.Strategy == "Hard hands")
            {
                _playerStrategy = new PlayerStrategyHardHands();
            }
            else if (_blackJackForm.Strategy == "Soft hands")
            {
                _playerStrategy = new PlayerStrategySoftHands();
            }

            if (!File.Exists($"{_blackJackForm.PlayerName}.json"))
            {
                _player = (Player)_playerFactory.CreatePlayer(_blackJackForm.PlayerName, _blackJackForm.Table, _playerStrategy);
            }
            else
            {
                //Liest das Guthaben des Spielers von der Datei ab
                await using Stream stream = new FileStream($"{_blackJackForm.PlayerName}.json", FileMode.Open, FileAccess.Read);
                _player = Player.ReadJson(stream);
                _player.CardSource = new SevenCardSource();
                _player.SetPlayerStrategy(_playerStrategy);
                stream.Close();
            }

            _game = _gameFactory.CreateGame(_blackJackForm.Table, _player);

            //Audio im Casino wird im Hintergrund abgespielt
            Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\BlackJack2022_3AHITN\casino audio.mp3");
            _casinoAudio.Init(fileReader);
            _casinoAudio.Play();

            //Spieler macht seine Wette
            _player.Bet(_blackJackForm.PlayerBet);

            //Spiel wird jetzt gestartet …
            _game.StartGame();

            //Alle labels werden mit nötigen Informationen befüllt
            lblNameOfTable.Text = _blackJackForm.Table.Name;
            lblBetinEuro.Text = _blackJackForm.PlayerBet + @" €";
            lblPlayer.Text = _game.Player.GetName();

            //ResourceManager wird mit Bildern von allen Karten befüllt
            _resourceManager = new ResourceManager("BlackJack2022_3AHITN.GUI.Properties.Resources", Assembly.GetExecutingAssembly());
            await Task.Delay(500);

            //Spieler bekommt seine erste Karte und Status und Punkte des Spielers werden angezeigt
            _playerCards = _game.Player.Cards.ToList();
            pnlPlayerCards.Controls.Add(CreateCardImage(0, _playerCards.First(), _playerCards.Count));
            _playerHand.AddCard(_playerCards.First());
            lblPlayerStatus.Text = @"Status: " + _game.Player.GetHandStatus();
            lblPlayerInfo.Text = @"Punkte: " + _playerHand.Sum;
            await Task.Delay(500);

            //Dealer bekommt seine erste Karte und die Punkte des Dealers werden angezeigt
            _card = _game.Dealer.FirstCard;
            pnlDealerCards.Controls.Add(CreateCardImage(0, _card, _game.Dealer.Cards.Count()));
            _dealerHand.AddCard(_card);
            lblDealerStatus.Text = @"Status: Normal";
            lblDealerInfo.Text = @"Punkte: " + _dealerHand.Sum;
            await Task.Delay(500);

            //Spieler bekommt seine zweite Karte und die Punkte des Spielers werden aktualisiert und angezeigt
            PictureBox pbxSecondCard = CreateCardImage(1, _playerCards[1], _playerCards.Count);
            pnlPlayerCards.Controls.Add(pbxSecondCard);
            pbxSecondCard.BringToFront();
            lblPlayerInfo.Text = @"Punkte: " + _game.Player.GetHandValue();
            await Task.Delay(500);

            //Dealer bekommt seine zweite Karte, aber sie ist unsichtbar
            int distanceBetweenCards = _cardWidth / 3;

            PictureBox pbxClosedDealerCard = new PictureBox();
            pbxClosedDealerCard.Image = (Bitmap)_resourceManager.GetObject("Card_Skin_Red")!;
            pbxClosedDealerCard.Size = new Size(_cardWidth, 120);
            pbxClosedDealerCard.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxClosedDealerCard.BorderStyle = BorderStyle.Fixed3D;
            pbxClosedDealerCard.Location = new Point(distanceBetweenCards, 0);
            pnlDealerCards.Controls.Add(pbxClosedDealerCard);
            pbxClosedDealerCard.BringToFront();

            //Wenn der Spieler schon am Anfang des Spiels den Status BlackJack hat, dann darf er nur auf Stand drücken
            if (_game.Player.GetHandStatus() == HandStatus.BlackJack)
            {
                btnAutoAction.Enabled = false;
                btnHit.Enabled = false;
                btnDouble.Enabled = false;
            }

            //Wenn die Karten des Spielers den gleichen Wert haben, dann kann der Spieler teilen
            if (_playerHand.Sum == (_player.GetHandValue() - _playerHand.Sum))
            {
                btnSplit.Enabled = true;
            }
        }

        private void btnAutoAction_Click(object sender, EventArgs e)
        {
            _game.Play();

            pnlPlayerCards.Controls.Clear();

            //Alle Karten und Status und Punkte des Spielers werden aktualisiert und angezeigt
            List<Card> cards = _game.Player.Cards.ToList();
            for (int i = 0; i < cards.Count; i++)
            {
                PictureBox allCards = CreateCardImage(i, cards[i], cards.Count);
                pnlPlayerCards.Controls.Add(allCards);
                allCards.BringToFront();
            }

            //Status und Punkte des Spielers werden aktualisiert
            lblPlayerStatus.Text = @"Status: " + _game.Player.GetHandStatus();
            lblPlayerInfo.Text = @"Punkte: " + _game.Player.GetHandValue();

            //Wenn der Spieler den Wert 21 hat, dann kann er nicht mehr Karten ziehen oder automatische Aktion ausführen
            if (_game.Player.GetHandValue() == 21)
            {
                btnAutoAction.Enabled = false;
                btnHit.Enabled = false;
                btnDouble.Enabled = false;
                btnSplit.Enabled = false;
            }

            //Wenn die Anzahl der Karten weniger oder mehr als 2 ist, dann kann der Spieler nicht mehr verdoppeln
            btnDouble.Enabled = pnlPlayerCards.Controls.Count == 2;

            if (_game.Player.HasFinished)
            {
                btnStand_Click(sender, e);
            }

            btnSplit.Enabled = false;
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            if (pnlPlayerCards.Controls.Count == _game.Player.Cards.ToList().Count && pnlPlayerCards.Controls.Count != _game.Player.SecondHandCards.ToList().Count)
            {
                //Wenn der Spieler auf Hit klickt, dann wird diese Aktion ausgeführt
                _game.Play(PlayerAction.Hit, false);

                pnlPlayerCards.Controls.Clear();

                //Alle Karten und Status und Punkte des Spielers werden aktualisiert und angezeigt
                List<Card> cards = _game.Player.Cards.ToList();
                for (int i = 0; i < cards.Count; i++)
                {
                    PictureBox allCards = CreateCardImage(i, cards[i], cards.Count);
                    pnlPlayerCards.Controls.Add(allCards);
                    allCards.BringToFront();
                }

                //Status und Punkte des Spielers werden aktualisiert
                lblPlayerStatus.Text = @"Status: " + _game.Player.GetHandStatus();
                lblPlayerInfo.Text = @"Punkte: " + _game.Player.GetHandValue();

                //Wenn der Spieler den Wert 21 hat, dann kann er nicht mehr Karten ziehen oder automatische Aktion ausführen
                if (_game.Player.GetHandValue() == 21)
                {
                    btnAutoAction.Enabled = false;
                    btnHit.Enabled = false;
                    btnDouble.Enabled = false;
                    btnSplit.Enabled = false;
                }

                //Wenn die Anzahl der Karten weniger oder mehr als 2 ist, dann kann der Spieler nicht mehr verdoppeln
                btnDouble.Enabled = pnlPlayerCards.Controls.Count == 2;

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

                pnlPlayerCards.Controls.Clear();

                //Alle Karten und Status und Punkte des Spielers werden aktualisiert und angezeigt
                List<Card> secondHandCards = _game.Player.SecondHandCards.ToList();
                for (int i = 0; i < secondHandCards.Count; i++)
                {
                    PictureBox allCards = CreateCardImage(i, secondHandCards[i], secondHandCards.Count);
                    pnlPlayerCards.Controls.Add(allCards);
                    allCards.BringToFront();
                }

                //Status und Punkte des Spielers werden aktualisiert
                lblPlayerStatus.Text = @"Status: " + _game.Player.GetSecondHandStatus();
                lblPlayerInfo.Text = @"Punkte: " + _game.Player.GetSecondHandValue();

                //Wenn der Spieler den Wert 21 hat, dann kann er nicht mehr Karten ziehen oder automatische Aktion ausführen
                if (_game.Player.GetSecondHandValue() == 21)
                {
                    btnAutoAction.Enabled = false;
                    btnHit.Enabled = false;
                    btnDouble.Enabled = false;
                    btnSplit.Enabled = false;
                }

                //Wenn die Anzahl der Karten weniger oder mehr als 2 ist, dann kann der Spieler nicht mehr verdoppeln
                btnDouble.Enabled = pnlPlayerCards.Controls.Count == 2;

                //Wenn der Spieler den Status Bust hat, dann ist das Spiel zu Ende (ohne dass der Dealer Karten ziehen muss)
                if (_game.Player.GetSecondHandStatus() == HandStatus.Bust)
                {
                    btnStand_Click(sender, e);
                }
            }

            btnSplit.Enabled = false;
        }

        private async void btnStand_Click(object sender, EventArgs e)
        {
            if (_game.Player.SecondHandCards.ToList().Count > 0 && _countStandClick == 0)
            {
                _playerCards = _game.Player.Cards.ToList();
                _splittedCards = _game.Player.SecondHandCards.ToList();

                pnlPlayerCards.Controls.Clear();
                pnlPlayerSplitCards.Controls.Clear();

                for (int i = 0; i < _splittedCards.Count; i++)
                {
                    PictureBox allSecondHandCards = CreateCardImage(i, _splittedCards[i], _splittedCards.Count);
                    pnlPlayerCards.Controls.Add(allSecondHandCards);
                    allSecondHandCards.BringToFront();
                }

                for (int i = 0; i < _playerCards.Count; i++)
                {
                    PictureBox allFirstHandCards = CreateCardImage(i, _playerCards[i], _playerCards.Count);
                    pnlPlayerSplitCards.Controls.Add(allFirstHandCards);
                    allFirstHandCards.BringToFront();
                }

                //Status und Punkte des Spielers werden aktualisiert
                lblPlayerStatus.Text = @"Status: " + _game.Player.GetSecondHandStatus();
                lblPlayerInfo.Text = @"Punkte: " + _game.Player.GetSecondHandValue();

                btnAutoAction.Enabled = false;
                btnHit.Enabled = true;
                btnDouble.Enabled = false;

                _countStandClick++;
            }
            else
            {
                if (_game.Player.SecondHandCards.ToList().Count > 0 && _countStandClick > 0)
                {
                    //Spieler kann nicht mehr Karten ziehen oder das Spiel beenden
                    btnAutoAction.Enabled = false;
                    btnHit.Enabled = false;
                    btnStand.Enabled = false;
                    btnDouble.Enabled = false;
                    btnSplit.Enabled = false;

                    //Audio im Hintergrund wird gestoppt, da das Spiel bereits zu Ende ist
                    _casinoAudio.Stop();

                    //Wenn der Spieler weder den Status BlackJack, noch Bust hat, dann wird die Aktion Stand ausgeführt
                    if (_game.Player.GetSecondHandStatus() != HandStatus.BlackJack && _game.Player.GetSecondHandStatus() != HandStatus.Bust)
                    {
                        _game.Play(PlayerAction.Stand, true);
                    }

                    _game.PlayGameToEnd();

                    //Alle Karten des Dealers werden angezeigt
                    pnlDealerCards.Controls.Clear();

                    List<Card> cards = _game.Dealer.Cards.ToList();
                    for (int i = 0; i < cards.Count; i++)
                    {
                        PictureBox dealerCards = CreateCardImage(i, cards[i], cards.Count);
                        pnlDealerCards.Controls.Add(dealerCards);
                        dealerCards.BringToFront();
                    }

                    //Status und Punkte des Dealers werden aktualisiert
                    if (_game.Dealer.GetHandStatus() == HandStatus.TripleSeven)
                    {
                        lblDealerStatus.Text = @"Status: Normal";
                    }
                    else
                    {
                        lblDealerStatus.Text = @"Status: " + _game.Dealer.GetHandStatus();
                    }

                    lblDealerInfo.Text = @"Punkte: " + _game.Dealer.GetHandValue();

                    //Überprüfungen werden durchgeführt, damit man weiß, wer das Spiel gewonnen hat
                    if (_game.GetSecondHandWinner() == GameWinner.Player)
                    {
                        if (_game.Player.GetSecondHandStatus() == HandStatus.BlackJack)
                        {
                            pbxBlackJack.Visible = true;
                            await Task.Delay(1500);
                            pbxBlackJack.Visible = false;
                        }

                        //Es wird gezeigt, dass der Spieler gewonnen hat
                        lblPlayerWon.Visible = true;

                        //Wenn der Spieler gewinnt, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\BlackJack2022_3AHITN\playerWin.mp3");
                        _win.Init(fileReader);
                        _win.Play();

                        //Wenn der Spieler gewinnt, dann wird sein Guthaben mehr
                        _player.Payout(_game.GetSecondHandWinRatio());

                        await Task.Delay(5500);

                        lblPlayerWon.Visible = false;
                    }
                    else if (_game.GetSecondHandWinner() == GameWinner.Dealer)
                    {
                        //Wenn der Spieler den Status Bust hat, dann wird ihm gezeigt, dass er schon verloren hat
                        if (_game.Player.GetSecondHandStatus() == HandStatus.Bust)
                        {
                            pbxBusted.Visible = true;
                            await Task.Delay(1500);
                            pbxBusted.Visible = false;
                        }

                        //Es wird gezeigt, dass der Dealer gewonnen hat
                        lblDealerWon.Visible = true;

                        //Wenn der Spieler verliert, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\BlackJack2022_3AHITN\playerLose.mp3");
                        _lose.Init(fileReader);
                        _lose.Play();

                        //Wenn der Spieler verliert, dann wird sein Guthaben geringer
                        _player.Payout(_game.GetSecondHandWinRatio());

                        await Task.Delay(5000);

                        lblDealerWon.Visible = false;
                    }
                    else
                    {
                        //Wenn es unentschieden ist, dann wird auch diese Information dem Spieler mitgeteilt
                        lblPush.Visible = true;

                        _player.Payout(_game.GetSecondHandWinRatio());

                        await Task.Delay(2000);

                        lblPush.Visible = false;
                    }

                    _player.Bet(_blackJackForm.PlayerBet / 2);

                    pnlPlayerCards.Controls.Clear();
                    pnlPlayerSplitCards.Controls.Clear();

                    lblSecondHand.Visible = false;

                    for (int i = 0; i < _playerCards.Count; i++)
                    {
                        PictureBox card = CreateCardImage(i, _playerCards[i], _playerCards.Count);
                        pnlPlayerCards.Controls.Add(card);
                        card.BringToFront();
                    }

                    //Status und Punkte des Spielers werden aktualisiert
                    lblPlayerStatus.Text = @"Status: " + _game.Player.GetHandStatus();
                    lblPlayerInfo.Text = @"Punkte: " + _game.Player.GetHandValue();

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
                            pbxBlackJack.Visible = true;
                            await Task.Delay(1500);
                            pbxBlackJack.Visible = false;
                        }

                        //Es wird gezeigt, dass der Spieler gewonnen hat
                        lblPlayerWon.Visible = true;

                        //Wenn der Spieler gewinnt, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\BlackJack2022_3AHITN\playerWin.mp3");
                        _win.Init(fileReader);
                        _win.Play();

                        //Wenn der Spieler gewinnt, dann wird sein Guthaben mehr
                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(5500);
                    }
                    else if (_game.GetWinner() == GameWinner.Dealer)
                    {
                        //Wenn der Spieler den Status Bust hat, dann wird ihm gezeigt, dass er schon verloren hat
                        if (_game.Player.GetHandStatus() == HandStatus.Bust)
                        {
                            pbxBusted.Visible = true;
                            await Task.Delay(1500);
                            pbxBusted.Visible = false;
                        }

                        //Es wird gezeigt, dass der Dealer gewonnen hat
                        lblDealerWon.Visible = true;

                        //Wenn der Spieler verliert, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\BlackJack2022_3AHITN\playerLose.mp3");
                        _lose.Init(fileReader);
                        _lose.Play();

                        //Wenn der Spieler verliert, dann wird sein Guthaben geringer
                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(5000);
                    }
                    else
                    {
                        //Wenn es unentschieden ist, dann wird auch diese Information dem Spieler mitgeteilt
                        lblPush.Visible = true;

                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(2000);
                    }
                }
                else
                {
                    //Spieler kann nicht mehr Karten ziehen oder das Spiel beenden
                    btnAutoAction.Enabled = false;
                    btnHit.Enabled = false;
                    btnStand.Enabled = false;
                    btnDouble.Enabled = false;
                    btnSplit.Enabled = false;

                    //Audio im Hintergrund wird gestoppt, da das Spiel bereits zu Ende ist
                    _casinoAudio.Stop();

                    //Wenn der Spieler weder den Status BlackJack, noch Bust hat, dann wird die Aktion Stand ausgeführt
                    if (_game.Player.GetHandStatus() != HandStatus.BlackJack && _game.Player.GetHandStatus() != HandStatus.Bust)
                    {
                        _game.Play(PlayerAction.Stand, false);
                    }

                    _game.PlayGameToEnd();

                    //Alle Karten des Dealers werden angezeigt
                    pnlDealerCards.Controls.Clear();
                    List<Card> cards = _game.Dealer.Cards.ToList();
                    for (int i = 0; i < cards.Count; i++)
                    {
                        PictureBox dealerCards = CreateCardImage(i, cards[i], cards.Count);
                        pnlDealerCards.Controls.Add(dealerCards);
                        dealerCards.BringToFront();
                    }

                    //Status und Punkte des Dealers werden aktualisiert
                    if (_game.Dealer.GetHandStatus() == HandStatus.TripleSeven)
                    {
                        lblDealerStatus.Text = @"Status: Normal";
                    }
                    else
                    {
                        lblDealerStatus.Text = @"Status: " + _game.Dealer.GetHandStatus();
                    }

                    lblDealerInfo.Text = @"Punkte: " + _game.Dealer.GetHandValue();

                    //Überprüfungen werden durchgeführt, damit man weiß, wer das Spiel gewonnen hat
                    if (_game.GetWinner() == GameWinner.Player)
                    {
                        if (_game.Player.GetHandStatus() == HandStatus.BlackJack)
                        {
                            pbxBlackJack.Visible = true;
                            await Task.Delay(1500);
                            pbxBlackJack.Visible = false;
                        }

                        //Es wird gezeigt, dass der Spieler gewonnen hat
                        lblPlayerWon.Visible = true;

                        //Wenn der Spieler gewinnt, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\BlackJack2022_3AHITN\playerWin.mp3");
                        _win.Init(fileReader);
                        _win.Play();

                        //Wenn der Spieler gewinnt, dann wird sein Guthaben mehr
                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(5500);
                    }
                    else if (_game.GetWinner() == GameWinner.Dealer)
                    {
                        //Wenn der Spieler den Status Bust hat, dann wird ihm gezeigt, dass er schon verloren hat
                        if (_game.Player.GetHandStatus() == HandStatus.Bust)
                        {
                            pbxBusted.Visible = true;
                            await Task.Delay(1500);
                            pbxBusted.Visible = false;
                        }

                        //Es wird gezeigt, dass der Dealer gewonnen hat
                        lblDealerWon.Visible = true;

                        //Wenn der Spieler verliert, dann wird ihm diese Information mithilfe von einem Audio mitgeteilt
                        Mp3FileReader fileReader = new Mp3FileReader(@"..\..\..\..\BlackJack2022_3AHITN\playerLose.mp3");
                        _lose.Init(fileReader);
                        _lose.Play();

                        //Wenn der Spieler verliert, dann wird sein Guthaben geringer
                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(5000);
                    }
                    else
                    {
                        //Wenn es unentschieden ist, dann wird auch diese Information dem Spieler mitgeteilt
                        lblPush.Visible = true;

                        _player.Payout(_game.GetWinRatio());

                        await Task.Delay(2000);
                    }
                }

                //Seite für das Spiel wird geschlossen und die Startseite wird angezeigt
                Hide();
                _blackJackForm.Show();
            }
        }

        private void btnDouble_Click(object sender, EventArgs e)
        {
            //Wette des Spielers wird verdoppelt und angezeigt
            int playerBet = Convert.ToInt32(lblBetinEuro.Text.Split(' ')[0]);

            _player.Bet(_blackJackForm.PlayerBet);

            lblBetinEuro.Text = playerBet * 2 + @" €";

            if (pnlPlayerCards.Controls.Count == _game.Player.Cards.ToList().Count && pnlPlayerCards.Controls.Count != _game.Player.SecondHandCards.ToList().Count)
            {
                //Wenn der Spieler auf Double klickt, dann wird diese Aktion ausgeführt
                _game.Play(PlayerAction.Double, false);

                pnlPlayerCards.Controls.Clear();

                //Alle Karten und Status und Punkte des Spielers werden aktualisiert und angezeigt
                List<Card> cards = _game.Player.Cards.ToList();
                for (int i = 0; i < cards.Count; i++)
                {
                    PictureBox allCards = CreateCardImage(i, cards[i], cards.Count);
                    pnlPlayerCards.Controls.Add(allCards);
                    allCards.BringToFront();
                }

                //Status und Punkte des Spielers werden aktualisiert
                lblPlayerStatus.Text = @"Status: " + _game.Player.GetHandStatus();
                lblPlayerInfo.Text = @"Punkte: " + _game.Player.GetHandValue();
            }
            else
            {
                //Wenn der Spieler auf Double klickt, dann wird diese Aktion ausgeführt
                _game.Play(PlayerAction.Double, true);

                pnlPlayerCards.Controls.Clear();

                //Alle Karten und Status und Punkte des Spielers werden aktualisiert und angezeigt
                List<Card> cards = _game.Player.SecondHandCards.ToList();
                for (int i = 0; i < cards.Count; i++)
                {
                    PictureBox allCards = CreateCardImage(i, cards[i], cards.Count);
                    pnlPlayerCards.Controls.Add(allCards);
                    allCards.BringToFront();
                }

                //Status und Punkte des Spielers werden aktualisiert
                lblPlayerStatus.Text = @"Status: " + _game.Player.GetSecondHandStatus();
                lblPlayerInfo.Text = @"Punkte: " + _game.Player.GetSecondHandValue();
            }

            btnStand_Click(sender, e);
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            //Wenn der Spieler auf Split klickt, dann wird diese Aktion ausgeführt
            _game.Play(PlayerAction.Split, true);

            _game.Play(PlayerAction.Hit, false);

            _player.Bet((_blackJackForm.PlayerBet / 2) * (-1));

            lblSecondHand.Visible = true;

            pnlPlayerCards.Controls.Clear();

            //Alle Karten und die Punkte des Spielers werden aktualisiert und angezeigt
            _splittedCards = _game.Player.Cards.ToList();
            for (int i = 0; i < _splittedCards.Count; i++)
            {
                PictureBox allCards = CreateCardImage(i, _splittedCards[i], _splittedCards.Count);
                pnlPlayerCards.Controls.Add(allCards);
                allCards.BringToFront();
            }

            lblPlayerInfo.Text = @"Punkte: " + _game.Player.GetHandValue();

            pnlPlayerSplitCards.Visible = true;

            //Karte in der zweiten Hand des Spielers wird angezeigt
            List<Card> splittedCards = _game.Player.SecondHandCards.ToList();
            for (int i = 0; i < splittedCards.Count; i++)
            {
                PictureBox allCards = CreateCardImage(i, splittedCards[i], splittedCards.Count);
                pnlPlayerSplitCards.Controls.Add(allCards);
                allCards.BringToFront();
            }

            lblBetinEuro.Text = _blackJackForm.PlayerBet / 2 + @" €";

            if (_game.Player.GetHandStatus() == HandStatus.BlackJack)
            {
                btnAutoAction.Enabled = false;
                btnDouble.Enabled = false;
                btnHit.Enabled = false;
            }

            btnSplit.Enabled = false;
        }

        private void btnDouble_MouseHover(object sender, EventArgs e)
        {
            //Wenn der Spieler den Mauszeiger über btnDouble bewegt, dann wird die Schrift größer
            btnDouble.Font = new Font("Century", 14, FontStyle.Bold);
        }

        private void btnDouble_MouseLeave(object sender, EventArgs e)
        {
            //Wenn der Spieler den Mauszeiger von btnDouble entfernt, dann wird die Schrift wieder normal
            btnDouble.Font = new Font("Century", 13, FontStyle.Bold);
        }

        private void btnSplit_MouseHover(object sender, EventArgs e)
        {
            //Wenn der Spieler den Mauszeiger über btnSplit bewegt, dann wird die Schrift größer
            btnSplit.Font = new Font("Century", 20, FontStyle.Bold);
        }

        private void btnSplit_MouseLeave(object sender, EventArgs e)
        {
            //Wenn der Spieler den Mauszeiger von btnSplit entfernt, dann wird die Schrift wieder normal
            btnSplit.Font = new Font("Century", 18, FontStyle.Bold);
        }

        private void btnHit_MouseHover(object sender, EventArgs e)
        {
            //Wenn der Spieler den Mauszeiger über btnHit bewegt, dann wird die Schrift größer
            btnHit.Font = new Font("Century", 24, FontStyle.Bold);
        }

        private void btnHit_MouseLeave(object sender, EventArgs e)
        {
            //Wenn der Spieler den Mauszeiger von btnHit entfernt, dann wird die Schrift wieder normal
            btnHit.Font = new Font("Century", 20, FontStyle.Bold);
        }

        private void btnStand_MouseHover(object sender, EventArgs e)
        {
            //Wenn der Spieler den Mauszeiger über btnStand bewegt, dann wird die Schrift größer
            btnStand.Font = new Font("Century", 18, FontStyle.Bold);
        }

        private void btnStand_MouseLeave(object sender, EventArgs e)
        {
            //Wenn der Spieler den Mauszeiger von btnStand entfernt, dann wird die Schrift wieder normal
            btnStand.Font = new Font("Century", 16, FontStyle.Bold);
        }

        private void btnAutoAction_MouseHover(object sender, EventArgs e)
        {
            //Wenn der Spieler den Mauszeiger über btnAutoAction bewegt, dann wird die Schrift größer
            btnAutoAction.Font = new Font("Century", 20, FontStyle.Bold);
        }

        private void btnAutoAction_MouseLeave(object sender, EventArgs e)
        {
            //Wenn der Spieler den Mauszeiger von btnAutoAction entfernt, dann wird die Schrift wieder normal
            btnAutoAction.Font = new Font("Century", 18, FontStyle.Bold);
        }

        private void SaveData(object sender, FormClosingEventArgs e)
        {
            //Schreibt das Guthaben des Spielers in eine Datei rein
            using Stream stream = new FileStream($"{_player.GetName()}.json", FileMode.Create, FileAccess.Write);
            _player.WriteJson(stream);
            stream.Close();
        }

        /// <summary>
        /// Für eine bestimmte Karte wird ein PictureBox mit passenden Einstellungen und dem Bild erstellt und zurückgegeben
        /// </summary>
        /// <param name="xOffset">Horizontale Abstand zwischen den Kartenbildern</param>
        /// <param name="card">Karte</param>
        /// <param name="cardCount">Anzahl der Karten</param>
        /// <returns></returns>
        private PictureBox CreateCardImage(int xOffset, Card card, int cardCount)
        {
            int distanceBetweenCards = _cardWidth / 3;

            if (cardCount > 6)
            {
                distanceBetweenCards = _cardWidth / 4;
            }

            PictureBox pbxCard = new PictureBox();
            pbxCard.Image = (Bitmap)_resourceManager.GetObject(card.Color + "s_" + card.Value)!;
            pbxCard.Size = new Size(_cardWidth, 120);
            pbxCard.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCard.BorderStyle = BorderStyle.Fixed3D;
            pbxCard.Location = new Point(xOffset * distanceBetweenCards, 0);
            pbxCard.BringToFront();
            return pbxCard;
        }
        #endregion
    }
}

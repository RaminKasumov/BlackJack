using BlackJack2022_3AHITN.Lib;

namespace BlackJack2022_3AHITN.GUI
{
    public partial class BlackJackForm : Form
    {
        #region instancevariables
        GameForm _gameForm = null!;
        HandForm _handForm = null!;
        TableForm _tableForm = null!;
        readonly Table _table = new Table("Tisch2198");
        int _playerTotalBalance;
        int _playerChangedBalance;
        #endregion

        #region properties
        /// <summary>
        /// Name des Spielers wird als Eigenschaft gespeichert
        /// </summary>
        public string PlayerName
        {
            get
            {
                string name = tbxPlayerName.Text;
                return name;
            }
        }

        /// <summary>
        /// Wette des Spielers wird als Eigenschaft gespeichert
        /// </summary>
        public int PlayerBet
        {
            get
            {
                int playerBet = (int)nudBet.Value;
                return playerBet;
            }
        }

        /// <summary>
        /// Tisch wird für das Spiel ausgegeben
        /// </summary>
        internal Table Table => _table;

        /// <summary>
        /// Strategie des Spielers wird ausgegeben
        /// </summary>
        internal string Strategy
        {
            get
            {
                string strategy = Convert.ToString(cbxStrategy.SelectedItem)!;
                return strategy;
            }
        }
        #endregion

        #region constructor
        public BlackJackForm()
        {
            InitializeComponent();
        }
        #endregion

        #region methods
        private void rdbGame_CheckedChanged(object sender, EventArgs e)
        {
            _playerTotalBalance = Convert.ToInt32(lblBet.Text.Split(' ')[2]);

            //Wenn der Spieler auf radioButton für das Spiel drückt, dann wird sein Wetteinsatz abgefragt
            lblBet.Visible = true;
            nudBet.Visible = true;
            nudBet.Value = 0;
            pbxCoin10.Visible = true;
            pbxCoin20.Visible = true;
            pbxCoin50.Visible = true;
            pbxCoin100.Visible = true;
            pbxCoin200.Visible = true;
            pbxCoin500.Visible = true;
            lblStrategy.Visible = true;
            cbxStrategy.Visible = true;
            cbxStrategy.SelectedIndex = 0;
        }

        private void rdbHand_CheckedChanged(object sender, EventArgs e)
        {
            //Wenn der Spieler auf radioButton für die Hand drückt, dann wird sein Wetteinsatz nicht mehr abgefragt
            lblBet.Visible = false;
            nudBet.Visible = false;
            pbxCoin10.Visible = false;
            pbxCoin20.Visible = false;
            pbxCoin50.Visible = false;
            pbxCoin100.Visible = false;
            pbxCoin200.Visible = false;
            pbxCoin500.Visible = false;
            lblStrategy.Visible = false;
            cbxStrategy.Visible = false;
        }

        private void rdbTable_CheckedChanged(object sender, EventArgs e)
        {
            _playerTotalBalance = Convert.ToInt32(lblBet.Text.Split(' ')[2]);

            //Wenn der Spieler auf radioButton für den Tisch drückt, dann wird sein Wetteinsatz abgefragt
            lblBet.Visible = true;
            nudBet.Visible = true;
            nudBet.Value = 0;
            pbxCoin10.Visible = true;
            pbxCoin20.Visible = true;
            pbxCoin50.Visible = true;
            pbxCoin100.Visible = true;
            pbxCoin200.Visible = true;
            pbxCoin500.Visible = true;
            lblStrategy.Visible = true;
            cbxStrategy.Visible = true;
            cbxStrategy.SelectedIndex = 0;
        }

        private void tbxPlayerName_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists($"{PlayerName}.json"))
            {
                using Stream stream = new FileStream($"{PlayerName}.json", FileMode.Open, FileAccess.Read);
                Player player = Player.ReadJson(stream);
                player.CardSource = _table;
                lblBet.Text = $@"Einsatz (Kapital: {player.Balance} €)";
                stream.Close();
            }
            else
            {
                lblBet.Text = @"Einsatz (Kapital: 1000 €)";
            }

            _playerTotalBalance = Convert.ToInt32(lblBet.Text.Split(' ')[2]);
            nudBet.Value = 0;

            pbxCoin10.Enabled = true;
            pbxCoin20.Enabled = true;
            pbxCoin50.Enabled = true;
            pbxCoin100.Enabled = true;
            pbxCoin200.Enabled = true;
            pbxCoin500.Enabled = true;
        }

        private void nudBet_ValueChanged(object sender, EventArgs e)
        {
            if (_playerTotalBalance >= nudBet.Value)
            {
                lblBet.Text = $@"Einsatz (Kapital: {_playerTotalBalance - nudBet.Value} €)";
            }
            else
            {
                nudBet.Value = _playerTotalBalance;
            }

            pbxCoin10.Enabled = true;
            pbxCoin20.Enabled = true;
            pbxCoin50.Enabled = true;
            pbxCoin100.Enabled = true;
            pbxCoin200.Enabled = true;
            pbxCoin500.Enabled = true;
        }

        private async void pbxCoin10_Click(object sender, EventArgs e)
        {
            _playerChangedBalance = Convert.ToInt32(lblBet.Text.Split(' ')[2]);

            //Wenn der Spieler darauf klickt, dann wird sein Wetteinsatz aktualisiert
            if (sender == pbxCoin10)
            {
                if (_playerTotalBalance >= nudBet.Value + 10)
                {
                    nudBet.Value += 10;
                    lblBet.Text = $@"Einsatz (Kapital: {_playerChangedBalance - 10} €)";
                    pbxCoin10.Visible = false;
                    pbxCoin10Added.Visible = true;

                    await Task.Delay(300);

                    pbxCoin10.Visible = true;
                    pbxCoin10Added.Visible = false;
                }
                else
                {
                    pbxCoin10.Enabled = false;
                }
            }
        }

        private async void pbxCoin20_Click(object sender, EventArgs e)
        {
            _playerChangedBalance = Convert.ToInt32(lblBet.Text.Split(' ')[2]);

            //Wenn der Spieler darauf klickt, dann wird sein Wetteinsatz aktualisiert
            if (sender == pbxCoin20)
            {
                if (_playerTotalBalance >= nudBet.Value + 20)
                {
                    nudBet.Value += 20;
                    lblBet.Text = $@"Einsatz (Kapital: {_playerChangedBalance - 20} €)";
                    pbxCoin20.Visible = false;
                    pbxCoin20Added.Visible = true;

                    await Task.Delay(300);

                    pbxCoin20.Visible = true;
                    pbxCoin20Added.Visible = false;
                }
                else
                {
                    pbxCoin20.Enabled = false;
                }
            }
        }

        private async void pbxCoin50_Click(object sender, EventArgs e)
        {
            _playerChangedBalance = Convert.ToInt32(lblBet.Text.Split(' ')[2]);

            //Wenn der Spieler darauf klickt, dann wird sein Wetteinsatz aktualisiert
            if (sender == pbxCoin50)
            {
                if (_playerTotalBalance >= nudBet.Value + 50)
                {
                    nudBet.Value += 50;
                    lblBet.Text = $@"Einsatz (Kapital: {_playerChangedBalance - 50} €)";
                    pbxCoin50.Visible = false;
                    pbxCoin50Added.Visible = true;

                    await Task.Delay(300);

                    pbxCoin50.Visible = true;
                    pbxCoin50Added.Visible = false;
                }
                else
                {
                    pbxCoin50.Enabled = false;
                }
            }
        }

        private async void pbxCoin100_Click(object sender, EventArgs e)
        {
            _playerChangedBalance = Convert.ToInt32(lblBet.Text.Split(' ')[2]);

            //Wenn der Spieler darauf klickt, dann wird sein Wetteinsatz aktualisiert
            if (sender == pbxCoin100)
            {
                if (_playerTotalBalance >= nudBet.Value + 100)
                {
                    nudBet.Value += 100;
                    lblBet.Text = $@"Einsatz (Kapital: {_playerChangedBalance - 100} €)";
                    pbxCoin100.Visible = false;
                    pbxCoin100Added.Visible = true;

                    await Task.Delay(300);

                    pbxCoin100.Visible = true;
                    pbxCoin100Added.Visible = false;
                }
                else
                {
                    pbxCoin100.Enabled = false;
                }
            }
        }

        private async void pbxCoin200_Click(object sender, EventArgs e)
        {
            _playerChangedBalance = Convert.ToInt32(lblBet.Text.Split(' ')[2]);

            //Wenn der Spieler darauf klickt, dann wird sein Wetteinsatz aktualisiert
            if (sender == pbxCoin200)
            {
                if (_playerTotalBalance >= nudBet.Value + 200)
                {
                    nudBet.Value += 200;
                    lblBet.Text = $@"Einsatz (Kapital: {_playerChangedBalance - 200} €)";
                    pbxCoin200.Visible = false;
                    pbxCoin200Added.Visible = true;

                    await Task.Delay(300);

                    pbxCoin200.Visible = true;
                    pbxCoin200Added.Visible = false;
                }
                else
                {
                    pbxCoin200.Enabled = false;
                }
            }
        }

        private async void pbxCoin500_Click(object sender, EventArgs e)
        {
            _playerChangedBalance = Convert.ToInt32(lblBet.Text.Split(' ')[2]);

            //Wenn der Spieler darauf klickt, dann wird sein Wetteinsatz aktualisiert
            if (sender == pbxCoin500)
            {
                if (_playerTotalBalance >= nudBet.Value + 500)
                {
                    nudBet.Value += 500;
                    lblBet.Text = $@"Einsatz (Kapital: {_playerChangedBalance - 500} €)";
                    pbxCoin500.Visible = false;
                    pbxCoin500Added.Visible = true;

                    await Task.Delay(300);

                    pbxCoin500.Visible = true;
                    pbxCoin500Added.Visible = false;
                }
                else
                {
                    pbxCoin500.Enabled = false;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Es wird abgefragt, ob der Spieler das Feld für seinen Namen befüllt hat oder nicht
            if (PlayerName != "")
            {
                //Wenn der Spieler irgendein radioButton gedrückt hat, dann wird die passende Seite für ihn geöffnet
                if (rdbGame.Checked)
                {
                    //Es wird geprüft, ob der Spieler mindestens 5 Euro wettet oder nicht
                    if (nudBet.Value >= _table.MinimumBet)
                    {
                        _gameForm = new GameForm(this);
                        this.Hide();
                        _gameForm.ShowDialog();
                        lblBet.Text = @"Einsatz (max. " + _gameForm.Player.Balance + @" €):";
                        _playerTotalBalance = Convert.ToInt32(lblBet.Text.Split(' ')[2]);
                        nudBet.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show(@"Sie müssen mindestens 5 € wetten!!!", @"MINDESTEINSATZ 5 Euro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (rdbHand.Checked)
                {
                    _handForm = new HandForm(this);
                    this.Hide();
                    _handForm.Show();
                }
                else if (rdbTable.Checked)
                {
                    //Es wird geprüft, ob der Spieler mindestens 5 Euro wettet oder nicht
                    if (nudBet.Value >= _table.MinimumBet)
                    {
                        _tableForm = new TableForm(this);
                        this.Hide();
                        _tableForm.ShowDialog();
                        lblBet.Text = $@"Einsatz (Kapital: {_playerTotalBalance + PlayerBet} €)";
                        nudBet.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show(@"Sie müssen mindestens 5 € wetten!!!", @"MINDESTEINSATZ 5 Euro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(@"Bitte wählen Sie entweder Spiel oder Hand oder Tisch aus!!!", @"SPIEL, HAND oder TISCH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(@"Bitte geben Sie unbedingt ihren Namen ein!!!", @"NAME DES SPIELERS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}

using System.Resources;
using System.Reflection;
using BlackJack2022_3AHITN.Lib;

namespace BlackJack2022_3AHITN.GUI
{
    public partial class HandForm : Form
    {
        #region instancevariables
        readonly BlackJackForm _blackJackForm = null!;
        readonly Hand _hand = new Hand();
        AddCardForm _addCard = null!;
        ResourceManager _resourceManager = null!;
        #endregion

        #region constructor
        public HandForm()
        {
            InitializeComponent();
        }

        public HandForm(BlackJackForm blackJackForm)
        {
            _blackJackForm = blackJackForm;
            InitializeComponent();
            InitializeData();
        }
        #endregion

        #region methods
        private void InitializeData()
        {
            //Textbox für den Namen des Spielers wird befüllt
            lblNameOfPlayer.Text = _blackJackForm.PlayerName;

            //ResourceManager wird mit Bildern von allen Karten befüllt
            _resourceManager = new ResourceManager("BlackJack2022_3AHITN.GUI.Properties.Resources", Assembly.GetExecutingAssembly());
        }

        private void RefreshOutput()
        {
            //Summe der Karten des Spielers wird aktualisiert und angezeigt
            nudSumOfCardValues.Value = _hand.Sum;

            //Status der Karten des Spielers wird aktualisiert und angezeigt
            lblStatus.Text = _hand.GetStatus().ToString();
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            //Seite für das Hinzufügen der Karte wird angezeigt
            _addCard = new AddCardForm(this);
            this.Hide();
            _addCard.ShowDialog();

            //Symbol und Wert der Karte wird gespeichert und in die Hand hinzugefügt
            Card card = new Card(_addCard.CardColor, _addCard.CardValue);
            _hand.AddCard(card);

            //Die Bilder der Karten, die es in der Hand des Spielers gibt, werden angezeigt
            List<Card> cards = _hand.GetCards().ToList();
            flpPlayerCards.Controls.Add(CreatePbx(cards[^1]));
            RefreshOutput();
        }

        private void btnClearHand_Click(object sender, EventArgs e)
        {
            //Spieler kann nicht mehr eine Karte hinzufügen oder die Hand leeren
            btnAddCard.Enabled = false;
            btnClearHand.Enabled = false;

            //Alle Karten in der Hand des Spielers werden entfernt
            _hand.RemoveCards();
            flpPlayerCards.Controls.Clear();

            //Summe der Karten wird auf 0 gesetzt
            nudSumOfCardValues.Value = 0;

            //Status der Karten ist jetzt wieder Normal
            lblStatus.Text = @"Normal";

            //Dem Spieler wird die Information ermittelt, dass seine Hand erfolgreich geleert wurde
            MessageBox.Show(@"Alle Karten wurden erfolgreich aus der Hand entfernt.");

            //Seite für die Hand des Spielers wird geschlossen und die Startseite wird angezeigt
            this.Hide();
            _blackJackForm.Show();
        }

        /// <summary>
        /// Für eine bestimmte Karte wird ein PictureBox mit passenden Einstellungen und dem Bild erstellt und zurückgegeben
        /// </summary>
        /// <param name="card">Karte</param>
        /// <returns></returns>
        private PictureBox CreatePbx(Card card)
        {
            PictureBox pbxCard = new PictureBox();
            pbxCard.Image = (Bitmap)_resourceManager.GetObject(card.Color + "s_" + card.Value)!;
            pbxCard.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCard.Size = new Size(90, 120);
            return pbxCard;
        }
        #endregion
    }
}

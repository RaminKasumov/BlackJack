using BlackJack2022_3AHITN.Lib;

namespace BlackJack2022_3AHITN.GUI
{
    public partial class AddCardForm : Form
    {
        #region instancevariable
        readonly HandForm _handForm = null!;
        #endregion

        #region properties
        //Symbol der Karte wird als Eigenschaft für die Hand des Spielers gespeichert
        internal CardColor CardColor
        {
            get
            {
                int index = Convert.ToString(cbxCardColor.SelectedItem)!.IndexOf(" ", StringComparison.Ordinal);
                return (CardColor)Enum.Parse(typeof(CardColor), Convert.ToString(cbxCardColor.SelectedItem)!.Substring(0, index));
            }
        }

        //Wert der Karte wird als Eigenschaft für die Hand des Spielers gespeichert
        internal CardValue CardValue
        {
            get
            {
                int index = Convert.ToString(cbxCardValue.SelectedItem)!.LastIndexOf(" ", StringComparison.Ordinal);
                return (CardValue)Enum.Parse(typeof(CardValue), Convert.ToString(cbxCardValue.SelectedItem)!.Substring(index));
            }
        }
        #endregion

        #region constructors
        public AddCardForm()
        {
            InitializeComponent();
        }

        public AddCardForm(HandForm blackJackForm)
        {
            _handForm = blackJackForm;
            InitializeComponent();
            InitializeData();
        }
        #endregion

        #region methods
        private void InitializeData()
        {
            //Combobox für das Symbol der Karten wird befüllt
            foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                if (color == CardColor.Club)
                {
                    cbxCardColor.Items.Add(color + " ♣");
                }
                else if (color == CardColor.Spade)
                {
                    cbxCardColor.Items.Add(color + " ♠");
                }
                else if (color == CardColor.Heart)
                {
                    cbxCardColor.Items.Add(color + " ♥");
                }
                else
                {
                    cbxCardColor.Items.Add(color + " ♦");
                }
            }

            //Combobox für den Wert der Karten wird befüllt
            foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
            {
                if (value == CardValue.Ace)
                {
                    cbxCardValue.Items.Add("A - " + value);
                }
                else if (value == CardValue.Two)
                {
                    cbxCardValue.Items.Add("2 - " + value);
                }
                else if (value == CardValue.Three)
                {
                    cbxCardValue.Items.Add("3 - " + value);
                }
                else if (value == CardValue.Four)
                {
                    cbxCardValue.Items.Add("4 - " + value);
                }
                else if (value == CardValue.Five)
                {
                    cbxCardValue.Items.Add("5 - " + value);
                }
                else if (value == CardValue.Six)
                {
                    cbxCardValue.Items.Add("6 - " + value);
                }
                else if (value == CardValue.Seven)
                {
                    cbxCardValue.Items.Add("7 - " + value);
                }
                else if (value == CardValue.Eight)
                {
                    cbxCardValue.Items.Add("8 - " + value);
                }
                else if (value == CardValue.Nine)
                {
                    cbxCardValue.Items.Add("9 - " + value);
                }
                else if (value == CardValue.Ten)
                {
                    cbxCardValue.Items.Add("10 - " + value);
                }
                else if (value == CardValue.Jack)
                {
                    cbxCardValue.Items.Add("J - " + value);
                }
                else if (value == CardValue.Queen)
                {
                    cbxCardValue.Items.Add("Q - " + value);
                }
                else if (value == CardValue.King)
                {
                    cbxCardValue.Items.Add("K - " + value);
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //Es wird überprüft, ob der Spieler irgendein Symbol und Wert von seiner Karte ausgewählt hat oder nicht
            if (cbxCardColor.SelectedItem != null && cbxCardValue.SelectedItem != null)
            {
                //Seite für das Hinzufügen der Karte wird geschlossen und die Seite für die Hand des Spielers wird angezeigt
                this.Hide();
                _handForm.Show();
            }
            else
            {
                MessageBox.Show(@"Bitte wählen Sie das Symbol und den Wert Ihrer Karte aus!!!");
            }
        }

        private void btnRandomChoice_Click(object sender, EventArgs e)
        {
            //Symbol und Wert der Karte werden zufällig ausgewählt
            Random random = new Random();
            cbxCardColor.SelectedIndex = random.Next(cbxCardColor.Items.Count);
            cbxCardValue.SelectedIndex = random.Next(cbxCardValue.Items.Count);
        }
        #endregion
    }
}

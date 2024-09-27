
namespace BlackJack2022_3AHITN.GUI
{
    partial class BlackJackForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackJackForm));
            pnlMain = new Panel();
            cbxStrategy = new ComboBox();
            lblStrategy = new Label();
            pbxCasinoIcon = new PictureBox();
            pbxCoin10Added = new PictureBox();
            pbxCoin50Added = new PictureBox();
            pbxCoin100Added = new PictureBox();
            pbxCoin20Added = new PictureBox();
            pbxCoin200Added = new PictureBox();
            pbxCoin100 = new PictureBox();
            pbxCoin50 = new PictureBox();
            pbxCoin200 = new PictureBox();
            pbxCoin500Added = new PictureBox();
            pbxCoin500 = new PictureBox();
            pbxCoin20 = new PictureBox();
            pbxCoin10 = new PictureBox();
            nudBet = new NumericUpDown();
            lblBet = new Label();
            rdbHand = new RadioButton();
            rdbTable = new RadioButton();
            rdbGame = new RadioButton();
            btnStart = new Button();
            tbxPlayerName = new TextBox();
            lblPlayerName = new Label();
            lblPresentation = new Label();
            lblBlackJack = new Label();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxCasinoIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin10Added).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin50Added).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin100Added).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin20Added).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin200Added).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin100).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin50).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin200).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin500Added).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin500).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin20).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudBet).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = SystemColors.Control;
            pnlMain.BackgroundImage = (Image)resources.GetObject("pnlMain.BackgroundImage");
            pnlMain.BackgroundImageLayout = ImageLayout.Stretch;
            pnlMain.Controls.Add(cbxStrategy);
            pnlMain.Controls.Add(lblStrategy);
            pnlMain.Controls.Add(pbxCasinoIcon);
            pnlMain.Controls.Add(pbxCoin10Added);
            pnlMain.Controls.Add(pbxCoin50Added);
            pnlMain.Controls.Add(pbxCoin100Added);
            pnlMain.Controls.Add(pbxCoin20Added);
            pnlMain.Controls.Add(pbxCoin200Added);
            pnlMain.Controls.Add(pbxCoin100);
            pnlMain.Controls.Add(pbxCoin50);
            pnlMain.Controls.Add(pbxCoin200);
            pnlMain.Controls.Add(pbxCoin500Added);
            pnlMain.Controls.Add(pbxCoin500);
            pnlMain.Controls.Add(pbxCoin20);
            pnlMain.Controls.Add(pbxCoin10);
            pnlMain.Controls.Add(nudBet);
            pnlMain.Controls.Add(lblBet);
            pnlMain.Controls.Add(rdbHand);
            pnlMain.Controls.Add(rdbTable);
            pnlMain.Controls.Add(rdbGame);
            pnlMain.Controls.Add(btnStart);
            pnlMain.Controls.Add(tbxPlayerName);
            pnlMain.Controls.Add(lblPlayerName);
            pnlMain.Controls.Add(lblPresentation);
            pnlMain.Controls.Add(lblBlackJack);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.ForeColor = SystemColors.Control;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Margin = new Padding(3, 2, 3, 2);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1071, 698);
            pnlMain.TabIndex = 0;
            // 
            // cbxStrategy
            // 
            cbxStrategy.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxStrategy.FormattingEnabled = true;
            cbxStrategy.Items.AddRange(new object[] { "Hard hands", "Soft hands" });
            cbxStrategy.Location = new Point(624, 275);
            cbxStrategy.Margin = new Padding(3, 4, 3, 4);
            cbxStrategy.Name = "cbxStrategy";
            cbxStrategy.Size = new Size(154, 31);
            cbxStrategy.TabIndex = 25;
            cbxStrategy.Visible = false;
            // 
            // lblStrategy
            // 
            lblStrategy.AutoSize = true;
            lblStrategy.BackColor = Color.Transparent;
            lblStrategy.Font = new Font("Century", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStrategy.ForeColor = Color.Peru;
            lblStrategy.Location = new Point(459, 275);
            lblStrategy.Name = "lblStrategy";
            lblStrategy.Size = new Size(126, 28);
            lblStrategy.TabIndex = 24;
            lblStrategy.Text = "Strategie:";
            lblStrategy.Visible = false;
            // 
            // pbxCasinoIcon
            // 
            pbxCasinoIcon.BackColor = Color.Transparent;
            pbxCasinoIcon.Cursor = Cursors.NoMove2D;
            pbxCasinoIcon.Image = (Image)resources.GetObject("pbxCasinoIcon.Image");
            pbxCasinoIcon.Location = new Point(206, 289);
            pbxCasinoIcon.Margin = new Padding(3, 4, 3, 4);
            pbxCasinoIcon.Name = "pbxCasinoIcon";
            pbxCasinoIcon.Size = new Size(129, 134);
            pbxCasinoIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCasinoIcon.TabIndex = 23;
            pbxCasinoIcon.TabStop = false;
            // 
            // pbxCoin10Added
            // 
            pbxCoin10Added.BackColor = Color.Transparent;
            pbxCoin10Added.Cursor = Cursors.Hand;
            pbxCoin10Added.Image = Properties.Resources.coin_status_added;
            pbxCoin10Added.Location = new Point(467, 399);
            pbxCoin10Added.Margin = new Padding(3, 4, 3, 4);
            pbxCoin10Added.Name = "pbxCoin10Added";
            pbxCoin10Added.Size = new Size(60, 75);
            pbxCoin10Added.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin10Added.TabIndex = 22;
            pbxCoin10Added.TabStop = false;
            pbxCoin10Added.Visible = false;
            // 
            // pbxCoin50Added
            // 
            pbxCoin50Added.BackColor = Color.Transparent;
            pbxCoin50Added.Cursor = Cursors.Hand;
            pbxCoin50Added.Image = Properties.Resources.coin_status_added;
            pbxCoin50Added.Location = new Point(627, 399);
            pbxCoin50Added.Margin = new Padding(3, 4, 3, 4);
            pbxCoin50Added.Name = "pbxCoin50Added";
            pbxCoin50Added.Size = new Size(60, 75);
            pbxCoin50Added.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin50Added.TabIndex = 21;
            pbxCoin50Added.TabStop = false;
            pbxCoin50Added.Visible = false;
            // 
            // pbxCoin100Added
            // 
            pbxCoin100Added.BackColor = Color.Transparent;
            pbxCoin100Added.Cursor = Cursors.Hand;
            pbxCoin100Added.Image = Properties.Resources.coin_status_added;
            pbxCoin100Added.Location = new Point(707, 399);
            pbxCoin100Added.Margin = new Padding(3, 4, 3, 4);
            pbxCoin100Added.Name = "pbxCoin100Added";
            pbxCoin100Added.Size = new Size(60, 75);
            pbxCoin100Added.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin100Added.TabIndex = 20;
            pbxCoin100Added.TabStop = false;
            pbxCoin100Added.Visible = false;
            // 
            // pbxCoin20Added
            // 
            pbxCoin20Added.BackColor = Color.Transparent;
            pbxCoin20Added.Cursor = Cursors.Hand;
            pbxCoin20Added.Image = Properties.Resources.coin_status_added;
            pbxCoin20Added.Location = new Point(547, 399);
            pbxCoin20Added.Margin = new Padding(3, 4, 3, 4);
            pbxCoin20Added.Name = "pbxCoin20Added";
            pbxCoin20Added.Size = new Size(60, 75);
            pbxCoin20Added.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin20Added.TabIndex = 19;
            pbxCoin20Added.TabStop = false;
            pbxCoin20Added.Visible = false;
            // 
            // pbxCoin200Added
            // 
            pbxCoin200Added.BackColor = Color.Transparent;
            pbxCoin200Added.Cursor = Cursors.Hand;
            pbxCoin200Added.Image = Properties.Resources.coin_status_added;
            pbxCoin200Added.Location = new Point(787, 399);
            pbxCoin200Added.Margin = new Padding(3, 4, 3, 4);
            pbxCoin200Added.Name = "pbxCoin200Added";
            pbxCoin200Added.Size = new Size(60, 75);
            pbxCoin200Added.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin200Added.TabIndex = 18;
            pbxCoin200Added.TabStop = false;
            pbxCoin200Added.Visible = false;
            // 
            // pbxCoin100
            // 
            pbxCoin100.BackColor = Color.Transparent;
            pbxCoin100.Cursor = Cursors.Hand;
            pbxCoin100.Image = Properties.Resources.coin_100;
            pbxCoin100.Location = new Point(707, 399);
            pbxCoin100.Margin = new Padding(3, 4, 3, 4);
            pbxCoin100.Name = "pbxCoin100";
            pbxCoin100.Size = new Size(60, 75);
            pbxCoin100.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin100.TabIndex = 17;
            pbxCoin100.TabStop = false;
            pbxCoin100.Visible = false;
            pbxCoin100.Click += pbxCoin100_Click;
            // 
            // pbxCoin50
            // 
            pbxCoin50.BackColor = Color.Transparent;
            pbxCoin50.Cursor = Cursors.Hand;
            pbxCoin50.Image = Properties.Resources.coin_50;
            pbxCoin50.Location = new Point(627, 399);
            pbxCoin50.Margin = new Padding(3, 4, 3, 4);
            pbxCoin50.Name = "pbxCoin50";
            pbxCoin50.Size = new Size(60, 75);
            pbxCoin50.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin50.TabIndex = 16;
            pbxCoin50.TabStop = false;
            pbxCoin50.Visible = false;
            pbxCoin50.Click += pbxCoin50_Click;
            // 
            // pbxCoin200
            // 
            pbxCoin200.BackColor = Color.Transparent;
            pbxCoin200.Cursor = Cursors.Hand;
            pbxCoin200.Image = Properties.Resources.coin_200;
            pbxCoin200.Location = new Point(787, 399);
            pbxCoin200.Margin = new Padding(3, 4, 3, 4);
            pbxCoin200.Name = "pbxCoin200";
            pbxCoin200.Size = new Size(60, 75);
            pbxCoin200.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin200.TabIndex = 15;
            pbxCoin200.TabStop = false;
            pbxCoin200.Visible = false;
            pbxCoin200.Click += pbxCoin200_Click;
            // 
            // pbxCoin500Added
            // 
            pbxCoin500Added.BackColor = Color.Transparent;
            pbxCoin500Added.Cursor = Cursors.Hand;
            pbxCoin500Added.Image = Properties.Resources.coin_status_added;
            pbxCoin500Added.Location = new Point(867, 399);
            pbxCoin500Added.Margin = new Padding(3, 4, 3, 4);
            pbxCoin500Added.Name = "pbxCoin500Added";
            pbxCoin500Added.Size = new Size(60, 75);
            pbxCoin500Added.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin500Added.TabIndex = 13;
            pbxCoin500Added.TabStop = false;
            pbxCoin500Added.Visible = false;
            // 
            // pbxCoin500
            // 
            pbxCoin500.BackColor = Color.Transparent;
            pbxCoin500.Cursor = Cursors.Hand;
            pbxCoin500.Image = Properties.Resources.coin_500;
            pbxCoin500.Location = new Point(867, 399);
            pbxCoin500.Margin = new Padding(3, 4, 3, 4);
            pbxCoin500.Name = "pbxCoin500";
            pbxCoin500.Size = new Size(60, 75);
            pbxCoin500.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin500.TabIndex = 12;
            pbxCoin500.TabStop = false;
            pbxCoin500.Visible = false;
            pbxCoin500.Click += pbxCoin500_Click;
            // 
            // pbxCoin20
            // 
            pbxCoin20.BackColor = Color.Transparent;
            pbxCoin20.Cursor = Cursors.Hand;
            pbxCoin20.Image = Properties.Resources.coin_20;
            pbxCoin20.Location = new Point(547, 399);
            pbxCoin20.Margin = new Padding(3, 4, 3, 4);
            pbxCoin20.Name = "pbxCoin20";
            pbxCoin20.Size = new Size(60, 75);
            pbxCoin20.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin20.TabIndex = 11;
            pbxCoin20.TabStop = false;
            pbxCoin20.Visible = false;
            pbxCoin20.Click += pbxCoin20_Click;
            // 
            // pbxCoin10
            // 
            pbxCoin10.BackColor = Color.Transparent;
            pbxCoin10.Cursor = Cursors.Hand;
            pbxCoin10.Image = Properties.Resources.coin_10;
            pbxCoin10.Location = new Point(467, 399);
            pbxCoin10.Margin = new Padding(3, 4, 3, 4);
            pbxCoin10.Name = "pbxCoin10";
            pbxCoin10.Size = new Size(60, 75);
            pbxCoin10.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCoin10.TabIndex = 10;
            pbxCoin10.TabStop = false;
            pbxCoin10.Visible = false;
            pbxCoin10.Click += pbxCoin10_Click;
            // 
            // nudBet
            // 
            nudBet.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nudBet.Location = new Point(839, 331);
            nudBet.Margin = new Padding(3, 4, 3, 4);
            nudBet.Maximum = new decimal(new int[] { 200000, 0, 0, 0 });
            nudBet.Name = "nudBet";
            nudBet.Size = new Size(111, 32);
            nudBet.TabIndex = 9;
            nudBet.TabStop = false;
            nudBet.TextAlign = HorizontalAlignment.Center;
            nudBet.ThousandsSeparator = true;
            nudBet.Visible = false;
            nudBet.ValueChanged += nudBet_ValueChanged;
            // 
            // lblBet
            // 
            lblBet.AutoSize = true;
            lblBet.BackColor = Color.Transparent;
            lblBet.Font = new Font("Century", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBet.ForeColor = Color.Peru;
            lblBet.Location = new Point(459, 331);
            lblBet.Name = "lblBet";
            lblBet.Size = new Size(311, 28);
            lblBet.TabIndex = 8;
            lblBet.Text = "Einsatz: (Kapital: 1000 €)";
            lblBet.Visible = false;
            // 
            // rdbHand
            // 
            rdbHand.AutoSize = true;
            rdbHand.BackColor = Color.LimeGreen;
            rdbHand.Font = new Font("Century", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdbHand.ForeColor = Color.Black;
            rdbHand.Location = new Point(709, 514);
            rdbHand.Margin = new Padding(3, 4, 3, 4);
            rdbHand.Name = "rdbHand";
            rdbHand.Size = new Size(96, 32);
            rdbHand.TabIndex = 7;
            rdbHand.TabStop = true;
            rdbHand.Text = "Hand";
            rdbHand.UseVisualStyleBackColor = false;
            rdbHand.CheckedChanged += rdbHand_CheckedChanged;
            // 
            // rdbTable
            // 
            rdbTable.AutoSize = true;
            rdbTable.BackColor = Color.LimeGreen;
            rdbTable.Font = new Font("Century", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdbTable.ForeColor = Color.Black;
            rdbTable.Location = new Point(890, 514);
            rdbTable.Margin = new Padding(3, 4, 3, 4);
            rdbTable.Name = "rdbTable";
            rdbTable.Size = new Size(95, 32);
            rdbTable.TabIndex = 6;
            rdbTable.TabStop = true;
            rdbTable.Text = "Tisch";
            rdbTable.UseVisualStyleBackColor = false;
            rdbTable.CheckedChanged += rdbTable_CheckedChanged;
            // 
            // rdbGame
            // 
            rdbGame.AutoSize = true;
            rdbGame.BackColor = Color.LimeGreen;
            rdbGame.Font = new Font("Century", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdbGame.ForeColor = Color.Black;
            rdbGame.Location = new Point(529, 514);
            rdbGame.Margin = new Padding(3, 4, 3, 4);
            rdbGame.Name = "rdbGame";
            rdbGame.Size = new Size(91, 32);
            rdbGame.TabIndex = 5;
            rdbGame.TabStop = true;
            rdbGame.Text = "Spiel";
            rdbGame.UseVisualStyleBackColor = false;
            rdbGame.CheckedChanged += rdbGame_CheckedChanged;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Gold;
            btnStart.FlatAppearance.BorderColor = Color.Blue;
            btnStart.FlatAppearance.BorderSize = 5;
            btnStart.FlatAppearance.MouseDownBackColor = Color.Red;
            btnStart.FlatAppearance.MouseOverBackColor = Color.Fuchsia;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Century", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.FromArgb(128, 64, 0);
            btnStart.Location = new Point(678, 591);
            btnStart.Margin = new Padding(4, 5, 4, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(177, 61);
            btnStart.TabIndex = 4;
            btnStart.Text = "Starten";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // tbxPlayerName
            // 
            tbxPlayerName.Font = new Font("Century", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxPlayerName.Location = new Point(740, 210);
            tbxPlayerName.Margin = new Padding(4, 5, 4, 5);
            tbxPlayerName.Name = "tbxPlayerName";
            tbxPlayerName.Size = new Size(227, 35);
            tbxPlayerName.TabIndex = 3;
            tbxPlayerName.TextChanged += tbxPlayerName_TextChanged;
            // 
            // lblPlayerName
            // 
            lblPlayerName.AutoSize = true;
            lblPlayerName.BackColor = Color.Transparent;
            lblPlayerName.Font = new Font("Century", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlayerName.ForeColor = Color.Peru;
            lblPlayerName.Location = new Point(459, 214);
            lblPlayerName.Margin = new Padding(4, 0, 4, 0);
            lblPlayerName.Name = "lblPlayerName";
            lblPlayerName.Size = new Size(234, 28);
            lblPlayerName.TabIndex = 2;
            lblPlayerName.Text = "Name des Spielers:";
            // 
            // lblPresentation
            // 
            lblPresentation.AutoSize = true;
            lblPresentation.BackColor = Color.Transparent;
            lblPresentation.Font = new Font("Century", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPresentation.ForeColor = Color.FromArgb(255, 255, 128);
            lblPresentation.Location = new Point(530, 115);
            lblPresentation.Name = "lblPresentation";
            lblPresentation.Size = new Size(352, 39);
            lblPresentation.TabIndex = 1;
            lblPresentation.Text = "Kundenpräsentation";
            // 
            // lblBlackJack
            // 
            lblBlackJack.AutoSize = true;
            lblBlackJack.BackColor = Color.Transparent;
            lblBlackJack.Font = new Font("Century", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBlackJack.ForeColor = Color.FromArgb(255, 128, 0);
            lblBlackJack.Location = new Point(503, 25);
            lblBlackJack.Name = "lblBlackJack";
            lblBlackJack.Size = new Size(415, 60);
            lblBlackJack.TabIndex = 0;
            lblBlackJack.Text = "BlackJack-Spiel";
            // 
            // BlackJackForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1071, 698);
            Controls.Add(pnlMain);
            Margin = new Padding(3, 2, 3, 2);
            Name = "BlackJackForm";
            Text = "BlackJack";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxCasinoIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin10Added).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin50Added).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin100Added).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin20Added).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin200Added).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin100).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin50).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin200).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin500Added).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin500).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin20).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCoin10).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudBet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblBlackJack;
        private System.Windows.Forms.Label lblPresentation;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbxPlayerName;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.RadioButton rdbTable;
        private System.Windows.Forms.RadioButton rdbGame;
        private System.Windows.Forms.RadioButton rdbHand;
        private System.Windows.Forms.Label lblBet;
        private System.Windows.Forms.PictureBox pbxCoin10;
        private System.Windows.Forms.PictureBox pbxCoin100;
        private System.Windows.Forms.PictureBox pbxCoin50;
        private System.Windows.Forms.PictureBox pbxCoin200;
        private System.Windows.Forms.PictureBox pbxCoin500Added;
        private System.Windows.Forms.PictureBox pbxCoin500;
        private System.Windows.Forms.PictureBox pbxCoin20;
        private System.Windows.Forms.NumericUpDown nudBet;
        private System.Windows.Forms.PictureBox pbxCoin10Added;
        private System.Windows.Forms.PictureBox pbxCoin50Added;
        private System.Windows.Forms.PictureBox pbxCoin100Added;
        private System.Windows.Forms.PictureBox pbxCoin20Added;
        private System.Windows.Forms.PictureBox pbxCoin200Added;
        private System.Windows.Forms.PictureBox pbxCasinoIcon;
        private System.Windows.Forms.Label lblStrategy;
        private System.Windows.Forms.ComboBox cbxStrategy;
    }
}



namespace BlackJack2022_3AHITN.GUI
{
    partial class TableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMain = new Panel();
            lblBetinEuro = new Label();
            lblNameOfDealer = new Label();
            lblNameOfTable = new Label();
            flpDrawCard = new FlowLayoutPanel();
            btnBack = new Button();
            btnDrawCard = new Button();
            lblDrawCard = new Label();
            lblDealerName = new Label();
            lblBet = new Label();
            lblTableName = new Label();
            lblTable = new Label();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackgroundImage = Properties.Resources.Tisch;
            pnlMain.BackgroundImageLayout = ImageLayout.Stretch;
            pnlMain.Controls.Add(lblBetinEuro);
            pnlMain.Controls.Add(lblNameOfDealer);
            pnlMain.Controls.Add(lblNameOfTable);
            pnlMain.Controls.Add(flpDrawCard);
            pnlMain.Controls.Add(btnBack);
            pnlMain.Controls.Add(btnDrawCard);
            pnlMain.Controls.Add(lblDrawCard);
            pnlMain.Controls.Add(lblDealerName);
            pnlMain.Controls.Add(lblBet);
            pnlMain.Controls.Add(lblTableName);
            pnlMain.Controls.Add(lblTable);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1071, 698);
            pnlMain.TabIndex = 0;
            // 
            // lblBetinEuro
            // 
            lblBetinEuro.AutoSize = true;
            lblBetinEuro.BackColor = Color.Transparent;
            lblBetinEuro.Font = new Font("Century", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBetinEuro.ForeColor = Color.Yellow;
            lblBetinEuro.Location = new Point(468, 250);
            lblBetinEuro.Name = "lblBetinEuro";
            lblBetinEuro.Size = new Size(97, 33);
            lblBetinEuro.TabIndex = 14;
            lblBetinEuro.Text = "Wette";
            // 
            // lblNameOfDealer
            // 
            lblNameOfDealer.AutoSize = true;
            lblNameOfDealer.BackColor = Color.Transparent;
            lblNameOfDealer.Font = new Font("Century", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameOfDealer.ForeColor = Color.Orange;
            lblNameOfDealer.Location = new Point(509, 328);
            lblNameOfDealer.Name = "lblNameOfDealer";
            lblNameOfDealer.Size = new Size(108, 33);
            lblNameOfDealer.TabIndex = 13;
            lblNameOfDealer.Text = "Dealer";
            // 
            // lblNameOfTable
            // 
            lblNameOfTable.AutoSize = true;
            lblNameOfTable.BackColor = Color.Transparent;
            lblNameOfTable.Font = new Font("Century", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameOfTable.ForeColor = Color.PaleTurquoise;
            lblNameOfTable.Location = new Point(489, 175);
            lblNameOfTable.Name = "lblNameOfTable";
            lblNameOfTable.Size = new Size(90, 33);
            lblNameOfTable.TabIndex = 12;
            lblNameOfTable.Text = "Tisch";
            // 
            // flpDrawCard
            // 
            flpDrawCard.BackColor = Color.Transparent;
            flpDrawCard.Location = new Point(560, 396);
            flpDrawCard.Margin = new Padding(3, 4, 3, 4);
            flpDrawCard.Name = "flpDrawCard";
            flpDrawCard.Size = new Size(132, 196);
            flpDrawCard.TabIndex = 11;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(192, 0, 192);
            btnBack.FlatAppearance.BorderColor = Color.Yellow;
            btnBack.FlatAppearance.BorderSize = 5;
            btnBack.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
            btnBack.FlatAppearance.MouseOverBackColor = Color.Red;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Century", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.DarkGreen;
            btnBack.Location = new Point(741, 161);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(139, 60);
            btnBack.TabIndex = 10;
            btnBack.Text = "Zurück";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnDrawCard
            // 
            btnDrawCard.BackColor = Color.FromArgb(192, 0, 192);
            btnDrawCard.FlatAppearance.BorderColor = Color.Yellow;
            btnDrawCard.FlatAppearance.BorderSize = 5;
            btnDrawCard.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
            btnDrawCard.FlatAppearance.MouseOverBackColor = Color.Red;
            btnDrawCard.FlatStyle = FlatStyle.Flat;
            btnDrawCard.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDrawCard.ForeColor = Color.DarkGreen;
            btnDrawCard.Location = new Point(343, 521);
            btnDrawCard.Margin = new Padding(3, 4, 3, 4);
            btnDrawCard.Name = "btnDrawCard";
            btnDrawCard.Size = new Size(188, 60);
            btnDrawCard.TabIndex = 9;
            btnDrawCard.Text = "Karte ziehen";
            btnDrawCard.UseVisualStyleBackColor = false;
            btnDrawCard.Click += btnDrawCard_Click;
            // 
            // lblDrawCard
            // 
            lblDrawCard.AutoSize = true;
            lblDrawCard.BackColor = Color.Transparent;
            lblDrawCard.Font = new Font("Century", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDrawCard.ForeColor = Color.GreenYellow;
            lblDrawCard.Location = new Point(204, 396);
            lblDrawCard.Name = "lblDrawCard";
            lblDrawCard.Size = new Size(327, 33);
            lblDrawCard.TabIndex = 6;
            lblDrawCard.Text = "Ziehen Sie eine Karte:";
            // 
            // lblDealerName
            // 
            lblDealerName.AutoSize = true;
            lblDealerName.BackColor = Color.Transparent;
            lblDealerName.Font = new Font("Century", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDealerName.ForeColor = Color.GreenYellow;
            lblDealerName.Location = new Point(204, 328);
            lblDealerName.Name = "lblDealerName";
            lblDealerName.Size = new Size(277, 33);
            lblDealerName.TabIndex = 5;
            lblDealerName.Text = "Name des Dealers:";
            // 
            // lblBet
            // 
            lblBet.AutoSize = true;
            lblBet.BackColor = Color.Transparent;
            lblBet.Font = new Font("Century", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBet.ForeColor = Color.GreenYellow;
            lblBet.Location = new Point(203, 249);
            lblBet.Name = "lblBet";
            lblBet.Size = new Size(243, 33);
            lblBet.TabIndex = 3;
            lblBet.Text = "Einsatz in Euro:";
            // 
            // lblTableName
            // 
            lblTableName.AutoSize = true;
            lblTableName.BackColor = Color.Transparent;
            lblTableName.Font = new Font("Century", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTableName.ForeColor = Color.GreenYellow;
            lblTableName.Location = new Point(203, 175);
            lblTableName.Name = "lblTableName";
            lblTableName.Size = new Size(259, 33);
            lblTableName.TabIndex = 1;
            lblTableName.Text = "Name des Tischs:";
            // 
            // lblTable
            // 
            lblTable.AutoSize = true;
            lblTable.BackColor = Color.Transparent;
            lblTable.Font = new Font("Century", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTable.ForeColor = Color.Gold;
            lblTable.Location = new Point(485, 22);
            lblTable.Name = "lblTable";
            lblTable.Size = new Size(147, 55);
            lblTable.TabIndex = 0;
            lblTable.Text = "Tisch";
            // 
            // TableForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 698);
            Controls.Add(pnlMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TableForm";
            Text = "Tisch";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label lblBet;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblDrawCard;
        private System.Windows.Forms.Label lblDealerName;
        private System.Windows.Forms.Button btnDrawCard;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.FlowLayoutPanel flpDrawCard;
        private System.Windows.Forms.Label lblNameOfDealer;
        private System.Windows.Forms.Label lblNameOfTable;
        private System.Windows.Forms.Label lblBetinEuro;
    }
}
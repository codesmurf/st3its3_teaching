namespace WindowsFormsCardCounter
{
    partial class Cardcounter
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxCardFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNumberOfCards = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSumOfSpades = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNumberOfAces = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(13, 13);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(95, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxCardFile
            // 
            this.textBoxCardFile.Location = new System.Drawing.Point(116, 61);
            this.textBoxCardFile.Name = "textBoxCardFile";
            this.textBoxCardFile.Size = new System.Drawing.Size(163, 20);
            this.textBoxCardFile.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Card file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of cards";
            // 
            // textBoxNumberOfCards
            // 
            this.textBoxNumberOfCards.Location = new System.Drawing.Point(116, 95);
            this.textBoxNumberOfCards.Name = "textBoxNumberOfCards";
            this.textBoxNumberOfCards.Size = new System.Drawing.Size(163, 20);
            this.textBoxNumberOfCards.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sum of spades";
            // 
            // textBoxSumOfSpades
            // 
            this.textBoxSumOfSpades.Location = new System.Drawing.Point(116, 134);
            this.textBoxSumOfSpades.Name = "textBoxSumOfSpades";
            this.textBoxSumOfSpades.Size = new System.Drawing.Size(163, 20);
            this.textBoxSumOfSpades.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Number of aces";
            // 
            // textBoxNumberOfAces
            // 
            this.textBoxNumberOfAces.Location = new System.Drawing.Point(116, 173);
            this.textBoxNumberOfAces.Name = "textBoxNumberOfAces";
            this.textBoxNumberOfAces.Size = new System.Drawing.Size(163, 20);
            this.textBoxNumberOfAces.TabIndex = 8;
            // 
            // Cardcounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 223);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNumberOfAces);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSumOfSpades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNumberOfCards);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCardFile);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonStart);
            this.Name = "Cardcounter";
            this.Text = "Cardcounter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxCardFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNumberOfCards;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSumOfSpades;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNumberOfAces;
    }
}


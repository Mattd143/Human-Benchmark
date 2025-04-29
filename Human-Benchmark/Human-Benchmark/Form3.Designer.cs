namespace Human_Benchmark
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.przyciskZielony = new System.Windows.Forms.Button();
            this.przyciskPomarancz = new System.Windows.Forms.Button();
            this.przyciskZolty = new System.Windows.Forms.Button();
            this.przyciskNiebieski = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(120, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1072, 91);
            this.label1.TabIndex = 1;
            this.label1.Text = "Złożony test reakcji optycznej";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1309, 256);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(595, 630);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 58);
            this.button1.TabIndex = 3;
            this.button1.Text = "Rozpocznij";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // przyciskZielony
            // 
            this.przyciskZielony.BackColor = System.Drawing.Color.Gold;
            this.przyciskZielony.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.przyciskZielony.Location = new System.Drawing.Point(296, 684);
            this.przyciskZielony.Name = "przyciskZielony";
            this.przyciskZielony.Size = new System.Drawing.Size(231, 49);
            this.przyciskZielony.TabIndex = 4;
            this.przyciskZielony.Text = "Zielony";
            this.przyciskZielony.UseVisualStyleBackColor = false;
            this.przyciskZielony.Visible = false;
            this.przyciskZielony.Click += new System.EventHandler(this.PrzyciskKolory_click);
            // 
            // przyciskPomarancz
            // 
            this.przyciskPomarancz.BackColor = System.Drawing.Color.Gold;
            this.przyciskPomarancz.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.przyciskPomarancz.Location = new System.Drawing.Point(849, 567);
            this.przyciskPomarancz.Name = "przyciskPomarancz";
            this.przyciskPomarancz.Size = new System.Drawing.Size(231, 49);
            this.przyciskPomarancz.TabIndex = 5;
            this.przyciskPomarancz.Text = "Pomarańczowy";
            this.przyciskPomarancz.UseVisualStyleBackColor = false;
            this.przyciskPomarancz.Visible = false;
            this.przyciskPomarancz.Click += new System.EventHandler(this.PrzyciskKolory_click);
            // 
            // przyciskZolty
            // 
            this.przyciskZolty.BackColor = System.Drawing.Color.Gold;
            this.przyciskZolty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.przyciskZolty.Location = new System.Drawing.Point(849, 684);
            this.przyciskZolty.Name = "przyciskZolty";
            this.przyciskZolty.Size = new System.Drawing.Size(231, 49);
            this.przyciskZolty.TabIndex = 6;
            this.przyciskZolty.Text = "Żółty";
            this.przyciskZolty.UseVisualStyleBackColor = false;
            this.przyciskZolty.Visible = false;
            this.przyciskZolty.Click += new System.EventHandler(this.PrzyciskKolory_click);
            // 
            // przyciskNiebieski
            // 
            this.przyciskNiebieski.BackColor = System.Drawing.Color.Gold;
            this.przyciskNiebieski.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.przyciskNiebieski.Location = new System.Drawing.Point(296, 567);
            this.przyciskNiebieski.Name = "przyciskNiebieski";
            this.przyciskNiebieski.Size = new System.Drawing.Size(231, 49);
            this.przyciskNiebieski.TabIndex = 7;
            this.przyciskNiebieski.Text = "Niebieski";
            this.przyciskNiebieski.UseVisualStyleBackColor = false;
            this.przyciskNiebieski.Visible = false;
            this.przyciskNiebieski.Click += new System.EventHandler(this.PrzyciskKolory_click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(561, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(497, 644);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1366, 758);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.przyciskNiebieski);
            this.Controls.Add(this.przyciskZolty);
            this.Controls.Add(this.przyciskPomarancz);
            this.Controls.Add(this.przyciskZielony);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Złożony test reakcji optycznej";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button przyciskZielony;
        private System.Windows.Forms.Button przyciskPomarancz;
        private System.Windows.Forms.Button przyciskZolty;
        private System.Windows.Forms.Button przyciskNiebieski;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
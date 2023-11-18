
namespace OS2_projekt
{
    partial class Form1
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
            this.txtJavniKljuc = new System.Windows.Forms.TextBox();
            this.txtTajniKljuc = new System.Windows.Forms.TextBox();
            this.txtPrivatniKljuc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerirajAsimetricne = new System.Windows.Forms.Button();
            this.btnGenerirajSimetricne = new System.Windows.Forms.Button();
            this.btnSimetricnoKriptiranje = new System.Windows.Forms.Button();
            this.btnAsimetricnoKriptiranje = new System.Windows.Forms.Button();
            this.btnHash = new System.Windows.Forms.Button();
            this.btnDigitalniPotpis = new System.Windows.Forms.Button();
            this.btnSimetricnoDesifriranje = new System.Windows.Forms.Button();
            this.btnAsimetricnoDesifriranje = new System.Windows.Forms.Button();
            this.btnDatotekaUnos = new System.Windows.Forms.Button();
            this.labDatoteka = new System.Windows.Forms.Label();
            this.btnProvjeriPotpis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtJavniKljuc
            // 
            this.txtJavniKljuc.Location = new System.Drawing.Point(129, 32);
            this.txtJavniKljuc.Name = "txtJavniKljuc";
            this.txtJavniKljuc.Size = new System.Drawing.Size(212, 22);
            this.txtJavniKljuc.TabIndex = 0;
            // 
            // txtTajniKljuc
            // 
            this.txtTajniKljuc.Location = new System.Drawing.Point(129, 121);
            this.txtTajniKljuc.Name = "txtTajniKljuc";
            this.txtTajniKljuc.Size = new System.Drawing.Size(212, 22);
            this.txtTajniKljuc.TabIndex = 1;
            // 
            // txtPrivatniKljuc
            // 
            this.txtPrivatniKljuc.Location = new System.Drawing.Point(129, 73);
            this.txtPrivatniKljuc.Name = "txtPrivatniKljuc";
            this.txtPrivatniKljuc.Size = new System.Drawing.Size(212, 22);
            this.txtPrivatniKljuc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Javni Kljuc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Privatni Kljuc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tajni Kljuc";
            // 
            // btnGenerirajAsimetricne
            // 
            this.btnGenerirajAsimetricne.Location = new System.Drawing.Point(391, 42);
            this.btnGenerirajAsimetricne.Name = "btnGenerirajAsimetricne";
            this.btnGenerirajAsimetricne.Size = new System.Drawing.Size(173, 37);
            this.btnGenerirajAsimetricne.TabIndex = 6;
            this.btnGenerirajAsimetricne.Text = "Generiraj Javni i Privatni";
            this.btnGenerirajAsimetricne.UseVisualStyleBackColor = true;
            this.btnGenerirajAsimetricne.Click += new System.EventHandler(this.btnGenerirajAsimetricne_Click);
            // 
            // btnGenerirajSimetricne
            // 
            this.btnGenerirajSimetricne.Location = new System.Drawing.Point(416, 111);
            this.btnGenerirajSimetricne.Name = "btnGenerirajSimetricne";
            this.btnGenerirajSimetricne.Size = new System.Drawing.Size(128, 37);
            this.btnGenerirajSimetricne.TabIndex = 7;
            this.btnGenerirajSimetricne.Text = "Generiraj Tajni";
            this.btnGenerirajSimetricne.UseVisualStyleBackColor = true;
            this.btnGenerirajSimetricne.Click += new System.EventHandler(this.btnGenerirajSimetricne_Click);
            // 
            // btnSimetricnoKriptiranje
            // 
            this.btnSimetricnoKriptiranje.Location = new System.Drawing.Point(712, 262);
            this.btnSimetricnoKriptiranje.Name = "btnSimetricnoKriptiranje";
            this.btnSimetricnoKriptiranje.Size = new System.Drawing.Size(95, 45);
            this.btnSimetricnoKriptiranje.TabIndex = 14;
            this.btnSimetricnoKriptiranje.Text = "Simetricno kriptiranje";
            this.btnSimetricnoKriptiranje.UseVisualStyleBackColor = true;
            this.btnSimetricnoKriptiranje.Click += new System.EventHandler(this.btnSimetricnoKriptiranje_Click);
            // 
            // btnAsimetricnoKriptiranje
            // 
            this.btnAsimetricnoKriptiranje.Location = new System.Drawing.Point(712, 336);
            this.btnAsimetricnoKriptiranje.Name = "btnAsimetricnoKriptiranje";
            this.btnAsimetricnoKriptiranje.Size = new System.Drawing.Size(95, 49);
            this.btnAsimetricnoKriptiranje.TabIndex = 15;
            this.btnAsimetricnoKriptiranje.Text = "Asimetricno kriptiranje";
            this.btnAsimetricnoKriptiranje.UseVisualStyleBackColor = true;
            this.btnAsimetricnoKriptiranje.Click += new System.EventHandler(this.btnAsimetricnoKriptiranje_Click);
            // 
            // btnHash
            // 
            this.btnHash.Location = new System.Drawing.Point(755, 551);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(128, 37);
            this.btnHash.TabIndex = 16;
            this.btnHash.Text = "Hash";
            this.btnHash.UseVisualStyleBackColor = true;
            this.btnHash.Click += new System.EventHandler(this.btnHash_Click);
            // 
            // btnDigitalniPotpis
            // 
            this.btnDigitalniPotpis.Location = new System.Drawing.Point(712, 420);
            this.btnDigitalniPotpis.Name = "btnDigitalniPotpis";
            this.btnDigitalniPotpis.Size = new System.Drawing.Size(95, 52);
            this.btnDigitalniPotpis.TabIndex = 17;
            this.btnDigitalniPotpis.Text = "Digitalni Potpis";
            this.btnDigitalniPotpis.UseVisualStyleBackColor = true;
            this.btnDigitalniPotpis.Click += new System.EventHandler(this.btnDigitalniPotpis_Click);
            // 
            // btnSimetricnoDesifriranje
            // 
            this.btnSimetricnoDesifriranje.Location = new System.Drawing.Point(836, 262);
            this.btnSimetricnoDesifriranje.Name = "btnSimetricnoDesifriranje";
            this.btnSimetricnoDesifriranje.Size = new System.Drawing.Size(95, 45);
            this.btnSimetricnoDesifriranje.TabIndex = 18;
            this.btnSimetricnoDesifriranje.Text = "Simetricno dekriptiranje";
            this.btnSimetricnoDesifriranje.UseVisualStyleBackColor = true;
            this.btnSimetricnoDesifriranje.Click += new System.EventHandler(this.btnSimetricnoDesifriranje_Click);
            // 
            // btnAsimetricnoDesifriranje
            // 
            this.btnAsimetricnoDesifriranje.Location = new System.Drawing.Point(836, 340);
            this.btnAsimetricnoDesifriranje.Name = "btnAsimetricnoDesifriranje";
            this.btnAsimetricnoDesifriranje.Size = new System.Drawing.Size(95, 45);
            this.btnAsimetricnoDesifriranje.TabIndex = 19;
            this.btnAsimetricnoDesifriranje.Text = "Simetricno dekriptiranje";
            this.btnAsimetricnoDesifriranje.UseVisualStyleBackColor = true;
            this.btnAsimetricnoDesifriranje.Click += new System.EventHandler(this.btnAsimetricnoDesifriranje_Click);
            // 
            // btnDatotekaUnos
            // 
            this.btnDatotekaUnos.Location = new System.Drawing.Point(252, 384);
            this.btnDatotekaUnos.Name = "btnDatotekaUnos";
            this.btnDatotekaUnos.Size = new System.Drawing.Size(122, 64);
            this.btnDatotekaUnos.TabIndex = 20;
            this.btnDatotekaUnos.Text = "Upload file";
            this.btnDatotekaUnos.UseVisualStyleBackColor = true;
            this.btnDatotekaUnos.Click += new System.EventHandler(this.btnDatotekaUnos_Click);
            // 
            // labDatoteka
            // 
            this.labDatoteka.AutoSize = true;
            this.labDatoteka.Location = new System.Drawing.Point(262, 343);
            this.labDatoteka.Name = "labDatoteka";
            this.labDatoteka.Size = new System.Drawing.Size(0, 17);
            this.labDatoteka.TabIndex = 21;
            // 
            // btnProvjeriPotpis
            // 
            this.btnProvjeriPotpis.Location = new System.Drawing.Point(836, 420);
            this.btnProvjeriPotpis.Name = "btnProvjeriPotpis";
            this.btnProvjeriPotpis.Size = new System.Drawing.Size(95, 52);
            this.btnProvjeriPotpis.TabIndex = 22;
            this.btnProvjeriPotpis.Text = "Provjeri Potpis";
            this.btnProvjeriPotpis.UseVisualStyleBackColor = true;
            this.btnProvjeriPotpis.Click += new System.EventHandler(this.btnProvjeriPotpis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 687);
            this.Controls.Add(this.btnProvjeriPotpis);
            this.Controls.Add(this.labDatoteka);
            this.Controls.Add(this.btnDatotekaUnos);
            this.Controls.Add(this.btnAsimetricnoDesifriranje);
            this.Controls.Add(this.btnSimetricnoDesifriranje);
            this.Controls.Add(this.btnDigitalniPotpis);
            this.Controls.Add(this.btnHash);
            this.Controls.Add(this.btnAsimetricnoKriptiranje);
            this.Controls.Add(this.btnSimetricnoKriptiranje);
            this.Controls.Add(this.btnGenerirajSimetricne);
            this.Controls.Add(this.btnGenerirajAsimetricne);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrivatniKljuc);
            this.Controls.Add(this.txtTajniKljuc);
            this.Controls.Add(this.txtJavniKljuc);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtJavniKljuc;
        private System.Windows.Forms.TextBox txtTajniKljuc;
        private System.Windows.Forms.TextBox txtPrivatniKljuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerirajAsimetricne;
        private System.Windows.Forms.Button btnGenerirajSimetricne;
        private System.Windows.Forms.Button btnSimetricnoKriptiranje;
        private System.Windows.Forms.Button btnAsimetricnoKriptiranje;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.Button btnDigitalniPotpis;
        private System.Windows.Forms.Button btnSimetricnoDesifriranje;
        private System.Windows.Forms.Button btnAsimetricnoDesifriranje;
        private System.Windows.Forms.Button btnDatotekaUnos;
        private System.Windows.Forms.Label labDatoteka;
        private System.Windows.Forms.Button btnProvjeriPotpis;
    }
}


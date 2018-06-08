namespace TicTacToe
{
    partial class BoardForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoardForm));
            this.B20 = new System.Windows.Forms.Button();
            this.B01 = new System.Windows.Forms.Button();
            this.B11 = new System.Windows.Forms.Button();
            this.B21 = new System.Windows.Forms.Button();
            this.B02 = new System.Windows.Forms.Button();
            this.B12 = new System.Windows.Forms.Button();
            this.B22 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B00 = new System.Windows.Forms.Button();
            this.B10 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // B20
            // 
            this.B20.BackColor = System.Drawing.Color.Wheat;
            this.B20.Location = new System.Drawing.Point(257, 24);
            this.B20.Name = "B20";
            this.B20.Size = new System.Drawing.Size(110, 110);
            this.B20.TabIndex = 3;
            this.B20.UseVisualStyleBackColor = false;
            this.B20.Click += new System.EventHandler(this.button_ClickX);
            // 
            // B01
            // 
            this.B01.BackColor = System.Drawing.Color.Wheat;
            this.B01.Location = new System.Drawing.Point(25, 140);
            this.B01.Name = "B01";
            this.B01.Size = new System.Drawing.Size(110, 110);
            this.B01.TabIndex = 4;
            this.B01.UseVisualStyleBackColor = false;
            this.B01.Click += new System.EventHandler(this.button_ClickX);
            // 
            // B11
            // 
            this.B11.BackColor = System.Drawing.Color.Wheat;
            this.B11.Location = new System.Drawing.Point(141, 140);
            this.B11.Name = "B11";
            this.B11.Size = new System.Drawing.Size(110, 110);
            this.B11.TabIndex = 5;
            this.B11.UseVisualStyleBackColor = false;
            this.B11.Click += new System.EventHandler(this.button_ClickX);
            // 
            // B21
            // 
            this.B21.BackColor = System.Drawing.Color.Wheat;
            this.B21.Location = new System.Drawing.Point(257, 140);
            this.B21.Name = "B21";
            this.B21.Size = new System.Drawing.Size(110, 110);
            this.B21.TabIndex = 6;
            this.B21.UseVisualStyleBackColor = false;
            this.B21.Click += new System.EventHandler(this.button_ClickX);
            // 
            // B02
            // 
            this.B02.BackColor = System.Drawing.Color.Wheat;
            this.B02.Location = new System.Drawing.Point(25, 256);
            this.B02.Name = "B02";
            this.B02.Size = new System.Drawing.Size(110, 110);
            this.B02.TabIndex = 7;
            this.B02.UseVisualStyleBackColor = false;
            this.B02.Click += new System.EventHandler(this.button_ClickX);
            // 
            // B12
            // 
            this.B12.BackColor = System.Drawing.Color.Wheat;
            this.B12.Location = new System.Drawing.Point(141, 256);
            this.B12.Name = "B12";
            this.B12.Size = new System.Drawing.Size(110, 110);
            this.B12.TabIndex = 8;
            this.B12.UseVisualStyleBackColor = false;
            this.B12.Click += new System.EventHandler(this.button_ClickX);
            // 
            // B22
            // 
            this.B22.BackColor = System.Drawing.Color.Wheat;
            this.B22.Location = new System.Drawing.Point(257, 256);
            this.B22.Name = "B22";
            this.B22.Size = new System.Drawing.Size(110, 110);
            this.B22.TabIndex = 9;
            this.B22.UseVisualStyleBackColor = false;
            this.B22.Click += new System.EventHandler(this.button_ClickX);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.B00);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 366);
            this.panel1.TabIndex = 0;
            // 
            // B00
            // 
            this.B00.BackColor = System.Drawing.Color.Wheat;
            this.B00.Location = new System.Drawing.Point(12, 11);
            this.B00.Name = "B00";
            this.B00.Size = new System.Drawing.Size(110, 110);
            this.B00.TabIndex = 1;
            this.B00.UseVisualStyleBackColor = false;
            this.B00.Click += new System.EventHandler(this.button_ClickX);
            // 
            // B10
            // 
            this.B10.BackColor = System.Drawing.Color.Wheat;
            this.B10.Location = new System.Drawing.Point(141, 24);
            this.B10.Name = "B10";
            this.B10.Size = new System.Drawing.Size(110, 110);
            this.B10.TabIndex = 2;
            this.B10.UseVisualStyleBackColor = false;
            this.B10.Click += new System.EventHandler(this.button_ClickX);
            // 
            // BoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(393, 389);
            this.Controls.Add(this.B22);
            this.Controls.Add(this.B12);
            this.Controls.Add(this.B02);
            this.Controls.Add(this.B21);
            this.Controls.Add(this.B11);
            this.Controls.Add(this.B01);
            this.Controls.Add(this.B20);
            this.Controls.Add(this.B10);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BoardForm";
            this.Text = "TicTacToe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B00;
        private System.Windows.Forms.Button B10;
        private System.Windows.Forms.Button B20;
        private System.Windows.Forms.Button B01;
        private System.Windows.Forms.Button B11;
        private System.Windows.Forms.Button B21;
        private System.Windows.Forms.Button B02;
        private System.Windows.Forms.Button B12;
        private System.Windows.Forms.Button B22;
        private System.Windows.Forms.Panel panel1;
    }
}


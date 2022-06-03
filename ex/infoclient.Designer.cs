
namespace Examen
{
    partial class infoclient
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
            this.pronnumber = new System.Windows.Forms.Button();
            this.callme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pronnumber
            // 
            this.pronnumber.Location = new System.Drawing.Point(12, 22);
            this.pronnumber.Name = "pronnumber";
            this.pronnumber.Size = new System.Drawing.Size(181, 36);
            this.pronnumber.TabIndex = 0;
            this.pronnumber.Text = "Забронировать номер";
            this.pronnumber.UseVisualStyleBackColor = true;
            this.pronnumber.Click += new System.EventHandler(this.pronnumber_Click);
            // 
            // callme
            // 
            this.callme.Location = new System.Drawing.Point(12, 82);
            this.callme.Name = "callme";
            this.callme.Size = new System.Drawing.Size(181, 36);
            this.callme.TabIndex = 1;
            this.callme.Text = "Связаться с нами";
            this.callme.UseVisualStyleBackColor = true;
            this.callme.Click += new System.EventHandler(this.callme_Click);
            // 
            // infoclient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(205, 132);
            this.Controls.Add(this.callme);
            this.Controls.Add(this.pronnumber);
            this.Name = "infoclient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Бронирование номера";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pronnumber;
        private System.Windows.Forms.Button callme;
    }
}
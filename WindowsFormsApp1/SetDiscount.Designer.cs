﻿namespace WindowsFormsApp1
{
    partial class SetDiscount
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
            this.Price = new System.Windows.Forms.Label();
            this.Msg = new System.Windows.Forms.Label();
            this.AmountBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SumbitB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Price.Location = new System.Drawing.Point(201, 199);
            this.Price.Name = "Price";
            this.Price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Price.Size = new System.Drawing.Size(0, 18);
            this.Price.TabIndex = 49;
            this.Price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Price.UseMnemonic = false;
            // 
            // Msg
            // 
            this.Msg.AutoSize = true;
            this.Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Msg.ForeColor = System.Drawing.Color.Red;
            this.Msg.Location = new System.Drawing.Point(277, 244);
            this.Msg.Name = "Msg";
            this.Msg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Msg.Size = new System.Drawing.Size(0, 20);
            this.Msg.TabIndex = 48;
            this.Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Msg.UseMnemonic = false;
            // 
            // AmountBox
            // 
            this.AmountBox.Location = new System.Drawing.Point(168, 169);
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.Size = new System.Drawing.Size(219, 20);
            this.AmountBox.TabIndex = 47;
            this.AmountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(254, 88);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(54, 24);
            this.label13.TabIndex = 46;
            this.label13.Text = "הנחה";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.UseMnemonic = false;
            // 
            // SumbitB
            // 
            this.SumbitB.Location = new System.Drawing.Point(212, 283);
            this.SumbitB.Name = "SumbitB";
            this.SumbitB.Size = new System.Drawing.Size(130, 24);
            this.SumbitB.TabIndex = 45;
            this.SumbitB.Text = "אישור";
            this.SumbitB.UseVisualStyleBackColor = true;
            this.SumbitB.Click += new System.EventHandler(this.SumbitB_Click);
            // 
            // SetDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 394);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.AmountBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.SumbitB);
            this.Name = "SetDiscount";
            this.Text = "SetDiscount";
            this.Load += new System.EventHandler(this.SetDiscount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label Msg;
        private System.Windows.Forms.TextBox AmountBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button SumbitB;
    }
}
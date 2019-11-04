namespace CowApp
{
    partial class CowListForm
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
            this.lbCows = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateCow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCows
            // 
            this.lbCows.FormattingEnabled = true;
            this.lbCows.Location = new System.Drawing.Point(12, 31);
            this.lbCows.Name = "lbCows";
            this.lbCows.Size = new System.Drawing.Size(346, 225);
            this.lbCows.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of Cows";
            // 
            // btnUpdateCow
            // 
            this.btnUpdateCow.Location = new System.Drawing.Point(12, 263);
            this.btnUpdateCow.Name = "btnUpdateCow";
            this.btnUpdateCow.Size = new System.Drawing.Size(346, 36);
            this.btnUpdateCow.TabIndex = 2;
            this.btnUpdateCow.Text = "Update Selected Cow Data";
            this.btnUpdateCow.UseVisualStyleBackColor = true;
            this.btnUpdateCow.Click += new System.EventHandler(this.btnUpdateCow_Click);
            // 
            // CowListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 311);
            this.Controls.Add(this.btnUpdateCow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCows);
            this.Name = "CowListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cow Farm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbCows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateCow;
    }
}


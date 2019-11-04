namespace CowApp.SubForms
{
    partial class UpdateCowForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBreed = new System.Windows.Forms.Label();
            this.ddBreed = new System.Windows.Forms.ComboBox();
            this.lblDob = new System.Windows.Forms.Label();
            this.dpDob = new System.Windows.Forms.DateTimePicker();
            this.lblVetId = new System.Windows.Forms.Label();
            this.mtxtVetId = new System.Windows.Forms.MaskedTextBox();
            this.lblDoA = new System.Windows.Forms.Label();
            this.dpDoA = new System.Windows.Forms.DateTimePicker();
            this.lblCalfCount = new System.Windows.Forms.Label();
            this.numCalf = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCalf)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(15, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(235, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblBreed
            // 
            this.lblBreed.AutoSize = true;
            this.lblBreed.Location = new System.Drawing.Point(12, 67);
            this.lblBreed.Name = "lblBreed";
            this.lblBreed.Size = new System.Drawing.Size(35, 13);
            this.lblBreed.TabIndex = 2;
            this.lblBreed.Text = "Breed";
            // 
            // ddBreed
            // 
            this.ddBreed.FormattingEnabled = true;
            this.ddBreed.Location = new System.Drawing.Point(15, 84);
            this.ddBreed.Name = "ddBreed";
            this.ddBreed.Size = new System.Drawing.Size(235, 21);
            this.ddBreed.TabIndex = 3;
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Location = new System.Drawing.Point(12, 116);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(66, 13);
            this.lblDob.TabIndex = 4;
            this.lblDob.Text = "Date of Birth";
            // 
            // dpDob
            // 
            this.dpDob.Location = new System.Drawing.Point(15, 133);
            this.dpDob.Name = "dpDob";
            this.dpDob.Size = new System.Drawing.Size(235, 20);
            this.dpDob.TabIndex = 5;
            // 
            // lblVetId
            // 
            this.lblVetId.AutoSize = true;
            this.lblVetId.Location = new System.Drawing.Point(12, 163);
            this.lblVetId.Name = "lblVetId";
            this.lblVetId.Size = new System.Drawing.Size(37, 13);
            this.lblVetId.TabIndex = 6;
            this.lblVetId.Text = "Vet ID";
            // 
            // mtxtVetId
            // 
            this.mtxtVetId.Location = new System.Drawing.Point(15, 179);
            this.mtxtVetId.Mask = "HR999999999";
            this.mtxtVetId.Name = "mtxtVetId";
            this.mtxtVetId.Size = new System.Drawing.Size(235, 20);
            this.mtxtVetId.TabIndex = 7;
            // 
            // lblDoA
            // 
            this.lblDoA.AutoSize = true;
            this.lblDoA.Location = new System.Drawing.Point(12, 209);
            this.lblDoA.Name = "lblDoA";
            this.lblDoA.Size = new System.Drawing.Size(112, 13);
            this.lblDoA.TabIndex = 8;
            this.lblDoA.Text = "Date of Arrival to Farm";
            // 
            // dpDoA
            // 
            this.dpDoA.Location = new System.Drawing.Point(15, 226);
            this.dpDoA.Name = "dpDoA";
            this.dpDoA.Size = new System.Drawing.Size(235, 20);
            this.dpDoA.TabIndex = 9;
            // 
            // lblCalfCount
            // 
            this.lblCalfCount.AutoSize = true;
            this.lblCalfCount.Location = new System.Drawing.Point(12, 256);
            this.lblCalfCount.Name = "lblCalfCount";
            this.lblCalfCount.Size = new System.Drawing.Size(55, 13);
            this.lblCalfCount.TabIndex = 10;
            this.lblCalfCount.Text = "Calf count";
            // 
            // numCalf
            // 
            this.numCalf.Location = new System.Drawing.Point(15, 273);
            this.numCalf.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numCalf.Name = "numCalf";
            this.numCalf.Size = new System.Drawing.Size(235, 20);
            this.numCalf.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 33);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(141, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 33);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UpdateCowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 364);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numCalf);
            this.Controls.Add(this.lblCalfCount);
            this.Controls.Add(this.dpDoA);
            this.Controls.Add(this.lblDoA);
            this.Controls.Add(this.mtxtVetId);
            this.Controls.Add(this.lblVetId);
            this.Controls.Add(this.dpDob);
            this.Controls.Add(this.lblDob);
            this.Controls.Add(this.ddBreed);
            this.Controls.Add(this.lblBreed);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "UpdateCowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Cow";
            ((System.ComponentModel.ISupportInitialize)(this.numCalf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBreed;
        private System.Windows.Forms.ComboBox ddBreed;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.DateTimePicker dpDob;
        private System.Windows.Forms.Label lblVetId;
        private System.Windows.Forms.MaskedTextBox mtxtVetId;
        private System.Windows.Forms.DateTimePicker dpDoA;
        private System.Windows.Forms.Label lblDoA;
        private System.Windows.Forms.Label lblCalfCount;
        private System.Windows.Forms.NumericUpDown numCalf;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
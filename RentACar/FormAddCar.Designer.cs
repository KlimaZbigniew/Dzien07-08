
namespace RentACar
{
    partial class FormAddCar
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
            this.cbBrands = new System.Windows.Forms.ComboBox();
            this.cbModels = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.tbRegPlate = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFuel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picCar = new System.Windows.Forms.PictureBox();
            this.btnLoadPic = new System.Windows.Forms.Button();
            this.btnDelPic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBrands
            // 
            this.cbBrands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrands.FormattingEnabled = true;
            this.cbBrands.Location = new System.Drawing.Point(72, 54);
            this.cbBrands.Name = "cbBrands";
            this.cbBrands.Size = new System.Drawing.Size(121, 21);
            this.cbBrands.TabIndex = 0;
            // 
            // cbModels
            // 
            this.cbModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModels.FormattingEnabled = true;
            this.cbModels.Location = new System.Drawing.Point(72, 93);
            this.cbModels.Name = "cbModels";
            this.cbModels.Size = new System.Drawing.Size(121, 21);
            this.cbModels.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Marka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Własność:";
            // 
            // cbTypes
            // 
            this.cbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Location = new System.Drawing.Point(72, 135);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(121, 21);
            this.cbTypes.TabIndex = 4;
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(72, 204);
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(120, 20);
            this.numYear.TabIndex = 6;
            // 
            // tbRegPlate
            // 
            this.tbRegPlate.Location = new System.Drawing.Point(72, 248);
            this.tbRegPlate.Name = "tbRegPlate";
            this.tbRegPlate.Size = new System.Drawing.Size(120, 20);
            this.tbRegPlate.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nr rej,:";
            // 
            // cbFuel
            // 
            this.cbFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuel.FormattingEnabled = true;
            this.cbFuel.Items.AddRange(new object[] {
            "PB",
            "ON",
            "LPG"});
            this.cbFuel.Location = new System.Drawing.Point(72, 317);
            this.cbFuel.Name = "cbFuel";
            this.cbFuel.Size = new System.Drawing.Size(121, 21);
            this.cbFuel.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "paliwo:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(94, 368);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(151, 55);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "button1";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(514, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(181, 49);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "button2";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // picCar
            // 
            this.picCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCar.Location = new System.Drawing.Point(381, 57);
            this.picCar.Name = "picCar";
            this.picCar.Size = new System.Drawing.Size(313, 280);
            this.picCar.TabIndex = 13;
            this.picCar.TabStop = false;
            // 
            // btnLoadPic
            // 
            this.btnLoadPic.Location = new System.Drawing.Point(711, 89);
            this.btnLoadPic.Name = "btnLoadPic";
            this.btnLoadPic.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPic.TabIndex = 14;
            this.btnLoadPic.Text = "+";
            this.btnLoadPic.UseVisualStyleBackColor = true;
            // 
            // btnDelPic
            // 
            this.btnDelPic.Location = new System.Drawing.Point(711, 143);
            this.btnDelPic.Name = "btnDelPic";
            this.btnDelPic.Size = new System.Drawing.Size(75, 23);
            this.btnDelPic.TabIndex = 15;
            this.btnDelPic.Text = "-";
            this.btnDelPic.UseVisualStyleBackColor = true;
            // 
            // FormAddCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelPic);
            this.Controls.Add(this.btnLoadPic);
            this.Controls.Add(this.picCar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbFuel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbRegPlate);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbModels);
            this.Controls.Add(this.cbBrands);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddCar";
            this.Text = "FormAddCar";
            this.Load += new System.EventHandler(this.FormAddCar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBrands;
        private System.Windows.Forms.ComboBox cbModels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.MaskedTextBox tbRegPlate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFuel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picCar;
        private System.Windows.Forms.Button btnLoadPic;
        private System.Windows.Forms.Button btnDelPic;
    }
}
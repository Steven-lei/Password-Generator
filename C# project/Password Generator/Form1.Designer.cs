namespace Password_Generator
{
    partial class FormGenerator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxIncUpper = new System.Windows.Forms.CheckBox();
            this.checkBoxIncLower = new System.Windows.Forms.CheckBox();
            this.checkBoxIncNumbers = new System.Windows.Forms.CheckBox();
            this.checkBoxIncSymbols = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMaxLen = new System.Windows.Forms.TextBox();
            this.textBoxMinLen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxCreateCount = new System.Windows.Forms.TextBox();
            this.checkBoxBatchCreate = new System.Windows.Forms.CheckBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxIncUpper);
            this.groupBox1.Controls.Add(this.checkBoxIncLower);
            this.groupBox1.Controls.Add(this.checkBoxIncNumbers);
            this.groupBox1.Controls.Add(this.checkBoxIncSymbols);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxMaxLen);
            this.groupBox1.Controls.Add(this.textBoxMinLen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(50, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 218);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configeration";
            // 
            // checkBoxIncUpper
            // 
            this.checkBoxIncUpper.AutoSize = true;
            this.checkBoxIncUpper.Checked = true;
            this.checkBoxIncUpper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncUpper.Location = new System.Drawing.Point(359, 168);
            this.checkBoxIncUpper.Name = "checkBoxIncUpper";
            this.checkBoxIncUpper.Size = new System.Drawing.Size(245, 35);
            this.checkBoxIncUpper.TabIndex = 10;
            this.checkBoxIncUpper.Text = "Upper Characters";
            this.checkBoxIncUpper.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncLower
            // 
            this.checkBoxIncLower.AutoSize = true;
            this.checkBoxIncLower.Checked = true;
            this.checkBoxIncLower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncLower.Location = new System.Drawing.Point(42, 168);
            this.checkBoxIncLower.Name = "checkBoxIncLower";
            this.checkBoxIncLower.Size = new System.Drawing.Size(243, 35);
            this.checkBoxIncLower.TabIndex = 9;
            this.checkBoxIncLower.Text = "Lower Characters";
            this.checkBoxIncLower.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncNumbers
            // 
            this.checkBoxIncNumbers.AutoSize = true;
            this.checkBoxIncNumbers.Location = new System.Drawing.Point(360, 117);
            this.checkBoxIncNumbers.Name = "checkBoxIncNumbers";
            this.checkBoxIncNumbers.Size = new System.Drawing.Size(242, 35);
            this.checkBoxIncNumbers.TabIndex = 8;
            this.checkBoxIncNumbers.Text = "include Numbers";
            this.checkBoxIncNumbers.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncSymbols
            // 
            this.checkBoxIncSymbols.AutoSize = true;
            this.checkBoxIncSymbols.Location = new System.Drawing.Point(42, 117);
            this.checkBoxIncSymbols.Name = "checkBoxIncSymbols";
            this.checkBoxIncSymbols.Size = new System.Drawing.Size(232, 35);
            this.checkBoxIncSymbols.TabIndex = 7;
            this.checkBoxIncSymbols.Text = "include Symbols";
            this.checkBoxIncSymbols.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "To";
            // 
            // textBoxMaxLen
            // 
            this.textBoxMaxLen.Location = new System.Drawing.Point(464, 48);
            this.textBoxMaxLen.MaxLength = 2;
            this.textBoxMaxLen.Name = "textBoxMaxLen";
            this.textBoxMaxLen.Size = new System.Drawing.Size(79, 38);
            this.textBoxMaxLen.TabIndex = 5;
            // 
            // textBoxMinLen
            // 
            this.textBoxMinLen.Location = new System.Drawing.Point(321, 48);
            this.textBoxMinLen.MaxLength = 2;
            this.textBoxMinLen.Name = "textBoxMinLen";
            this.textBoxMinLen.Size = new System.Drawing.Size(75, 38);
            this.textBoxMinLen.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password Length From:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 31;
            this.listBox1.Location = new System.Drawing.Point(50, 299);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(1031, 500);
            this.listBox1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxCreateCount);
            this.groupBox2.Controls.Add(this.checkBoxBatchCreate);
            this.groupBox2.Controls.Add(this.btnCopy);
            this.groupBox2.Controls.Add(this.btnGenerate);
            this.groupBox2.Location = new System.Drawing.Point(713, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 218);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operate";
            // 
            // textBoxCreateCount
            // 
            this.textBoxCreateCount.Location = new System.Drawing.Point(256, 59);
            this.textBoxCreateCount.Name = "textBoxCreateCount";
            this.textBoxCreateCount.ReadOnly = true;
            this.textBoxCreateCount.Size = new System.Drawing.Size(67, 38);
            this.textBoxCreateCount.TabIndex = 17;
            this.textBoxCreateCount.Text = "10";
            // 
            // checkBoxBatchCreate
            // 
            this.checkBoxBatchCreate.AutoSize = true;
            this.checkBoxBatchCreate.Location = new System.Drawing.Point(27, 62);
            this.checkBoxBatchCreate.Name = "checkBoxBatchCreate";
            this.checkBoxBatchCreate.Size = new System.Drawing.Size(185, 35);
            this.checkBoxBatchCreate.TabIndex = 16;
            this.checkBoxBatchCreate.Text = "BatchCreate";
            this.checkBoxBatchCreate.UseVisualStyleBackColor = true;
            this.checkBoxBatchCreate.CheckedChanged += new System.EventHandler(this.checkBoxBatchCreate_CheckedChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(214, 131);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(138, 46);
            this.btnCopy.TabIndex = 15;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(27, 131);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(138, 46);
            this.btnGenerate.TabIndex = 14;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // FormGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 831);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormGenerator";
            this.Text = "Password Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private GroupBox groupBox1;
        private CheckBox checkBoxIncUpper;
        private CheckBox checkBoxIncLower;
        private CheckBox checkBoxIncNumbers;
        private CheckBox checkBoxIncSymbols;
        private Label label3;
        private TextBox textBoxMaxLen;
        private TextBox textBoxMinLen;
        private Label label2;
        private ListBox listBox1;
        private GroupBox groupBox2;
        private TextBox textBoxCreateCount;
        private CheckBox checkBoxBatchCreate;
        private Button btnCopy;
        private Button btnGenerate;
    }
}
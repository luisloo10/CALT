namespace CoEVO.Forms
{
    partial class Parameters
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
            this.label1 = new System.Windows.Forms.Label();
            this.dFrom = new System.Windows.Forms.DateTimePicker();
            this.dTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.nPopSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nIterationsGA = new System.Windows.Forms.NumericUpDown();
            this.nIterationsCoEA = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nCrossoverRate = new System.Windows.Forms.NumericUpDown();
            this.nMutationRate = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.nPopSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIterationsGA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIterationsCoEA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCrossoverRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMutationRate)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // dFrom
            // 
            this.dFrom.Location = new System.Drawing.Point(97, 30);
            this.dFrom.Name = "dFrom";
            this.dFrom.Size = new System.Drawing.Size(153, 20);
            this.dFrom.TabIndex = 1;
            this.dFrom.ValueChanged += new System.EventHandler(this.dFrom_ValueChanged);
            // 
            // dTo
            // 
            this.dTo.Location = new System.Drawing.Point(97, 56);
            this.dTo.Name = "dTo";
            this.dTo.Size = new System.Drawing.Size(153, 20);
            this.dTo.TabIndex = 1;
            this.dTo.ValueChanged += new System.EventHandler(this.dTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "To";
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(97, 228);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(80, 41);
            this.bOK.TabIndex = 2;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // nPopSize
            // 
            this.nPopSize.Location = new System.Drawing.Point(97, 82);
            this.nPopSize.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nPopSize.Name = "nPopSize";
            this.nPopSize.Size = new System.Drawing.Size(49, 20);
            this.nPopSize.TabIndex = 6;
            this.nPopSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nPopSize.ValueChanged += new System.EventHandler(this.nPopSize_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "POP Size";
            // 
            // nIterationsGA
            // 
            this.nIterationsGA.Location = new System.Drawing.Point(97, 108);
            this.nIterationsGA.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nIterationsGA.Name = "nIterationsGA";
            this.nIterationsGA.Size = new System.Drawing.Size(49, 20);
            this.nIterationsGA.TabIndex = 6;
            this.nIterationsGA.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nIterationsGA.ValueChanged += new System.EventHandler(this.nPopSize_ValueChanged);
            // 
            // nIterationsCoEA
            // 
            this.nIterationsCoEA.Location = new System.Drawing.Point(97, 134);
            this.nIterationsCoEA.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nIterationsCoEA.Name = "nIterationsCoEA";
            this.nIterationsCoEA.Size = new System.Drawing.Size(49, 20);
            this.nIterationsCoEA.TabIndex = 6;
            this.nIterationsCoEA.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nIterationsCoEA.ValueChanged += new System.EventHandler(this.nPopSize_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "IterationsGA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "IterationsCoEA";
            // 
            // nCrossoverRate
            // 
            this.nCrossoverRate.DecimalPlaces = 2;
            this.nCrossoverRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nCrossoverRate.Location = new System.Drawing.Point(97, 160);
            this.nCrossoverRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nCrossoverRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nCrossoverRate.Name = "nCrossoverRate";
            this.nCrossoverRate.Size = new System.Drawing.Size(49, 20);
            this.nCrossoverRate.TabIndex = 6;
            this.nCrossoverRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nCrossoverRate.ValueChanged += new System.EventHandler(this.nPopSize_ValueChanged);
            // 
            // nMutationRate
            // 
            this.nMutationRate.DecimalPlaces = 2;
            this.nMutationRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nMutationRate.Location = new System.Drawing.Point(97, 186);
            this.nMutationRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMutationRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nMutationRate.Name = "nMutationRate";
            this.nMutationRate.Size = new System.Drawing.Size(49, 20);
            this.nMutationRate.TabIndex = 6;
            this.nMutationRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMutationRate.ValueChanged += new System.EventHandler(this.nPopSize_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Crossover";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Mutation";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(596, 531);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(588, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Algorithm Parameters";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(588, 505);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Supplying POP";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bOK);
            this.groupBox1.Controls.Add(this.nMutationRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nCrossoverRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nIterationsCoEA);
            this.groupBox1.Controls.Add(this.dFrom);
            this.groupBox1.Controls.Add(this.nIterationsGA);
            this.groupBox1.Controls.Add(this.dTo);
            this.groupBox1.Controls.Add(this.nPopSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(22, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 345);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(588, 505);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Demanding POP";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Parameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 531);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Name = "Parameters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parameters";
            this.Load += new System.EventHandler(this.Parameters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nPopSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIterationsGA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIterationsCoEA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCrossoverRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMutationRate)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dFrom;
        private System.Windows.Forms.DateTimePicker dTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.NumericUpDown nPopSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nIterationsGA;
        private System.Windows.Forms.NumericUpDown nIterationsCoEA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nCrossoverRate;
        private System.Windows.Forms.NumericUpDown nMutationRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage3;
    }
}
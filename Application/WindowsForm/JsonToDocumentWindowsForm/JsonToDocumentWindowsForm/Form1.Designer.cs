namespace JsonToDocumentWindowsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_head = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox_exit = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.richTextBox_json = new System.Windows.Forms.RichTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox_properties = new System.Windows.Forms.CheckBox();
            this.checkBox_pascal = new System.Windows.Forms.CheckBox();
            this.checkBox_example = new System.Windows.Forms.CheckBox();
            this.button_generate = new System.Windows.Forms.Button();
            this.radioButton_class = new System.Windows.Forms.RadioButton();
            this.radioButton_dataset = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_head)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_exit)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox_head);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(51, 579);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 480);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(533, 47);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox_head
            // 
            this.pictureBox_head.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_head.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_head.Name = "pictureBox_head";
            this.pictureBox_head.Size = new System.Drawing.Size(533, 52);
            this.pictureBox_head.TabIndex = 0;
            this.pictureBox_head.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.panel2.Controls.Add(this.pictureBox_exit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(479, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(62, 579);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox_exit
            // 
            this.pictureBox_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_exit.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_exit.Image")));
            this.pictureBox_exit.Location = new System.Drawing.Point(8, 5);
            this.pictureBox_exit.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_exit.Name = "pictureBox_exit";
            this.pictureBox_exit.Size = new System.Drawing.Size(48, 47);
            this.pictureBox_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_exit.TabIndex = 0;
            this.pictureBox_exit.TabStop = false;
            this.pictureBox_exit.Click += new System.EventHandler(this.PictureBox_exit_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(51, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(428, 101);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Kunstler Script", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Json to Document";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.CadetBlue;
            this.panel7.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(428, 52);
            this.panel7.TabIndex = 1;
            this.panel7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel7_MouseMove);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(51, 536);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(428, 43);
            this.panel4.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.CadetBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Kunstler Script", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 43);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thank you";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.richTextBox_json);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(51, 101);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(428, 176);
            this.panel5.TabIndex = 4;
            // 
            // richTextBox_json
            // 
            this.richTextBox_json.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_json.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_json.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_json.Name = "richTextBox_json";
            this.richTextBox_json.Size = new System.Drawing.Size(428, 176);
            this.richTextBox_json.TabIndex = 0;
            this.richTextBox_json.Text = "{\n   \"name\":\"cake\",\n    \"level\":{\n          \"current\":80,\n          \"max\":99\n   }" +
    "\n}";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.radioButton_dataset);
            this.panel6.Controls.Add(this.radioButton_class);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(51, 318);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(428, 218);
            this.panel6.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(51, 324);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(428, 180);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(420, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox_properties
            // 
            this.checkBox_properties.AutoSize = true;
            this.checkBox_properties.Checked = true;
            this.checkBox_properties.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_properties.Location = new System.Drawing.Point(55, 298);
            this.checkBox_properties.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_properties.Name = "checkBox_properties";
            this.checkBox_properties.Size = new System.Drawing.Size(92, 17);
            this.checkBox_properties.TabIndex = 0;
            this.checkBox_properties.Text = "UseProperties";
            this.checkBox_properties.UseVisualStyleBackColor = true;
            // 
            // checkBox_pascal
            // 
            this.checkBox_pascal.AutoSize = true;
            this.checkBox_pascal.Checked = true;
            this.checkBox_pascal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_pascal.Location = new System.Drawing.Point(153, 298);
            this.checkBox_pascal.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_pascal.Name = "checkBox_pascal";
            this.checkBox_pascal.Size = new System.Drawing.Size(101, 17);
            this.checkBox_pascal.TabIndex = 0;
            this.checkBox_pascal.Text = "UsePascalCase";
            this.checkBox_pascal.UseVisualStyleBackColor = true;
            // 
            // checkBox_example
            // 
            this.checkBox_example.AutoSize = true;
            this.checkBox_example.Checked = true;
            this.checkBox_example.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_example.Location = new System.Drawing.Point(258, 298);
            this.checkBox_example.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_example.Name = "checkBox_example";
            this.checkBox_example.Size = new System.Drawing.Size(124, 17);
            this.checkBox_example.TabIndex = 0;
            this.checkBox_example.Text = "ExampleInDocument";
            this.checkBox_example.UseVisualStyleBackColor = true;
            // 
            // button_generate
            // 
            this.button_generate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button_generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generate.Location = new System.Drawing.Point(399, 294);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(75, 23);
            this.button_generate.TabIndex = 6;
            this.button_generate.Text = "Generate";
            this.button_generate.UseVisualStyleBackColor = false;
            this.button_generate.Click += new System.EventHandler(this.Button_generate_Click);
            // 
            // radioButton_class
            // 
            this.radioButton_class.AutoSize = true;
            this.radioButton_class.Checked = true;
            this.radioButton_class.Location = new System.Drawing.Point(11, 192);
            this.radioButton_class.Name = "radioButton_class";
            this.radioButton_class.Size = new System.Drawing.Size(50, 17);
            this.radioButton_class.TabIndex = 0;
            this.radioButton_class.TabStop = true;
            this.radioButton_class.Text = "Class";
            this.radioButton_class.UseVisualStyleBackColor = true;
            this.radioButton_class.CheckedChanged += new System.EventHandler(this.RadioButton_class_CheckedChanged);
            // 
            // radioButton_dataset
            // 
            this.radioButton_dataset.AutoSize = true;
            this.radioButton_dataset.Location = new System.Drawing.Point(82, 192);
            this.radioButton_dataset.Name = "radioButton_dataset";
            this.radioButton_dataset.Size = new System.Drawing.Size(74, 17);
            this.radioButton_dataset.TabIndex = 0;
            this.radioButton_dataset.Text = "Document";
            this.radioButton_dataset.UseVisualStyleBackColor = true;
            this.radioButton_dataset.CheckedChanged += new System.EventHandler(this.radioButton_dataset_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(416, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(541, 579);
            this.Controls.Add(this.button_generate);
            this.Controls.Add(this.checkBox_example);
            this.Controls.Add(this.checkBox_pascal);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.checkBox_properties);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "JsonToDocument";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_head)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_exit)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RichTextBox richTextBox_json;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox checkBox_properties;
        private System.Windows.Forms.CheckBox checkBox_pascal;
        private System.Windows.Forms.CheckBox checkBox_example;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox_head;
        private System.Windows.Forms.PictureBox pictureBox_exit;
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RadioButton radioButton_dataset;
        private System.Windows.Forms.RadioButton radioButton_class;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}


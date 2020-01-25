using JsonToDocumentWindowsForm.Module;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonToDocumentWindowsForm
{
    public partial class Form1 : Form
    {
        List<UI> listUI = new List<UI>();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Panel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void PictureBox_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        

        private void Button_generate_Click(object sender, EventArgs e)
        {
            prettyJson();
            tabControl1.TabPages.Clear();
            listUI.Clear();
            AllDataRequestModel request = new AllDataRequestModel();
            request.ExamplesInDocumentation = checkBox_example.Checked;
            request.JsonText = richTextBox_json.Text;
            request.UsePascalCase = checkBox_pascal.Checked;
            request.UseProperties = checkBox_properties.Checked;
            request.MainClass = "SampleResponse1";
            request.SecondaryNamespace = "SampleResponse1JsonTypes";
            request.Namespace = "Example";

            AllDataResponseModel response = Json2csharpAPI.getData("https://localhost:44312/api/AllFromJson", request);

            if (response != null && response.classJson != null)
            {
                for (int i = 0; i < response.classJson.Count; i++)
                {
                    string classStr = "";
                    foreach(string str in response.classJson[i])
                    {
                        classStr += str;
                    }
                    string className = response.document.datasetJson[i].tableName;
                    DataTable dt = CreateDataTable();
                    foreach (AllDataResponseModel.DatasetJson dsJson in response.document.datasetJson)
                    {
                        foreach (AllDataResponseModel.Row r in dsJson.rows)
                        {
                            DataRow row = dt.NewRow();
                            row["ColumnName"] = r.columName;
                            row["Type"] = r.type;
                            row["Example"] = r.example;
                        }
                    }
                    listUI.Add(createUI(className,classStr,dt));
                }
            }
            

        }

        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ColumnName", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Example", typeof(string));

            return table;
        }

        private void prettyJson()
        {
            string rawData = Regex.Replace(richTextBox_json.Text, @"\s+", string.Empty);
            string json = JsonHelper.FormatJson(rawData);
            richTextBox_json.Text = json;
        }

        private void RadioButton_class_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_class.Checked)
            {
                //visible grid = false
                foreach (UI ui in listUI)
                {
                    ui.dataGridView_doc.Visible = false;
                }
            }
        }
        private void radioButton_dataset_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_dataset.Checked)
            {
                //visible grid = true
                foreach(UI ui in listUI)
                {
                    ui.dataGridView_doc.Visible = true;
                }
            }
        }

        class UI
        {
            public System.Windows.Forms.TabPage tabPage1;
            public System.Windows.Forms.RichTextBox richTextBox_class;
            public  System.Windows.Forms.DataGridView dataGridView_doc;
            public UI(System.Windows.Forms.TabPage tabPage1,
            System.Windows.Forms.RichTextBox richTextBox_class,
            System.Windows.Forms.DataGridView dataGridView_doc)
            {
                this.tabPage1 = tabPage1;
                this.richTextBox_class = richTextBox_class;
                this.dataGridView_doc = dataGridView_doc;
            }
        }
        private UI createUI(string tapName,string classStr,DataTable dt)
        {
            //decare
            System.Windows.Forms.TabPage tabPage1;
            //System.Windows.Forms.Panel panel_view;
            //System.Windows.Forms.RadioButton radioButton_class;
            //System.Windows.Forms.RadioButton radioButton_dataset;
            System.Windows.Forms.RichTextBox richTextBox_class;
            System.Windows.Forms.DataGridView dataGridView_doc;

            tabPage1 = new System.Windows.Forms.TabPage();
            //radioButton_dataset = new System.Windows.Forms.RadioButton();
            //radioButton_class = new System.Windows.Forms.RadioButton();
            richTextBox_class = new System.Windows.Forms.RichTextBox();
            //panel_view = new System.Windows.Forms.Panel();
            dataGridView_doc = new System.Windows.Forms.DataGridView();
            //tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            //panel_view.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_doc)).BeginInit();
            this.SuspendLayout();

            //// 
            //// tabControl1
            //// 
            tabControl1.Controls.Add(tabPage1);
            //tabControl1.Location = new System.Drawing.Point(51, 324);
            //tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            //tabControl1.Name = "tabControl1";
            //tabControl1.SelectedIndex = 0;
            //tabControl1.Size = new System.Drawing.Size(428, 214);
            //tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView_doc);
            tabPage1.Controls.Add(richTextBox_class);
            //tabPage1.Controls.Add(panel_view);
            tabPage1.Location = new System.Drawing.Point(4, 22);
            tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            tabPage1.Name = "tabPage";
            tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            tabPage1.Size = new System.Drawing.Size(420, 188);
            tabPage1.TabIndex = 0;
            tabPage1.Text = tapName;
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel_view
            // 
            //panel_view.Controls.Add(radioButton_class);
            //panel_view.Controls.Add(radioButton_dataset);
            //panel_view.Dock = System.Windows.Forms.DockStyle.Top;
            //panel_view.Location = new System.Drawing.Point(2, 2);
            //panel_view.Name = "panel_view";
            //panel_view.Size = new System.Drawing.Size(416, 33);
            //panel_view.TabIndex = 0;
            // 
            // radioButton_dataset
            // 
            //radioButton_dataset.AutoSize = true;
            //radioButton_dataset.Location = new System.Drawing.Point(7, 9);
            //radioButton_dataset.Name = "radioButton_dataset";
            //radioButton_dataset.Size = new System.Drawing.Size(64, 17);
            //radioButton_dataset.TabIndex = 0;
            //radioButton_dataset.Text = "DataSet";
            //radioButton_dataset.UseVisualStyleBackColor = true;
            //radioButton_dataset.CheckedChanged += new System.EventHandler(this.radioButton_dataset_CheckedChanged);
            //// 
            //// radioButton_class
            //// 
            //radioButton_class.AutoSize = true;
            //radioButton_class.Checked = true;
            //radioButton_class.Location = new System.Drawing.Point(77, 9);
            //radioButton_class.Name = "radioButton_class";
            //radioButton_class.Size = new System.Drawing.Size(50, 17);
            //radioButton_class.TabIndex = 0;
            //radioButton_class.TabStop = true;
            //radioButton_class.Text = "Class";
            //radioButton_class.UseVisualStyleBackColor = true;
            //radioButton_class.CheckedChanged += new System.EventHandler(this.RadioButton_class_CheckedChanged);
            // 
            // richTextBox_class
            // 
            richTextBox_class.Dock = System.Windows.Forms.DockStyle.Fill;
            richTextBox_class.Location = new System.Drawing.Point(2, 35);
            richTextBox_class.Name = "richTextBox_class";
            richTextBox_class.Size = new System.Drawing.Size(416, 150);
            richTextBox_class.TabIndex = 1;
            richTextBox_class.Text = classStr;
            // 
            // dataGridView_doc
            // 
            dataGridView_doc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_doc.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView_doc.Location = new System.Drawing.Point(2, 35);
            dataGridView_doc.Name = "dataGridView_doc";
            dataGridView_doc.Size = new System.Drawing.Size(416, 150);
            dataGridView_doc.TabIndex = 2;
            dataGridView_doc.DataSource = dt;
            dataGridView_doc.Visible = false;
            //Form1

            //this.tabControl1.ResumeLayout(false);
            //tabPage1.ResumeLayout(false);
            //tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            return new UI(tabPage1, richTextBox_class, dataGridView_doc);
        }
    }
}

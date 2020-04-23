namespace TestDatasetMarian
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
            this.components = new System.ComponentModel.Container();
            this.vMTbABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsTest1 = new TestDatasetMarian.DsTest1();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vMTbATableAdapter = new TestDatasetMarian.DsTest1TableAdapters.vMTbATableAdapter();
            this.dsTest1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.valoareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.vMTbABindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.abc1 = new TestDatasetMarian.abc();
            this.vMTbATableAdapter1 = new TestDatasetMarian.abcTableAdapters.vMTbATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vMTbABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTest1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTest1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMTbABindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abc1)).BeginInit();
            this.SuspendLayout();
            // 
            // vMTbABindingSource
            // 
            this.vMTbABindingSource.DataMember = "vMTbA";
            this.vMTbABindingSource.DataSource = this.dsTest1;
            // 
            // dsTest1
            // 
            this.dsTest1.DataSetName = "DsTest1";
            this.dsTest1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 128);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 22);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(75, 202);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(161, 22);
            this.textBox2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Denumire";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Valoare";
            // 
            // vMTbATableAdapter
            // 
            this.vMTbATableAdapter.ClearBeforeFill = true;
            // 
            // dsTest1BindingSource
            // 
            this.dsTest1BindingSource.DataSource = this.dsTest1;
            this.dsTest1BindingSource.Position = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(75, 250);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(161, 44);
            this.button5.TabIndex = 10;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // valoareDataGridViewTextBoxColumn
            // 
            this.valoareDataGridViewTextBoxColumn.DataPropertyName = "valoare";
            this.valoareDataGridViewTextBoxColumn.HeaderText = "valoare";
            this.valoareDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.valoareDataGridViewTextBoxColumn.Name = "valoareDataGridViewTextBoxColumn";
            this.valoareDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "denumire";
            this.dataGridViewTextBoxColumn2.HeaderText = "denumire";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.valoareDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.vMTbABindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(276, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(512, 333);
            this.dataGridView1.TabIndex = 3;
            // 
            // vMTbABindingSource1
            // 
            this.vMTbABindingSource1.DataMember = "vMTbA";
            this.vMTbABindingSource1.DataSource = this.abc1;
            // 
            // abc1
            // 
            this.abc1.DataSetName = "abc";
            this.abc1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vMTbATableAdapter1
            // 
            this.vMTbATableAdapter1.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vMTbABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTest1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTest1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMTbABindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abc1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DsTest1 dsTest1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn denumireDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource vMTbABindingSource;
        private DsTest1TableAdapters.vMTbATableAdapter vMTbATableAdapter;
        private System.Windows.Forms.BindingSource dsTest1BindingSource;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private abc abc1;
        private System.Windows.Forms.BindingSource vMTbABindingSource1;
        private abcTableAdapters.vMTbATableAdapter vMTbATableAdapter1;
    }
}


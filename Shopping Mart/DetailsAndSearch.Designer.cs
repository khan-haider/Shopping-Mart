namespace Shopping_Mart
{
    partial class DetailsAndSearch
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.SEARCHtextBox = new System.Windows.Forms.TextBox();
            this.SEARCHbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FINALCOSTtextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 231);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(737, 207);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search By Invoice";
            // 
            // SEARCHtextBox
            // 
            this.SEARCHtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEARCHtextBox.Location = new System.Drawing.Point(36, 59);
            this.SEARCHtextBox.Name = "SEARCHtextBox";
            this.SEARCHtextBox.Size = new System.Drawing.Size(216, 34);
            this.SEARCHtextBox.TabIndex = 2;
            // 
            // SEARCHbutton
            // 
            this.SEARCHbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEARCHbutton.Location = new System.Drawing.Point(38, 114);
            this.SEARCHbutton.Name = "SEARCHbutton";
            this.SEARCHbutton.Size = new System.Drawing.Size(112, 45);
            this.SEARCHbutton.TabIndex = 3;
            this.SEARCHbutton.Text = "Search";
            this.SEARCHbutton.UseVisualStyleBackColor = true;
            this.SEARCHbutton.Click += new System.EventHandler(this.SEARCHbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Final Cost";
            // 
            // FINALCOSTtextBox
            // 
            this.FINALCOSTtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FINALCOSTtextBox.Location = new System.Drawing.Point(191, 185);
            this.FINALCOSTtextBox.Name = "FINALCOSTtextBox";
            this.FINALCOSTtextBox.ReadOnly = true;
            this.FINALCOSTtextBox.Size = new System.Drawing.Size(178, 34);
            this.FINALCOSTtextBox.TabIndex = 5;
            // 
            // DetailsAndSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FINALCOSTtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SEARCHbutton);
            this.Controls.Add(this.SEARCHtextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DetailsAndSearch";
            this.Text = "DetailsAndSearch";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SEARCHtextBox;
        private System.Windows.Forms.Button SEARCHbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FINALCOSTtextBox;
    }
}
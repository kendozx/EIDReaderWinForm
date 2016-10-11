namespace EIDReaderWinForm
{
    partial class Form01_Query
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
            this.dgSearchResult = new System.Windows.Forms.DataGridView();
            this.btnSearch = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.textSearchUser = new System.Windows.Forms.TextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.lbSearchResult = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSearchResult
            // 
            this.dgSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSearchResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgSearchResult.Location = new System.Drawing.Point(12, 145);
            this.dgSearchResult.Name = "dgSearchResult";
            this.dgSearchResult.Size = new System.Drawing.Size(560, 304);
            this.dgSearchResult.TabIndex = 12;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Depth = 0;
            this.btnSearch.Location = new System.Drawing.Point(12, 107);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Primary = true;
            this.btnSearch.Size = new System.Drawing.Size(100, 31);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 80);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(81, 19);
            this.materialLabel1.TabIndex = 17;
            this.materialLabel1.Text = "Username:";
            // 
            // textSearchUser
            // 
            this.textSearchUser.Location = new System.Drawing.Point(99, 80);
            this.textSearchUser.Name = "textSearchUser";
            this.textSearchUser.Size = new System.Drawing.Size(175, 20);
            this.textSearchUser.TabIndex = 16;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(121, 112);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(137, 18);
            this.materialLabel2.TabIndex = 19;
            this.materialLabel2.Text = "Total record found: ";
            // 
            // lbSearchResult
            // 
            this.lbSearchResult.AutoSize = true;
            this.lbSearchResult.BackColor = System.Drawing.SystemColors.Window;
            this.lbSearchResult.Depth = 0;
            this.lbSearchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbSearchResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbSearchResult.Location = new System.Drawing.Point(252, 112);
            this.lbSearchResult.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbSearchResult.Name = "lbSearchResult";
            this.lbSearchResult.Size = new System.Drawing.Size(17, 18);
            this.lbSearchResult.TabIndex = 20;
            this.lbSearchResult.Text = "0";
            // 
            // Form01_Query
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.lbSearchResult);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.textSearchUser);
            this.Controls.Add(this.dgSearchResult);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(584, 461);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(584, 461);
            this.Name = "Form01_Query";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-ID Reader to SuccessFactors / QUERY Employees";
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgSearchResult;
        private MaterialSkin.Controls.MaterialRaisedButton btnSearch;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox textSearchUser;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel lbSearchResult;
    }
}
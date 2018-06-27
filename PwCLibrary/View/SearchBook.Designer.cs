namespace PwCLibrary.View
{
    partial class SearchBook
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
            this.searchTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labetShowTitle = new System.Windows.Forms.Label();
            this.labelShowAvailable = new System.Windows.Forms.Label();
            this.labelShowDate = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonDelayed = new System.Windows.Forms.Button();
            this.labelShowUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.AutoSize = true;
            this.searchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTitle.Location = new System.Drawing.Point(31, 64);
            this.searchTitle.Name = "searchTitle";
            this.searchTitle.Size = new System.Drawing.Size(99, 25);
            this.searchTitle.TabIndex = 0;
            this.searchTitle.Text = "Book Title";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(169, 63);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(257, 26);
            this.textBoxTitle.TabIndex = 1;
            // 
            // labetShowTitle
            // 
            this.labetShowTitle.AutoSize = true;
            this.labetShowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labetShowTitle.Location = new System.Drawing.Point(23, 206);
            this.labetShowTitle.Name = "labetShowTitle";
            this.labetShowTitle.Size = new System.Drawing.Size(46, 18);
            this.labetShowTitle.TabIndex = 2;
            this.labetShowTitle.Text = "label1";
            // 
            // labelShowAvailable
            // 
            this.labelShowAvailable.AutoSize = true;
            this.labelShowAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShowAvailable.Location = new System.Drawing.Point(112, 206);
            this.labelShowAvailable.Name = "labelShowAvailable";
            this.labelShowAvailable.Size = new System.Drawing.Size(46, 18);
            this.labelShowAvailable.TabIndex = 3;
            this.labelShowAvailable.Text = "label1";
            // 
            // labelShowDate
            // 
            this.labelShowDate.AutoSize = true;
            this.labelShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShowDate.Location = new System.Drawing.Point(218, 206);
            this.labelShowDate.Name = "labelShowDate";
            this.labelShowDate.Size = new System.Drawing.Size(46, 18);
            this.labelShowDate.TabIndex = 4;
            this.labelShowDate.Text = "label1";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(126, 129);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(104, 30);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "SEARCH";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonDelayed
            // 
            this.buttonDelayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelayed.Location = new System.Drawing.Point(297, 129);
            this.buttonDelayed.Name = "buttonDelayed";
            this.buttonDelayed.Size = new System.Drawing.Size(158, 30);
            this.buttonDelayed.TabIndex = 6;
            this.buttonDelayed.Text = "DELAYED BOOKS";
            this.buttonDelayed.UseVisualStyleBackColor = true;
            this.buttonDelayed.Click += new System.EventHandler(this.buttonDelayed_Click);
            // 
            // labelShowUser
            // 
            this.labelShowUser.AutoSize = true;
            this.labelShowUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShowUser.Location = new System.Drawing.Point(367, 206);
            this.labelShowUser.Name = "labelShowUser";
            this.labelShowUser.Size = new System.Drawing.Size(46, 18);
            this.labelShowUser.TabIndex = 7;
            this.labelShowUser.Text = "label1";
            // 
            // SearchBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 278);
            this.Controls.Add(this.labelShowUser);
            this.Controls.Add(this.buttonDelayed);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelShowDate);
            this.Controls.Add(this.labelShowAvailable);
            this.Controls.Add(this.labetShowTitle);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.searchTitle);
            this.Name = "SearchBook";
            this.Text = "Search Book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label searchTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labetShowTitle;
        private System.Windows.Forms.Label labelShowAvailable;
        private System.Windows.Forms.Label labelShowDate;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonDelayed;
        private System.Windows.Forms.Label labelShowUser;
    }
}


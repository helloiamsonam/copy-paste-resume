namespace ResumeSnippetManager
{
    partial class EditSnippetForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtTitle;
        private TextBox txtCategory;
        private TextBox txtContent;
        private Button btnOK;
        private Button btnCancel;
        private Label lblTitle;
        private Label lblCategory;
        private Label lblContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTitle = new TextBox();
            this.txtCategory = new TextBox();
            this.txtContent = new TextBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.lblTitle = new Label();
            this.lblCategory = new Label();
            this.lblContent = new Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(32, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";

            // txtTitle
            this.txtTitle.Location = new Point(12, 33);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new Size(360, 23);
            this.txtTitle.TabIndex = 1;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new Point(12, 70);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new Size(58, 15);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category:";

            // txtCategory
            this.txtCategory.Location = new Point(12, 88);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new Size(360, 23);
            this.txtCategory.TabIndex = 3;

            // lblContent
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new Point(12, 125);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new Size(53, 15);
            this.lblContent.TabIndex = 4;
            this.lblContent.Text = "Content:";

            // txtContent
            this.txtContent.Location = new Point(12, 143);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = ScrollBars.Vertical;
            this.txtContent.Size = new Size(360, 200);
            this.txtContent.TabIndex = 5;

            // btnOK
            this.btnOK.Location = new Point(216, 360);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Location = new Point(297, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // EditSnippetForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(384, 395);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSnippetForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Edit Snippet";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
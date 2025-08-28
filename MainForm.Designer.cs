namespace ResumeSnippetManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listSnippets;
        private TextBox txtContent;
        private Button btnCopy;
        private Label lblSnippets;
        private MenuStrip menuStrip;
        private ToolStripMenuItem snippetToolStripMenuItem;
        private ToolStripMenuItem addSnippetToolStripMenuItem;
        private ToolStripMenuItem editSnippetToolStripMenuItem;
        private ToolStripMenuItem deleteSnippetToolStripMenuItem;

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
            this.listSnippets = new ListBox();
            this.txtContent = new TextBox();
            this.btnCopy = new Button();
            this.lblSnippets = new Label();
            this.menuStrip = new MenuStrip();
            this.snippetToolStripMenuItem = new ToolStripMenuItem();
            this.addSnippetToolStripMenuItem = new ToolStripMenuItem();
            this.editSnippetToolStripMenuItem = new ToolStripMenuItem();
            this.deleteSnippetToolStripMenuItem = new ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();

            // menuStrip
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.snippetToolStripMenuItem});
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(704, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";

            // snippetToolStripMenuItem
            this.snippetToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.addSnippetToolStripMenuItem,
                this.editSnippetToolStripMenuItem,
                this.deleteSnippetToolStripMenuItem});
            this.snippetToolStripMenuItem.Name = "snippetToolStripMenuItem";
            this.snippetToolStripMenuItem.Size = new Size(59, 20);
            this.snippetToolStripMenuItem.Text = "Snippet";

            // addSnippetToolStripMenuItem
            this.addSnippetToolStripMenuItem.Name = "addSnippetToolStripMenuItem";
            this.addSnippetToolStripMenuItem.Size = new Size(152, 22);
            this.addSnippetToolStripMenuItem.Text = "Add Snippet";

            // editSnippetToolStripMenuItem
            this.editSnippetToolStripMenuItem.Name = "editSnippetToolStripMenuItem";
            this.editSnippetToolStripMenuItem.Size = new Size(152, 22);
            this.editSnippetToolStripMenuItem.Text = "Edit Snippet";

            // deleteSnippetToolStripMenuItem
            this.deleteSnippetToolStripMenuItem.Name = "deleteSnippetToolStripMenuItem";
            this.deleteSnippetToolStripMenuItem.Size = new Size(152, 22);
            this.deleteSnippetToolStripMenuItem.Text = "Delete Snippet";

            // lblSnippets
            this.lblSnippets.AutoSize = true;
            this.lblSnippets.Location = new Point(12, 35);
            this.lblSnippets.Name = "lblSnippets";
            this.lblSnippets.Size = new Size(111, 15);
            this.lblSnippets.TabIndex = 1;
            this.lblSnippets.Text = "Resume Snippets:";

            // listSnippets
            this.listSnippets.FormattingEnabled = true;
            this.listSnippets.ItemHeight = 15;
            this.listSnippets.Location = new Point(12, 53);
            this.listSnippets.Name = "listSnippets";
            this.listSnippets.Size = new Size(250, 334);
            this.listSnippets.TabIndex = 2;

            // txtContent
            this.txtContent.Location = new Point(280, 53);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = ScrollBars.Vertical;
            this.txtContent.Size = new Size(400, 334);
            this.txtContent.TabIndex = 3;

            // btnCopy
            this.btnCopy.Location = new Point(550, 404);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new Size(130, 23);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy to Clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;

            // MainForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(704, 441);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.listSnippets);
            this.Controls.Add(this.lblSnippets);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Resume Snippet Manager";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
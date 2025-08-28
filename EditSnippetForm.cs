using System;
using System.Windows.Forms;

namespace ResumeSnippetManager
{
    public partial class EditSnippetForm : Form
    {
        private Snippet snippet;

        public EditSnippetForm(Snippet snippet)
        {
            this.snippet = snippet;
            InitializeComponent();
            LoadSnippetData();
        }

        private void LoadSnippetData()
        {
            txtTitle.Text = snippet.Title;
            txtCategory.Text = snippet.Category;
            txtContent.Text = snippet.Content;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            snippet.Title = txtTitle.Text;
            snippet.Category = txtCategory.Text;
            snippet.Content = txtContent.Text;
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
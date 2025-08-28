using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ResumeSnippetManager
{
    public partial class MainForm : Form
    {
        private List<Snippet> snippets;
        private SnippetRepository repository;

        public MainForm()
        {
            InitializeComponent();
            InitializeData();
            SetupEventHandlers();
        }

        private void InitializeData()
        {
            repository = new SnippetRepository();
            LoadSnippets();
        }

        private void SetupEventHandlers()
        {
            btnCopy.Click += BtnCopy_Click;
            listSnippets.SelectedIndexChanged += ListSnippets_SelectedIndexChanged;
            
            addSnippetToolStripMenuItem.Click += AddSnippetMenuItem_Click;
            editSnippetToolStripMenuItem.Click += EditSnippetMenuItem_Click;
            deleteSnippetToolStripMenuItem.Click += DeleteSnippetMenuItem_Click;
        }

        private void AddSnippetMenuItem_Click(object? sender, EventArgs e)
        {
            var snippet = new Snippet
            {
                Id = Guid.NewGuid().ToString(),
                Category = "General",
                Title = "New Snippet",
                Content = "Enter your resume snippet here..."
            };
            snippets.Add(snippet);
            SaveSnippets();
            RefreshSnippetsList();
            listSnippets.SelectedIndex = snippets.Count - 1;
        }

        private void EditSnippetMenuItem_Click(object? sender, EventArgs e)
        {
            if (listSnippets.SelectedIndex >= 0)
            {
                var snippet = snippets[listSnippets.SelectedIndex];
                using (var editForm = new EditSnippetForm(snippet))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        SaveSnippets();
                        RefreshSnippetsList();
                        txtContent.Text = snippet.Content;
                    }
                }
            }
        }

        private void DeleteSnippetMenuItem_Click(object? sender, EventArgs e)
        {
            if (listSnippets.SelectedIndex >= 0)
            {
                var snippet = snippets[listSnippets.SelectedIndex];
                var result = MessageBox.Show($"Are you sure you want to delete '{snippet.Title}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    snippets.RemoveAt(listSnippets.SelectedIndex);
                    SaveSnippets();
                    RefreshSnippetsList();
                    txtContent.Text = "";
                }
            }
        }

        private void BtnCopy_Click(object? sender, EventArgs e)
        {
            if (listSnippets.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a snippet to copy.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtContent.Text))
            {
                Clipboard.SetText(txtContent.Text);
                MessageBox.Show("Snippet copied!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ListSnippets_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listSnippets.SelectedIndex >= 0)
            {
                var snippet = snippets[listSnippets.SelectedIndex];
                txtContent.Text = snippet.Content;
            }
        }

        private void RefreshSnippetsList()
        {
            listSnippets.Items.Clear();
            foreach (var snippet in snippets)
            {
                listSnippets.Items.Add(snippet.Title);
            }
        }

        private void LoadSnippets()
        {
            try
            {
                snippets = repository.LoadSnippets();
                RefreshSnippetsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading snippets: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                snippets = new List<Snippet>();
            }
        }

        private void SaveSnippets()
        {
            try
            {
                repository.SaveSnippets(snippets);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving snippets: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
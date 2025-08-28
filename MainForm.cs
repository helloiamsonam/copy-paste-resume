using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ResumeSnippetManager
{
    public partial class MainForm : Form
    {
        private List<Snippet> snippets;
        private SnippetRepository repository;
        private System.Windows.Forms.Timer statusTimer;

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
            InitializeStatusTimer();
        }

        private void InitializeStatusTimer()
        {
            statusTimer = new System.Windows.Forms.Timer();
            statusTimer.Interval = 3000;
            statusTimer.Tick += StatusTimer_Tick;
        }

        private void StatusTimer_Tick(object? sender, EventArgs e)
        {
            statusLabel.Text = "Ready";
            statusTimer.Stop();
        }

        private void SetupEventHandlers()
        {
            btnCopy.Click += BtnCopy_Click;
            btnSave.Click += BtnSave_Click;
            listSnippets.SelectedIndexChanged += ListSnippets_SelectedIndexChanged;
            listSnippets.DoubleClick += ListSnippets_DoubleClick;
            
            addSnippetToolStripMenuItem.Click += AddSnippetMenuItem_Click;
            editSnippetToolStripMenuItem.Click += EditSnippetMenuItem_Click;
            deleteSnippetToolStripMenuItem.Click += DeleteSnippetMenuItem_Click;
        }

        private void AddSnippetMenuItem_Click(object? sender, EventArgs e)
        {
            using (var titleDialog = new Form())
            {
                titleDialog.Text = "New Snippet";
                titleDialog.Size = new Size(350, 120);
                titleDialog.StartPosition = FormStartPosition.CenterParent;
                titleDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                titleDialog.MaximizeBox = false;
                titleDialog.MinimizeBox = false;

                var lblTitle = new Label() { Left = 12, Top = 15, Text = "Snippet Title:", AutoSize = true };
                var txtTitle = new TextBox() { Left = 12, Top = 35, Width = 300, Text = "New Snippet" };
                txtTitle.SelectAll();
                
                var btnOK = new Button() { Text = "OK", Left = 157, Width = 75, Top = 65, DialogResult = DialogResult.OK };
                var btnCancel = new Button() { Text = "Cancel", Left = 237, Width = 75, Top = 65, DialogResult = DialogResult.Cancel };

                titleDialog.Controls.Add(lblTitle);
                titleDialog.Controls.Add(txtTitle);
                titleDialog.Controls.Add(btnOK);
                titleDialog.Controls.Add(btnCancel);
                titleDialog.AcceptButton = btnOK;
                titleDialog.CancelButton = btnCancel;

                if (titleDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    var snippet = new Snippet
                    {
                        Id = Guid.NewGuid().ToString(),
                        Category = "General",
                        Title = txtTitle.Text.Trim(),
                        Content = "Enter your resume snippet here..."
                    };
                    snippets.Add(snippet);
                    SaveSnippets();
                    RefreshSnippetsList();
                    listSnippets.SelectedIndex = snippets.Count - 1;
                }
            }
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

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (listSnippets.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a snippet to save.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedSnippet = snippets[listSnippets.SelectedIndex];
            selectedSnippet.Content = txtContent.Text;
            
            SaveSnippets();
            MessageBox.Show("Snippet saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCopy_Click(object? sender, EventArgs e)
        {
            if (listSnippets.SelectedIndex < 0)
            {
                statusLabel.Text = "Please select a snippet to copy.";
                statusTimer.Stop();
                statusTimer.Start();
                return;
            }

            if (!string.IsNullOrEmpty(txtContent.Text))
            {
                Clipboard.SetText(txtContent.Text);
                statusLabel.Text = "Snippet copied to clipboard!";
                statusTimer.Stop();
                statusTimer.Start();
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

        private void ListSnippets_DoubleClick(object? sender, EventArgs e)
        {
            if (listSnippets.SelectedIndex >= 0)
            {
                var snippet = snippets[listSnippets.SelectedIndex];
                
                using (var titleDialog = new Form())
                {
                    titleDialog.Text = "Rename Snippet";
                    titleDialog.Size = new Size(350, 120);
                    titleDialog.StartPosition = FormStartPosition.CenterParent;
                    titleDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                    titleDialog.MaximizeBox = false;
                    titleDialog.MinimizeBox = false;

                    var lblTitle = new Label() { Left = 12, Top = 15, Text = "Snippet Title:", AutoSize = true };
                    var txtTitle = new TextBox() { Left = 12, Top = 35, Width = 300, Text = snippet.Title };
                    txtTitle.SelectAll();
                    
                    var btnOK = new Button() { Text = "OK", Left = 157, Width = 75, Top = 65, DialogResult = DialogResult.OK };
                    var btnCancel = new Button() { Text = "Cancel", Left = 237, Width = 75, Top = 65, DialogResult = DialogResult.Cancel };

                    titleDialog.Controls.Add(lblTitle);
                    titleDialog.Controls.Add(txtTitle);
                    titleDialog.Controls.Add(btnOK);
                    titleDialog.Controls.Add(btnCancel);
                    titleDialog.AcceptButton = btnOK;
                    titleDialog.CancelButton = btnCancel;

                    if (titleDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(txtTitle.Text))
                    {
                        snippet.Title = txtTitle.Text.Trim();
                        SaveSnippets();
                        RefreshSnippetsList();
                        statusLabel.Text = "Snippet renamed!";
                        statusTimer.Stop();
                        statusTimer.Start();
                    }
                }
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
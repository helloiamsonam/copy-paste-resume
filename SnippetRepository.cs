using System.Text.Json;

namespace ResumeSnippetManager
{
    public class SnippetRepository
    {
        private readonly string _dataDirectory;
        private readonly string _filePath;

        public SnippetRepository()
        {
            _dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ResumeHelper");
            _filePath = Path.Combine(_dataDirectory, "snippets.json");
        }

        public List<Snippet> LoadSnippets()
        {
            try
            {
                if (!Directory.Exists(_dataDirectory))
                {
                    Directory.CreateDirectory(_dataDirectory);
                }

                if (!File.Exists(_filePath))
                {
                    return new List<Snippet>();
                }

                string jsonString = File.ReadAllText(_filePath);
                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    return new List<Snippet>();
                }

                var snippets = JsonSerializer.Deserialize<List<Snippet>>(jsonString);
                return snippets ?? new List<Snippet>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load snippets: {ex.Message}", ex);
            }
        }

        public void SaveSnippets(List<Snippet> snippets)
        {
            try
            {
                if (!Directory.Exists(_dataDirectory))
                {
                    Directory.CreateDirectory(_dataDirectory);
                }

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(snippets, options);
                File.WriteAllText(_filePath, jsonString);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save snippets: {ex.Message}", ex);
            }
        }
    }
}
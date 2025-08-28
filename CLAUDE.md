- Current Structure:
  - MainForm.cs: Main application logic with snippet management
  functionality
  - MainForm.Designer.cs: UI layout with menu bar containing "Add Snippet"
  option
  - Snippet.cs: Simple data model (Id, Category, Title, Content)
  - SnippetRepository.cs: JSON-based persistence to AppData folder
  - EditSnippetForm.cs/Designer.cs: Form for editing existing snippets

  Key Features Already Implemented:
  - Add new snippets via Snippet → Add Snippet menu
  - Edit existing snippets
  - Delete snippets with confirmation
  - Copy snippets to clipboard
  - JSON persistence in user's AppData folder
  - List-based UI showing snippet titles
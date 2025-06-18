namespace MainMemoryGame;

public class Theme
{
    public string ThemeName { get; private set; }
    public int ThemeId { get; private set; }
    public List<Choice> Choices { get; private set; } = new List<Choice>();
    public bool Active { get; private set; }

    public Theme(string themeName, int themeId, bool active)
    {
        ThemeName = themeName;
        ThemeId = themeId;
        Active = active;
    }

    public Theme(string themeName, int themeId)
    {
        ThemeName = themeName;
        ThemeId = themeId;
        Active = false;
    }

    public void ChangeThemeName(string newThemeName)
    {
        ThemeName = newThemeName;
    }

    public void ChangeActive()
    {
        Active = !Active;
    }

    public void AddChoice(Choice choice)
    {
        Choices.Add(choice);
    }
    
    
}
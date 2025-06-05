namespace MainMemoryGame;

public class Theme
{
    public string ThemeName { get; private set; }
    public int ThemeId { get; private set; }
    private List<Choice> _choices = new List<Choice>();
    private bool _active;

    public Theme(string themeName, int themeId, bool active)
    {
        ThemeName = themeName;
        ThemeId = themeId;
        _active = active;
    }
    public Theme(string themeName, int themeId)
    {
        ThemeName = themeName;
        ThemeId = themeId;
        _active = false;
    }

    public void ChangeThemeName(string newThemeName)
    {
        ThemeName = newThemeName;
    }
    public void ChangeActive()
    {
        _active = !_active;
    }
    public void AddChoice(Choice choice)
    {
        _choices.Add(choice);
    }
}
namespace Language_Memory_Game;

public class Theme
{
    private string _themeName;
    private int _themeId;
    private List<Choice> _choices = new List<Choice>();
    private bool _active;

    public Theme(string themeName, int themeId, bool active)
    {
        _themeName = themeName;
        _themeId = themeId;
        _active = active;
    }
    public Theme(string themeName, int themeId)
    {
        _themeName = themeName;
        _themeId = themeId;
        _active = false;
    }

    public void ChangeThemeName(string newThemeName)
    {
        _themeName = newThemeName;
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
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

    public void EditTheme()
    {
        while (true)
        {
            Console.WriteLine("""
                              1) To Add a Choice
                              2) To Delete a Choice
                              3) To Edit Choice
                              4) To Edit Theme Name
                              5) Return
                              """);
            var input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    ChoiceCreator();
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    // int selected = SelectTheme();
                    // _themes[selected].EditTheme();
                    break;
                case ConsoleKey.D4:
                    return;
                case ConsoleKey.D5:
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid key pressed, please try again.");
                    break;
            }
        }
    }

    private void ChoiceCreator()
    {
        string wordInput;
        while (true)
        {
            var alreadyExist = false;
            Console.WriteLine("The Word of Original Language");
            wordInput = Console.ReadLine();
            if (wordInput != "")
            {
                foreach (var choice in _choices)
                {
                    if (choice.Original.Word == wordInput || choice.Translated.Word == wordInput)
                    {
                        Console.Clear();
                        Console.WriteLine("""
                                          A Choice has already that Word
                                          Change the word slightly so you wont be confused
                                          """);
                        alreadyExist = true;
                    }
                }

                if (!alreadyExist)
                {
                    break;
                }
            }


        }

        var id = IdGenerator(_choices);
        // _choices.Add(new Choice(id, originalLanguage, translatedLanguage));
    }


    private int IdGenerator(int BiggestID)
    {
        return BiggestID + 1;
    }

    private int IdGenerator(List<Choice> choices)
    {
        var highestId = 0;
        if (choices.Count == 0)
        {
            return IdGenerator(choices.Count);
        }
        else
        {
            foreach (var choice in choices)
            {
                if (choice.Id > highestId)
                {
                    highestId = choice.Id;
                }
            }

            return IdGenerator(highestId);
        }
    }
}
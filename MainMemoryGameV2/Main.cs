using MainMemoryGame;

public class Main
{
    private List<Theme> _themes = new List<Theme>();
    private readonly List<Choice> _choices = new List<Choice>();
    private readonly List<Option> _choices2 = new List<Option>();
    private Random _random = new Random();
    public void Run()
    {
        Console.WriteLine("""
                           1) To Add/Delete/Edit Themes
                           2) Play Game
                           """);
        var input = Console.ReadKey(true);
        switch (input.Key)
        {
            case ConsoleKey.D1:
                EditThemeMenu();
                break;
            case ConsoleKey.D2:
                StartGame();
                break;
            default:
                Run();
                break;
        }
                         
        
        
        
    }

    private void EditThemeMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("""
                          1) To Add a Theme
                          2) To Delete a Theme
                          3) To Edit or Add Choice
                          4) Return
                          """);
        var input = Console.ReadKey(true);
        switch (input.Key)
        {
            case ConsoleKey.D1:
                ThemeCreator();
                break;
            case ConsoleKey.D2:
                break;
            case ConsoleKey.D3:
                int selected = SelectTheme();
                _themes[selected].EditTheme();
                break;
            case ConsoleKey.D4:
                return;
            default:
                Console.Clear();
                Console.WriteLine("Invalid key pressed, please try again.");
                break;
        }
        }
    }

    private int SelectTheme()
    {
        while (true)
        {
            var optionsIndex = 0;
            Console.Clear();
            foreach (var theme in _themes)
            {
                Console.WriteLine($"{optionsIndex++}) {theme.ThemeName}");
            }
            var inputSelection = Console.ReadLine();
            var inputChoice =  Convert.ToInt32(inputSelection);

            var index = 0;
            foreach (var theme in _themes)
            {
                if(inputChoice == index)
                {
                    Console.WriteLine($"{index} = {_themes[index].ThemeName}");
                    return index;
                }
                else
                {
                    index++;
                }
            
            }
        
        }
    }

    private void ThemeCreator()
    {
        string nameInput;
        while (true)
        {
            var alreadyExist = false;
            Console.WriteLine("The Name of the Theme");
            nameInput = Console.ReadLine();
            if (nameInput != "")
            {
                foreach (var theme in _themes)
                {
                    if (theme.ThemeName == nameInput)
                    {
                        Console.Clear();
                        Console.WriteLine("A Theme has already that name");
                        alreadyExist = true;
                    }
                }
                if (!alreadyExist)
                {
                    break;
                }
            }

            
        }
        
        _themes.Add(new Theme(nameInput, IdGenerator(_themes), true));
    }
    
    
    private void StartGame()
    {
        foreach (var choice in _choices)
        {
            _choices2.Add(choice.Original);
            _choices2.Add(choice.Translated);
        }
        Randomize(_choices2);
        
        while (true)
        {
            ShowGame(); 
           
        }
    }

    private void ShowGame()
    {
        int amountofChoices = 0;
        foreach (var choice in _choices2)
        {
            Console.Write(choice + "     ");
            amountofChoices++;
            if (amountofChoices % 5 == 0)
            {
                Console.WriteLine();
            }
        }
    }

    private void Randomize(List<Option> choices2)
    {
        int randomIndex;
        Option extraVariable;
        for (int i = 0; i < choices2.Count; i++)
        {
            randomIndex = _random.Next(0, choices2.Count);
            extraVariable = choices2[i];
            choices2[i] = choices2[randomIndex];
            choices2[randomIndex] = extraVariable;
        } 
    }
    
    private int IdGenerator(int BiggestID)
    {
        return BiggestID + 1;
    }

    private int IdGenerator(List<Theme> themes)
    {
        var highestId = 0;
        if (themes.Count == 0)
        {
            return IdGenerator(themes.Count);
        }
        else
        {
            foreach (var theme in themes)
            {
                if (theme.ThemeId > highestId)
                {
                    highestId = theme.ThemeId;
                }
            }
            return IdGenerator(highestId);
        }
    }
}
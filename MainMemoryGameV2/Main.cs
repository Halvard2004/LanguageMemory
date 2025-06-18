using MainMemoryGame;

public class Main
{
    private List<Theme> _themes = new List<Theme>();
    private readonly List<Choice> _choices = new List<Choice>();
    private readonly List<Option> _options = new List<Option>();
    private Random _random = new Random();
   
    
    public void Run()
    {
        while (true){
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
                EditTheme(selected);
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
                Console.WriteLine($"{optionsIndex++ + 1}) {theme.ThemeName}");
            }
            var inputSelection = Console.ReadLine();
            var inputChoice =  Convert.ToInt32(inputSelection) - 1;

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

    private void EditTheme(int selectedTheme)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("""
                              1) To Add a Choice
                              2) To Delete a Choice
                              3) To Edit Choice
                              4) To Edit Theme Name
                              5) Change Activation
                              6) Return
                              """);
            var input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    ChoiceCreator(selectedTheme);
                    break;
                case ConsoleKey.D2:
                    ChoiceDeleter(selectedTheme);
                    break;
                case ConsoleKey.D3:
                    // int selected = SelectTheme();
                    // _themes[selected].EditTheme();
                    break;
                case ConsoleKey.D4:
                    var inputName = Console.ReadLine();
                    if (inputName == "")
                    {
                        Console.WriteLine("Invalid, please write a name try again.");
                        continue;
                    }
                    _themes[selectedTheme].ChangeThemeName(inputName);
                    break;
                case ConsoleKey.D5:
                    _themes[selectedTheme].ChangeActive();
                    break;
                case ConsoleKey.D6:
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid key pressed, please try again.");
                    break;
            }
        }
    }

    

    private void ChoiceCreator(int selectedTheme)
    {
        Option originalLanguage;
        Option translatedLanguage;
        var id = IdGenerator(_themes[selectedTheme].Choices);
        while (true)
        {
            var alreadyExist = false;
            originalLanguage = OptionCreator("Original", selectedTheme, id);
            translatedLanguage = OptionCreator("Translated",  selectedTheme, id);
            foreach (var choice in _themes[selectedTheme].Choices.Where(choice => choice.Original.Word == originalLanguage.Word || choice.Translated.Word == originalLanguage.Word ||
                         choice.Original.Word == translatedLanguage.Word ||
                         choice.Translated.Word == translatedLanguage.Word))
            {
                Console.Clear();
                Console.WriteLine("""
                                  A Choice has already that Word
                                  Change the word slightly so you wont be confused
                                  """);
                alreadyExist = true;
            }

            if (!alreadyExist)
            {
                break;
            }


        }
        var NewChoice = new Choice(id, originalLanguage, translatedLanguage);
        _themes[selectedTheme].AddChoice(NewChoice); 
    }
    
    private void ChoiceDeleter(int selectedTheme)
    {
        Console.Clear();
        while (true)
        {
            var index = 1;
            Console.WriteLine("Which do you want to remove or write Q to return to the menu");
                    foreach (var choice in _themes[selectedTheme].Choices)
                    {
                        Console.WriteLine($"{index++}) Original word {choice.Original.Word} and {(Languages) choice.Original.LangaugeId}");
                        Console.WriteLine($"   Translated word {choice.Translated.Word} and {(Languages) choice.Translated.LangaugeId}");
                    }
            
                    var input = Console.ReadLine();
                    Console.Clear();
                    if (input == "Q")
                    {
                        return;
                    }
            
                    if (!int.TryParse(input, out var inputChoice))
                    {
                        Console.WriteLine("Invalid input, please try again.");
                        continue;
                    }
                    inputChoice--;
                    _themes[selectedTheme].Choices.RemoveAt(inputChoice);
                    return;
        }
        
            


    }
    private Option OptionCreator(string version, int selectedTheme, int choiceId)
    {
        Option option;
        string wordInput;
        while (true)
        {
            var alreadyExist = false;
            Console.WriteLine($"The Word of {version} Language");
            wordInput = Console.ReadLine();
            if (wordInput == "") continue;
            foreach (var choice in _themes[selectedTheme].Choices)
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
        var Language = (int) SelectLanguage();
        return new Option(choiceId, Language,wordInput);
    }

    private Languages SelectLanguage()
    {
        var languages = Enum.GetValues<Languages>();
        int index;
        foreach (var language in languages)
        {
            Console.WriteLine($"{(int)language}){language}");
        }
        var input = Console.ReadLine();
        index = 1;
        while (true)
        {
            if (index == Convert.ToInt32(input))
            {
                return (Languages) index;
            }
            index++;
            if (index <= languages.Length) continue;
            Console.Clear();
            Console.WriteLine("Invalid input, please try again.");
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
                if (nameInput == "") continue;
                foreach (var theme in _themes.Where(theme => theme.ThemeName == nameInput))
                {
                    Console.Clear();
                    Console.WriteLine("A Theme has already that name");
                    alreadyExist = true;
                }
                if (!alreadyExist)
                {
                    break;
                }


            }
        
            _themes.Add(new Theme(nameInput, IdGenerator(_themes), true));
        }
    
    
        private void StartGame()
        {
            var themes = _themes.Where(x => x.Active is true);
            foreach (var theme in themes)
            {
                foreach (var choice in theme.Choices)
                {
                    _options.Add(choice.Original);
                    _options.Add(choice.Translated);
                    
                }
            }
            Randomize(_options);
        
            while (true)
            {
                ShowGame(); 
           
            }
        }

        private void ShowGame()
        {
            int amountofChoices = 0;
            foreach (var option in _options)
            {
                Console.Write(option + "     ");
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
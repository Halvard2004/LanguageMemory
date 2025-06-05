using Language_Memory_Game;

public class Main
{
    private List<Theme> _themes = new List<Theme>();
    private readonly List<SimpleChoicesVersion> _choices = new List<SimpleChoicesVersion>();
    private readonly List<int> _choices2 = new List<int>();
    private Random _random = new Random();
    public void Run()
    {
        testCode();

        foreach (var choice in _choices)
        {
            _choices2.Add(choice.Option1);
            _choices2.Add(choice.Option2);
        }
        Randomize(_choices2);
        ShowGame();
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

    private void Randomize(List<int> choices2)
    {
        int randomIndex;
        int extraVariable;
        for (int i = 0; i < choices2.Count; i++)
        {
            randomIndex = _random.Next(0, choices2.Count);
            extraVariable = choices2[i];
            choices2[i] = choices2[randomIndex];
            choices2[randomIndex] = extraVariable;
        } 
    }

    private void testCode()
    {
        for (int i = 0; i < 20; i++)
        {
           _choices.Add(new SimpleChoicesVersion(i));    
        }
        
    }
}
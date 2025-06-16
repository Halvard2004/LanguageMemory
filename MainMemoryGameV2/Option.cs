namespace MainMemoryGame;

public class Option
{
    private int _choiceId;
    public int LangaugeId { get; private set; }
    public string Word { get; private set; }

    public Option(int choiceId,int idLanguage, string word)
    {
        _choiceId = choiceId;
        LangaugeId = idLanguage;
        Word = word;
    }
}
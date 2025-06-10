namespace MainMemoryGame;

public class Option
{
    private int _choiceId;
    private int _langaugeId;
    public string Word { get; private set; }

    public Option(int _choiceId,int idLanguage, string word)
    {
        _choiceId = _choiceId;
        _langaugeId = idLanguage;
        Word = word;
    }
}
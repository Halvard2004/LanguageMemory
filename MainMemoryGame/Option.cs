namespace MainMemoryGame;

public class Option
{
    private int _choiceId;
    private int _langaugeId;
    private string _word;

    public Option(int _choiceId,int idLanguage, string word)
    {
        _choiceId = _choiceId;
        _langaugeId = idLanguage;
        _word = word;
    }
}
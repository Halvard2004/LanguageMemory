namespace MainMemoryGame;

public class Choice
{
    private int Id;
    internal Option Original;
    internal Option Translated;

    public Choice(int id, string originalWord, int originalLanguage, string translatedWord, int translatedLanguage)
    {
        Id = id;
        Original = new Option(id, originalLanguage, originalWord);
        Translated = new Option(id, translatedLanguage, translatedWord);
    }
}
namespace MainMemoryGame;

public class Choice
{
    public int Id { get; private set; }
    internal readonly Option Original;
    internal readonly Option Translated;

    public Choice(int id, string originalWord, int originalLanguage, string translatedWord, int translatedLanguage)
    {
        Id = id;
        Original = new Option(id, originalLanguage, originalWord);
        Translated = new Option(id, translatedLanguage, translatedWord);
    }
}
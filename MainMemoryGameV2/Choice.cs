﻿namespace MainMemoryGame;

public class Choice
{
    public int Id { get; private set; }
    internal Option Original;
    internal Option Translated;

    public Choice(int id, string originalWord, int originalLanguage, string translatedWord, int translatedLanguage)
    {
        Id = id;
        Original = new Option(id, originalLanguage, originalWord);
        Translated = new Option(id, translatedLanguage, translatedWord);
    }

    public Choice(int id, Option original, Option translated)
    {
        Id = id;
        Original = original;
        Translated = translated;
    }
}
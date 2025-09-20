using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitWords = text.Split(" ");
        foreach (string word in splitWords)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();

        for (int i = 0; i < count; i++)
        {
            int index = rand.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {

        List<string> displayWords = new List<string>();

        foreach (Word w in _words)
        {
            displayWords.Add(w.GetDisplayText());
        }

        string scriptureText = string.Join(" ", displayWords);
        return _reference.GetDisplayText() + " " + scriptureText;
    }

    public bool IsCompletelyHidden()
    {
         foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                return false;
            }
        }
        return true;
    }    
    
}

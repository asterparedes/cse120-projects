using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference Reference, string text)
    {
        _reference = Reference;
        string [] words = text.Split(" ");
        foreach (string wordString in words)
        {
            Word word = new Word(wordString);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        /* Stretch Challenge 
            Randomly select words that are not already hidden. 
        */
        Random random = new Random();
        
        int wordsNotHidden = 0;

        while (numberToHide > wordsNotHidden  && IsCompletelyHidden() == false)
        {
            for(int i = 0; i < numberToHide; ++i)
            {
                int randomWordsIndex = random.Next(0, _words.Count);
                Word word = _words [randomWordsIndex];
                
                if (word.IsHidden() == false)
                {
                    wordsNotHidden += 1;
                    word.Hide();
                    if (wordsNotHidden >= numberToHide)
                    {
                        break;
                    }
                }
                
            }
        }
    }

    public string GetDisplayText()
    {
        string verse = "";  
        int index = 0; 
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                verse += word.GetDisplayText();
            }
            else
            {
                for (int i = 0; i < word.GetDisplayText().Length; ++i)
                {
                    verse += "_";
                }
            }

            if (index < _words.Count - 1)
            {
                verse += " ";
            }
        }        
        return $"{_reference.GetDisplayText()} {verse}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                return false;
            }
        }
        return true;
    }
}
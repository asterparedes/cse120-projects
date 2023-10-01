using System;

public class Word
{
    private string _string;
    private bool _isHidden;

    public Word(string text)
    {
        _string = text;
    }
    
    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _string;
    }
}
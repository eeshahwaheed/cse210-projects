public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public string Text => _text;
    public bool IsHidden => _isHidden;

    public void Hide()
    {
        _isHidden = true;
    }

    public override string ToString()
    {
        return _isHidden ? "___" : _text;
    }
}

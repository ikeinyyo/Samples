namespace Maktub82.Sample.Speech
{
    public enum TextCommandType
    {
        Upper,
        Lower,
        Reverse
    }

    public class TextCommand
    {
        public TextCommandType Type { get; set; }
        public string Sentence { get; set; }
    }
}

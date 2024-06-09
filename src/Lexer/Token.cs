namespace TheGreatInterpreter.Lexer;

public class Token(ETokenType type, int? value = null)
{
    public ETokenType Type { get; set; } = type;
    public int? Value{ get; set; } = value;
}
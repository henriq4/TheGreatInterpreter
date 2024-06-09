using TheGreatInterpreter.Lexer;

namespace TheGreatInterpreter.SymbolTable;

public class TableEntry(ETokenType type, string name, double? value = null)
{
    public ETokenType Type { get; set; } = type;
    public string Name { get; set; } = name;
    public double? Value { get; set; } = value;
}
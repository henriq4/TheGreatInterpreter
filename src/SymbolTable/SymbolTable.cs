using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TheGreatInterpreter.Lexer;

namespace TheGreatInterpreter.SymbolTable;

public class SymbolTable
{
    private int _key = 0;
    private readonly Dictionary<int, TableEntry> _data = new();

    public int Put(string name, double? value = null)
    {
        var (entry, k) = GetByName(name);
        if (entry != null)
            return k;

        _data.Add(++_key, new TableEntry(ETokenType.Var, name, value));
        return _key;
    }

    private (TableEntry?, int) GetByName(string name)
    {
        foreach (var k in _data.Keys.ToList().Where(k => _data[k].Name == name))
        {
            return (_data[k], k);
        }
        
        return (null, 0);
    }

    public double? Get(int key)
    {
        if (!(_data.ContainsKey(key)))
            return null;
        var entry = _data[key];
        return entry.Value;
    }


    public TableEntry? GetEntry(int key)
    {
        if (!(_data.ContainsKey(key)))
            return null;
        var entry = _data[key];
        return entry;
    }


    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("ID".PadRight(5, ' '));
        sb.Append("Type".PadRight(10, ' '));
        sb.Append("Name".PadRight(15, ' '));
        sb.Append("Value".PadRight(5, ' '));
        sb.AppendLine();

        _data.Keys.ToList().ForEach(k =>
        {
            var entry = _data[k];
            sb.Append(k.ToString().PadRight(5, ' '));
            sb.Append(entry.Type.ToString().PadRight(10, ' '));
            sb.Append(entry.Name.ToString().PadRight(15, ' '));
            if (entry.Value.HasValue)
                sb.Append(entry.Value.Value.ToString(CultureInfo.InvariantCulture).PadRight(5, ' '));
            sb.AppendLine();
        });
        return sb.ToString();
    }
}
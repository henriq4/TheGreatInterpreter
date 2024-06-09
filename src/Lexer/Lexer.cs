namespace TheGreatInterpreter.Lexer;

using SymbolTable;

public class Lexer
{
	public int Ptr { get; set; }

	private string Command { get; set; }
	private SymbolTable SymbolTable { get; set; }

	private char? _peek;

	public Lexer(string command, SymbolTable? st = null)
	{
		this.Command = command;

		st ??= new SymbolTable();

		SymbolTable = st;

		Ptr = 0;
	}

	public Token GetNextToken()
	{
		_peek = Scan();

		if (_peek == null)
			return new Token(ETokenType.Eof);

		while (_peek is null or ' ' or '\t' or '\r')
		{
			_peek = Scan();
		}

		switch (_peek)
		{
			case '+':
				return new Token(ETokenType.Sum);
			case '-':
				return new Token(ETokenType.Sub);
			case '=':
				return new Token(ETokenType.Eq);
			case '\n':
				return new Token(ETokenType.Eof);
		}

		//[a-z]+
		if (char.IsLower(_peek.Value))
		{
			var varName = " ";
			do
			{
				_peek = Scan();
				if (char.IsLetter(_peek.Value))
					varName += _peek;
			} while (char.IsLetter(_peek.Value));

			var key = SymbolTable.Put(varName, null);

			return new Token(ETokenType.Var, key);
		}

		//[0-9]+
		if (char.IsDigit(_peek.Value))
		{
			var value = 0;
			do
			{
				value = 10 * value + (int)char.GetNumericValue(_peek.Value);
				_peek = Scan();
			} while (char.IsDigit(_peek.Value));

			return new Token(ETokenType.Num, value);
		}

		return new Token(ETokenType.Unk);
	}

	private char Scan()
	{
		return Ptr == Command.Length ? '\0' : Command[Ptr];
	}

	private bool TestSuffix(string suffix)
	{
		var res = true;
		suffix.ToCharArray().ToList().ForEach(c =>
		{
			_peek = Scan();
			if (_peek == c) return;
			res = false;
		});
		_peek = null;
		return res;
	}

	private int ParseInt(char? c)
	{
		return c switch
		{
			'0' => 0,
			'1' => 1,
			'2' => 2,
			'3' => 3,
			'4' => 4,
			'5' => 5,
			'6' => 6,
			'7' => 7,
			'8' => 8,
			'9' => 9,
			_ => 0
		};
	}
}
using System;
using TheGreatInterpreter.Lexer;

namespace TheGreatInterpreter;

public class Interpreter
{
	private readonly SymbolTable.SymbolTable _table = new();

	public void Exec()
	{
		Console.WriteLine("Welcome!");

		var command = ReadLine();
		Token t;

		var lexer = new Lexer.Lexer(command, _table);
		
		do
		{
			t = lexer.GetNextToken();
			
			Console.WriteLine($"<{t.Type},{t.Value}>");
			
		} while (t.Type != ETokenType.Eof || t.Type != ETokenType.Unk);
		
		Console.WriteLine("Bye!");
	}

	private static string ReadLine()
	{
			Console.Write("> ");

			var command = Console.ReadLine();

			return command ?? " ";
	}
}
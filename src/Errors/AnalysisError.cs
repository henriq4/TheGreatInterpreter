using System;
using TheGreatInterpreter.Lexer;

namespace TheGreatInterpreter.Errors;

public class AnalysisError
{
	public static void PrintError(Token token, int column)
	{
		Console.WriteLine("#Error in " + token.Type + " " + token.Value);
		Console.WriteLine("Char " + column);

		Console.WriteLine("________________");
		Console.WriteLine("Expected " + token.Type + " - Found " + token.Type);
		Console.WriteLine("________________");
	}
}
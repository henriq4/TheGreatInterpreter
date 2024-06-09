using System.Runtime.InteropServices.JavaScript;
using TheGreatInterpreter.Errors;

namespace TheGreatInterpreter.Parser;

using SymbolTable;
using Lexer;

public class Parser
{
	private readonly SymbolTable _symbolTable;
	private readonly Lexer _lexer;
	private Token _lookAhead;

	public Parser(Lexer lexer, SymbolTable st)
	{
		_lexer = lexer;
		_lookAhead = _lexer.GetNextToken();
		_symbolTable = st;
	}

	private void Match(ETokenType tokenType)
	{
		if (_lookAhead.Type == tokenType)
			_lookAhead = _lexer.GetNextToken();
		else
			AnalysisError.PrintError(_lookAhead, _lexer.Ptr);
	}


	public void Atrib() // atrib  : VAR EQ expr
	{
		Match(ETokenType.Var);
		Match(ETokenType.Eq);
		Expr();
	}

	private void Expr() // expr   : tern rest 
	{
		Term();
		Rest();
	}

	private void Term() // term		: NUM | VAR
	{
		switch (_lookAhead.Type)
		{
			case ETokenType.Num:
				Match(ETokenType.Num);
				break;
			case ETokenType.Var:
				Match(ETokenType.Var);
				break;
			default:
				break;
		}
	}

	private void Rest() // rest		: SUM expr | SUB expr | EOF
	{
		switch (_lookAhead.Type)
		{
			case ETokenType.Sum:
				Match(ETokenType.Sum);
				break;
			case ETokenType.Sub:
				Match(ETokenType.Sub);
				break;
			default:
				break;
		}
	}
}
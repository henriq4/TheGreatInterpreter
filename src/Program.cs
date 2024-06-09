using System;
using TheGreatInterpreter;
using TheGreatInterpreter.SymbolTable;

var st = new SymbolTable();
var itp = new Interpreter();

itp.Exec();

Console.WriteLine(st);
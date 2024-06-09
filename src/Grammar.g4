grammar Grammar;

atrib       : VAR EQ expr;

expr        : term rest;

rest        : '+' expr
            | '-' expr
            | EOF;

term        : NUM 
            | VAR;

NUM         : [0-9]+;

SUM         : '+';

SUB         : '-';

EQ          : '=';

VAR         : [a-zA-Z]+;

EOF         : '\n';

// abc = 1 + 2
// a + c
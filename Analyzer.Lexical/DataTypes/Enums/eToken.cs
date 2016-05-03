namespace Analyzer.DataTypes.Enums
{
    enum eToken
    {
        Identifier,
        Number,
        Delim,
        OperatorAddition,
        OperatorSubtraction,
        OperatorMultiply,
        OperatorDivision,
        OperatorPower,
        Attribution,
        OpenParenthesis,
        CloseParenthesis,

        StartOfSentence,
        EndOfSentence,
        Expression,
        Error,
        Term,
        ExpressionL,
        Empty,
        TermL,
        Fator,
        FatorL,
        NumberL,

        //future features
        ArithmeticOperator, //replace all operators by 
        Comma,
        SemiColon,
        Colon,
        Constant //replace Number by
    }
}

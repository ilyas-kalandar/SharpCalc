﻿namespace SharpCalc;

public enum TokenType
{
    PLUS,
    MINUS,
    DIVIDE,
    MULTIPLY,
    INT_VALUE,
    RIGHT_PAREN,
    LEFT_PAREN
}

public class Token
{
    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TokenType Type { get; private set; }
    public string Value { get; private set; }

    public override string? ToString()
    {
        return $"Token(Type={Type}, Value=({Value}))";
    }
}
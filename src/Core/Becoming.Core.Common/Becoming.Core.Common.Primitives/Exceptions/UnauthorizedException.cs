﻿namespace Becoming.Core.Common.Primitives.Exceptions;

public sealed class UnauthorizedException : ApplicationException
{
    public UnauthorizedException() : base() { }

    public UnauthorizedException(string message) : base(message) { }

    public UnauthorizedException(string message, Exception ex) : base(message, ex) { }
}
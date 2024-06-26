﻿namespace Becoming.Core.Common.Domain.Seedwork;

public abstract class DomainException : Exception
{
    protected DomainException() : this(string.Empty) { }
    protected DomainException(string message) : base(message) { }
    protected DomainException(string message, Exception innerException) : base(message, innerException) { }
}
﻿using System;

namespace PrevisaoDoTempoApp.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}

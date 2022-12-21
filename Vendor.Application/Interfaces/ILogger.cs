﻿namespace Vendor.Application.Interfaces
{
    public interface ILogger
    {
        void Info(string message);

        void Error(string message);

        void Debug(string message);
    }
}

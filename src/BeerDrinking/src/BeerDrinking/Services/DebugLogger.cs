using System;
using FFImageLoading.Helpers;
using Prism.Logging;
using static System.Diagnostics.Debug;

namespace BeerDrinking.Services
{
    public class DebugLogger : ILoggerFacade, IMiniLogger
    {
        public void Log(string message, Category category, Priority priority) =>
            WriteLine($"{category} - {priority}: {message}");

        public void Debug(string message) =>
            WriteLine($"{nameof(IMiniLogger)} : Debug : {message}");

        public void Error(string errorMessage) =>
            WriteLine($"{nameof(IMiniLogger)} : Error : {errorMessage}");

        public void Error(string errorMessage, Exception ex) =>
            Error($"{errorMessage}{Environment.NewLine}{ex}");
    }
}
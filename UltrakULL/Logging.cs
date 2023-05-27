
using BepInEx.Logging;

namespace UltrakULL
{
    public static class Logging 
    {
        public static ManualLogSource UllLogger = Logger.CreateLogSource("ULL LOGGING");

        public static void Debug(string text)
        {
            UllLogger.LogDebug(text);
        }
        
        public static void Message(string text)
        {
            UllLogger.LogMessage(text);
        }
        
        public static void Warn(string text)
        {
            UllLogger.LogWarning(text);
        }
        
        public static void Error(string text)
        {
            UllLogger.LogError(text);
        }
        
        public static void Fatal(string text)
        {
            UllLogger.LogFatal(text);
        }
        
        public static void Info(string text)
        {
            UllLogger.LogInfo(text);
        }

        
    }
}
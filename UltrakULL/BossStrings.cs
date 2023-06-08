using UltrakULL.json;

namespace UltrakULL
{
    public static class BossStrings
    {
        public static string GetBossName(string originalBossName)
        {
            Logging.Warn(originalBossName);
            return EnemyBios.GetName(originalBossName.ToUpper());
        }
    }
}

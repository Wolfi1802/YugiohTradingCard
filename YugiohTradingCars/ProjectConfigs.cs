using System.Reflection;

namespace YugiohTradingCars
{
    public class ProjectConfigs
    {
        /// <summary>
        /// Welche Runtime wird aktuell verwendet?
        /// </summary>
        public static bool IsDebugBuild
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }

        public static string? CurrentVersion
        { get { return Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString(); } }

    }
}

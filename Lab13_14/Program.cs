using NLog;
using NLog.Config;
using NLog.Targets;

namespace Lab13_14
{
    internal class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        static void Main()
        {
            SetupLogger();

            Protector.Register("Admin", "Admin", new[] { "Admin" });
            Protector.Register("User1", "password1", new[] { "User", "Sales" });
            Protector.Register("User2", "password2", new[] { "Admin", "Sales" });
            Protector.Register("User3", "password3", new[] { "User" });

            AuthenticateUser("User1", "password1");

            TryAdminsFeature();
            Console.WriteLine();
            Console.WriteLine("-------------------");
            logger.Debug("Debug example");

            AuthenticateUser("Admin", "Admin");

            TryAdminsFeature();

            Console.WriteLine();
            Console.WriteLine("-------------------");
            logger.Fatal("Fatal example");

        }

        static void AuthenticateUser(string userName, string password)
        {
            Protector.LogIn(userName, password);

            logger.Info($"Authenticated User: {userName}, Roles: {string.Join(", ", Protector.GetCurrentUserRoles())}");
        }

        static void TryAdminsFeature()
        {
            try
            {
                Protector.OnlyForAdminsFeature();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error in protected feature.");

            }
        }

        static void SetupLogger()
        {
            var config = new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget() 
            {
                Layout = "${longdate}|${level:uppercase=true}|${callsite}|${message}|${exception:format=tostring}"
            };

            config.AddTarget("console", consoleTarget);
            config.AddRuleForAllLevels(consoleTarget);

            var fileTarget = new FileTarget
            {
                FileName = "logfile.txt",
                Layout = "${longdate}|${level:uppercase=true}|${callsite}|${message}|${exception:format=tostring}"
            };
            config.AddTarget("file", fileTarget);
            config.AddRuleForOneLevel(LogLevel.Warn, fileTarget);
            config.AddRuleForOneLevel(LogLevel.Error, fileTarget);
            config.AddRuleForOneLevel(LogLevel.Fatal, fileTarget);

            LogManager.Configuration = config;
        }

    }
}

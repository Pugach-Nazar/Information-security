using NLog;
using System.Security;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Lab13_14
{
    internal class Protector
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static Dictionary<string, User> _users = new Dictionary<string, User>();

        public static User Register(string userName, string password, string[] roles = null)
        {

            if (_users.ContainsKey(userName))
            {
                logger.Warn($"User with the name {userName} is already registered.");
                throw new InvalidOperationException("User with this name already exists.");
            }

            byte[] salt = GenerateSalt(16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(32);

            var user = new User
            {
                Login = userName,
                PasswordHash = Convert.ToBase64String(hash),
                Salt = Convert.ToBase64String(salt),
                Roles = roles
            };

            _users.Add(userName, user);

            logger.Info($"User {userName} registered successfully.");

            return user;
        }

        public static bool CheckPassword(string userName, string password)
        {

            if (!_users.ContainsKey(userName))
            {
                logger.Warn($"User with the name {userName} does not exist.");
                return false;
            }

            var user = _users[userName];
            var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(user.Salt), 10000);
            byte[] hash = pbkdf2.GetBytes(32);

            if (Convert.ToBase64String(hash) == user.PasswordHash)
            {
                logger.Trace($"Password for user {userName} is correct.");
                return true;
            }
            else
            {
                logger.Warn($"Incorrect password for user {userName}.");
                return false;
            }
        }

        public static void LogIn(string userName, string password)
        {
            
            if (CheckPassword(userName, password))
            {
                var identity = new GenericIdentity(userName, "OIBAuth");
                
                var principal = new GenericPrincipal(identity, _users[userName].Roles);

                System.Threading.Thread.CurrentPrincipal = principal;
                logger.Info($"User {userName} logged in successfully.");
            }
        }

        public static void OnlyForAdminsFeature()
        {

            if (Thread.CurrentPrincipal == null)
            {
                logger.Error("Thread.CurrentPrincipal cannot be null.");
                throw new SecurityException("Thread.CurrentPrincipal cannot be null.");
            }


            if (!Thread.CurrentPrincipal.IsInRole("Admin"))
            {
                logger.Warn("User must be a member of Admins to access this feature.");
                throw new SecurityException("User must be a member of Admins to access this feature.");
            }
            logger.Info("Protected feature accessed successfully.");
            Console.WriteLine("You have access to this secure feature.");
        }

        public static string[] GetCurrentUserRoles()
        {

            if (Thread.CurrentPrincipal != null)
            {
                var userName = Thread.CurrentPrincipal.Identity.Name;
                if (_users.ContainsKey(userName))
                {
                    return _users[userName].Roles;
                }

            }

            return new string[0];
        }

        public static byte[] GenerateSalt( int lenght)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[32];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
    }
}

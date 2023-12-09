using System.Security;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Lab11_12
{
    internal class Protector
    {
        private static Dictionary<string, User> _users = new Dictionary<string, User>();

        public static User Register(string userName, string password, string[] roles = null)
        {

            if (_users.ContainsKey(userName))
            {
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

            return user;
        }

        public static bool CheckPassword(string userName, string password)
        {

            if (!_users.ContainsKey(userName))
            {
                throw new InvalidOperationException("User with this name does not exist.");
            }

            var user = _users[userName];
            var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(user.Salt), 10000);
            byte[] hash = pbkdf2.GetBytes(32);

            return Convert.ToBase64String(hash) == user.PasswordHash;
        }

        public static void LogIn(string userName, string password)
        {
            // Перевірка пароля
            if (CheckPassword(userName, password))
            {
                // Створюється екземпляр автентифікованого користувача
                var identity = new GenericIdentity(userName, "OIBAuth");

                // Виконується прив’язка до ролей, до яких належить користувач
                var principal = new GenericPrincipal(identity, _users[userName].Roles);

                // Створений екземпляр автентифікованого користувача з відповідними
                // ролями присвоюється потоку, в якому виконується програма
                System.Threading.Thread.CurrentPrincipal = principal;
            }
        }

        public static void OnlyForAdminsFeature()
        {

            if (Thread.CurrentPrincipal == null)
            {
                throw new SecurityException("Thread.CurrentPrincipal cannot be null.");
            }


            if (!Thread.CurrentPrincipal.IsInRole("Admin"))
            {
                throw new SecurityException("User must be a member of Admins to access this feature.");
            }


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

using Lab11_12;

namespace lab11_12
{
    internal class Program
    {
        static void Main()
        {

            Protector.Register("Admin", "Admin", new[] { "Admin" });
            Protector.Register("User1", "password1", new[] { "User", "Sales"});
            Protector.Register("User2", "password2", new[] { "Admin", "Sales" });
            Protector.Register("User3", "password3", new[] { "User" });

            AuthenticateUser("User1", "password");

            try
            {
                Protector.OnlyForAdminsFeature();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

            AuthenticateUser("Admin", "Admin");

            try
            {
                Protector.OnlyForAdminsFeature();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

            try
            {
                AuthenticateUser("Admin1", "Admin");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AuthenticateUser(string userName, string password)
        {
            Protector.LogIn(userName, password);

            Console.WriteLine($"Authenticated User: {userName}, Roles: {string.Join(", ", Protector.GetCurrentUserRoles())}");
        }



    }
}

using System;

//namespace StaticCredentialCheck
//{
    public static class CredentialCheck
    {
        public static string? Username { get; set; } // only one set of credentials to rule them all
        public static string? Password { get; set; }
        public static bool invalidCredentials { get; set; }

        static CredentialCheck() // constructor
        {
        }
        public static bool ResetCredentials() // save credentials to class
        {
            invalidCredentials = true; // reset credentials anytime this function is called
            int setAttempts = 0;
        string? enteredUsername, enteredPassword;
            do
            {
                setAttempts++;
                Console.WriteLine($"Enter your new credentials. (Attempt {setAttempts})");
                Console.Write("Username: ");
                enteredUsername = Console.ReadLine();
                Console.Write("Password: ");
                enteredPassword = Console.ReadLine();
                // simple blank/null error checking here, need more
                if (string.IsNullOrWhiteSpace(enteredUsername) || string.IsNullOrWhiteSpace(enteredPassword))
                {
                    Console.WriteLine("Invalid Entry - Username or Password cannot be blank or whitespace.");
                }
                else
                {
                    invalidCredentials = false; // credentials accepted
                }
            } while (invalidCredentials && setAttempts < 3);

            if (invalidCredentials == false)
            {
                // save valid credentials to 
                Username = enteredUsername;
                Password = enteredPassword;
                Console.WriteLine("\nValid Credentials saved.\n");
                return true;
            }
            else
            {
                Console.WriteLine("\nInvalid Credentials NOT saved.\n");
                return false;
            }
        }
        public static bool VerifyCredentials()
        {
            if (invalidCredentials)
            {
                Console.WriteLine("\nCannot verify credentials. Reset your credentials.\n");
                return false;
            }

            bool successfulLogon = false;
            int logonAttempts = 0;
            int maxLogonAttemptsAllowed = 3;
            do
            {
                logonAttempts++;

                Console.Clear();
                Console.WriteLine($"Logon Screen. Enter your credentials. (Attempt {logonAttempts})\n");

                Console.WriteLine("Username: ");
                string? userInputUsername = Console.ReadLine();

                Console.WriteLine("Password: ");
                string? userInputPassword = Console.ReadLine();

                if ((userInputPassword != Password) || (userInputUsername != Username))
                {
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n*** INVALID CREDENTIALS ***\n");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                else
                {
                    successfulLogon = true;
                    break;
                }

            } while (logonAttempts < maxLogonAttemptsAllowed);

            if (successfulLogon)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
//}
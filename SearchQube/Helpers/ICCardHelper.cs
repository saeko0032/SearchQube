using System;
using SearchQube.Models;

namespace SearchQube.Helpers
{
    public class ICCardHelper
    {
        #region Methods

        public User? ReadUserInformation()
        {
            try
            {
                // Simulate reading user information from IC Card
                var user = new User
                {
                    EmployeeId = "12345",
                    SESAID = "SESA12345",
                    Name = "John Doe",
                    Department = "IT"
                };

                return user;
            }
            catch (Exception ex)
            {
                // Log the exception and return null
                Console.WriteLine($"Error reading user information: {ex.Message}");
                return null;
            }
        }

        #endregion Methods
    }
}

using System;
using SearchQube.Models;
using FelicaLib; // Appropriate library for PaSoRi RC-S380

namespace SearchQube.Helpers
{
    public class ICCardHelper
    {
        #region Methods

        public User? ReadUserInformation()
        {
            try
            {
                // Initialize the PaSoRi RC-S380 reader
                var felica = new Felica();
                felica.Polling(FelicaSystemCode.Any);

                // Read user information from the IC card
                var user = new User
                {
                    EmployeeId = felica.IDm.ToString(),
                    SESAID = "SESA" + felica.IDm.ToString(),
                    Name = "John Doe", // Placeholder, replace with actual logic to read name
                    Department = "IT" // Placeholder, replace with actual logic to read department
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

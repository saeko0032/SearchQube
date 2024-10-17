using System;
using System.Threading.Tasks;
using SearchQube.Models;

namespace SearchQube.Services
{
    public class RFIDCardService
    {
        #region Methods

        public async Task<Equipment> ReadEquipmentInfoAsync()
        {
            // Simulate reading equipment information from RFID card
            await Task.Delay(1000);

            // Return dummy equipment information for now
            return new Equipment
            {
                TerminalId = "12345",
                Info = "Sample Equipment",
                Location = "Sample Location"
            };
        }

        #endregion Methods
    }
}

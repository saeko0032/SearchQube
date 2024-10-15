using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using SearchQube.Models;

namespace SearchQube.Services
{
    public class ExcelService
    {
        private readonly string _filePath;

        public ExcelService(string filePath)
        {
            _filePath = filePath;
        }

        public List<User> ReadUsers()
        {
            var users = new List<User>();

            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var user = new User
                    {
                        EmployeeId = worksheet.Cells[row, 1].Text,
                        SESAID = worksheet.Cells[row, 2].Text,
                        Name = worksheet.Cells[row, 3].Text,
                        Department = worksheet.Cells[row, 4].Text
                    };
                    users.Add(user);
                }
            }

            return users;
        }

        public List<Equipment> ReadEquipments()
        {
            var equipments = new List<Equipment>();

            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var worksheet = package.Workbook.Worksheets[1];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var equipment = new Equipment
                    {
                        TerminalId = worksheet.Cells[row, 1].Text,
                        Info = worksheet.Cells[row, 2].Text,
                        Location = worksheet.Cells[row, 3].Text
                    };
                    equipments.Add(equipment);
                }
            }

            return equipments;
        }

        public bool CompareEmployeeId(string employeeId)
        {
            var users = ReadUsers();
            foreach (var user in users)
            {
                if (user.EmployeeId == employeeId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CompareTerminalId(string terminalId)
        {
            var equipments = ReadEquipments();
            foreach (var equipment in equipments)
            {
                if (equipment.TerminalId == terminalId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

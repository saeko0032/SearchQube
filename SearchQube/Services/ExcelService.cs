using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using OfficeOpenXml;
using SearchQube.Models;

namespace SearchQube.Services
{
    public class ExcelService
    {
        #region Fields

        // 確認済みのEquipmentのリストを格納するプロパティ
        private static readonly ObservableCollection<Equipment> _confirmedEquipments = new ObservableCollection<Equipment>();

        // 外部クラスから読み取り専用でアクセスできるプロパティ
        public static ReadOnlyObservableCollection<Equipment> ConfirmedEquipments { get; } = new ReadOnlyObservableCollection<Equipment>(_confirmedEquipments);

        // 確認済みのEquipmentを追加するメソッド
        public void AddConfirmedEquipment(Equipment equipment)
        {
            _confirmedEquipments.Add(equipment);
        }

        private readonly string? _filePath;

        #endregion Fields

        #region Constructors

        public ExcelService()
        {
        }

        public ExcelService(string filePath)
        {
            _filePath = filePath;
        }

        #endregion Constructors

        #region Methods

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
                    AddConfirmedEquipment(equipment);
                    return true;
                }
            }
            return false;
        }

        public List<Equipment> ReadEquipments()
        {
            var equipments = new List<Equipment>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
#pragma warning disable CS8604 // Null 参照引数の可能性があります。
            using (var package = new ExcelPackage(new FileInfo("C:\\dev\\practice\\RFID\\SearchQube-main\\SearchQube-main\\SearchQube\\Device.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets[0];
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
#pragma warning restore CS8604 // Null 参照引数の可能性があります。

            return equipments;
        }

        public List<User> ReadUsers()
        {
            var users = new List<User>();
            // ライセンスコンテキストを設定
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
#pragma warning disable CS8604 // Null 参照引数の可能性があります。
            using (var package = new ExcelPackage(new FileInfo("C:\\dev\\practice\\RFID\\SearchQube-main\\SearchQube-main\\SearchQube\\sample.xlsx")))
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
#pragma warning restore CS8604 // Null 参照引数の可能性があります。

            return users;
        }

        internal bool CompareEquipmentId(object id)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}

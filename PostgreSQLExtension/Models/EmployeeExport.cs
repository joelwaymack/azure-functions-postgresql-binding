using System;

namespace PostgreSQLExtension.Models
{
    public class EmployeeExport
    {
        public Guid Id { get; set; }
        public DateTime ExtractDate { get; set; }
    }
}

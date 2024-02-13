namespace vue3.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;    
        public string TitleOfCourtesy { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int? ReportsTo { get; set; }
    }
}

namespace MIS.Business.Models.Employee
{
    public class ListEmployeesRequest
    {
        public string Firstname { get; set; } = string.Empty;
        public string Middlename { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
    }
}

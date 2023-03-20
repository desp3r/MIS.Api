namespace MIS.Business.Models.Employee
{
    public class ListEmployeesRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Guid? SpecialtyId { get; set; } = Guid.Empty;
    }
}

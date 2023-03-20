using MIS.Business.Models.User;
using MIS.Data.Models;

namespace MIS.Business.Interfaces
{
    public interface IUserService
    {
        public void GetInfo(int Id);

        public void CreateAppointment(Appointment appointment);

        public void GetAppointment();
    }
}

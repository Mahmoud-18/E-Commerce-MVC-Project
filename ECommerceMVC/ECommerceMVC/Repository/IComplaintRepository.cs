using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IComplaintRepository
    {
        List<Complaint> GetAll();
        List<Complaint> GetByEmployeeId(int id);
        Complaint GetById(int id);
        void Insert(Complaint newcomplaint);
        void Update(int id, Complaint complaint);
        void Delete(int id);
    }
}

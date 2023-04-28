using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class ComplaintRepository :IComplaintRepository
    {
        private readonly EcommerceDbContext context;

        public ComplaintRepository(EcommerceDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Complaint> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Complaint> GetByEmployeeId(int id)
        {
            throw new NotImplementedException();
        }

        public Complaint GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Complaint newcomplaint)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Complaint complaint)
        {
            throw new NotImplementedException();
        }
    }
}

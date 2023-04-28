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
            context.Complaint.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Complaint> GetAll()
        {
            return context.Complaint.ToList();
        }

        public List<Complaint> GetByEmployeeId(int id)
        {
            return context.Complaint.Where(i => i.CustomerId == id).ToList();
        }

        public Complaint GetById(int id)
        {
            return context.Complaint.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(Complaint newcomplaint)
        {
            context.Complaint.Add(newcomplaint);
            context.SaveChanges();
        }

        public void Update(int id, Complaint complaint)
        {
            context.Update(complaint);
            context.SaveChanges();
        }
    }
}

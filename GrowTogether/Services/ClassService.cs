using GrowTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GrowTogether.Services
{


    public class ClassService:IClassService
    {
        private readonly GrowDbContext _context = null;
        public ClassService(GrowDbContext dbContext)
        {
            _context = dbContext;
        }

        public string JoinClass(User user, ComputerScience classes)
        {
            try
            {
                ComputerScience computer = new ComputerScience()
                {
                    cid = classes.cid,
                    UserId = user.UserID
                };
                _context.computerScience.Add(computer);
                _context.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public string LeaveClass(User user, ComputerScience classes)
        {
            try
            {
                var del = _context.computerScience.Where(x => x.UserId == user.UserID);
                _context.Remove(del);
                _context.SaveChanges();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ComputerScience ValidateUSer(User user)
        {
            try
            {
                var valid = _context.computerScience.Find(user.UserID);
                return valid;
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}

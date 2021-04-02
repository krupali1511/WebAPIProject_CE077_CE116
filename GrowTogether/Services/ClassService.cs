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

        public String JoinClass(User user, Classes classes)
        {
            try
            {
                var a = classes.name;
                if (classes.name=="Maths") 
                {
                    var maths = new Maths() {
                        UserId = user.UserID,
                        cid= classes.id,
                        
                    };
                    _context.Maths.Add(maths);
                }
                else if (classes.name == "Medical") 
                {
                    var medical = new Medical()
                    {
                        UserId = user.UserID,
                        cid = classes.id,

                    };
                    _context.Medical.Add(medical);
                }
                else if (classes.name == "ComputerScience") 
                {
                    var cs = new ComputerScience()
                    {
                        UserId = user.UserID,
                        cid = classes.id,

                    };
                    _context.computerScience.Add(cs);
                }
                else if (classes.name == "Science") 
                {
                    var science = new Science()
                    {
                        UserId = user.UserID,
                        cid = classes.id,

                    };
                    _context.Science.Add(science);
                }
                else if (classes.name == "JEE") 
                {
                    var jee = new JEE()
                    {
                        UserId = user.UserID,
                        cid = classes.id,

                    };
                    _context.JEE.Add(jee);
                }
                else
                {
                    return "Fail";
                }
                return "Success";
                
            }
            catch (Exception)
            {

                throw ;
            }
        }

        public String LeaveClass(User user, Classes classes)
        {
            try
            {
               
                if (classes.name == "Maths")
                {
                    var maths = _context.Maths.Where(u => u.UserId == user.UserID && u.cid == classes.id).FirstOrDefault();
                    _context.Maths.Remove(maths);
                }
                else if (classes.name == "Medical")
                {
                    var medical = _context.Medical.Where(u => u.UserId == user.UserID && u.cid == classes.id).FirstOrDefault();
                    _context.Medical.Remove(medical);
                }
                else if (classes.name == "ComputerScience")
                {

                    var cs = _context.computerScience.Where(u => u.UserId == user.UserID && u.cid == classes.id).FirstOrDefault();
                    _context.computerScience.Remove(cs);
                }
                else if (classes.name == "Science")
                {
                    var science = _context.Science.Where(u => u.UserId == user.UserID && u.cid == classes.id).FirstOrDefault();
                    _context.Science.Remove(science);
                }
                else if (classes.name == "JEE")
                {
                    var jee = _context.JEE.Where(u => u.UserId == user.UserID && u.cid == classes.id).FirstOrDefault();
                    _context.JEE.Remove(jee);
                }
                else
                {
                    return "Fail";
                }
                return "Success";            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}

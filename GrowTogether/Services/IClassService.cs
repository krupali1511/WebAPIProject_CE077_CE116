using GrowTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowTogether.Services
{
    public interface IClassService
    {
        public String JoinClass(User user, Classes classes);
        public String LeaveClass(User user, Classes classes);
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class LeaveType
    {
        public int LeaveId { get; set; }
        public string LeaveName { get; set;}

        public IList<Student> Students { get; set; }
    }
}

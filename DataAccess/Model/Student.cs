using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Title { get; set; }
        public DateTime LeaveDate { get; set; }
        public string Reason { get; set; }

        public string Status { get; set; }

        public int ClassId { get; set; }
        public ClassLeave ClassLeave { get; set; }
        public int LeaveId { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}

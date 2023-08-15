using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ClassLeave
    {
        public int ClassId { get; set; }
        public string Name { get; set; }

        public IList<Student> Students { get; set; }
    }
}

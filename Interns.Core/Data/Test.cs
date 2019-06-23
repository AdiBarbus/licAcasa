using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interns.Core.Data
{
    public class Test : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}

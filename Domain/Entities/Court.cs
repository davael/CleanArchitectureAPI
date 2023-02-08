using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Court
    {
        public int CourtId { get; set; }
        public string CourtDes { get; set; }
        public bool Active { get; set; }
        public int ClubID { get; set; }
        public virtual Club Club { get; set; }
    }
}

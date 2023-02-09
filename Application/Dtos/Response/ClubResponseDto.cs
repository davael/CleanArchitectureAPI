using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Response
{
    public class ClubResponseDto
    {
        public int ClubID { get; set; }
        public string ClubDes { get; set; }
        public bool Active { get; set; }
    }
}

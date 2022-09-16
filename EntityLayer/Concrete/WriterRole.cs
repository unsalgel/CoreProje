using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //bu tablo AspNetUsers tablosuyla birleştirildi

    public class WriterRole:IdentityRole<int>
    {
    }
}

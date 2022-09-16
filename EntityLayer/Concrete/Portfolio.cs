using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string SmallImageURL { get; set; }
        public string BigImageURL { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

    }
}

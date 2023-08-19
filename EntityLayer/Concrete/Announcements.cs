using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Announcements
    {
        [Key]
        public int ID { get; set; }
        public string AnnouncementsTitle { get; set; }
        public string AnnouncementsContent { get; set; }
        public DateTime Date { get; set; }
    }
}

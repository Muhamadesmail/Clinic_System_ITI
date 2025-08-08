using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.FeedBackVM
{
   public class GetAllFeedbacksVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NextGen_Technology.Models
{
    public class Query
    {


        [StringLength(20,MinimumLength = 3)]
        public string firstName { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string lastName { get; set; }
        
       
        public string country { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string city { get; set; }

        
        public string phone { get; set; }

      
        public string email { get; set; }

        [StringLength(2000, MinimumLength = 10)]
        public string description { get; set;}
        
        public DateTime? time { get; set; }
    }
}

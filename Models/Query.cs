using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NextGen_Technology.Models
{
    public class Query
    {
        [BindProperty]
        public string firstName {  get; set; }
        [BindProperty]
        
        public string lastName { get; set; }
        [BindProperty]
        
        public string country { get; set; }
        [BindProperty]
        
        public string city { get; set; }
        [BindProperty]
        
        public string phone { get; set; }
        [BindProperty]
        
        public string email { get; set; }
        [BindProperty]
        
        public string description { get; set;}
        [BindProperty]
        public DateTime time { get; set; }
    }
}

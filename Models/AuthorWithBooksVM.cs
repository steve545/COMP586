using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreAngCombinedNew.Models
{
    public class AuthorWithBooksVM
    {
        [Display(Name ="Author Name")]
        public string AuthorName { get; set; }

        [Display(Name="Book Name List")]
        public virtual ICollection<Books> BookNameList { get; set; }
        /*public List<string>*/
    }
}

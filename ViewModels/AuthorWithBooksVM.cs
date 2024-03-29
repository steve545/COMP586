﻿using CoreAngCombinedNew.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreAngCombinedNew.ViewModels
{
    public class AuthorWithBooksVM
    {
        [Display(Name ="Author Name")]
        public string AuthorName { get; set; }

        [Display(Name="Book Name List")]
        public List<string> BookNameList { get; set; }
    }
}

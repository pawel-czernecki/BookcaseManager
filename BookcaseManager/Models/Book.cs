//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookcaseManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        [Range(1,10)]
        public Nullable<short> rating { get; set; }
        public string ISBN { get; set; }
        public string genre { get; set; }
        public string readBy { get; set; }
        public string note { get; set; }
        public int id { get; set; }
    }
}
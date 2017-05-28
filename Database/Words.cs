namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Words
    {
        public Words()
        {

        }
        public int Id { get; set; }

        [StringLength(255)]
        public string PolishValue { get; set; }

        [StringLength(255)]
        public string EnglishValue { get; set; }
    }
}

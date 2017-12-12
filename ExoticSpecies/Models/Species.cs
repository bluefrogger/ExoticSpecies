/*
    Author: Alex Yoo
    Content: Names and introduced dates of each species
    Usage: constructor
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExoticSpeciesOfTheNorth.Models
{
    public class Species
    {
        public int SpeciesId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesName { get; set; }

        [Display(Name = "Date Introduced")]
        public DateTime DateIntroduced { get; set; }

        public int HomelandId { get; set; }
        public virtual Homeland SpeciesHomeland { get; set; }
    }
}
/*
    Author: Alex Yoo
    Content: Original homelands of exotic species.
    Usage: constructor
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExoticSpeciesOfTheNorth.Models
{
    public class Homeland
    {
        public int HomelandId { get; set; }

        [Display(Name = "Homeland Name")]
        public string HomelandName { get; set; }

        public virtual List<Species> HomelandSpecies { get; set; }
    }
}
/*
    Author: Alex Yoo
    Content: Database context repository. See web.config for connection string.
    Usage: constructor
*/
using ExoticSpeciesOfTheNorth.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExoticSpeciesOfTheNorth.Models
{
    public class ExoticSpeciesDbContext : DbContext
    {
        public ExoticSpeciesDbContext() :
            base(RdsHelper.GetRdsConnStr())
        {

        }

        public DbSet<Species> MySpecies { get; set; }
        public DbSet<Homeland> MyHomelands { get; set; }
    }
}
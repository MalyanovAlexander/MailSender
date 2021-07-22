﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest2.Data
{
    public class SongsDB : DbContext
    {
        public DbSet<Track> Tracks { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }

    [Table("Track")]
    public class Track
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        public int Length { get; set; }
    }

    public class Artist
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }
    }
}

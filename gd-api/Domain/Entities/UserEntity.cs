﻿using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Entities
{
    public class UserEntity : EntityBase
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }
}

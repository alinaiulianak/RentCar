﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    class Users
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public Roles RoleID { get; set; }
    }
}

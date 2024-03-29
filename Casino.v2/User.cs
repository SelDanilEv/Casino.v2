﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.v2
{
    [Serializable]
    public class User
    {
        public User(string name,string password,int cash)
        {
            Name = name;
            Password = password;
            Cash = cash;
        }

        public User() { CorrectTransition = false; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Rate { get; set; }
        public int Cash { get; set; }
        public bool CorrectTransition { get; set; }
        public TypeRate TypeOfRate { get; set; }

        public enum TypeRate : int
        {
            noth = 0,
            zero,
            color,
            sector
        }
    }
}

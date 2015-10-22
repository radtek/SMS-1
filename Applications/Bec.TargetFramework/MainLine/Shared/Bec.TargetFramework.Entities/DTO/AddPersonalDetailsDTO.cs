﻿using System;

namespace Bec.TargetFramework.Entities
{
    public class AddPersonalDetailsDTO
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostalCode { get; set; }
        public bool Manual { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
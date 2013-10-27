using System;
using System.Collections.Generic;

namespace CSharp.CodeSchool.Api.Models
{
    public class Account : CodeSchoolBase
    {
        public User user { get; set; }
        public Courses courses { get; set; }
        public List<Badge> badges { get; set; }
    }
}

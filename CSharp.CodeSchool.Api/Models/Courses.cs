using System;
using System.Collections.Generic;

namespace CSharp.CodeSchool.Api.Models
{
    public class Courses
    {
        public List<Course> completed { get; set; }
        public List<Course> in_progress { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CollegeManagement.API.Entities;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public int? CollegeId { get; set; }
}

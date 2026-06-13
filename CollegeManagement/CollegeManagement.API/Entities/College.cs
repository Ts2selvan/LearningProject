using System;
using System.Collections.Generic;

namespace CollegeManagement.API.Entities;

public partial class College
{
    public int CollegeId { get; set; }

    public string? CollegeName { get; set; }

    public string? City { get; set; }

    public string? StateName { get; set; }
}

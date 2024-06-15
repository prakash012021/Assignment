﻿using System.ComponentModel.DataAnnotations;

namespace Assignment_iVally.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }       
        public string? FirstName { get; set; }       
        public string? LastName { get; set; }       
        public string? City { get; set; }       
        public string? Zip { get; set; }       
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models;
public class Expense
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Description { get; set; } = null!;

    [Required, Range(0.01,double.MaxValue, ErrorMessage = "Amount need Can't be Negative")]
    public double Amount { get; set; }

    [Required]
    public string Category { get; set; } = null!;

    public DateTime Date { get; set; } = DateTime.Now;


}

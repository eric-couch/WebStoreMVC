using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebStoreMVC.Models;

public partial class Customer
{
    [Key]
    public int Id { get; set; }
    [Display(Name ="First Name")]
    [Required(ErrorMessage = "First Name is required")]
    [StringLength(50)]
    [MinLength(4, ErrorMessage = "This Name is too short.")]
    public string FirstName { get; set; } = null!;
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;
    [Display(Name = "Customer Address")]
    public string? Address { get; set; }
    [Display(Name = "Phone Number")]
    [Phone(ErrorMessage ="You don't know your own phone number?")]
    public string? Phone { get; set; }
    [Display(Name = "Email Address")]
    [EmailAddress]
    public string? Email { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}

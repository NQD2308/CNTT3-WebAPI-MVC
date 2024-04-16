using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Serminar_WebApi_MVC.Models;

public partial class Product
{
    public int Id { get; set; }

    [Required]
    [DisplayName("Product Name")]
    public string? Product1 { get; set; }

    [Required]
    public string? Img { get; set; }

    [Required]
    public decimal? Price { get; set; }
}

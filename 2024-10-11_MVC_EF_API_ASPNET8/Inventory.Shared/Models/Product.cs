﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq; // TODO
using MathNet.Numerics;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Shared.Models;

[Table("Product")]

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(255)]
    public string Name { get; set; } = null!;

    [StringLength(255)]
    public string? Description { get; set; }

    //[Precision(10, 2)]
    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Products")]
    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    public String Slug => Name.Replace(" ", "-").ToLower();
}
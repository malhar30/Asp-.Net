﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Models
{
    [Table("orders")]
    [Index(nameof(CustomerId), Name = "customer_id")]
    [Index(nameof(CustomerId), Name = "customers_orders")]
    [Index(nameof(EmployeeId), Name = "employee_id")]
    [Index(nameof(EmployeeId), Name = "employees_orders")]
    [Index(nameof(OrderDate), Name = "order_date")]
    [Index(nameof(ShipPostalCode), Name = "ship_postal_code")]
    [Index(nameof(ShippedDate), Name = "shipped_date")]
    [Index(nameof(ShipVia), Name = "shippers_orders")]
    public partial class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("customer_id")]
        [StringLength(5)]
        public string? CustomerId { get; set; }
        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        [Column("order_date", TypeName = "datetime")]
        [Display(Name ="Ordered")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        [Column("required_date", TypeName = "datetime")]
        public DateTime? RequiredDate { get; set; }
        [Column("shipped_date", TypeName = "datetime")]
        [Display(Name = "Shipped")]
        [DataType(DataType.Date)]
        public DateTime? ShippedDate { get; set; }
        [Column("ship_via")]
        [Display(Name = "Shipper")]
        public int? ShipVia { get; set; }
        [Column("freight", TypeName = "money")]
        [Display(Name = "Frieght")]
        public decimal? Freight { get; set; }
        [Column("ship_name")]
        [StringLength(40)]
        [Display(Name = "Ship Name")]
        public string? ShipName { get; set; }
        [Column("ship_address")]
        [StringLength(60)]
        public string? ShipAddress { get; set; }
        [Column("ship_city")]
        [StringLength(15)]
        public string? ShipCity { get; set; }
        [Column("ship_region")]
        [StringLength(15)]
        [Display(Name = "Region")]
        public string? ShipRegion { get; set; }
        [Column("ship_postal_code")]
        [StringLength(10)]
        public string? ShipPostalCode { get; set; }
        [Column("ship_country")]
        [StringLength(15)]
        [Display(Name = "Country")]
        public string? ShipCountry { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Orders")]
        public virtual Employee? Employee { get; set; }
        [ForeignKey(nameof(ShipVia))]
        [InverseProperty(nameof(Shipper.Orders))]
        public virtual Shipper? ShipViaNavigation { get; set; }
    }
}

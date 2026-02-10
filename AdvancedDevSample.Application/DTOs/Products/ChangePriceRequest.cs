using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvancedDevSample.Application.DTOs.Products
{
    public class ChangePriceRequest
    {
        [Required]

        [Range(0.01, double.MaxValue)]

        public decimal NewPrice { get; set; }

    }
}

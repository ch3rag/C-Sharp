using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarLotMVC.AutoLotDALEF.Models.Metadata {
    public class InventoryMetadata {
        [Display(Name = "Pet Name")]
        [StringLength(50, ErrorMessage = "Please Enter A Value Less Than 50 Characters Long.")]
        public string PetName { get; set; }
    }
}
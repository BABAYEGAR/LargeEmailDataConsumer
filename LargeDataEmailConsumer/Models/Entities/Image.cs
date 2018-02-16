﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LargeDataEmailConsumer.Models.Services;

namespace LargeDataEmailConsumer.Models.Entities
{
    public class Image : Transport
    {
        public long ImageId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Theme { get; set; }
        [Required]
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        [Display(Name = "Camera")]
        public long? CameraId { get; set; }
        [ForeignKey("CameraId")]
        public Camera Camera { get; set; }
        [Display(Name = "Location")]
        public long? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        [Display(Name = "Selling Price")]
        [Required]
        [Currency.MinDecimalValueAttribute(1000.00)]
        [Currency.MaxDecimalValueAttribute(500000.00)]
        [DefaultValue("0")]
        public long? SellingPrice { get; set; }
        [Currency.MinDecimalValueAttribute(0.01)]
        [Currency.MaxDecimalValueAttribute(100.00)]
        [DefaultValue("0")]
        public long? Discount { get; set; }
        public bool? Featured { get; set; }
        public string Inspiration { get; set; }
        [Display(Name = "Sub-Category/Sub-Genre")]
        public long? ImageSubCategoryId { get; set; }
        [ForeignKey("ImageSubCategoryId")]
        public ImageSubCategory ImageSubCategory { get; set; }
        [Required]
        [Display(Name = "Category/Genre")]
        public long? ImageCategoryId { get; set; }
        [ForeignKey("ImageCategoryId")]
        public ImageCategory ImageCategory { get; set; }
        public long? AppUserId { get; set; }
        public string Status { get; set; }
        [Display(Name = "Upload Category")]
        public string UploadCategory { get; set; }
        public string Tags { get; set; }
        [Display(Name = "A1")]
        public bool A1 { get; set; }
        [Display(Name = "A2")]
        public bool A2 { get; set; }
        [Display(Name = "A3")]
        public bool A3 { get; set; }
        [Display(Name = "A4")]
        public bool A4 { get; set; }
        [Display(Name = "A5")]
        public bool A5 { get; set; }
        [Display(Name = "A6")]
        public bool A6 { get; set; }
        public IEnumerable<ImageTag> ImageTags { get; set; }
        public IEnumerable<ImageComment> ImageComments { get; set; }
        public IEnumerable<ImageAction> ImageActions { get; set; }
        public IEnumerable<ImageReport> ImageReports { get; set; }
    }
}

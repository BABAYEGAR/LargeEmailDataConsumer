﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LargeDataEmailConsumer.Models.Entities
{
    public class Camera : Transport
    {
        public long CameraId { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DTOModels {
    public class ItemCreateDTO {
        [Required, MinLength(3, ErrorMessage = "Minimum allowed title length is 3 characters.")]
        [MaxLength(30, ErrorMessage = "Maximum allowed title length is 30 characters.")]
        public string Title { get; set; } = string.Empty;
        public Guid StorageId { get; set; } = Guid.Empty;
        public Guid ImageId { get; set; } = Guid.Empty;
        [Required]
        public ImageDTO Image { get; set; } = new ImageDTO();
        public string? SerialNumber { get; set; }
        public string? Classification { get; set; }
        public string? ItemOwner { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Weight should be positive number.")]
        public double? Weight { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Length should be positive number.")]
        public double? Length { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Width should be positive number.")]
        public double? Width { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Height should be positive number.")]
        public double? Height { get; set; }

        public ItemCreateDTO() { }
        public ItemCreateDTO(ItemDTO item) {
            Title = item.Title;
            StorageId = item.StorageId;
            ImageId = item.ImageId;
            Image = item.Image;
            SerialNumber = item.SerialNumber;
            Classification = item.Classification;
            ItemOwner = item.ItemOwner;
            Weight = item.Weight;
            Length = item.Length;
            Width = item.Width;
            Height = item.Height;
        }
    }
}

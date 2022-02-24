namespace DTOModels {
    public class ItemDTO {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public Guid StorageId { get; set; } = Guid.Empty;
        public StorageDTO? ParentStorage { get; set; }
        public Guid ImageId { get; set; } = Guid.Empty;
        public ImageDTO Image { get; set; } = new ImageDTO();
        public string? SerialNumber { get; set; }
        public string? Classification { get; set; }
        public string? ItemOwner { get; set; }
        public double? Weight { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
    }
}

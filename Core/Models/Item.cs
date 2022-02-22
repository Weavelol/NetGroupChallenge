namespace Core.Models {
    public class Item : AbstractModel {
        public Guid StorageId { get; set; }
        public Storage ParentStorage { get; set; }
        public Guid ImageId { get; set; }
        public ItemImage? Image { get; set; }
        public string? SerialNumber { get; set; }
        public string? Classification { get; set; }
        public string? ItemOwner { get; set; }
        public double? Weight { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
    }
}

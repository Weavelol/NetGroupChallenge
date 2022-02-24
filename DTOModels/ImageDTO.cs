namespace DTOModels {
    public class ImageDTO {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public byte[] ImageData { get; set; } = Array.Empty<byte>();
    }
}

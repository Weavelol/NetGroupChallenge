namespace DTOModels {
    public class StorageCreateDTO {
        public string Title { get; set; } = string.Empty;
        public Guid? ParentStorageId { get; set; }
        public string OwnerId { get; set; } = string.Empty;
        public string StoragePath { get; set; } = string.Empty;
    }
}

namespace DTOModels {
    public class StorageDTO {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public Guid? ParentStorageId { get; set; }
        public StorageDTO? ParentStorage { get; set; }
        public List<StorageDTO>? NestedStorages { get; set; }
        public List<ItemDTO>? NestedItems { get; set; }
        public string OwnerId { get; set; } = string.Empty;
        public string StoragePath { get; set; } = string.Empty;
    }
}

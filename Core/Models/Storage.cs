namespace Core.Models {
    public class Storage : AbstractModel {
        public Guid? ParentStorageId { get; set; }
        public Storage? ParentStorage { get; set; }
        public List<Storage> NestedStorages { get; set; }
        public string OwnerId { get; set; }
        public string StoragePath { get; set; }
    }
}

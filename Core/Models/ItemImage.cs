namespace Core.Models {
    public class ItemImage : AbstractModel{
        public byte[] ImageData { get; set; }
        public List<ItemImage> ForeignImages { get; set; }
    }
}

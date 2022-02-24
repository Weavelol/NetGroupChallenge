using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models {
    public class ItemImage {
        [ForeignKey("Item")]
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public byte[] ImageData { get; set; } = Array.Empty<byte>();
        public virtual Item? Item { get; set; }
    }
}

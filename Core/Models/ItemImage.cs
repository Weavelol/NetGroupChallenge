using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models {
    public class ItemImage {

        [ForeignKey("Item")]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }

        public virtual Item? Item { get; set; }

        public ItemImage() {
            Id = Guid.Empty;
        }
    }
}

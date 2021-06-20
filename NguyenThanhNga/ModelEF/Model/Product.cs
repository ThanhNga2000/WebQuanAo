namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }
        [DisplayName("Tên SP")]
        [Required(ErrorMessage = "Bạn chưa nhập tên sản phẩm")]
        public string Name { get; set; }
        [DisplayName("Gía bán")]
        [Required(ErrorMessage = "Bạn chưa nhập giá bán")]
        public int UnitCost { get; set; }
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng ")]
        public int? Quantity { get; set; }
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }
        [DisplayName("Mô tả")]
        public string Description { get; set; }
        [DisplayName("Trạng thái")]
        public bool? Status { get; set; }
        [DisplayName("Loại SP")]
        [StringLength(10)]
        public string CategoryID { get; set; }
    }
}

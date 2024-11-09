public abstract class SanPham
{
    public static int idSanPham = 1;
    public int MaSanPham { get; set; }
    public string? TenSanPham { get; set; }
    public double GiaGoc { get; set; } = 0;
    public virtual void NhapThongTin()
    {
        MaSanPham = idSanPham;
        Console.WriteLine("Nhập tên sản phẩm: ");
        TenSanPham = Console.ReadLine();
        Console.WriteLine("Nhập giá gốc");
        GiaGoc = Convert.ToDouble(Console.ReadLine());
        idSanPham++;
    }

    // Phương thức trừu tượng để tính giá bán
    public abstract double TinhGiaBan();
    public virtual void HienThiThongTin()
    {
        Console.Write(@$"
            Mã: {MaSanPham} - Tên: {TenSanPham} - Giá bán: {TinhGiaBan()}$
        ");
    }


}
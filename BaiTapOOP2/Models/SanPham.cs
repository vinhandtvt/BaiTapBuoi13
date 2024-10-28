using System.Data;

class SanPham
{
    public static int idSanPham = 1;
    public int MaSanPham { get; set; }
    public string TenSanPham { get; set; } = "";
    public double GiaBan { get; set; }
    public int SoLuongTonKho { get; set; }

    public void NhapThongTin()
    {
        MaSanPham = idSanPham;
        Console.WriteLine("Nhập vào tên sản phẩm: ");
        TenSanPham = Console.ReadLine();
        Console.WriteLine("Nhập giá bán:");
        GiaBan = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Nhập số lượng hàng tồn kho: ");
        SoLuongTonKho = Convert.ToInt32(Console.ReadLine());

        idSanPham++;
    }

    public void XuatThongTin()
    {
        Console.WriteLine(@$"
            ---------Thông tin sản phẩm----------
            Mã số: {MaSanPham}
            Tên sản phẩm: {TenSanPham}
            Giá bán: {GiaBan}
            Số lượng tồn kho: {SoLuongTonKho}
        ");
    }

}
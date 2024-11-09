class ThucPham : SanPham
{
    public double PhiVanChuyen;

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.WriteLine("Nhập phí vẩn chuyển ($)");
        PhiVanChuyen = Convert.ToDouble(Console.ReadLine());
    }
    public override double TinhGiaBan()
    {
        // Cộng thêm phí vận chuyển vào giá gốc
        return GiaGoc + PhiVanChuyen;
    }
}
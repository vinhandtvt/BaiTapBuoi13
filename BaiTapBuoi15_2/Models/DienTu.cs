class DienTu : SanPham
{
    public double ThueBaoHanh;
    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.WriteLine("Nhập thuế bảo hành (%)");
        ThueBaoHanh = Convert.ToDouble(Console.ReadLine());
    }
    public override double TinhGiaBan()
    {
        // Thuế bảo hành bằng 10% giá
        return GiaGoc + (GiaGoc / 100) * ThueBaoHanh;
    }
}
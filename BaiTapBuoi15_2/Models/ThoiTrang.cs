class ThoiTrang : SanPham
{
    public double PhanTramGiamGia;

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.WriteLine("Nhập giảm giá (%): ");
        PhanTramGiamGia = Convert.ToDouble(Console.ReadLine());
    }
    public override double TinhGiaBan()
    {
        return GiaGoc - (GiaGoc / 100) * PhanTramGiamGia;
    }

}
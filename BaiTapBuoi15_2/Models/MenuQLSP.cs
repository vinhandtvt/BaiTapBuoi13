class MenuQLSP
{
    public List<SanPham> lstSanPham { get; set; } = new List<SanPham>();

    public int Chon { get; set; }
    public void HienThiMenuChucNang()
    {
        Console.WriteLine(@"
            ---Hệ thống quản lý bán hàng---
            1/ Thêm sản phẩm.
            2/ Hiện thị danh sách sản phẩm
            3/ Tính tổng doanh thu
            4/ Xóa sản phẩm
            5/ Thoát
        ");
    }

    // Thêm sản phẩm
    public void ThemSanPham()
    {
        Console.WriteLine(@$"
            Chon thêm sản phẩm:
            1/ Điện tử
            2/ Thời trang
            3/ Thực phẩm
        ");
        int sp = Convert.ToInt32(Console.ReadLine());
        if (sp == 1)
        {
            DienTu spMoi = new DienTu();
            spMoi.NhapThongTin();
            this.lstSanPham.Add(spMoi);
        }
        if (sp == 2)
        {
            ThoiTrang spMoi = new ThoiTrang();
            spMoi.NhapThongTin();
            this.lstSanPham.Add(spMoi);

        }
        if (sp == 3)
        {
            ThucPham spMoi = new ThucPham();
            spMoi.NhapThongTin();
            this.lstSanPham.Add(spMoi);
        }
    }
    // Hiện thị danh sách sản phẩm
    public void HienThiDanhSachSanPham()
    {
        foreach (SanPham sp in this.lstSanPham)
        {
            sp.HienThiThongTin();
        }
    }
    // Tính tổng doanh thu
    public void TinhTongDoanhThu()
    {
        double DoanhThu = 0;
        foreach (SanPham sp in this.lstSanPham)
        {
            DoanhThu += sp.TinhGiaBan();
        }

        Console.WriteLine($"Doanh thu là: {DoanhThu}$");
    }

    // Xóa sản phẩm
    public void XoaSanPham()
    {
        Console.WriteLine("Hãy nhập mã sp cần xóa");
        int maXoa = Convert.ToInt32(Console.ReadLine());
        SanPham spXoa = this.lstSanPham.Find(sp => sp.MaSanPham == maXoa);

        if (spXoa != null)
        {
            this.lstSanPham.Remove(spXoa);
        }

    }
    public void Thoat()
    {
        Chon = 5;
    }
}
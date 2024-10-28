using System.Text.Json;

class MenuQLSP
{
    public List<SanPham>? DSSP = new List<SanPham>();
    public int Chon { get; set; }
    public void HienThiChucNang()
    {
        Console.WriteLine(@"
            1/ Thêm sản phẩm.
            2/ Tìm kiếm học sinh theo tên
            3/ Cập nhật giá bán hoặc số lượng hàng tồn kho
            4/ Tính tổng giá trị kho hàng
            5/ Xóa sản phẩm
            6/ Hiện thị danh sách sản phẩm cùng tổng giá trị kho hàng
            7/ Hiện thị danh sách sản phẩm theo giá bán tăng dần 
            8/ Hiện thị danh sách sản phẩm theo giá bán từ thấp đến cao
            9/ Hiện thị sản phảm theo tên
            10/ Hiện thị danh sách sản phẩm theo tên (ký tự cuối)
            11/ Lưu dữ liệu vào file json
            12/ Đọc dữ liệu vào file json
            13/ Hiện thị
            14/ Thoát
        ");
    }

    //1. Thêm sản phẩm
    public void ThemSanPham()
    {
        SanPham sp = new SanPham();
        sp.NhapThongTin();

        DSSP.Add(sp);
    }

    // 2. Tìm kiếm thông tin sản phẩm theo tên
    public void TimKiemTheoTenSanPham()
    {
        Console.WriteLine("Nhập tên sạn phẩm cần tìm: ");
        string? keyword = Console.ReadLine()?.ToLower();

        List<SanPham> lstSanPham = this.DSSP.Where(sp => sp.TenSanPham.ToLower().Contains(keyword)).ToList();

        if (lstSanPham.Count > 0)
        {
            Console.WriteLine($"Tìm thấy {lstSanPham.Count} có tên chứa từ khóa: {keyword}");
            foreach (SanPham sp in lstSanPham)
            {
                sp.XuatThongTin();
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy!");
        }
    }

    // 3. Cập nhật giá bán hoặc số lượng hàng tồn kho
    public void CapNhatGiaBanORHangTonKho()
    {
        Console.WriteLine("Nhập mã sản phậm: ");
        int MaSanPhamMoi = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhập giá bán mới: ");
        double GiaBanMoi = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Nhập số lượng hàng tồn kho mới: ");
        int SoLuongTonKhoMoi = Convert.ToInt32(Console.ReadLine());

        SanPham? sp = this.DSSP?.Find(sp => sp.MaSanPham == MaSanPhamMoi);

        if (sp != null)
        {
            sp.GiaBan = GiaBanMoi;
            sp.SoLuongTonKho = SoLuongTonKhoMoi;
        }
        else
        {
            Console.WriteLine($"Không tìm thấy sản phẩm có mã: {MaSanPhamMoi}");
        }
    }
    // 4. Tính tổng giá trị kho hàng
    public void TinhTongGiaTriKhoHang()
    {
        Double Tong = 0;
        foreach (SanPham sp in this.DSSP)
        {
            Tong += sp.GiaBan * sp.SoLuongTonKho;
        }

        Console.WriteLine($"Tông giá trị kho hàng: {Tong}");
    }
    // 5. Xóa sản phẩm
    public void XoaSanPham()
    {
        Console.WriteLine("Nhập mã sản phẩm cần xóa: ");
        int MaSanPhamXoa = Convert.ToInt32(Console.ReadLine());

        SanPham? sp = this.DSSP?.Find(sp => sp.MaSanPham == MaSanPhamXoa);

        if (sp != null)
        {
            this.DSSP.Remove(sp);
        }
    }

    // 6. Hiện thị danh sách sản phẩm cùng tổng giá trị kho hàng
    public void HienThiDanhSachSanPhamCungTongGiaTriKhoHang()
    {
        Console.WriteLine("------DANH SÁCH SẢN PHẨM------");
        foreach (SanPham sp in this.DSSP)
        {
            sp.XuatThongTin();
        }
        Console.WriteLine("------TỔNG GIÁ TRỊ KHO HÀNG------");

        this.TinhTongGiaTriKhoHang();
    }

    //7. Hiện thị danh sách sản phẩm theo giá bán tăng dần 
    // 8. Hiện thị danh sách sản phẩm theo giá bán từ thấp đến cao
    public void HienThiDanhSachSanPhamGiaBanTangDan()
    {
        foreach (SanPham sp in DSSP.OrderBy(sp => sp.GiaBan))
        {
            sp.XuatThongTin();
        }
    }

    // 9. Hiện thị danh sách sản phẩm theo tên
    public void HienThiDanhSachSanPhamTheoTen()
    {
        List<SanPham> DSSPMOI = this.DSSP.OrderBy(sp => sp.TenSanPham).ToList();
        foreach (SanPham sp in DSSPMOI)
        {
            sp.XuatThongTin();
        }
    }

    // 10. Hiện thị danh sách sản phẩm theo tên (ký tự cuối)
    public void HienThiDanhSachSanPhamTheoTenCuoi()
    {
        List<SanPham> DSSPMOI = this.DSSP.OrderBy(hs => hs.TenSanPham.Split(' ').Last()).ToList();
        foreach (SanPham sp in DSSPMOI)
        {
            sp.XuatThongTin();
        }
    }

    // 11. Lưu dữ liệu vào file json
    public async void LuuDSSP()
    {
        // Đưa dữ liệu object ---> json string
        string sDSSP = JsonSerializer.Serialize(this.DSSP);
        // Lưu dữ liệu string danh sách học sinh vào file
        await File.WriteAllTextAsync("DSSP.json", sDSSP);
    }
    // 12. Đọc dữ liệu vào file json
    public async void LoadDSSP()
    {
        // Đọc text (string) tù file json
        string strDSSP = await File.ReadAllTextAsync("./DSSP.json");
        // Chuyển đổi text thành object theo định dạng mong muốn
        this.DSSP = JsonSerializer.Deserialize<List<SanPham>>(strDSSP);
    }
    //19.
    public void HienThiSanPham()
    {
        foreach (SanPham sp in this.DSSP)
        {
            sp.XuatThongTin();
        }
    }
    public void Thoat()
    {
        this.Chon = 14;
    }
}
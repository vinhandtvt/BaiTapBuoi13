using System.Text.Json;
class MenuQLHS
{
    public List<HocSinh>? DSHS = new List<HocSinh>();
    public int Chon { get; set; }
    public void HienThiChucNang()
    {
        Console.WriteLine(@"
            1/ Thêm học viên.
            2/ Tìm kiếm theo tên sản phẩm
            3/ Cập nhật điểm số học sinh
            4/ Tính điểm trung bình
            5/ Xóa học sinh
            6/ Hiện thị danh sách học sinh kèm điểm trung bình
            7/ Hiện thị danh sách học sinh theo điểm TB tăng dần 
            8/ Hiện thị danh sách học sinh theo tên 
            9/ Lưu dữ liệu vào file json
            10/ Đọc dữ liệu từ file json
            11/ Thoát
        ");
    }

    //1. Thêm học viên
    public void ThemHocSinh()
    {
        //Tạo ra 1 học sinh mới
        HocSinh HocSinhMoi = new HocSinh();
        // Nhập thông tin học sinh
        HocSinhMoi.NhapThongTin();
        // Thêm học sinh vào danh sách
        DSHS.Add(HocSinhMoi);

    }

    // 2. Tìm kiếm thông tin học viên theo tên
    public void TimKiemHocSinhTheoTen()
    {
        Console.WriteLine("Nhập tên học sinh cần tìm: ");
        string? keyword = Console.ReadLine()?.ToLower();

        List<HocSinh> lstHocSinh = this.DSHS.Where(hs => hs.TenHocSinh.ToLower().Contains(keyword)).ToList();

        if (lstHocSinh.Count > 0)
        {
            Console.WriteLine($"Tìm thấy {lstHocSinh.Count} có tên chứa từ khóa: {keyword}");
            foreach (HocSinh hs in lstHocSinh)
            {
                hs.XuatThongTin();
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy!");
        }
    }

    // 3. Chức năng cập nhật điểm số học sinh
    public void CapNhatDiemSoHocSinh()
    {
        Console.WriteLine("Nhập mã học sinh: ");
        int MaHocSinhMoi = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhập điểm toán: ");
        double DiemToanMoi = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Nhập điểm văn: ");
        double DiemVanMoi = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Nhập điểm anh: ");
        double DiemAnhMoi = Convert.ToDouble(Console.ReadLine());

        HocSinh? hs = this.DSHS?.Find(hs => hs.MaHocSinh == MaHocSinhMoi);

        if (hs != null)
        {
            hs.DiemToan = DiemToanMoi;
            hs.DiemVan = DiemVanMoi;
            hs.DiemAnh = DiemAnhMoi;
        }
        else
        {
            Console.WriteLine($"Không tìm thấy học sinh có mã: {MaHocSinhMoi}");
        }
    }

    // 4. Tính điểm trung bình và xếp loại
    public void TinhDiemTrungBinhVaXepLoai()
    {
        foreach (HocSinh hs in this.DSHS)
        {
            hs.XuatThongTin();
        }
    }

    // 5. Xóa học sinh khỏi danh sách
    public void XoaHocSinh()
    {
        Console.WriteLine("Nhập mã học sinh cần xóa: ");
        int MaHocSinhXoa = Convert.ToInt32(Console.ReadLine());

        HocSinh? hs = this.DSHS?.Find(hs => hs.MaHocSinh == MaHocSinhXoa);

        if (hs != null)
        {
            this.DSHS.Remove(hs);
        }
    }
    // 6. Hiện thị danh sách học sinh
    public void HienThiDanhSachHocSinh()
    {
        foreach (HocSinh hs in DSHS)
        {
            hs.XuatThongTin();
        }
    }
    // 7. Hiện thị danh sách học sinh
    public void HienThiDanhSachHocSinhTangDan()
    {
        foreach (HocSinh hs in DSHS.OrderBy(hs => hs.TinhDiemTrungBinh()))
        {
            hs.XuatThongTin();
        }
    }
    // 8. Hiện thị danh sách học sinh theo tên
    public void HienThiDanhSachHocSinhTheoTen()
    {
        List<HocSinh> DSHSMOI = this.DSHS.OrderBy(hs => hs.TenHocSinh.Split(' ').Last()).ToList();
        foreach (HocSinh hs in DSHSMOI)
        {
            hs.XuatThongTin();
        }
    }
    // 9. Lưu dữ liệu vào file json
    public async void LuuDSHS()
    {
        // Đưa dữ liệu object ---> json string
        string sDSHS = JsonSerializer.Serialize(this.DSHS);
        // Lưu dữ liệu string danh sách học sinh vào file
        await File.WriteAllTextAsync("DSHS.json", sDSHS);
    }
    // 10. Đọc dữ liệu vào file json
    public async void LoadDSHS()
    {
        // Đọc text (string) tù file json
        string strDSHS = await File.ReadAllTextAsync("./DSHS.json");
        // Chuyển đổi text thành object theo định dạng mong muốn
        this.DSHS = JsonSerializer.Deserialize<List<HocSinh>>(strDSHS);
    }

    // 11. Thoát
    public void Thoat()
    {
        this.Chon = 11;
    }
}
using System.Data;

class HocSinh
{
    public static int idHocSinh = 1;
    public int MaHocSinh { get; set; }
    public string TenHocSinh { get; set; } = "";
    public double DiemToan { get; set; }
    public double DiemVan { get; set; }
    public double DiemAnh { get; set; }

    public void NhapThongTin()
    {
        MaHocSinh = idHocSinh;
        Console.WriteLine("Nhập vào họ tên: ");
        TenHocSinh = Console.ReadLine();
        Console.WriteLine("Nhập điểm toán:");
        DiemToan = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Nhập điểm văn: ");
        DiemVan = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Nhập điểm anh: ");
        DiemAnh = Convert.ToDouble(Console.ReadLine());
        idHocSinh++;
    }

    public void XuatThongTin()
    {
        Console.WriteLine(@$"
            ---------Thông tin học sinh----------
            Mã số: {MaHocSinh}
            Họ tên: {TenHocSinh}
            Điểm trung bình: {TinhDiemTrungBinh()}
            Học lực: {XepLoai()}
        ");
    }

    public double TinhDiemTrungBinh()
    {
        double DTB = (this.DiemToan + this.DiemVan + this.DiemAnh) / 3;
        return Math.Round(DTB, 2);
    }

    public string XepLoai()
    {
        string HocLuc = "";
        double DTB = TinhDiemTrungBinh();
        if (DTB >= 8)
        {
            HocLuc = "Giỏi";
        }
        else if (DTB >= 6.5)
        {
            HocLuc = "Khá";
        }
        else if (DTB >= 5)
        {
            HocLuc = "Trung Bình";
        }
        else
        {
            HocLuc = "Yếu";
        }
        return HocLuc;
    }

}
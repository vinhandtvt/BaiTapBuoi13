
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.Json;

public enum LoaiThanhToan
{
    TienMat = 1,
    The,
    Online,
}

class MenuThanhToan
{
    private readonly List<IThanhToan> _thanhToanMethods;
    private List<Log>? LichSuGiaoDich = new List<Log>();
    public double bill = 0;
    public MenuThanhToan(List<IThanhToan> thanhToanMethods)
    {
        _thanhToanMethods = thanhToanMethods;
        // this.LoadLSGD();
    }

    public int Chon { get; set; }
    public void HienThiChucNang()
    {
        Console.WriteLine(@"
            1/ Thanh toán bằng tiền mặt.
            2/ Thanh toán bằng thẻ.
            3/ Thanh toán online.
            4/ Xem lịch sử giao dịch.
            5/ Thoát.
        ");
    }

    public void ThanhToanTienMat()
    {
        Console.WriteLine("Menu thanh toán tiền mặt");
        bool result = _thanhToanMethods.Find(mt => mt.GetType().Name == "ThanhToanTienMat").ThanhToan();
        HienThiThongBao(result, "ThanhToanTienMat");
    }

    public void ThanhToanBangThe()
    {
        Console.WriteLine("Menu thanh toán bằng thẻ");
        bool result = _thanhToanMethods.Find(mt => mt.GetType().Name == "ThanhToanBangThe").ThanhToan();
        HienThiThongBao(result, "ThanhToanBangThe");
    }

    public void ThanhToanOnline()
    {
        Console.WriteLine("Menu thanh toán online");
        bool result = _thanhToanMethods.Find(mt => mt.GetType().Name == "ThanhToanOnline").ThanhToan();
        HienThiThongBao(result, "ThanhToanOnline");
    }

    public void XemLichSuGiaoDich()
    {
        for (int i = 0; i < this.LichSuGiaoDich?.Count; i++)
        {
            Log log = this.LichSuGiaoDich[i];
            Console.WriteLine($@"
                --------------------------
                {i + 1}.Loại: {log._type} ---Số tiền {log._soTien}$
                --------------------------
            ");
        }

    }

    public void NhapSoTien()
    {
        Console.WriteLine("Nhập số tiền cần thanh toán:");
        bill = Convert.ToDouble(Console.ReadLine());
    }

    private void HienThiThongBao(bool result, string type)
    {
        if (result)
        {
            Console.WriteLine($"Thanh toán thành công! Sô tiền {bill}$");
            GhiLichXuGiaoDich(type);
        }
        else
        {
            Console.WriteLine($"Thanh toán thất bại!");
        }
    }
    private async void GhiLichXuGiaoDich(string PhuongThucThanhToan)
    {
        // Log log = new Log(PhuongThucThanhToan, bill);
        Log log = new Log();
        log._type = PhuongThucThanhToan;
        log._soTien = this.bill;
        this.LichSuGiaoDich?.Add(log);
        // Đưa dữ liệu object ---> json string
        string LXGD = JsonSerializer.Serialize(this.LichSuGiaoDich);
        // Lưu dữ liệu string danh sách học sinh vào file
        await File.WriteAllTextAsync("LXGD.json", LXGD);
    }

    public async void LoadLSGD()
    {
        // Đọc text (string) tù file json
        string strLSGD = await File.ReadAllTextAsync("./LXGD.json");
        // Chuyển đổi text thành object theo định dạng mong muốn
        this.LichSuGiaoDich = JsonSerializer.Deserialize<List<Log>>(strLSGD);
    }
    public void Thoat()
    {
        this.Chon = 5;
    }

}
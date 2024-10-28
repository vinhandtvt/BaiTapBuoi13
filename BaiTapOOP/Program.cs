//1. Khỏi tạo menu
MenuQLHS menu = new MenuQLHS();

if (menu.DSHS.Count != 0)
{
    HocSinh.idHocSinh = menu.DSHS.Last().MaHocSinh + 1;
}

menu.HienThiChucNang();

while (true)
{
    Console.WriteLine("Hãy chọn chức năng: ");
    menu.Chon = Convert.ToInt32(Console.ReadLine());

    switch (menu.Chon)
    {
        case 1:
            {
                menu.ThemHocSinh();
            }; break;
        case 2:
            {
                menu.TimKiemHocSinhTheoTen();
            }; break;
        case 3:
            {
                menu.CapNhatDiemSoHocSinh();
            }; break;
        case 4:
            {
                menu.TinhDiemTrungBinhVaXepLoai();
            }; break;
        case 5:
            {
                menu.XoaHocSinh();
            }; break;
        case 6:
            {
                menu.HienThiDanhSachHocSinh();
            }; break;
        case 7:
            {
                menu.HienThiDanhSachHocSinhTangDan();
            }; break;
        case 8:
            {
                menu.HienThiDanhSachHocSinhTheoTen();
            }; break;
        case 9:
            {
                menu.LuuDSHS();
            }; break;
        case 10:
            {
                menu.LoadDSHS();
            }; break;
        case 11:
            {
                menu.Thoat();
            }; break;
    }

    if (menu.Chon == 11)
    {
        break;
    }

    menu.HienThiChucNang();
}
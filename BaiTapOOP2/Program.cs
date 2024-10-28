//1. Khỏi tạo menu
MenuQLSP menu = new MenuQLSP();

if (menu.DSSP.Count != 0)
{
    SanPham.idSanPham = menu.DSSP.Last().MaSanPham + 1;
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
                menu.ThemSanPham();
            }; break;
        case 2:
            {
                menu.TimKiemTheoTenSanPham();
            }; break;
        case 3:
            {
                menu.CapNhatGiaBanORHangTonKho();
            }; break;
        case 4:
            {
                menu.TinhTongGiaTriKhoHang();
            }; break;
        case 5:
            {
                menu.XoaSanPham();
            }; break;
        case 6:
            {
                menu.HienThiDanhSachSanPhamCungTongGiaTriKhoHang();
            }; break;
        case 7:
        case 8:
            {
                menu.HienThiDanhSachSanPhamGiaBanTangDan();
            }; break;
        case 9:
            {
                menu.HienThiDanhSachSanPhamTheoTen();
            }; break;
        case 10:
            {
                menu.HienThiDanhSachSanPhamTheoTenCuoi();
            }; break;
        case 11:
            {
                menu.LuuDSSP();
            }; break;
        case 12:
            {
                menu.LoadDSSP();
            }; break;
        case 13:
            {
                menu.HienThiSanPham();
            }; break;
        case 14:
            {
                menu.Thoat();
            }; break;
    }

    if (menu.Chon == 14)
    {
        break;
    }

    menu.HienThiChucNang();
}
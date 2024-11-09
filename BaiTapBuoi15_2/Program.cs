MenuQLSP menu = new MenuQLSP();


menu.HienThiMenuChucNang();


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
                menu.HienThiDanhSachSanPham();
            }; break;
        case 3:
            {
                menu.TinhTongDoanhThu();
            }; break;
        case 4:
            {
                menu.XoaSanPham();
            }; break;
        case 5:
            {
                menu.Thoat();
            }; break;

    }

    if (menu.Chon == 5)
    {
        break;
    }

    menu.HienThiMenuChucNang();
}
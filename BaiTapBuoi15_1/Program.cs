using Microsoft.Extensions.DependencyInjection;

var service = new ServiceCollection();

service.AddTransient<IThanhToan, ThanhToanTienMat>();
service.AddTransient<IThanhToan, ThanhToanBangThe>();
service.AddTransient<IThanhToan, ThanhToanOnline>();
var ServiceBuild = service.BuildServiceProvider();

MenuThanhToan menu = new MenuThanhToan(ServiceBuild.GetServices<IThanhToan>().ToList());

menu.HienThiChucNang();

while (true)
{
    Console.WriteLine("Hãy chọn chức năng: ");
    menu.Chon = Convert.ToInt32(Console.ReadLine());
    switch (menu.Chon)
    {
        case 1:
            {
                menu.NhapSoTien();
                menu.ThanhToanTienMat();
            }; break;
        case 2:
            {
                menu.NhapSoTien();
                menu.ThanhToanBangThe();
            }; break;
        case 3:
            {
                menu.NhapSoTien();
                menu.ThanhToanOnline();
            }; break;
        case 4:
            {
                menu.XemLichSuGiaoDich();
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

    menu.HienThiChucNang();
}



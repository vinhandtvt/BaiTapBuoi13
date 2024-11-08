// Bài tập
public interface IThanhToan
{
    bool ThanhToan();
}

public class ThanhToanTienMat : IThanhToan
{
    public bool ThanhToan()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("Xử lý thanh toán bằng tiền mặt");
        Console.WriteLine("==============================");
        return true;
    }
}

public class ThanhToanBangThe : IThanhToan
{
    public bool ThanhToan()
    {
        Console.WriteLine("Hãy nhập mã PIN: ");
        double? MaPIN = Convert.ToDouble(Console.ReadLine());
        if (MaPIN == null)
        {
            Console.WriteLine("==============================");
            Console.WriteLine("=====Mã PIN không hợp lệ!=====");
            Console.WriteLine("==============================");
            return false;
        }
        Console.WriteLine("Xử lý thanh toán bằng thẻ");
        return true;
    }
}

public class ThanhToanOnline : IThanhToan
{
    public bool ThanhToan()
    {
        Console.WriteLine("Hãy nhập mã OTP: ");
        double? MaOTP = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(MaOTP);
        if (MaOTP == null)
        {
            Console.WriteLine("==============================");
            Console.WriteLine("=====Mã OTP không hợp lệ!=====");
            Console.WriteLine("==============================");
            return false;
        }
        Console.WriteLine("Xủ lý thanh toán online");
        return true;
    }
}
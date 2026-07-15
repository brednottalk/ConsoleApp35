using System;
Console.OutputEncoding = System.Text.Encoding.UTF8;
int points = 1000;
int Wins = 0;
int Losses = 0;
int tienthanglonnhat = 0;

Menu:
Console.WriteLine("\n1. Số dư 2. Chơi 3. thống kê 4. thoát");
string choice = Console.ReadLine();
switch (choice)
{
    case "1": Console.WriteLine("Điểm hiện tại của bạn là {0}", points); goto Menu;
    case "2": goto Game;
    case "3": goto Thongke;
    case "4": goto Thoat;
    default: Console.WriteLine("Vui lòng chọn lại"); goto Menu;
}

Game:
if (points <= 0)
{
    Console.WriteLine("Bạn đã hết tiền! Trò chơi kết thúc.");
    goto Thoat;
}

string chosenanimal = null;
Console.WriteLine("\nVui lòng chọn linh vật của ban");
Console.WriteLine("1. Bầu  2. Cua  3. Tôm  4. Cá  5. Gà  6.Nai");
string linhvat = Console.ReadLine();
switch (linhvat)
{
    case "1": Console.WriteLine("Bạn đã chọn Bầu làm linh vật"); chosenanimal = "Bầu"; break;
    case "2": Console.WriteLine("Bạn đã chọn Cua làm linh vật"); chosenanimal = "Cua"; break;
    case "3": Console.WriteLine("Bạn đã chọn Tôm làm linh vật"); chosenanimal = "Tôm"; break;
    case "4": Console.WriteLine("Bạn đã chọn Cá làm linh vật"); chosenanimal = "Cá"; break;
    case "5": Console.WriteLine("Bạn đã chọn Gà làm linh vật"); chosenanimal = "Gà"; break;
    case "6": Console.WriteLine("Bạn đã chọn Nai làm linh vật"); chosenanimal = "Nai"; break;
    default: Console.WriteLine("Vui lòng chọn lại"); goto Menu;
}

int starting = int.Parse(linhvat);
Console.WriteLine("Bạn muốn cược bao nhiêu");
int tiencuoc = int.Parse(Console.ReadLine());

if (tiencuoc > points || tiencuoc <= 0)
{
    Console.WriteLine("Tiền cược không hợp lệ hoặc lớn hơn số dư!");
    goto Menu; 
}

points -= tiencuoc;
Random dice = new Random();
Console.WriteLine("--- Đang tung xúc xắc ---");

int totalwin = 0;
for (int i = 1; i <= 3; i++)
{
    int roll = dice.Next(1, 7);
    Console.WriteLine($"Xúc xắc {i}: [ {roll} ]");

    if (roll == starting)
    {
        Console.WriteLine($"Xúc xắc số {i} thắng");
        totalwin++;
    }
    else
    {
        Console.WriteLine($"Xúc xắc số {i} thua");
    }
}

if (totalwin > 0)
{
    Wins++;
    int tienthang = totalwin * tiencuoc;
    points += tiencuoc + tienthang; 
    Console.WriteLine($"-> Bạn thắng ván này! Nhận về {tienthang} điểm.");

    if (tienthang > tienthanglonnhat)
    {
        tienthanglonnhat = tienthang;
    }
}
else
{
    Losses++;
    Console.WriteLine("-> Bạn thua ván này!");
}

Console.WriteLine("----------------------");
goto Menu;

Thongke:
Console.WriteLine("\n--- THỐNG KÊ ---");
Console.WriteLine("số trận thắng của bạn là {0}", Wins);
Console.WriteLine("số trận thua của bạn là {0}", Losses);
Console.WriteLine("số tiền thắng lớn nhất của bạn là {0}", tienthanglonnhat);
goto Menu;

Thoat:
Console.WriteLine("Hẹn gặp lại lần sau");
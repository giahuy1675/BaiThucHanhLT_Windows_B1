using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2280601178_NguyenGiaHuy_Lab01_03
{
    public class Student : Person
    {
        public string Faculty { get; set; }
        public float AverageScore { get; set; }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhập khoa: ");
            Faculty = Console.ReadLine();
            Console.Write("Nhập điểm trung bình: ");
            AverageScore = float.Parse(Console.ReadLine());
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Khoa: {Faculty}, Điểm trung bình: {AverageScore}");
        }
    }

}

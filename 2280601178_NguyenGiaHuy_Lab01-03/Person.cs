using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2280601178_NguyenGiaHuy_Lab01_03
{
    public class Person
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public virtual void Input()
        {
            Console.Write("Nhập mã số: ");
            ID = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            Name = Console.ReadLine();
        }

        public virtual void Show()
        {
            Console.WriteLine($"Mã số: {ID}, Họ tên: {Name}");
        }
    }
}

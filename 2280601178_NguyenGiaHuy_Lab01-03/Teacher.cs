using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2280601178_NguyenGiaHuy_Lab01_03
{
    public class Teacher : Person
    {
        public string Address { get; set; }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhập địa chỉ: ");
            Address = Console.ReadLine();
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Địa chỉ: {Address}");
        }
    }

}

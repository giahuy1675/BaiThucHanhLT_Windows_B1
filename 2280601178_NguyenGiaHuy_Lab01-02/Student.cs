using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2280601178_NguyenGiaHuy_Lab01_02
{
     public class Student
    {
        private string studentID;
        private string fullName;
        private float averageScore;
        private string faculty;

        public Student()
        {
        }

        public Student(string studentID, string fullName, float averageScore, string faculty)
        {
            this.studentID = studentID;
            this.fullName = fullName;
            this.averageScore = averageScore;
            this.faculty = faculty;
        }
        public string StudentID { get => studentID; set => studentID = value;}
        public string FullName { get => fullName; set => fullName = value;}
        public float AverageScore { get => averageScore; set => averageScore = value;}
        public string Faculty { get => faculty; set => faculty = value;}
        public void Input()
        {
            Console.Write("Nhập MSSV: ");
            StudentID = Console.ReadLine();
            Console.Write("Nhập tên sinh viên: ");
            FullName = Console.ReadLine();
            Console.Write("Nhập điểm: ");
            AverageScore = float.Parse(Console.ReadLine());
            Console.Write("Nhập khoa: ");
            Faculty = Console.ReadLine();
        }
        public void Show()
        {
            Console.WriteLine("MSSV: {0} Họ tên: {1} Khoa: {2} Điểm: {3}",this.StudentID,this.FullName,this.Faculty,this.AverageScore);
        }
    }
}

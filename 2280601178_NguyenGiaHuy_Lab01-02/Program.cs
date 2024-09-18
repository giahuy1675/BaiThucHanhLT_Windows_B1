using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2280601178_NguyenGiaHuy_Lab01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Thêm 1 sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Hiển thị sinh viên theo khoa CNTT");
                Console.WriteLine("4. Hiển thị sinh viên có điểm trung bình >= 5");
                Console.WriteLine("5. Sắp xếp sinh viên theo điểm trung bình");
                Console.WriteLine("6. Hiển thị sinh viên theo khoa CNTT và điểm >= 5");
                Console.WriteLine("7. Hiển thị sinh viên có điểm trung bình cao nhất theo khoa CNTT");
                Console.WriteLine("8. Số lượng sinh viên theo từng loại");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("Chọn chức năng (0-7):");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        DisplayStudentList(studentList);
                        break;
                    case "3":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "4":
                        DisplayStudentsWithAverageScore(studentList, 5);
                        break;
                    case "5":
                        SortStudentsByAverageScore(studentList);
                        break;
                    case "6":
                        DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5);
                        break;
                    case "7":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;
                    case "8":
                        DisplayStudentRatingsCount(studentList);
                        break;

                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình");
                        break;
                    default:
                        Console.WriteLine("Tuỳ chọn không hợp lệ");
                        break;
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        private static void DisplayStudentRatingsCount(List<Student> studentList)
        {
            Console.WriteLine("=== Số lượng sinh viên theo xếp loại ===");

            int xuatSac = studentList.Count(s => s.AverageScore >= 9 && s.AverageScore <= 10);
            int gioi = studentList.Count(s => s.AverageScore >= 8 && s.AverageScore < 9);
            int kha = studentList.Count(s => s.AverageScore >= 7 && s.AverageScore < 8);
            int trungBinh = studentList.Count(s => s.AverageScore >= 5 && s.AverageScore < 7);
            int yeu = studentList.Count(s => s.AverageScore >= 4 && s.AverageScore < 5);
            int kem = studentList.Count(s => s.AverageScore < 4);

            Console.WriteLine("Xuất sắc (9,0 - 10,0): {0} sinh viên", xuatSac);
            Console.WriteLine("Giỏi (8,0 - 9,0): {0} sinh viên", gioi);
            Console.WriteLine("Khá (7,0 - 8,0): {0} sinh viên", kha);
            Console.WriteLine("Trung bình (5,0 - 7,0): {0} sinh viên", trungBinh);
            Console.WriteLine("Yếu (4,0 - 5,0): {0} sinh viên", yeu);
            Console.WriteLine("Kém (dưới 4,0): {0} sinh viên", kem);
        }

        private static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            var highestAverageScore = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .Max(s => s.AverageScore);

            var students = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase) && s.AverageScore == highestAverageScore)
                .ToList();

            Console.WriteLine("Sinh viên có điểm trung bình cao nhất trong khoa {0}:", faculty);
            DisplayStudentList(students);
        }

        private static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            Console.WriteLine("Danh sách sinh viên có điểm trung bình >= {0} và thuộc khoa {1}:", minDTB, faculty);
            var students = studentList
                .Where(s => s.AverageScore >= minDTB && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();
            DisplayStudentList(students);
        }

        private static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sinh viên sắp xếp theo điểm trung bình ===");
            var sortedStudents = studentList.OrderBy(s => s.AverageScore).ToList();
            DisplayStudentList(sortedStudents);
        }

        private static void DisplayStudentsWithAverageScore(List<Student> studentList, float minDT)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm >= {0} ===", minDT);
            var students = studentList.Where(s => s.AverageScore >= minDT).ToList();
            DisplayStudentList(students);
        }

        private static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("Danh sách sinh viên thuộc khoa {0}:", faculty);
            var students = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();
            DisplayStudentList(students);
        }

        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách chi tiết thông tin sinh viên ===");
            foreach (Student student in studentList)
            {
                student.Show();
            }   

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2280601178_NguyenGiaHuy_Lab01_03
{
    class Program
    {
        
        static List<Student> studentList = new List<Student>();
        static List<Teacher> teacherList = new List<Teacher>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Thêm giáo viên");
                Console.WriteLine("3. Xuất danh sách sinh viên");
                Console.WriteLine("4. Xuất danh sách giáo viên");
                Console.WriteLine("5. Số lượng từng danh sách");
                Console.WriteLine("6. Xuất danh sách sinh viên khoa CNTT");
                Console.WriteLine("7. Xuất danh sách giáo viên có địa chỉ chứa 'Quận 9'");
                Console.WriteLine("8. Xuất sinh viên có điểm cao nhất khoa CNTT");
                Console.WriteLine("9. Số lượng sinh viên theo xếp loại");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        AddTeacher();
                        break;
                    case "3":
                        DisplayStudents();
                        break;
                    case "4":
                        DisplayTeachers();
                        break;
                    case "5":
                        DisplayCounts();
                        break;
                    case "6":
                        DisplayStudentsByFaculty("CNTT");
                        break;
                    case "7":
                        DisplayTeachersByAddress("Quan 9");
                        break;
                    case "8":
                        DisplayTopStudentByFaculty("CNTT");
                        break;
                    case "9":
                        DisplayStudentRatingsCount();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void AddTeacher()
        {
            Teacher teacher = new Teacher();
            teacher.Input();
            teacherList.Add(teacher);
            Console.WriteLine("Thêm giáo viên thành công!");
        }

        static void DisplayStudents()
        {
            Console.WriteLine("=== Danh sách sinh viên ===");
            foreach (var student in studentList)
            {
                student.Show();
            }
        }

        static void DisplayTeachers()
        {
            Console.WriteLine("=== Danh sách giáo viên ===");
            foreach (var teacher in teacherList)
            {
                teacher.Show();
            }
        }

        static void DisplayCounts()
        {
            Console.WriteLine($"Tổng số sinh viên: {studentList.Count}");
            Console.WriteLine($"Tổng số giáo viên: {teacherList.Count}");
        }

        static void DisplayStudentsByFaculty(string faculty)
        {
            Console.WriteLine($"=== Danh sách sinh viên khoa {faculty} ===");
            var students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var student in students)
            {
                student.Show();
            }
        }

        static void DisplayTeachersByAddress(string address)
        {
            Console.WriteLine($"=== Danh sách giáo viên có địa chỉ chứa '{address}' ===");
            var teachers = teacherList.Where(t => t.Address.Contains(address)).ToList();
            foreach (var teacher in teachers)
            {
                teacher.Show();
            }
        }

        static void DisplayTopStudentByFaculty(string faculty)
        {
            var topStudent = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                                        .OrderByDescending(s => s.AverageScore)
                                        .FirstOrDefault();
            if (topStudent != null)
            {
                Console.WriteLine("Sinh viên có điểm trung bình cao nhất khoa CNTT:");
                topStudent.Show();
            }
            else
            {
                Console.WriteLine("Không có sinh viên trong khoa này.");
            }
        }

        static void DisplayStudentRatingsCount()
        {
            Console.WriteLine("=== Số lượng sinh viên theo xếp loại ===");
            int xuatSac = studentList.Count(s => s.AverageScore >= 9);
            int gioi = studentList.Count(s => s.AverageScore >= 8 && s.AverageScore < 9);
            int kha = studentList.Count(s => s.AverageScore >= 7 && s.AverageScore < 8);
            int trungBinh = studentList.Count(s => s.AverageScore >= 5 && s.AverageScore < 7);
            int yeu = studentList.Count(s => s.AverageScore >= 4 && s.AverageScore < 5);
            int kem = studentList.Count(s => s.AverageScore < 4);

            Console.WriteLine($"Xuất sắc: {xuatSac}");
            Console.WriteLine($"Giỏi: {gioi}");
            Console.WriteLine($"Khá: {kha}");
            Console.WriteLine($"Trung bình: {trungBinh}");
            Console.WriteLine($"Yếu: {yeu}");
            Console.WriteLine($"Kém: {kem}");
        }
    }

}

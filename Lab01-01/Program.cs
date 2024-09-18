using System;
using System.Text;

namespace Lab01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Chương trình đoán số");
            Random random = new Random();
            int targetNumber = random.Next(100, 999);
            string targetString = targetNumber.ToString();
            int attempt = 0, MAX_GUESS = 7;
            string guess, feedback = "";

            while (feedback != "+++" && attempt < MAX_GUESS)
            {
                Console.Write("Nhập dự đoán của bạn (3 chữ số): ");
                guess = Console.ReadLine();

                if (guess.Length != 3 || !int.TryParse(guess, out _))
                {
                    Console.WriteLine("Vui lòng nhập một số hợp lệ gồm 3 chữ số.");
                    continue;
                }

                feedback = GetFeedback(targetString, guess);
                Console.WriteLine("Phản hồi từ máy tính: {0}", feedback);

                attempt++;
            }

            Console.WriteLine("Người chơi đã dự đoán {0} lần. Trò chơi kết thúc!", attempt);
            if (attempt >= MAX_GUESS)
                Console.WriteLine("Người chơi đã thua cuộc. Số cần đoán là: {0}", targetNumber);
            else
                Console.WriteLine("Người chơi đã thắng cuộc! Số bạn đoán là: {0}", attempt);

            Console.ReadKey();
        }

        static string GetFeedback(string target, string guess)
        {
            string feedback = "";
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] == guess[i])
                    feedback += target[i];
                else if (target.Contains(guess[i].ToString()))
                    feedback += "?";
            }
            return feedback;
        }
    }
}

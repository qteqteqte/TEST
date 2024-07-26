using System.Security.Cryptography;

namespace TEST;
public class CHECK_NUMBER
{
    static void Main1(String []args)
    {
        program_start();
    }

    public static void program_start()
    {
        string number = string.Empty;

        while(true)
        {
        Console.WriteLine("주민등록번호를 입력하시오: ");
        number = Console.ReadLine();

        if (string.IsNullOrEmpty(number))
            {
                Console.WriteLine("다시 입력하세요.");
                continue;
            }

            if (number.Length == 13)
            {
                bool isNumeric = true;
                foreach (char c in number)
                {
                    if (!char.IsDigit(c))
                    {
                        isNumeric = false;
                        break;
                    }
                }
                
                if (!isNumeric)
                {
                    Console.WriteLine("숫자가 아닌 문자가 포함되어 있습니다. 다시 입력하세요.");
                    continue;
                }
                
                number_check(ref number);
                break;
            }

            else if (number.Length == 14)
            {
                if (number[6] != '-' && number[6] != ' ')
                {
                    Console.WriteLine("잘못된 형식입니다. 다시 입력하세요.");
                    continue;
                }
                
                number = number.Substring(0, 6) + number.Substring(7);
                number_check(ref number);
            }

            else
            {
                Console.WriteLine("입력 길이가 잘못되었습니다. 다시 입력하세요.");
            }
        }
    }

    public static void number_check(ref string number)
    {
        int[] number_check = {2,3,4,5,6,7,8,9,2,3,4,5};
        int[] k = new int[number_check.Length];
        int sum = 0;
        int avg = 0;

        for(int i=0; i<12; i++)
        {
            k[i] = number_check[i] * number[i];
            sum += k[i];
        }

        avg = 11 - (sum%11);

        string gender = number[6].ToString();

        if (gender == "1" || gender == "3")
        {
            gender = "남자";
        }

        else if (gender == "2" || gender == "4")
        {
            gender = "여자";
        }

        if(avg == number[12])
        {
            Console.WriteLine("정상 주민번호입니다. {0}", gender);
        }

        else
        {
            Console.WriteLine("주민번호가 틀립니다.");
        }
    }
}
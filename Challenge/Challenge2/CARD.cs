namespace TEST;
public class CARD
{
    static void Main2(String[] args)
    {
        Menu_Print();
    }

    public static void Menu_Print()
    {
        while(true)
        {
            Console.WriteLine("카드 게임을 시작합니다. 1. 게임 시작 2. 게임 종료");
            int menu1 = Convert.ToInt32(Console.ReadLine());

            if(menu1==1)
            {
                while(true) {
                    Console.WriteLine("1. 카드 뽑기(3번까지 수행) 2. 메뉴로 돌아가기");
                    int menu2 = Convert.ToInt32(Console.ReadLine());

                    if(menu2==1)
                    {
                        Card_open();
                    }

                    else if(menu2==2)
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("오류 발생!");
                    }
                }
            }

            else if(menu1==2)
            {
                Console.WriteLine("게임을 종료합니다.");
                return;
            }

            else
            {
                Console.WriteLine("오류 발생!");
            }
        }
    }

    public static void Card_open()
    {
        Random cnt = new Random();

            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < 3; i++)
            {
                int user_number = cnt.Next(1, 101);
                int computer_number = cnt.Next(1, 101);

                Console.WriteLine($"{i+1}번째 사용자 카드 뽑기 결과 : {user_number}");
                Console.WriteLine($"{i+1}번째 컴퓨터 카드 뽑기 결과 : {computer_number}");

                sum1 += user_number;
                sum2 += computer_number;

                if (i < 2)
                {
                    Console.WriteLine("1. 카드뽑기(3번까지 수행), 2. 메뉴로 돌아가기");
                    int menu2 = Convert.ToInt32(Console.ReadLine());

                    if (menu2 == 2)
                    {
                        return;
                    }
                }
            }

            Console.WriteLine("카드 게임의 결과");
            if (sum1 > sum2)
            {
                Console.WriteLine("사용자가 승리했습니다.");
            }
            else if (sum2 > sum1)
            {
                Console.WriteLine("컴퓨터가 승리했습니다.");
            }
            else
            {
                Console.WriteLine("비겼습니다.");
            }

    }
}
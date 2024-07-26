namespace TEST;
public class CARDcopy
{
    static void Main3(String[] args)
    {
        GAME game = new GAME();
        game.Menu_Print();
    }
}

class GAME
{
    private Random random;
    private int player1Wins;
    private int player2Wins;
    private int player3Wins;

    public GAME()
    {
        random = new Random();
        player1Wins = 0;
        player2Wins = 0;
        player3Wins = 0;
    }
        
    public void Menu_Print()
    {
        while(true)
        {
            Console.WriteLine("카드 게임을 시작합니다. 1. 게임 시작 2. 게임 종료");
            int menu1 = Convert.ToInt32(Console.ReadLine());

            if(menu1==1)
            {
                while(true) {
                    Console.WriteLine("1. 카드 뽑기(3번까지 수행) 2. 카드 자동 뽑기 3. 메뉴로 돌아가기");
                    int menu2 = Convert.ToInt32(Console.ReadLine());

                    if(menu2==1)
                    {
                        Card_open();
                    }

                    else if(menu2==2)
                    {
                        Card_auto_open();
                    }

                    else if(menu2==3)
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

    private void Card_open()
    {
        Random cnt = new Random();

            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;

            for (int i = 0; i < 3; i++)
            {
                sum1 = DrawCard().GetValue();
                sum2 = DrawCard().GetValue();
                sum3 = DrawCard().GetValue();
            }

            Console.WriteLine("카드 게임의 결과");
            if (sum1 > sum2 && sum1 > sum3)
            {
                Console.WriteLine("사용자1이 승리했습니다.");
                player1Wins++;
            }
            else if (sum2 > sum1 && sum2 > sum3)
            {
                Console.WriteLine("사용자2가 승리했습니다.");
                player2Wins++;
            }
            else if (sum3 > sum1 && sum3 > sum2)
            {
                Console.WriteLine("사용자3가 승리했습니다.");
                player3Wins++;
            }
            else
            {
                Console.WriteLine("비겼습니다!");
            }

    }

    private void Card_auto_open()
    {
        for (int i = 0; i < 100; i++)
        {
            Card_open();
        }

        Console.WriteLine("100번의 자동 게임 결과:");
        Console.WriteLine($"사용자1 승리 횟수: {player1Wins}");
        Console.WriteLine($"사용자2 승리 횟수: {player2Wins}");
        Console.WriteLine($"사용자3 승리 횟수: {player3Wins}");

        int maxWins = Math.Max(player1Wins, Math.Max(player2Wins, player3Wins));

        if (maxWins == player1Wins)
        {
            Console.WriteLine("가장 많이 승리한 사람: 사용자1");
        }
        else if (maxWins == player2Wins)
        {
            Console.WriteLine("가장 많이 승리한 사람: 사용자2");
        }
        else
        {
            Console.WriteLine("가장 많이 승리한 사람: 사용자3");
        }
    }

    private CARD2 DrawCard()
    {
        int cardValue = random.Next(1, 101);
        return new CARD2(cardValue);
    }
}

class CARD2
{
    private int value;

        public CARD2(int value)
        {
            this.value = value;
        }

        public int GetValue()
        {
            return value;
        }
}
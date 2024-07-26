namespace TEST
{
    public class LOL
    {
        static void Main4(String[] args)
        {
            Character[] champions = new Character[4];
            champions[0] = new HUMAN_Cham("루시안", 641, 320, 60, 28);
            champions[1] = new BEAST_Cham("렝가", 590, 5, 68, 34);
            champions[2] = new HUMAN_Cham("다리우스", 652, 263, 64, 39);

            Console.WriteLine("사용자 입력 챔피언 정보를 입력하세요.");
            Console.Write("이름: ");
            string name = Console.ReadLine();
            Console.Write("체력: ");
            int health = int.Parse(Console.ReadLine());
            Console.Write("마나: ");
            int mana = int.Parse(Console.ReadLine());
            Console.Write("공격력: ");
            int attack = int.Parse(Console.ReadLine());
            Console.Write("방어력: ");
            int defense = int.Parse(Console.ReadLine());

            champions[3] = new CustomChampion(name, health, mana, attack, defense);

            foreach (var hero in champions)
            {
                hero.DisplayInfo();
                hero.UseSpecialSkill();
                Console.WriteLine();
            }
        }
    }

    class Character
    {
        protected string name;
        protected int health;
        protected int mana;
        protected int attack;
        protected int defense;
        protected string type;

        public Character(string name, int health, int mana, int attack, int defense, string type)
        {
            this.name = name;
            this.health = health;
            this.mana = mana;
            this.attack = attack;
            this.defense = defense;
            this.type = type;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"이름: {name}");
            Console.WriteLine($"타입: {type}");
            Console.WriteLine($"체력: {health}");
            Console.WriteLine($"마나: {mana}");
            Console.WriteLine($"공격력: {attack}");
            Console.WriteLine($"방어력: {defense}");
        }

        public virtual void UseSpecialSkill()
        {
            Console.WriteLine("기본 스킬을 사용합니다.");
        }
    }

    class Champion : Character
    {
        public Champion(string name, int health, int mana, int attack, int defense, string type)
            : base(name, health, mana, attack, defense, type)
        {
        }

        public override void UseSpecialSkill()
        {
            Console.WriteLine("1차 업그레이드 스킬을 사용합니다.");
        }
    }

    class HUMAN_Cham : Champion
    {
        public HUMAN_Cham(string name, int health, int mana, int attack, int defense)
            : base(name, health, mana, attack, defense, "Human")
        {
        }

        public override void UseSpecialSkill()
        {
            Console.WriteLine("2차 업그레이드 스킬을 사용합니다.");
        }
    }

    class BEAST_Cham : Champion
    {
        public BEAST_Cham(string name, int health, int mana, int attack, int defense)
            : base(name, health, mana, attack, defense, "Beast")
        {
        }

        public override void UseSpecialSkill()
        {
            Console.WriteLine("2차 업그레이드 스킬을 사용합니다.");
        }
    }

    class CustomChampion : Champion
    {
        public CustomChampion(string name, int health, int mana, int attack, int defense)
            : base(name, health, mana, attack, defense, "Custom")
        {
        }

        public override void UseSpecialSkill()
        {
            Console.WriteLine("사용자 정의 챔피언은 1차 업그레이드 스킬만 사용 가능합니다.");
        }
    }
}
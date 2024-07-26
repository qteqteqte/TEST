namespace TEST
{
    public class LOLweapon
    {
        static void Main(String[] args)
        {
            Weapon sword = new Weapon("Sword", 20, 10, "Physical");
            Weapon staff = new Weapon("Staff", 10, 5, "Magical");

            Character2[] champions = new Character2[4];
            champions[0] = new HUMAN_Cham2("루시안", 641, 320, 60, 28);
            champions[1] = new BEAST_Cham2("렝가", 590, 5, 68, 34);
            champions[2] = new HUMAN_Cham2("다리우스", 652, 263, 64, 39);

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

            Console.WriteLine("사용자 입력 챔피언 무기 정보를 입력하세요.");
            Console.Write("무기 이름: ");
            string weaponName = Console.ReadLine();
            Console.Write("무기 공격력: ");
            int weaponAttack = int.Parse(Console.ReadLine());
            Console.Write("무기 방어력: ");
            int weaponDefense = int.Parse(Console.ReadLine());
            Console.Write("무기 타입 (물리/마법): ");
            string weaponType = Console.ReadLine();

            Weapon userWeapon = new Weapon(weaponName, weaponAttack, weaponDefense, weaponType);
            champions[3] = new CustomChampion2(name, health, mana, attack, defense, userWeapon);

            foreach (var hero in champions)
            {
                hero.DisplayInfo();
                hero.UseSpecialSkill();
                Console.WriteLine();
            }
        }
    }

    class Weapon
    {
        public string Name { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public string Type { get; private set; }

        public Weapon(string name, int attack, int defense, string type)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
            Type = type;
        }

        public void UpgradeWeapon()
        {
            Attack += 10;
            Defense += 5;
            Console.WriteLine($"{Name} 무기가 업그레이드 되었습니다! 새로운 공격력: {Attack}, 새로운 방어력: {Defense}");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"무기 이름: {Name}, 공격력: {Attack}, 방어력: {Defense}, 타입: {Type}");
        }
    }

    class Character2
    {
        protected string name;
        protected int health;
        protected int mana;
        protected int attack;
        protected int defense;
        protected string type;
        protected Weapon weapon;

        public Character2(string name, int health, int mana, int attack, int defense, string type, Weapon weapon = null)
        {
            this.name = name;
            this.health = health;
            this.mana = mana;
            this.attack = attack;
            this.defense = defense;
            this.type = type;
            this.weapon = weapon;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"이름: {name}");
            Console.WriteLine($"타입: {type}");
            Console.WriteLine($"체력: {health}");
            Console.WriteLine($"마나: {mana}");
            Console.WriteLine($"공격력: {attack + (weapon != null ? weapon.Attack : 0)}");
            Console.WriteLine($"방어력: {defense + (weapon != null ? weapon.Defense : 0)}");

            if (weapon != null)
            {
                weapon.DisplayInfo();
            }
        }

        public virtual void UseSpecialSkill()
        {
            Console.WriteLine("기본 스킬을 사용합니다.");
        }
    }

    class Champion2 : Character2
    {
        public Champion2(string name, int health, int mana, int attack, int defense, string type, Weapon weapon = null)
            : base(name, health, mana, attack, defense, type, weapon)
        {
        }

        public override void UseSpecialSkill()
        {
            Console.WriteLine("1차 업그레이드 스킬을 사용합니다.");
        }
    }

    class HUMAN_Cham2 : Champion2
    {
        public HUMAN_Cham2(string name, int health, int mana, int attack, int defense, Weapon weapon = null)
            : base(name, health, mana, attack, defense, "Human", weapon)
        {
        }

        public override void UseSpecialSkill()
        {
            Console.WriteLine("2차 업그레이드 스킬을 사용합니다.");
        }
    }

    class BEAST_Cham2 : Champion2
    {
        public BEAST_Cham2(string name, int health, int mana, int attack, int defense, Weapon weapon = null)
            : base(name, health, mana, attack, defense, "Beast", weapon)
        {
        }

        public override void UseSpecialSkill()
        {
            Console.WriteLine("2차 업그레이드 스킬을 사용합니다.");
        }
    }

    class CustomChampion2 : Champion2
    {
        public CustomChampion2(string name, int health, int mana, int attack, int defense, Weapon weapon = null)
            : base(name, health, mana, attack, defense, "Custom", weapon)
        {
        }
        public override void UseSpecialSkill()
        {
            if (weapon != null)
            {
                Console.WriteLine("사용자 정의 챔피언이 2차 업그레이드 스킬을 사용할 수 있습니다.");
            }
            else
            {
                Console.WriteLine("사용자 정의 챔피언은 1차 업그레이드 스킬만 사용 가능합니다.");
            }
        }
    }
}
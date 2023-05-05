using System.Text.Json;
using System;
using System.Reflection.Metadata;

public class Hangman
{
    public User[] Users = new User[] { };

    public Person[] Persons = new Person[] { };
    private const string _GG= "Person.json";
    protected Person _person;
 
    public void GG(out Person hangman)
    {
        string jsons = File.ReadAllText(_GG);
        hangman = JsonSerializer.Deserialize<Person>(jsons);
    }
    public void Start()
    {
        void UserSignUp()
        {
            Console.Clear();

            Console.Write("Введите никнейм: ");
            string nickname = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            User newUser = new User(nickname, password);

            User[] tUsers = new User[Users.Length + 1];

            for (int i = 0; i < Users.Length; i++)
            {
                tUsers[i] = Users[i];
            }

            tUsers[Users.Length] = newUser;

            Users = tUsers;

            

            Person tom = new Person(1,nickname);
            string json = JsonSerializer.Serialize(tom);
            File.WriteAllText("Person.json", json);

            Person[] tPersons = new Person[Persons.Length + 1];

            for (int i = 0; i < Persons.Length; i++)
            {
                tPersons[i] = Persons[i];
            }
            tPersons[Persons.Length] = tom;
            Persons = tPersons;


            Game();

        }

    
        void PrintMainMenu()
        {
        
            Console.Clear();
            Start:
            Console.WriteLine("== ГЛАВНОЕ МЕНЮ ==");
            Console.WriteLine("1. Регистрация пользователя");
            Console.WriteLine("2. Выход");
            Console.WriteLine("==================");
            int a=Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                UserSignUp();
            }
            else if (a == 2)
            {
                return;
            }
            else
            {
                Console.WriteLine("Пожалуйста выберите данное:");
                goto Start;
            }
        }
        PrintMainMenu();

        void PrintUserNicknames()
        {
           
            foreach (Person user in Persons)
            {
                Console.WriteLine(user.Name);
            }

        }

        static int InputCommand()
        {
            Console.Write("Введите команду: ");

            return Convert.ToInt32(Console.ReadLine());
        }
        
        void WaitEnterForContinue()
        {
            Console.Write("Нажмите ENTER для продолжения");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key != ConsoleKey.Enter)
            {
                WaitEnterForContinue();
            }
        }

        void InitializeData()
        {
            new Hangman().GG(out Person jsons);
            _person=jsons;
        }
        void GGS()
        {
            InitializeData();
            Console.WriteLine("============ТАБЛИЦА ЛИДЕРОВ===========");
            foreach (Person user in Persons)
            {
                Console.Write("                  ");
                Console.Write(user.Name);
                Console.WriteLine("                ");
            }
            
        }
       
        void Game()
        {
            Console.Clear();

            Console.WriteLine("=== МЕНЮ ИГРЫ ====");
            Console.WriteLine("1. Виселица с тематикой цветов");
            Console.WriteLine("2. Виселица с тематикой спорта ");
            Console.WriteLine("3. Виселица с тематикой стран");
            Console.WriteLine("4. Таблица лидеров");
            Console.WriteLine("==================");

            switch (InputCommand())
            {
                case 1:
                    VisiliccaCveta();
                    break;
                case 2:
                    VisiliccaSport();
                    break;
                case 3:
                    VisiliccaStran();
                    break;
                case 4:
                    GGS();
                    break;
                default:
                    break;
            }
        }
        void VisiliccaCveta()
        {
            Console.Clear();
        string[] slova = { "красный", "серый", "жёлтый", "белый", "оранжевый", "черный", "коричневый"};
        string slovo = slova[new Random().Next(0, slova.Length)];
        char[] bukvy = new char[slovo.Length];


        Console.WriteLine("Слово состоит из " + slovo.Length + " букв");
        int nepravBukvy = 0;
        int ochki = 0;
        for (int p = 0; p < slovo.Length; p++)
        {
            bukvy[p] = '*';
            Console.Write(bukvy[p]);
        }
        while (nepravBukvy < 5 && new string(bukvy) != slovo)
        {
        Start:
            Console.WriteLine();
            Console.WriteLine("Введите букву:");

            char bukva = Console.ReadLine()[0];
            bool pravilnBukv = false;
            for (int i = 0; i < slovo.Length; i++)
            {
                if (slovo[i] == bukva)
                {
                    bukvy[i] = bukva;
                    pravilnBukv = true;
                }

            }
            if (pravilnBukv)
            {
                    Console.Clear();

                Console.WriteLine("Верно");
                Console.WriteLine(bukvy);

            }
            else
            {
                    
                nepravBukvy++;
                printHangman(nepravBukvy);
                Console.WriteLine("Неверно! У вас осталось " + (5 - nepravBukvy) + " попыток");
                Console.Write("Желаете сдаться?   ДА=1   НЕТ=2");
                    Console.WriteLine();
                int gg=Convert.ToInt32(Console.ReadLine());
                    switch (gg)
                    {
                        case 1:
                            Start();
                             break;
                        case 2:
                            goto Start;
                            break;
                    }

                }
                
        }
        if (new string(bukvy) == slovo)
        {
                Console.Clear();
            Console.WriteLine("Женисин кутты болсын бауыр");
            ochki=10+(5-nepravBukvy);
            Console.WriteLine($"У вас {ochki} очков");
                Console.WriteLine("===================================");
                Console.WriteLine("Хотите сыграть еще раз?");
                string otv = Console.ReadLine();
                switch (otv)
                {
                    case "Да":
                        Game(); break;
                    case "Нет":
                        Start();
                        break;
                }
            }
        else
        {
                
            Console.WriteLine("Ты продул братишка ответ:" + slovo);
                Console.WriteLine("===================================");
                Console.WriteLine("Хотите сыграть еще раз?");
                string otv = Console.ReadLine();
                switch (otv)
                {
                    case "Да":
                        Game(); break;
                    case "Нет":
                        Start();
                        break;
                }
            }
        

        }
        void VisiliccaSport()
        {
            Console.Clear();
            string[] slova = { "футбол", "баскет", "тенис", "хокей", "бокс", "каратэ", "самбо" };
            string slovo = slova[new Random().Next(0, slova.Length)];
            char[] bukvy = new char[slovo.Length];


            Console.WriteLine("Слово состоит из " + slovo.Length + " букв");
            int nepravBukvy = 0;
            int ochki = 0;
            for (int p = 0; p < slovo.Length; p++)
            {
                bukvy[p] = '*';
                Console.Write(bukvy[p]);
            }
            while (nepravBukvy < 5 && new string(bukvy) != slovo)
            {
                Start:
                Console.WriteLine();
                Console.WriteLine("Введите букву:");

                char bukva = Console.ReadLine()[0];
                bool pravilnBukv = false;
                for (int i = 0; i < slovo.Length; i++)
                {
                    if (slovo[i] == bukva)
                    {
                        bukvy[i] = bukva;
                        pravilnBukv = true;
                    }

                }
                if (pravilnBukv)
                {
                    Console.Clear();
                    Console.WriteLine("Верно");
                    Console.WriteLine(bukvy);

                }
                else
                {
                    
                    nepravBukvy++;
                    printHangman(nepravBukvy);
                    Console.WriteLine("Неверно! У вас осталось " + (5 - nepravBukvy) + " попыток");
                    Console.Write("Желаете сдаться?   ДА=1   НЕТ=2");
                    Console.WriteLine();
                    int gg = Convert.ToInt32(Console.ReadLine());
                    switch (gg)
                    {
                        case 1:
                            Start();
                            break;
                        case 2:
                            goto Start;
                            break;
                    }

                }

            }
            if (new string(bukvy) == slovo)
            {
                Console.Clear();
                Console.WriteLine("Женисин кутты болсын бауыр");
                ochki = 10 + (5 - nepravBukvy);
                Console.WriteLine($"У вас {ochki} очков");
                Console.WriteLine("===================================");
                Console.WriteLine("Хотите сыграть еще раз?");
                string otv = Console.ReadLine();
                switch (otv)
                {
                    case "Да":
                        Game(); break;
                    case "Нет":
                        Start();
                        break;
                }

            }
            else
            {
                Console.WriteLine("Ты продул братишка ответ:" + slovo);
                Console.WriteLine("===================================");
                Console.WriteLine("Хотите сыграть еще раз?");
               string otv = Console.ReadLine();
              switch (otv)
              {
                  case "Да":
                      Game(); break;
                 case "Нет":
                        Start();
                     break;
              }
            }
            
        }
        void VisiliccaStran()
        {
            Console.Clear();
            string[] slova = { "казахстан", "франция", "германия", "армения", "грузия", "турция", "китай" };
            string slovo = slova[new Random().Next(0, slova.Length)];
            char[] bukvy = new char[slovo.Length];


            Console.WriteLine("Слово состоит из " + slovo.Length + " букв");
            int nepravBukvy = 0;
            int ochki = 0;
            for (int p = 0; p < slovo.Length; p++)
            {
                bukvy[p] = '*';
                Console.Write(bukvy[p]);
            }
            while (nepravBukvy < 5 && new string(bukvy) != slovo)
            {
                Start:
                Console.WriteLine();
                Console.WriteLine("Введите букву:");

                char bukva = Console.ReadLine()[0];
                bool pravilnBukv = false;
                for (int i = 0; i < slovo.Length; i++)
                {
                    if (slovo[i] == bukva)
                    {
                        bukvy[i] = bukva;
                        pravilnBukv = true;
                    }

                }
                if (pravilnBukv)
                {
                    Console.Clear();
                    Console.WriteLine("Верно");
                    Console.WriteLine(bukvy);

                }
                else
                {
                    
                    nepravBukvy++;
                    printHangman(nepravBukvy);
                    Console.WriteLine("Неверно! У вас осталось " + (5 - nepravBukvy) + " попыток");
                    Console.Write("Желаете сдаться?   ДА=1   НЕТ=2");
                    Console.WriteLine();
                    int gg = Convert.ToInt32(Console.ReadLine());
                    switch (gg)
                    {
                        case 1:
                            Start();
                            break;
                        case 2:
                            goto Start;
                            break;
                    }

                }

            }
            if (new string(bukvy) == slovo)
            {
                Console.Clear();
                Console.WriteLine("Женисин кутты болсын бауыр");
                ochki = 10 + (5 - nepravBukvy);
                Console.WriteLine($"У вас {ochki} очков");
                Console.WriteLine("===================================");
                Console.WriteLine("Хотите сыграть еще раз?");
                string otv = Console.ReadLine();
                switch (otv)
                {
                    case "Да":
                        Game(); break;
                    case "Нет":
                        Start();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ты продул братишка ответ:" + slovo);
                Console.WriteLine("===================================");
                Console.WriteLine("Хотите сыграть еще раз?");
                string otv = Console.ReadLine();
                switch (otv)
                {
                    case "Да":
                        Game(); break;
                    case "Нет":
                        Start();
                        break;
                }
            }
            

        }
    }
    private static void printHangman(int nepravil)
    {

        if (nepravil == 1)
        {
            Coloring.PrintOneM(@"









        ________________
        |              |
");
        }
        else if (nepravil == 2)
        {
            Console.Clear();
            Coloring.PrintTwoM(@"

          |     
          |     
          |     
          |    
          |     
          |      
          |      
          |
        __|_____________
        |              |
");
        }
        else if (nepravil == 3)
        {
            Console.Clear();
            Coloring.PrintThreeM(@"
          _______
          |/     |
          |     
          |     
          |    
          |      
          |     
          |    
          |
        __|_____________
        |              |
");
        }
        else if (nepravil == 4)
        {
            Console.Clear();
            Coloring.PrintFourM(@"
          _______
          |/     |
          |     (_)
          |     _|_
          |    / | \
          |      |
          |     / \
          |    /   \
          |  ----------
        __|____|____|___
        |              |
");
        }
        else if (nepravil == 5)
        {
            Console.Clear();
            Coloring.PrintFiveM(@"
          _______
          |/     |
          |     (_)               GAME OVER!
          |     _|_                You DEAD
          |    / | \
          |      |
          |     / \
          |    /   \
          |
        __|_____________
        |              |
");
        }

    }
}


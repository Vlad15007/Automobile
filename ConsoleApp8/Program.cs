using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine myMotor = new Engine() 
            { 
                Model = "Mega", 
                Type = "40 V", 
                Sostoianie = new Condition() 
            };



            Automobile myCar = new Automobile("моя #7895", "Быстровушка", "Лада-джини", 2, 200000.300)
            {
                Motor = myMotor,
                Shasi = new Shassis(){ Model = "Smart", Sostoianie = new Condition() },
                Kyzov = new Body(){ Model = "Lada", Color = "Lamba", Sostoianie = new Condition() },
            };

            myCar.Ezdit();
            //myCar.Ezdit();
            myCar.Osmotr();

            Console.ReadKey();
        }
    }









    class Automobile
    {
        string Name { get; set; }
        string Type { get; set; }
        string Model { get; set; }
        double Weigth { get; set; }
        double Cost { get; set; }

        public Shassis Shasi { get; set; }
        public Engine Motor { get; set; }
        public Body Kyzov { get; set; }

        public Automobile(string name, string type, string model, double weigth, double cost)
        {
            Name = name;
            Type = type;
            Model = model;
            Weigth = weigth;
            Cost = cost;
        }


        public void Ezdit()
        {
            int sostoianieShasi = Shasi.Sostoianie.ProcentIznoshenosti;
            sostoianieShasi += 20;
            Shasi.Sostoianie = new Condition(sostoianieShasi);

            int sostoianieMotora = Motor.Sostoianie.ProcentIznoshenosti;
            sostoianieMotora += 30;
            Motor.Sostoianie = new Condition(sostoianieMotora);

            int sostoianieKyzova = Kyzov.Sostoianie.ProcentIznoshenosti;
            sostoianieKyzova += 40;
            Kyzov.Sostoianie = new Condition(sostoianieKyzova);
        }


        public void Osmotr()
        {
            Console.WriteLine("При проверке автомобиля : " + Name);
            Console.WriteLine("Типа : " + Type);
            Console.WriteLine("Модели : " + Model + "\n");

            Console.WriteLine("Проверка шасси : ");
            Shasi.Sostoianie.Show();

            Console.WriteLine("Проверка мотора : ");
            Motor.Sostoianie.Show();

            Console.WriteLine("Проверка кузова : ");
            Kyzov.Sostoianie.Show();
        }
    }








    class Shassis
    {
        public string Model { get; set; }
        public Condition Sostoianie { get; set; }
    }


    class Engine
    {
        public string Model { get; set; }
        public string Type { get; set; }
        public Condition Sostoianie { get; set; }
    }


    class Body
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public Condition Sostoianie { get; set; }
    }








    class Condition
    {
        public string Opisanie { get; set; } 
        public int ProcentIznoshenosti { get; set; } 

        public Condition()
        {
            Opisanie = "Отличное";
            ProcentIznoshenosti = 0;
        }

        public Condition(int sostoianie)
        {
            if(sostoianie < 30) Opisanie = "Хорошее";
            else if(sostoianie < 40) Opisanie = "Нормальное";
            else if(sostoianie < 50) Opisanie = "Среднее";
            else if(sostoianie < 60) Opisanie = "Изношеное";
            else if(sostoianie < 70) Opisanie = "Плохое";
            else Opisanie = "Непригодное";

            ProcentIznoshenosti = sostoianie;
        }

        public void Show()
        {
            Console.WriteLine("Состояние : " + Opisanie);
            Console.WriteLine("Процент изношености : " + ProcentIznoshenosti + "\n");
        }
    }
}

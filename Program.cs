using System;



namespace iба_чотка

{

    internal class Program

    {

        static void Main(string[] args)

        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;



            Console.WriteLine("Вы просыпаетесь в Царицыно");

            Console.WriteLine("Введите ваше имя:");

            string name = Console.ReadLine();

            Console.WriteLine("Ваше имя: " + name);



            bool playing = true;



            // состояния предметов

            bool artifact1 = false; // под кроватью

            bool artifact2 = false; // вентиляция

            bool artifact3 = false; // тумбочка

            bool statueActivated = false; // ключ от ящика получен

            bool drawerOpened = false; // отмычка получена

            bool doorOpened = false; // дверь открыта



            int ventAttempts = 0; // попытки открыть вентиляцию



            while (playing)

            {

                Console.WriteLine("\nВы осматриваетесь вокруг.");

                Console.WriteLine("Что будете делать?");

                Console.WriteLine("1. Открыть дверь");

                Console.WriteLine("2. Заглянуть под кровать");

                Console.WriteLine("3. Открыть ящик в углу комнаты");

                Console.WriteLine("4. Открыть вентиляцию");

                Console.WriteLine("5. Взглянуть на тумбочку");

                Console.WriteLine("6. Взглянуть на статую рядом с дверью");

                Console.WriteLine("0. Выйти из игры");



                Console.Write("\nВаш выбор: ");

                string input = Console.ReadLine();



                switch (input)

                {

                    case "1": // дверь

                        if (doorOpened)

                        {

                            Console.WriteLine("Дверь уже открыта. Вы свободны!");

                            playing = false;

                        }

                        else if (drawerOpened)

                        {

                            Console.WriteLine($"{name}, вы открыли дверь с помощью отмычки!");

                            Console.WriteLine("Поздравляем! Вы успешно сбежали");

                            doorOpened = true;

                            playing = false;

                        }

                        else

                        {

                            Console.WriteLine("Дверь заперта. Нужна отмычка.");

                        }

                        break;



                    case "2": // кровать

                        if (!artifact1)

                        {

                            Console.WriteLine($"{name}, вы нашли первый артефакт!");

                            artifact1 = true;

                        }

                        else

                        {

                            Console.WriteLine("Под кроватью больше ничего нет.");

                        }

                        break;



                    case "3": // ящик

                        if (!drawerOpened)

                        {

                            if (statueActivated)

                            {

                                Console.WriteLine($"{name}, вы открыли ящик и нашли отмычку!");

                                drawerOpened = true;

                            }

                            else

                            {

                                Console.WriteLine("Ящик заперт. Нужен ключ от статуи.");

                            }

                        }

                        else

                        {

                            Console.WriteLine("Ящик уже открыт.");

                        }

                        break;



                    case "4": // вентиляция

                        if (!artifact2)

                        {

                            ventAttempts++;

                            if (ventAttempts < 3)

                            {

                                Console.WriteLine("Вы тянете решётку, но она не поддаётся");

                                Console.WriteLine($"(Попыток: {ventAttempts}/3)");

                            }

                            else

                            {

                                Console.WriteLine($"{name}, вы с трудом открыли вентиляцию и нашли второй артефакт!");

                                artifact2 = true;

                            }

                        }

                        else

                        {

                            Console.WriteLine("Вентиляция пуста, вы уже забрали артефакт.");

                        }

                        break;



                    case "5": // тумбочка

                        if (!artifact3)

                        {

                            Console.WriteLine($"{name}, вы нашли третий артефакт!");

                            artifact3 = true;

                        }

                        else

                        {

                            Console.WriteLine("На тумбочке больше ничего нет.");

                        }

                        break;



                    case "6": // статуя

                        if (!statueActivated)

                        {

                            if (artifact1 && artifact2 && artifact3)

                            {

                                Console.WriteLine($"{name}, вы активировали статую тремя артефактами!");

                                Console.WriteLine("В тайном отсеке вы находите ключ от ящика.");

                                statueActivated = true;

                            }

                            else

                            {

                                Console.WriteLine("Статуя требует три артефакта для активации.");

                            }

                        }

                        else

                        {

                            Console.WriteLine("Статуя уже активирована.");

                        }

                        break;



                    case "0":

                        Console.WriteLine("Игра завершена. Спасибо за игру, " + name + "!");

                        playing = false;

                        break;



                    default:

                        Console.WriteLine("Неверный выбор. Попробуйте ещё раз.");

                        break;

                }

            }

        }

    }

}


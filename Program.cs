using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        Avto[] cars = new Avto[2];

        // создаём машины и запрашиваем данные у пользователя
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"      Ввод данных для машины {i + 1}      ");
            Console.WriteLine("====================================");
            cars[i] = new Avto();
            cars[i].info();
            Console.WriteLine();
        }

        // выводим начальное состояние всех машин
        Console.WriteLine("====================================");
        Console.WriteLine("    Начальное состояние машин    ");
        Console.WriteLine("====================================");
        for (int i = 0; i < 2; i++)
        {
            cars[i].Out();
            Console.WriteLine();
        }
        Console.WriteLine("====================================");

        bool continueTrips = true;
        int index = 0; // отслеживаем выбранную машину

        while (continueTrips)
        {
            // выводим меню
            Console.WriteLine("====================================");
            Console.WriteLine("       ИГРА МАШИНКИ - МЕНЮ       ");
            Console.WriteLine("====================================");
            Console.WriteLine("  1. Выбрать машину              ");
            Console.WriteLine("  2. Установить координаты       ");
            Console.WriteLine("  3. Установить скорость машины  ");
            Console.WriteLine("  4. Разгон                      ");
            Console.WriteLine("  5. Торможение                  ");
            Console.WriteLine("  6. Залить бензин               ");
            Console.WriteLine("  7. Перемещение по горизонтали  ");
            Console.WriteLine("  8. Перемещение по вертикали    ");
            Console.WriteLine("  9. Выход                       ");
            Console.WriteLine("====================================");
            Console.Write("Выберите действие (1-9): ");
            string answer = Console.ReadLine();

            while (!IsValidNumber(answer) || int.Parse(answer) < 1 || int.Parse(answer) > 9)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Ошибка: Введите число от 1 до 9!");
                Console.WriteLine("------------------------------------");
                Console.Write("Выберите действие (1-9): ");
                answer = Console.ReadLine();
            }

            switch (answer)
            {
                case "1":
                    {
                        Console.WriteLine("------------------------------------");
                        Console.Write("Выберите машину (1 или 2): ");
                        string choiceInput = Console.ReadLine();
                        if (IsValidNumber(choiceInput))
                        {
                            int choice = Convert.ToInt32(choiceInput);
                            if (choice == 1)
                            {
                                index = 0;
                                Console.WriteLine($"Выбрана первая машина марки {cars[index].marka} с номером {cars[index].nomer_avto}");
                            }
                            else if (choice == 2)
                            {
                                index = 1;
                                Console.WriteLine($"Выбрана вторая машина марки {cars[index].marka} с номером {cars[index].nomer_avto}");
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: Такой машины нет! Выберите 1 или 2.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Введите число 1 или 2!");
                        }
                        Console.WriteLine("------------------------------------");
                    }
                    break;

                case "2":
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("      Установка координат      ");
                        Console.Write("Введите X: ");
                        string xInput = Console.ReadLine();
                        Console.Write("Введите Y: ");
                        string yInput = Console.ReadLine();
                        if (float.TryParse(xInput, out float x) && float.TryParse(yInput, out float y))
                        {
                            cars[index].setCoordinates(x, y);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Введите корректные числа для координат!");
                        }
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("    Текущее состояние машины    ");
                        Console.WriteLine("------------------------------------");
                        cars[index].Out();
                        Console.WriteLine("====================================");
                    }
                    break;

                case "3":
                    {
                        Console.WriteLine("------------------------------------");
                        Console.Write("Установите скорость (км/ч): ");
                        string speedInput = Console.ReadLine();
                        if (float.TryParse(speedInput, out float currentSpeed))
                        {
                            if (currentSpeed < 0)
                            {
                                Console.WriteLine("Ошибка: Скорость не может быть отрицательной!");
                            }
                            else
                            {
                                cars[index].razgon(currentSpeed);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Введите корректное число для скорости!");
                        }
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("    Текущее состояние машины    ");
                        Console.WriteLine("------------------------------------");
                        cars[index].Out();
                        Console.WriteLine("====================================");
                    }
                    break;

                case "4":
                    {
                        Console.WriteLine("------------------------------------");
                        Console.Write("Введите насколько вы хотите разогнаться (км/ч): ");
                        string razgonInput = Console.ReadLine();
                        if (float.TryParse(razgonInput, out float razgon))
                        {
                            if (razgon < 0)
                            {
                                Console.WriteLine("Ошибка: Разгон не может быть отрицательным!");
                            }
                            else
                            {
                                cars[index].razgon(razgon);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Введите корректное число для разгона!");
                        }
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("    Текущее состояние машины    ");
                        Console.WriteLine("------------------------------------");
                        cars[index].Out();
                        Console.WriteLine("====================================");
                    }
                    break;

                case "5":
                    {
                        Console.WriteLine("------------------------------------");
                        Console.Write("Введите насколько вы хотите затормозить (км/ч): ");
                        string tormozhenieInput = Console.ReadLine();
                        if (float.TryParse(tormozhenieInput, out float tormozhenie))
                        {
                            if (tormozhenie < 0)
                            {
                                Console.WriteLine("Ошибка: Торможение не может быть отрицательным!");
                            }
                            else
                            {
                                cars[index].tormozhenie(tormozhenie);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Введите корректное число для торможения!");
                        }
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("    Текущее состояние машины    ");
                        Console.WriteLine("------------------------------------");
                        cars[index].Out();
                        Console.WriteLine("====================================");
                    }
                    break;

                case "6":
                    {
                        Console.WriteLine("------------------------------------");
                        Console.Write("Введите сколько бензина вы хотите залить (л): ");
                        string responseInput = Console.ReadLine();
                        if (float.TryParse(responseInput, out float response))
                        {
                            if (response < 0)
                            {
                                Console.WriteLine("Ошибка: Количество топлива не может быть отрицательным!");
                            }
                            else
                            {
                                cars[index].zapravka(response);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Введите корректное число для количества топлива!");
                        }
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("    Текущее состояние машины    ");
                        Console.WriteLine("------------------------------------");
                        cars[index].Out();
                        Console.WriteLine("====================================");
                    }
                    break;

                case "7":
                    {
                        Console.WriteLine("------------------------------------");
                        Console.Write("Перемещение по горизонтали. Введите расстояние (км): ");
                        string moveHorizontalInput = Console.ReadLine();
                        if (float.TryParse(moveHorizontalInput, out float moveHorizontal))
                        {
                            cars[index].moveHorizontal(moveHorizontal);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Введите корректное число для перемещения!");
                        }
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("    Текущее состояние машины    ");
                        Console.WriteLine("------------------------------------");
                        cars[index].Out();
                        Console.WriteLine("====================================");
                    }
                    break;

                case "8":
                    {
                        Console.WriteLine("------------------------------------");
                        Console.Write("Перемещение по вертикали. Введите расстояние (км): ");
                        string moveVerticalInput = Console.ReadLine();
                        if (float.TryParse(moveVerticalInput, out float moveVertical))
                        {
                            cars[index].moveVertical(moveVertical);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Введите корректное число для перемещения!");
                        }
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("    Текущее состояние машины    ");
                        Console.WriteLine("------------------------------------");
                        cars[index].Out();
                        Console.WriteLine("====================================");
                    }
                    break;

                case "9":
                    {
                        Console.WriteLine("====================================");
                        Console.WriteLine("          Вы завершили игру         ");
                        Console.WriteLine("====================================");
                        continueTrips = false;
                    }
                    break;
            }
        }
    }

    public static bool IsValidNumber(string number)
    {
        int juk;
        if (int.TryParse(number, out juk))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
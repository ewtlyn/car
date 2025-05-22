using System;

// класс Avto описывает модель автомобиля с характеристиками и методами для управления
class Avto
{
    public string nomer_avto; // номер машины
    private int kolichestvo_benzina_v_bake; // количество бензина в баке 
    private float rashod_topliva_na_100_km; // расход топлива 
    private float currentSpeed = 0; // текущая скорость 
    private float totalDistance = 0; // Общий пробег 
    public string marka; // марки машин
    private bool inCrashed = false; // попала ли машина в аварию
    private float currentX = 0;
    private float currentY = 0;
    private int maxFuelCapacity;

    public void info()
    {
        Console.Write("Введите номер машины: ");
        nomer_avto = Console.ReadLine();

        Console.Write("Впишите марку машины: ");
        marka = Console.ReadLine();

        bool isValidInput = false;

        // запрашиваем максимальную вместимость бака
        while (!isValidInput)
        {
            Console.Write("Введите максимальную вместимость бака (целое число, больше 0): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out maxFuelCapacity))
            {
                if (maxFuelCapacity > 0)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Ошибка: Вместимость бака должна быть больше 0!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Введите целое число!");
            }
        }
        isValidInput = false;

        // количество бензина
        while (!isValidInput)
        {
            Console.Write($"Введите количество бензина в баке (целое число, не больше {maxFuelCapacity}): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out kolichestvo_benzina_v_bake))
            {
                if (kolichestvo_benzina_v_bake >= 0)
                {
                    if (kolichestvo_benzina_v_bake <= maxFuelCapacity)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: Количество бензина не может превышать вместимость бака ({maxFuelCapacity} литров)!");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: Количество бензина не может быть отрицательным!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Введите целое число!");
            }
        }
        isValidInput = false;

        // расход топлива
        while (!isValidInput)
        {
            Console.Write("Введите расход топлива на 100 км: ");
            string input = Console.ReadLine();
            if (float.TryParse(input, out rashod_topliva_na_100_km))
            {
                if (rashod_topliva_na_100_km >= 0)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Ошибка: Расход топлива не может быть отрицательным!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Введите число!");
            }
        }
    }

    // вывод текущего состояния машины
    public void Out()
    {
        Console.WriteLine("  Номер машины:            " + nomer_avto);
        Console.WriteLine("  Марка машины:            " + marka);
        Console.WriteLine("  Максимальная вместимость: " + maxFuelCapacity + " литров");
        Console.WriteLine("  Количество бензина:      " + kolichestvo_benzina_v_bake + " литров");
        Console.WriteLine("  Расход топлива на 100 км: " + rashod_topliva_na_100_km + " литров");
        Console.WriteLine("  Текущая скорость:        " + currentSpeed + " км/ч");
        Console.WriteLine("  Общий пробег:            " + totalDistance + " км");
        Console.WriteLine("  Текущие координаты:      X: " + currentX + ", Y: " + currentY);
    }

    // метод для заправки
    public void zapravka(float top)
    {
        if (top <= 0)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Ошибка: Нельзя добавить отрицательное количество топлива!");
            Console.WriteLine("------------------------------------");
        }
        else
        {
            int topInt = Convert.ToInt32(top);
            int newFuelLevel = kolichestvo_benzina_v_bake + topInt;
            if (newFuelLevel > maxFuelCapacity)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Ошибка: Нельзя добавить {topInt} литров, так как бак вмещает только {maxFuelCapacity} литров.");
                Console.WriteLine($"Можно добавить не больше {maxFuelCapacity - kolichestvo_benzina_v_bake} литров.");
                Console.WriteLine("------------------------------------");
            }
            else
            {
                kolichestvo_benzina_v_bake += topInt;
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Машина заправлена на {topInt} литров. Теперь в баке {kolichestvo_benzina_v_bake} литров.");
                Console.WriteLine("------------------------------------");
            }
        }
    }

    // метод для получения остатка топлива
    private int ostatok()
    {
        return kolichestvo_benzina_v_bake;
    }

    // метод для установки координат
    public void setCoordinates(float x, float y)
    {
        currentX = x;
        currentY = y;
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Установлены координаты X: {currentX}, Y: {currentY}");
        Console.WriteLine("------------------------------------");
    }

    // получаем координаты
    public void getCoordinates()
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Текущие координаты X: {currentX}, Y: {currentY}");
        Console.WriteLine("------------------------------------");
    }

    // перемещение по горизонтали
    public bool moveHorizontal(float dx)
    {
        // проверяем, не находится ли машина в аварии
        if (inCrashed)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Ошибка: Машина в аварии! Перемещение невозможно.");
            Console.WriteLine("------------------------------------");
            return false;
        }

        if (currentSpeed == 0)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Ошибка: Скорость равна 0, разгонитесь перед перемещением!");
            Console.WriteLine("------------------------------------");
            return false;
        }

        float distance = Math.Abs(dx); // расстояние для расчёта топлива и пробега
        float toplivoNeedX = (distance / 100) * rashod_topliva_na_100_km;
        int toplivoNeedXInt = Convert.ToInt32(Math.Ceiling(toplivoNeedX));
        int currentToplivoX = ostatok();

        // проверяем, достаточно ли топлива
        if (currentToplivoX >= toplivoNeedXInt)
        {
            currentX += dx; // обновляем координату
            kolichestvo_benzina_v_bake -= toplivoNeedXInt; // уменьшаем топливо
            totalDistance += distance; // увеличиваем пробег
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Перемещение по горизонтали на {distance} км успешно выполнено!");
            Console.WriteLine($"Ваши координаты: X: {currentX}, Y: {currentY}");
            Console.WriteLine("------------------------------------");
            return true;
        }
        else
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Недостаточно бензина для перемещения на {distance} км!");
            Console.WriteLine($"Нужно {toplivoNeedXInt} литров, а в баке {currentToplivoX} литров.");
            Console.WriteLine("------------------------------------");
            return false;
        }
    }

    // перемещение по вертикали
    public bool moveVertical(float dy)
    {
        // проверяем, не находится ли машина в аварии
        if (inCrashed)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Ошибка: Машина в аварии! Перемещение невозможно.");
            Console.WriteLine("------------------------------------");
            return false;
        }

        if (currentSpeed == 0)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Ошибка: Скорость равна 0, разгонитесь перед перемещением!");
            Console.WriteLine("------------------------------------");
            return false;
        }

        float distance = Math.Abs(dy); // расстояние для расчёта топлива и пробега
        float toplivoNeedY = (distance / 100) * rashod_topliva_na_100_km;
        int toplivoNeedYInt = Convert.ToInt32(Math.Ceiling(toplivoNeedY));
        int currentToplivoY = ostatok();

        // проверяем, достаточно ли топлива
        if (currentToplivoY >= toplivoNeedYInt)
        {
            currentY += dy; // Обновляем координату
            kolichestvo_benzina_v_bake -= toplivoNeedYInt; // уменьшаем топливо
            totalDistance += distance; // увеличиваем пробег
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Перемещение по вертикали на {distance} км успешно выполнено!");
            Console.WriteLine($"Ваши координаты: X: {currentX}, Y: {currentY}");
            Console.WriteLine("------------------------------------");
            return true;
        }
        else
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Недостаточно бензина для перемещения на {distance} км!");
            Console.WriteLine($"Нужно {toplivoNeedYInt} литров, а в баке {currentToplivoY} литров.");
            Console.WriteLine("------------------------------------");
            return false;
        }
    }

    // метод для поездки от точки до точки
    public bool move(float x1, float y1, float x2, float y2)
    {
        // вычисляем расстояние между точками
        float km = ezda(x1, y1, x2, y2);
        if (currentSpeed == 0)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Ошибка: Скорость равна 0! Разгонитесь перед поездкой.");
            Console.WriteLine("------------------------------------");
            return false;
        }

        // проверяем не находится ли машина в аварии
        if (inCrashed)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Ошибка: Машина в аварии! Поездка дальше невозможна");
            Console.WriteLine("------------------------------------");
            return false;
        }

        // вычисляем сколько топлива нужно для поездки
        float toplivoNeed = (km / 100) * rashod_topliva_na_100_km;
        int toplivoNeedInt = Convert.ToInt32(Math.Ceiling(toplivoNeed));
        int currentToplivo = ostatok();

        // проверяем достаточно ли топлива
        if (currentToplivo >= toplivoNeedInt)
        {
            kolichestvo_benzina_v_bake -= toplivoNeedInt; // уменьшаем топливо
            totalDistance += km; // увеличиваем пробег
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Поездка на {km} км выполнена успешно!");
            Console.WriteLine("------------------------------------");
            return true;
        }
        else
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Недостаточно бензина для поездки на {km} км!");
            Console.WriteLine($"Нужно {toplivoNeedInt} литров, а в баке {currentToplivo} литров.");
            Console.WriteLine("------------------------------------");
            return false;
        }
    }

    // метод для вычисления расстояния между двумя точками
    private float ezda(float x1, float y1, float x2, float y2)
    {
        float result = (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        return result;
    }

    // метод для разгона
    public void razgon(float speedIncrease)
    {
        if (speedIncrease < 0)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Ошибка: Нельзя увеличить скорость на отрицательное значение!");
            Console.WriteLine("------------------------------------");
        }
        else
        {
            currentSpeed = speedIncrease + currentSpeed;
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Скорость увеличена на {speedIncrease} км/ч.");
            Console.WriteLine($"Текущая скорость: {currentSpeed} км/ч.");
            Console.WriteLine("------------------------------------");
        }
    }

    // метод для торможения
    public void tormozhenie(float speedDecrease)
    {
        if (speedDecrease < 0)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Ошибка: Нельзя уменьшить скорость на отрицательное значение!");
            Console.WriteLine("------------------------------------");
        }
        else
        {
            currentSpeed = currentSpeed - speedDecrease;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Скорость уменьшена на {speedDecrease} км/ч.");
            Console.WriteLine($"Текущая скорость: {currentSpeed} км/ч.");
            Console.WriteLine("------------------------------------");
        }
    }

    // метод для аварии
    public void avaria()
    {
        inCrashed = true;
        currentSpeed = 0;
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Вы попали в аварию! Поездка дальше невозможна");
        Console.WriteLine("------------------------------------");
    }
}
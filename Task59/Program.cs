// Задача 59: Из двумерного массива целых чисел удалить строку и столбец,
// на пересечении которых расположен наименьший элемент.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Наименьший элемент - 1, на выходе получим
// следующий массив:
// 9 4 2
// 2 2 6
// 3 4 7

using System;
using static System.Console;
Clear();

Write("Введите размеры массива через пробел: ");
string[] nums = ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
WriteLine();
if(int.Parse(nums[0]) * int.Parse(nums[1]) > 100)
{
    WriteLine("Невозможно создать массив из неповторяющихся элементов");
    return;
}
int[,] array = GetArray(new int[] {int.Parse(nums[0]), int.Parse(nums[1])}, 0, 100);
PrintArray(array);

int x = 0;
int y = 0;
int min = array[0, 0];
for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        if (array[i, j] < min)
        {
            min = array[i, j];
            x = i;
            y = j;
        }
    }
}
WriteLine("Наименьший элемент в матрице: " + min);
WriteLine();
WriteLine("Вывод преобразованной матрицы:");
WriteLine();
for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        {
            if ((i == x) || (j == y)) continue;
            else Write(array[i, j] + " ");
        }
    }
    WriteLine();
}

int[,] GetArray(int[] sizes, int min, int max)
{
    int[,] result = new int[sizes[0], sizes[1]];
    for(int i = 0; i < result.GetLength(0); i++) 
    {
        int j = 0; 
        while(j< result.GetLength(1))
        {
            int element = new Random().Next(min, max + 1); 
            if(FindElement(result, element)) continue;  
            result[i, j] = element; 
            j++;
        }
    }
    return result;
}
bool FindElement(int[,] array, int el)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
           if(array[i, j] == el) return true;
        }
    }
    return false;
}
void PrintArray(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            Write($"{array[i, j]} ");
        }
        WriteLine();
    } 
}
WriteLine();


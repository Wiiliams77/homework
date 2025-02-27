﻿using System;

class Calculator
{
    static void Main()
    {
        
        Console.Write("请输入第一个数字: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        
        Console.Write("请输入运算符 (+, -, *, /): ");
        string operation = Console.ReadLine();

        
        Console.Write("请输入第二个数字: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        
        double result = 0;
        bool validOperation = true;

        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else
                {
                    validOperation = false;
                    Console.WriteLine("错误：除数不能为零!");
                }
                break;
            default:
                validOperation = false;
                Console.WriteLine("错误：无效的运算符!");
                break;
        }

        
        if (validOperation)
        {
            Console.WriteLine($"结果: {num1} {operation} {num2} = {result}");
        }
    }
}
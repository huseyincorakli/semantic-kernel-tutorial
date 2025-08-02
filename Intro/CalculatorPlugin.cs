using System;
using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace Intro;

public class CalculatorPlugin
{
    [KernelFunction("add")]
    [Description("İki sayısal değer üzerinde toplama işlemi gerçekleştirir.")]
    [return: Description("Toplam değeri döndürür.")]
    public int Add(int number1, int number2)
    {
        System.Console.WriteLine("çalıştı");
        System.Console.WriteLine($"sayılar :{number1} {number2}");
        return number1 + number2;
    }


    [KernelFunction("multiply")]
    [Description("iki sayısal değer üzerinden çarpma işlemi yapar")]
    [return: Description("çarpım sonucunu dönderir")]
    public int Multiply(int number1, int number2)
    {
        System.Console.WriteLine("Çarpma çalıştı");
        return number1 * number2;
    }
}

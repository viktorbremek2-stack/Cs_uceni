using System;

string answer = "";
do
{
  Console.WriteLine("Write your first number:");
  double num1 = Convert.ToDouble(Console.ReadLine());

  Console.WriteLine("Enter type of your operation (+-/*)");
  string operation = Console.ReadLine();

  Console.WriteLine("Write your second number:");
  double num2 = Convert.ToDouble(Console.ReadLine());

  double result = 0;

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
        Console.WriteLine("Error: you can't divide by zero.");
        continue;
      }
      break;
    default:
      Console.WriteLine("Error: Invalid operation.");
      continue;
  }

  Console.WriteLine(num1 + " " + operation + " " + num2 + " = " + result);

  Console.WriteLine("Do you want to continue? (yes/no)");
  answer = Console.ReadLine();
}
while (answer.ToLower() == "yes");
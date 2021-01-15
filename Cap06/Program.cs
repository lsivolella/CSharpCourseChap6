using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cap06
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise04();
        }

        private static void Exercise01()
        {
            Student[] pensionRoom = new Student[10];

            Console.Write("Type in the number of students that are going to rent a room (1 to 10): ");
            int n = int.Parse(Console.ReadLine());

            if (n < 1 || n > 10)
            {
                Console.Write("The number of students needs to be higher than 1 and lower than 10. Type in again: ");
                n = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Rent #{0}:", i);
                Console.Write("Type in the Room number the student wish to rent (0 to 9): ");
                int roomNumber = int.Parse(Console.ReadLine());
                Console.Write("Type in the name of the student for Room " + roomNumber + ": ");
                string tenantName = Console.ReadLine();
                Console.Write("Type in the Email of the student for Room " + roomNumber + ": ");
                string tenantEmail = Console.ReadLine();

                pensionRoom[roomNumber] = new  Student(tenantName, tenantEmail);
            }

            Console.WriteLine();
            Console.WriteLine("Busy Pension Rooms: ");
            for (int i = 1; i <= 10; i++)
            {
                if (pensionRoom[i] != null)
                {
                    Console.WriteLine("Room #" + i + ": " + pensionRoom[i]);
                }
            }
        }

        private static void Exercise02()
        {
            List<Employee> employess = new List<Employee>();

            Console.Write("How many employees will be registred: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine();
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Employee #{0}:", i);
                Console.Write("ID#: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Wage: ");
                double wage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine();

                if (employess.Find(x => x.Id == id) == null)
                    employess.Add(new Employee(id, name, wage));
                else
                {
                    Console.WriteLine();
                    Console.Write("The ID# provided is already in use. Please, type in another ID#: ");
                    id = int.Parse(Console.ReadLine());
                    employess.Add(new Employee(id, name, wage));
                }
            }

            Console.WriteLine();
            Console.Write("Enter the ID# of the employee that will have a salary raise: ");
            int searchId = int.Parse(Console.ReadLine());

            if (employess.Find(x => x.Id == searchId) == null)
                Console.WriteLine("Invalid ID#.");
            else
            {
                Console.WriteLine("Type in the wage raise: ");
                double raise = double.Parse(Console.ReadLine());
                Employee searchedEmployee = employess.Find(x => x.Id == searchId);
                searchedEmployee.RaiseWage(raise);
            }

            Console.WriteLine();
            Console.WriteLine("Updated list of employees:");
            foreach (Employee employee in employess)
            {
                Console.Write(employee.ToString());
                Console.WriteLine();
            }
        }

        private static void Exercise03()
        {
            Console.Write("Enter the size for a N x N matrix: ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            /*
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("Enter a value for the [{0},{1}] position: ", i, j);
                    int number = int.Parse(Console.ReadLine());
                    matrix[i, j] = number;
                }
            }

            foreach (int number in matrix)
            {
                Console.WriteLine(number);
            }
            */

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("Enter {0} number(s) for row {1}: ", n, i);
                string[] values = Console.ReadLine().Split(' ');

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(values[j]);
                }
            }

            Console.WriteLine("Main Daiagonal: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(matrix[i, i] + " ");
            }

            Console.WriteLine();
            int negativeNumbers = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        negativeNumbers++;
                }
            }
            Console.WriteLine("Negative Numbers: ");
            Console.WriteLine(negativeNumbers);
        }

        private static void Exercise04()
        {
            Console.Write("Enter the number of rows for the Matrix: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of columns for the Matrix: ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[m, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("Enter a integer number for position [{0}, {1}]: ", i, j);
                    int number = int.Parse(Console.ReadLine());
                    matrix[i, j] = number;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.Write("Enter a number that exists in the Matrix to see its neighbors: ");
            int checkNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Number: " + checkNumber);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == checkNumber)
                    {
                        Console.WriteLine("Position [{0},{1}]: ", i, j);
                        if (j > 0)
                            Console.WriteLine("Left: " + matrix[i, j-1]);
                        if (i > 0)
                            Console.WriteLine("Up: " + matrix[i-1, j]);
                        if (j < n - 1)
                            Console.WriteLine("Right: " + matrix[i, j+1]);
                        if (i < m - 1)
                            Console.WriteLine("Down: " + matrix[i+1, j]);
                    }
                }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Cap06
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Wage { get; private set; }

        public Employee() { }

        public Employee(int id, string name, double wage)
        {
            Id = id;
            Name = name;
            Wage = wage;
        }

        public void RaiseWage(double raise)
        {
            Wage += Wage * raise / 100.0;
        }


        public override string ToString()
        {
            return "ID#: " + Id
                + ", Name: " + Name
                + ", Wage: " + Wage.ToString("f2", CultureInfo.InvariantCulture);
        }
    }
}

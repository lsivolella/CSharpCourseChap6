using System;
using System.Collections.Generic;
using System.Text;

namespace Cap06
{
    class Student
    {
        public string TenantName { get; set; }
        public string TenantEmail { get; set; }

        public Student()
        {

        }

        public Student(string tenantName, string tenantEmail)
        {
            TenantName = tenantName;
            TenantEmail = tenantEmail;
        }

        public override string ToString()
        {
            return "Tenant Name: " + TenantName
                + "\nTenant Email: " + TenantEmail;
        }
    }
}

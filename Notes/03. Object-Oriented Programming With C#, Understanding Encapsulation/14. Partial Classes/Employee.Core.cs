using System;

namespace Notes {
    public partial class Employee {
        private string empName;
        private int empId;
        private float currentPay;
        private int ssn;

        // USING AUTOMATIC PROPERTY
        public int Age { get; set; }

        // STATIC MEMBER
        private static int empCount;

        static Employee() {
            // INITIALLY COMPANY HAS 1000 EMPLOYEES
            Count = 1000;
        }

        public Employee() { }
        public Employee(String empName, int empId, float currentPay, int ssn) : this(empName, 0, empId, currentPay, ssn) { }
        public Employee(String empName, int empAge, int empId, float currentPay, int ssn) {

            // IN ORDER TO VALUDATE THESE VALUES
            // ASSIGN THEM TO PROPERTY NAMES NOT TO RAW VARIABLES
            // this.empAge = empAge;
            // this.empName = empName;
            // this.empId = empId;

            this.Name = empName;
            this.Age = empAge;
            this.ID = empId;
            this.Pay = currentPay;

            Count++;

            // THIS DOES NOT HAVE PROPERTY SO IT CAN BE ASSIGNED DIRECTLY
            this.ssn = ssn;
        }
    }
}
using System;

namespace Employees {
    public abstract partial class Employee {

        protected string empName;
        protected int empId;
        protected float currentPay;
        protected int ssn;
        protected int age;
        protected BenefitPackage empBenefits = new BenefitPackage();

        public Employee() { }
        public Employee(String empName, int empId, float currentPay, int ssn) : this(empName, 0, empId, currentPay, ssn) { }
        public Employee(String empName, int empAge, int empId, float currentPay, int ssn) {
            this.Name = empName;
            this.Age = empAge;
            this.ID = empId;
            this.Pay = currentPay;
            this.ssn = ssn;
        }
    }
}
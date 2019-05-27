using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees {
    public abstract partial class Employee {
        public class BenefitPackage {
            public enum BenefitPackageLevel {
                Standard, Gold, Platinum
            }
            public double ComputePayDeduction() {
                return 125.0;
            }
        }
    }
}

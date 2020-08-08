using System;
using System.Collections.Generic;
using System.Text;

namespace UsandoInterfaces.Services {
    class PayPal : IPaymentService{
        public double Quota(double amount, int installments) {
            amount += amount * (0.01 * installments);
            double tax = 0.02;
            return amount += amount * tax;            
        }
    }
}

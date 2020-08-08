using System;
using System.Collections.Generic;
using System.Text;

namespace UsandoInterfaces.Services {
    class PayPal : IPaymentService{

        private const double _feePercentage = 0.02;
        private const double _monthlyInterest = 0.01;

        public double Interest(double amount, int months) {
            return amount * _monthlyInterest * months;
        }

        public double PaymentFee(double amount) {
            
            return amount * _feePercentage;            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using UsandoInterfaces.Entities;


namespace UsandoInterfaces.Services {
    class ProcessService {

        private IPaymentService _paymentService;

        public ProcessService(IPaymentService paymentService) {
            _paymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int months) {
            double installmentValue = contract.TotalValue / months;
            List<Installment> list = new List<Installment>();
            for (int i = 1; i <= months; i++) {
                DateTime date = contract.Date.AddMonths(i);
                double updateQuota = installmentValue + _paymentService.Interest(installmentValue, i);
                double fullQuota = updateQuota + _paymentService.PaymentFee(updateQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }       

    }
}

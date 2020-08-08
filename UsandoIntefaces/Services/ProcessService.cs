using System;
using System.Collections.Generic;
using System.Text;
using UsandoInterfaces.Entities;


namespace UsandoInterfaces.Services {
    class ProcessService {
        public Contract Contract { get; set; }

        private IPaymentService _paymentService;

        public ProcessService(Contract contract, IPaymentService paymentService) {
            Contract = contract;
            _paymentService = paymentService;
        }

        public List<Installment> Total(int installment) {
            double installmentValue = Contract.TotalValue / installment;
            List<Installment> list = new List<Installment>();
            for (int i = 1; i <= installment; i++) {
                DateTime date = Contract.Date.AddMonths(i);
                
                list.Add(new Installment(date, _paymentService.Quota(installmentValue, i)));
            }

            return list;
        }       

    }
}

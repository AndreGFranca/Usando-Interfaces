namespace UsandoInterfaces.Services {
    interface IPaymentService {
       double PaymentFee(double amount);

        double Interest(double amount, int months);
    }
}

namespace Education.Financial.Domain.Financial;

public class Invoice
{
    public Guid Id { get; set; }
    public Guid SourceId { get; set; }
    public decimal Price { get; set; }
    public PaymentType PaymentType { get; set; }
    public InvoiceType Type { get; set; }
}

public enum PaymentType
{
    NotPay = 0,
    PayedSuccessful = 1,
    PaymentFailed = 3,
}

public enum InvoiceType
{
    Registration = 1
}
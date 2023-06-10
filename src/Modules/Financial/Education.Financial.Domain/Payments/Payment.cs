namespace Education.Financial.Domain.Payments;

public class Payment
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public string? ReferenceId { get; set; }
    public bool IsSuccess { get; set; }
}
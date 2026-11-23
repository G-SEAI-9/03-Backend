// We only need to iterate; callers can pass arrays, lists, EF queries, etc.
public class InvoiceLine
{
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}

class InvoiceService
{
    public decimal CalculateTotal(IEnumerable<InvoiceLine> lines)
    {
        decimal total = 0m;
        foreach (var line in lines)
        {
            total += line.UnitPrice * line.Quantity;
        }
        return total;
    }
}

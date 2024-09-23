using Microsoft.EntityFrameworkCore;
using orders.Domain;

namespace orders.Repository.Impl;

public class PaymentRepositoryImpl : IPaymentRepository
{
    private readonly DatabaseContext _context;

    public PaymentRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    public void SavePayment(Payment payment)
    {
        _context.Payments.AddAsync(payment).GetAwaiter();

        _context.SaveChangesAsync().GetAwaiter(); ;
    }

    public async Task<Payment?> GetPaymentById(int id)
    {
        return await _context.Payments.FindAsync(id);
    }

    public async Task<List<Payment>> GetPayments()
    {
        return await _context.Payments.ToListAsync();
    }

    public async void UpdatePayment(Payment payment)
    {
        _context.Payments.Update(payment);

        await _context.SaveChangesAsync();
    }
}
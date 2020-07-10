using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SterkinekorMoviesAPI.Models;

namespace SterkinekorMoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly SterkinekorContext _context;

        public PaymentController(SterkinekorContext context)
        {
            _context = context;
        }

        // GET: api/Payment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayment()
        {
            return await _context.Payment.ToListAsync();
        }

        // GET: api/TaskLists
        //http://localhost:56236/api/payment/getpaymentdetails?cartid=1&itemid=1
        [HttpGet]
        [Route("GetPaymentDetails")]
        public async Task<ActionResult<IEnumerable<PaymentViewModel>>> GetPaymentDetails(int itemId, int cartId)
        {
            return await _context.PaymentViewModels.FromSqlInterpolated($"[dbo].[getPaymentDetails] {cartId},{itemId}").ToListAsync();
            //return await _context.Tasks.ToListAsync();
        }


        //// GET: api/Payment/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Payment>> GetPayment(int id)
        //{
        //    var payment = await _context.Payment.FindAsync(id);

        //    if (payment == null)
        //    {
        //        return NotFound();
        //    }

        //    return payment;
        //}

        // PUT: api/Payment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.paymentId)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Payment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayment", new { id = payment.paymentId }, payment);
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Payment>> DeletePayment(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        private bool PaymentExists(int id)
        {
            return _context.Payment.Any(e => e.paymentId == id);
        }
    }
}

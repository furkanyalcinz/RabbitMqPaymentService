using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentClient.Services;
using SharedModels.Models;

namespace PaymentClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentRequestController : ControllerBase
    {
        private IPaymentRequestService _paymentRequestService;
        public PaymentRequestController(IPaymentRequestService paymentRequestService)
        {
            _paymentRequestService = paymentRequestService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePaymentRequest(PaymentRequestDto paymentRequest)
        {
            await _paymentRequestService.CreateRequest(paymentRequest);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetPaymentStatus(string paymentRequestId)
        {
            return Ok(await _paymentRequestService.GetTransactionStatusResponseAsync(paymentRequestId));
        }
    }
}

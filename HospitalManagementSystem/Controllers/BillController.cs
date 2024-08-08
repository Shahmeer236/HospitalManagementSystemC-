using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BillController : ControllerBase
{
    private readonly IBillService _billService;

    public BillController(IBillService billService)
    {
        _billService = billService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BillDto>> GetBillById(Guid id)
    {
        var bill = await _billService.GetBillByIdAsync(id);
        if (bill == null)
        {
            return NotFound();
        }

        return Ok(bill);
    }

    [HttpGet]
    public async Task<ActionResult<List<BillForListing>>> GetBills()
    {
        var bills = await _billService.GetBillsAsync();
        return Ok(bills);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBill([FromBody] BillForCreation billForCreation)
    {
        try
        {
            var billId = await _billService.CreateBillAsync(billForCreation);
            return CreatedAtAction(nameof(GetBillById), new { id = billId }, billId);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBill(Guid id, [FromBody] BillForUpdation billForUpdation)
    {
        if (id != billForUpdation.Id)
        {
            return BadRequest();
        }

        var result = await _billService.UpdateBillAsync(billForUpdation);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBill(Guid id)
    {
        var result = await _billService.DeleteBillAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

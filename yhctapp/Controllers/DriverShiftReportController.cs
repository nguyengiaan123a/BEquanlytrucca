using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using yhctapp.Hubs;
using yhctapp.Model.Enitity;
using yhctapp.Services.Interface;
using Microsoft.EntityFrameworkCore;
using yhctapp.Data;

namespace yhctapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverShiftReportController : BaseCrudController<DriverShiftReport, DriverShiftReport>
    {
        private readonly IDriverShiftReport _driverShiftReport;
        private readonly IHubContext<ShiftReportHub> _hubContext;
        private readonly MyDbcontext _context; // Dùng để truy vấn Stats nhanh hơn

        public DriverShiftReportController(
            IGenericRepository<DriverShiftReport> repo, 
            IMapper mapper, 
            IDriverShiftReport driverShiftReport,
            IHubContext<ShiftReportHub> hubContext,
            MyDbcontext context) 
            : base(repo, mapper)
        {
            _driverShiftReport = driverShiftReport;
            _hubContext = hubContext;
            _context = context;
        }

        public override async Task<IActionResult> Add([FromBody] DriverShiftReport entityVM)
        {
            var result = await base.Add(entityVM);
            
            // Nếu gọi base.Add thành công (thường trả về OkObjectResult nếu Code == 1)
            if (result is OkObjectResult)
            {
                // Bắn sự kiện realtime cho Frontend
                await _hubContext.Clients.All.SendAsync("NewDriverReport", entityVM);
            }
            
            return result;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var reports = await _context.DriverShiftReports.AsNoTracking().ToListAsync();
            
            var totalShifts = reports.Count;
            var totalEndingMileage = reports.Sum(x => x.EndingMileage);
            var totalHospitalTransfers = reports.Sum(x => x.HospitalTransferCount);
            var totalOutsideEmergencies = reports.Sum(x => x.OutsideEmergencyCount);
            var totalIncidents = reports.Count(x => x.Incidents != "KHÔNG" && !string.IsNullOrEmpty(x.Incidents));

            // Dữ liệu biểu đồ 7 ngày gần nhất
            var last7Days = Enumerable.Range(0, 7)
                .Select(i => DateTime.Today.AddDays(-i))
                .Select(date => new
                {
                    Date = date.ToString("dd/MM"),
                    Count = reports.Count(x => x.Date.Date == date)
                })
                .Reverse()
                .ToList();

            return Ok(new
            {
                TotalShifts = totalShifts,
                TotalEndingMileage = totalEndingMileage,
                TotalHospitalTransfers = totalHospitalTransfers,
                TotalOutsideEmergencies = totalOutsideEmergencies,
                TotalIncidents = totalIncidents,
                ChartData = last7Days
            });
        }
    }
}

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
    public class SecurityGuardShiftReportController : BaseCrudController<SecurityGuardShiftReport, SecurityGuardShiftReport>
    {
        private readonly ISecurityGuardShiftReport _securityGuardShiftReport;
        private readonly IHubContext<ShiftReportHub> _hubContext;
        private readonly MyDbcontext _context;

        public SecurityGuardShiftReportController(
            IGenericRepository<SecurityGuardShiftReport> repo, 
            IMapper mapper, 
            ISecurityGuardShiftReport securityGuardShiftReport,
            IHubContext<ShiftReportHub> hubContext,
            MyDbcontext context) 
            : base(repo, mapper)
        {
            _securityGuardShiftReport = securityGuardShiftReport;
            _hubContext = hubContext;
            _context = context;
        }

        public override async Task<IActionResult> Add([FromBody] SecurityGuardShiftReport entityVM)
        {
            var result = await base.Add(entityVM);
            
            // Nếu gọi base.Add thành công
            if (result is OkObjectResult)
            {
                // Bắn sự kiện realtime cho Frontend
                await _hubContext.Clients.All.SendAsync("NewSecurityReport", entityVM);
            }
            
            return result;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var reports = await _context.SecurityGuardShiftReports.AsNoTracking().ToListAsync();
            
            var totalShifts = reports.Count;
            var nightShifts = reports.Count(x => x.ShiftType == "CA ĐÊM");
            var dayShifts = reports.Count(x => x.ShiftType == "CA NGÀY");
            
            // Tìm các ca có báo cáo sự cố (PatrolTasks chứa cụm từ báo lỗi hoặc sự cố, hoặc Proposals có nội dung)
            // Vì biểu mẫu dùng "Không phát hiện bất thường", nếu không có dòng này hoặc thêm nội dung khác -> có sự cố
            var totalIncidents = reports.Count(x => !string.IsNullOrEmpty(x.PatrolTasks) && !x.PatrolTasks.Contains("Không phát hiện bất thường"));

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
                NightShifts = nightShifts,
                DayShifts = dayShifts,
                TotalIncidents = totalIncidents,
                ChartData = last7Days
            });
        }
    }
}

using yhctapp.Data;
using yhctapp.Model.Enitity;
using yhctapp.Services.Interface;

namespace yhctapp.Services.Responsive
{
    public class DriverShiftReportResponsive : GenericRepository<DriverShiftReport>, IDriverShiftReport
    {
        public DriverShiftReportResponsive(MyDbcontext context) : base(context)
        {
        }
    }
}

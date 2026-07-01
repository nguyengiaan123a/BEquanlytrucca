using yhctapp.Data;
using yhctapp.Model.Enitity;
using yhctapp.Services.Interface;

namespace yhctapp.Services.Responsive
{
    public class SecurityGuardShiftReportResponsive : GenericRepository<SecurityGuardShiftReport>, ISecurityGuardShiftReport
    {
        public SecurityGuardShiftReportResponsive(MyDbcontext context) : base(context)
        {
        }
    }
}

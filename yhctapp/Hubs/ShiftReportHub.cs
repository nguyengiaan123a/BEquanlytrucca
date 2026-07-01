using Microsoft.AspNetCore.SignalR;

namespace yhctapp.Hubs
{
    public class ShiftReportHub : Hub
    {
        // Hub này được sử dụng để gửi các tin nhắn dạng Real-time
        // Không cần viết hàm ở đây nếu Server chủ động gửi (push) dữ liệu xuống Client.
        
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}

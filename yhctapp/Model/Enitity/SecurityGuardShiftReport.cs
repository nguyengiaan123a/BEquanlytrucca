using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using yhctapp.Model.Enitity.Base;

namespace yhctapp.Model.Enitity
{
    public class SecurityGuardShiftReport : BaseDomainEnitity
    {
        [NotMapped]
        public new string? Title { get; set; }

        [NotMapped]
        public new int Status { get; set; }

        [NotMapped]
        public new string? Thumnail { get; set; }

        [Required]
        public string ShiftType { get; set; } // CA NGÀY, CA ĐÊM

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [MaxLength(200)]
        public string ShiftLeaderName { get; set; }

        public string? ShiftPositions { get; set; }

        public string? SecurityTasks { get; set; }

        public string? PatrolTasks { get; set; }

        public string? ParkingTasks { get; set; }

        public string? PropertyTasks { get; set; }

        public string? HandoverTasks { get; set; }

        public string Proposals { get; set; } // Đề xuất

        public bool IsConfirmed { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using yhctapp.Model.Enitity.Base;

namespace yhctapp.Model.Enitity
{
    public class DriverShiftReport : BaseDomainEnitity
    {
        [NotMapped]
        public new string? Title { get; set; }

        [NotMapped]
        public new int Status { get; set; }

        [NotMapped]
        public new string? Thumnail { get; set; }

        [Required]
        public string ShiftType { get; set; } // CA NGÀY, CA ĐÊM, HÀNH CHÍNH

        public DateTime Date { get; set; }

        [Required]
        [MaxLength(200)]
        public string DriverName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; }

        public int StartingMileage { get; set; }

        // GIẤY TỜ PHÁP LÝ
        public string? RegistrationPaper { get; set; }
        public string? InspectionCertificate { get; set; }
        public string? PriorityCertificate { get; set; }
        public string? InsuranceCertificate { get; set; }

        // TỔNG QUAN THIẾT BỊ XE
        public string? Dashcam { get; set; }
        public string? AirConditioner { get; set; }
        public string? TirePressure { get; set; }
        public string? SpareTire { get; set; }
        public string? ExteriorInspection { get; set; }
        public string? LightsAndWipers { get; set; }
        public string? BrakesAndSteering { get; set; }
        public string? FireExtinguisherAndFirstAid { get; set; }
        public string? JackAndWrench { get; set; }
        public string? Battery { get; set; }
        public string? Gasoline { get; set; }
        public string? Diesel { get; set; }
        public string? MotorOil { get; set; }
        public string? Coolant { get; set; }
        public string? Oxygen { get; set; }
        public string? VehicleHygiene { get; set; }

        // TỔNG SỐ KM VÀ CHUYẾN ĐI
        public int EndingMileage { get; set; }
        public int HospitalTransferCount { get; set; }
        public int OutsideEmergencyCount { get; set; }
        public int AdminWorkCount { get; set; }

        public string? Incidents { get; set; } // SỰ CỐ PHÁT SINH
    }
}

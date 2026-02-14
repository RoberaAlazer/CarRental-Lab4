namespace Maintenance.WebAPI.Services
{
    public class FakeRepairHistoryService : IRepairHistoryService
    {
        public List<RepairHistoryDto> GetByVehicleId(int vehicleId)
        {
            var all = new List<RepairHistoryDto>
    {
        new RepairHistoryDto
        {
            Id = 1,
            VehicleId = 1,
            RepairDate = DateTime.Now.AddDays(-10),
            Description = "Oil change",
            Cost = 89.99m,
            PerformedBy = "Quick Lube"
        },
        new RepairHistoryDto
        {
            Id = 2,
            VehicleId = 2,
            RepairDate = DateTime.Now.AddDays(-40),
            Description = "Brake pad replacement",
            Cost = 350.00m,
            PerformedBy = "Auto Repair Pro"
        },
        new RepairHistoryDto
        {
            Id = 3,
            VehicleId = 3,
            RepairDate = DateTime.Now.AddDays(-30),
            Description = "Tire rotation",
            Cost = 49.99m,
            PerformedBy = "Tire World"
        }
    };

            return all.Where(x => x.VehicleId == vehicleId).ToList();
        }
    }
}
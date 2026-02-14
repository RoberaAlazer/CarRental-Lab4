using System.Collections.Generic;

namespace _8768364RobbieAlazer_MVC.Models
{
    public class RepairHistoryPageViewModel
    {
        public int? VehicleId { get; set; }
        public List<RepairHistoryViewModel> Repairs { get; set; } = new();
    }
}

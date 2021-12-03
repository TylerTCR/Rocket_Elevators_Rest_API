using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApi.Models
{
    public partial class Column
    {
        public Column()
        {
            Elevators = new HashSet<Elevator>();
            Interventions = new HashSet<Intervention>();
        }

        public long Id { get; set; }
        public string ColumnType { get; set; }
        public int? NumberOfFloor { get; set; }
        public string Status { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? BatteryId { get; set; }

        public virtual Battery Battery { get; set; }
        public virtual ICollection<Elevator> Elevators { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}

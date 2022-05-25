using System;
using System.Collections.Generic;
using System.Text;

namespace DashTripMobile.Models
{
    public class Trip
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set;}
        public DateTimeOffset? FinishedAt { get; set; }

        public TransportType TransportType { get; set; }

        public Vehicle Vehicle { get; set; }

        public string StartAddress { get; set; }
        public string FinishAddress { get; set; }

        public string TransportInfo
        {
            get
            {
                if (TransportType == TransportType.Vehicle)
                {
                    return $"{Enum.GetName(typeof(TransportType), TransportType)} - {Vehicle.Name} ({Enum.GetName(typeof(VehicleType), Vehicle.Type)})";
                }
                return Enum.GetName(typeof(TransportType), TransportType);
            }
        }

        public TimeSpan Duration
        {
            get
            {
                DateTimeOffset last = FinishedAt.HasValue ? FinishedAt.Value : DateTimeOffset.UtcNow;
                TimeSpan span = (last - CreatedAt);
                return span;
            }
        }

        public string DurationFormated
        {
            get
            {
                var d = Duration;
                if (d.Hours > 0)
                    return string.Format("{0:D1}h {1:D2}m {2:D2}s", d.Hours, d.Minutes, d.Seconds);
                else if (d.Minutes > 0)
                    return string.Format("{0:D2}m {1:D2}s", d.Minutes, d.Seconds);
                else
                    return string.Format("{0:D2}s", d.Seconds);
            }
        }
    }

    public enum TransportType
    {
        Walking,
        PublicTransport,
        Vehicle,
    }
}

namespace ASP.Net_HW_02._03._25.Models
{
    public class AnimalDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public virtual string Sound { get; } = "Unknown sound";

        public string? OtherInfo { get; set; }
        //public abstract string GetSound();
    }
}

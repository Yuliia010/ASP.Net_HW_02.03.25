namespace ASP.Net_HW_02._03._25.Models.Shapes
{
    public class ShapeBaseDto
    {
        public Guid Id { get; set; }
        public virtual string Type { get; set; } = "Unknown type";
        public virtual string Presentation { get; set; } = " ";
        public string? OtherInfo { get; set; }
    }
}

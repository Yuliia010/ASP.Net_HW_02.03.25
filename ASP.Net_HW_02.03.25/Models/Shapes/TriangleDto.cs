namespace ASP.Net_HW_02._03._25.Models.Shapes
{
    public class TriangleDto : ShapeBaseDto
    {
        public double Base { get; set; } 
        public double Height { get; set; }
        public override string Type => "Triangle";
        public override string Presentation =>
    "      *      \n" +
    "     ***     \n" +
    "    *****    \n" +
    "   *******   \n" +
    "  *********  \n" +
    " *********** \n" +
    "*************";
    }
}

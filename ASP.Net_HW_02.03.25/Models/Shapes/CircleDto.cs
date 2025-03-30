namespace ASP.Net_HW_02._03._25.Models.Shapes
{
    public class CircleDto : ShapeBaseDto
    {
        public double Radius { get; set; }
        public override string Type => "Circle";
        public override string Presentation =>
     "    * * *   \n" +
     "  *       *  \n" +
     " *         * \n" +
     " *         * \n" +
     "  *       *  \n" +
     "    * * *   ";
    }
}

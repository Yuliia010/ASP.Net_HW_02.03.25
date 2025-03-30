namespace ASP.Net_HW_02._03._25.Models.Shapes
{
    public class SquareDto : ShapeBaseDto
    {
        
        public double Side { get; set; }
        public override string Type => "Square";
        public override string Presentation =>
     "* * * * * *\n" +
     "* * * * * *\n" +
     "* * * * * *\n" +
     "* * * * * *\n" +
     "* * * * * *";
    }
}

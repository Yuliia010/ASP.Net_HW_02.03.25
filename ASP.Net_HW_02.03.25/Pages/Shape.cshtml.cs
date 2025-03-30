using ASP.Net_HW_02._03._25.Abstract;
using ASP.Net_HW_02._03._25.Models.Shapes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

namespace ASP.Net_HW_02._03._25.Pages
{
    public class ShapeModel : PageModel
    {
        [BindProperty]
        public ShapeBaseDto Shape { get; set; }
        [BindProperty]
        public double Radius { get; set; }

        [BindProperty]
        public double Side { get; set; }

        [BindProperty]
        public double Base { get; set; }

        [BindProperty]
        public double Height { get; set; }

        [BindProperty]
        public string SelectedShapeType { get; set; } = "Other";

        public List<SelectListItem> ShapeTypes { get; set; }

        public List<ShapeBaseDto> Shapes { get; set; } = new List<ShapeBaseDto>();

        private readonly IShapeService _shapeService;
        public ShapeModel(IShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        public async Task OnGetAsync()
        {
            Shapes = await _shapeService.GetAllAsync();


            ShapeTypes = new List<SelectListItem>
            {
                new SelectListItem { Value = "Circle", Text = "Circle" },
                new SelectListItem { Value = "Square", Text = "Square" },
                new SelectListItem { Value = "Triangle", Text = "Triangle" },
                new SelectListItem { Value = "Other", Text = "ќбер≥ть вид" }
            };
            if (string.IsNullOrEmpty(SelectedShapeType))
            {
                SelectedShapeType = "Other";
            }
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (string.IsNullOrEmpty(SelectedShapeType))
            {
                SelectedShapeType = "Other";
            }

            ShapeBaseDto newShape;

            switch (SelectedShapeType)
            {
                case "Circle":
                    newShape = new CircleDto
                    {
                        Type = SelectedShapeType,
                        OtherInfo = Shape.OtherInfo,
                        Radius = Radius 
                    };
                    break;
                case "Square":
                    newShape = new SquareDto
                    {
                        Type = SelectedShapeType,
                        OtherInfo = Shape.OtherInfo,
                        Side = Side 
                    };
                    break;
                case "Triangle":
                    newShape = new TriangleDto
                    {
                        Type = SelectedShapeType,
                        OtherInfo = Shape.OtherInfo,
                        Base = Base,   
                        Height = Height 
                    };
                    break;
                case "Other":
                default:
                    newShape = new ShapeBaseDto
                    {
                        Type = SelectedShapeType,
                        OtherInfo = Shape.OtherInfo
                    };
                    break;
            }

            await _shapeService.AddAsync(newShape);
            return RedirectToPage("/Shape");
        }

    }

}


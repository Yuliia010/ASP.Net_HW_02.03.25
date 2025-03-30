using ASP.Net_HW_02._03._25.Abstract;
using ASP.Net_HW_02._03._25.DAL.Abstract;
using ASP.Net_HW_02._03._25.DAL.Entities;
using ASP.Net_HW_02._03._25.Models.Animals;
using ASP.Net_HW_02._03._25.Models.Shapes;
using System.Text.RegularExpressions;

namespace ASP.Net_HW_02._03._25.Core
{
    public class ShapeService : IShapeService
    {
        private readonly IShapeRepository _repository;
        public ShapeService(IShapeRepository repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(ShapeBaseDto shape)
        {
            shape.Id = Guid.NewGuid();

            string parametersInfo = string.Empty;

            if (shape is CircleDto circleDto)
            {
                parametersInfo = $"radius: {circleDto.Radius}";
            }
            else if (shape is SquareDto squareDto)
            {
                parametersInfo = $"side: {squareDto.Side}";
            }
            else if (shape is TriangleDto triangleDto)
            {
                parametersInfo = $"base: {triangleDto.Base}; height: {triangleDto.Height}";
            }

            var sh = new Shape
            {
                Id = shape.Id,
                Type = shape.Type,
                OtherInfo = shape.OtherInfo,
                Presentation = shape.Presentation,
                ParametersInfo = parametersInfo 
            };

            await _repository.AddAsync(sh);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ShapeBaseDto>> GetAllAsync()
        {
            var shapesDto = new List<ShapeBaseDto>();

            var result = await _repository.GetAllAsync();

            foreach (var shape in result)
            {
                if (shape.Type == "Circle")
                {
                    // Извлечение радиуса из ParametersInfo (например, radius: 6.3)
                    double radius = 0;
                    var match = Regex.Match(shape.ParametersInfo, @"radius:\s*(\d+(\.\d+)?)");
                    if (match.Success && double.TryParse(match.Groups[1].Value, out radius))
                    {
                        var circleDto = new CircleDto
                        {
                            Type = shape.Type,
                            Id = shape.Id,
                            OtherInfo = shape.OtherInfo,
                            Presentation = shape.Presentation,
                            Radius = radius
                        };

                        shapesDto.Add(circleDto);
                    }
                    continue;
                }
                else if (shape.Type == "Square")
                {
                    
                    double side = 0;
                    var match = Regex.Match(shape.ParametersInfo, @"side:\s*(\d+(\.\d+)?)");
                    if (match.Success && double.TryParse(match.Groups[1].Value, out side))
                    {
                        var squareDto = new SquareDto
                        {
                            Type = shape.Type,
                            Id = shape.Id,
                            OtherInfo = shape.OtherInfo,
                            Presentation = shape.Presentation,
                            Side = side
                        };

                        shapesDto.Add(squareDto);
                    }
                    continue;
                }
                else if (shape.Type == "Triangle")
                {
                    
                    double baseLength = 0, height = 0;
                    var matchBase = Regex.Match(shape.ParametersInfo, @"base:\s*(\d+(\.\d+)?)");
                    var matchHeight = Regex.Match(shape.ParametersInfo, @"height:\s*(\d+(\.\d+)?)");

                    if (matchBase.Success && matchHeight.Success)
                    {
                        if (double.TryParse(matchBase.Groups[1].Value, out baseLength) && double.TryParse(matchHeight.Groups[1].Value, out height))
                        {
                            var triangleDto = new TriangleDto
                            {
                                Type = shape.Type,
                                Id = shape.Id,
                                OtherInfo = shape.OtherInfo,
                                Presentation = shape.Presentation,
                                Base = baseLength,
                                Height = height
                            };

                            shapesDto.Add(triangleDto);
                        }
                    }
                    continue;
                }
                else
                {
                    var otherDto = new ShapeBaseDto
                    {
                        Type = shape.Type,
                        Id = shape.Id,
                        OtherInfo = shape.OtherInfo,
                        Presentation = shape.Presentation,
                    };
                    shapesDto.Add(otherDto);
                    continue;
                }
            }

            return shapesDto;
        }

        public async Task UpdateAsync(ShapeBaseDto shape)
        {
            var sh = new Shape
            {
                Id = shape.Id,
                Type = shape.Type,
                OtherInfo = shape.OtherInfo,
                Presentation = shape.Presentation,
            };

            await _repository.UpdateAsync(sh);
        }
    }
}

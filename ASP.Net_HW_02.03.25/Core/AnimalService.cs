using ASP.Net_HW_02._03._25.Abstract;
using ASP.Net_HW_02._03._25.DAL.Abstract;
using ASP.Net_HW_02._03._25.DAL.Entities;
using ASP.Net_HW_02._03._25.Models;
using System;

namespace ASP.Net_HW_02._03._25.Core
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;
        public AnimalService(IAnimalRepository repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(AnimalDto animal)
        {
            animal.Id = Guid.NewGuid();

            var an = new Animal
            {
                Id = animal.Id,
                Name = animal.Name,
                OtherInfo = animal.OtherInfo,
                Sound  = animal.Sound
            };
            await _repository.AddAsync(an);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<AnimalDto>> GetAllAsync()
        {
            var animalsDto = new List<AnimalDto>();

            var result = await _repository.GetAllAsync();

            foreach (var animal in result)
            {
                if (animal.Sound == "Woof")
                {
                    var dogDto = new DogDto
                    {
                        Name = animal.Name,
                        Id = animal.Id,
                        OtherInfo = animal.OtherInfo
                    };
                    animalsDto.Add(dogDto);
                    continue;
                }
                else if (animal.Sound == "Meow")
                {
                    var catDto = new CatDto
                    {
                        Name = animal.Name,
                        Id = animal.Id,
                        OtherInfo = animal.OtherInfo
                    };
                    animalsDto.Add(catDto);
                    continue;
                }
                else if (animal.Sound == "Moo")
                {
                    var cowDto = new CowDto
                    {
                        Name = animal.Name,
                        Id = animal.Id,
                        OtherInfo = animal.OtherInfo
                    };
                    animalsDto.Add(cowDto);
                    continue;
                }
                else
                {
                    var otherDto = new AnimalDto
                    {
                        Name = animal.Name,
                        Id = animal.Id,
                        OtherInfo = animal.OtherInfo
                    };
                    animalsDto.Add(otherDto);
                    continue;
                }
            }

            return animalsDto;
        }

        public async Task UpdateAsync(AnimalDto animal)
        {
            var an = new Animal
            {
                Id = animal.Id,
                Name = animal.Name,
                OtherInfo = animal.OtherInfo
            };

            await _repository.UpdateAsync(an);
        }
    }
}

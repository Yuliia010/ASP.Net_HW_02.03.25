using ASP.Net_HW_02._03._25.Abstract;
using ASP.Net_HW_02._03._25.DAL.Entities;
using ASP.Net_HW_02._03._25.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.Net_HW_02._03._25.Pages
{
    public class AnimalModel : PageModel
    {
        [BindProperty]
        public AnimalDto Animal { get; set; }

        [BindProperty]
        public string SelectedAnimalType { get; set; } = "Other";

        public List<SelectListItem> AnimalTypes { get; set; }

        public List<AnimalDto> Animals { get; set; } = new List<AnimalDto>();

        private readonly IAnimalService _animalService;
        public AnimalModel(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task OnGetAsync()
        {
            Animals = await _animalService.GetAllAsync();
            AnimalTypes = new List<SelectListItem>
            {
                new SelectListItem { Value = "Cat", Text = "Cat" },
                new SelectListItem { Value = "Dog", Text = "Dog" },
                new SelectListItem { Value = "Cow", Text = "Cow" },
                new SelectListItem { Value = "Other", Text = "ќбер≥ть вид" }
            };
            if (string.IsNullOrEmpty(SelectedAnimalType))
            {
                SelectedAnimalType = "Other"; 
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (string.IsNullOrEmpty(SelectedAnimalType))
            {
                SelectedAnimalType = "Other"; 
            }

            switch (SelectedAnimalType)
            {
                case "Cat":
                    Animal = new CatDto { Name = Animal.Name, OtherInfo = Animal.OtherInfo };
                    break;
                case "Dog":
                    Animal = new DogDto { Name = Animal.Name, OtherInfo = Animal.OtherInfo };
                    break;
                case "Cow":
                    Animal = new CowDto { Name = Animal.Name, OtherInfo = Animal.OtherInfo };
                    break;
                case "Other":
                    Animal = new AnimalDto { Name = Animal.Name, OtherInfo = Animal.OtherInfo };
                    break;
                default:
                    break;
            }

            await _animalService.AddAsync(Animal);
            return RedirectToPage("/Animal");
           

        }
    }
}

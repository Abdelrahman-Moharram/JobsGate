using JobsGate.DTO;
using JobsGate.DTO.Jobs;
using JobsGate.Models;
using JobsGate.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsGate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IBaseRepository<Industry>  IndustryRepo;
        private readonly IBaseRepository<Category>  CategoryRepo;
        private readonly IBaseRepository<Job>       JobRepository;

        public AdminController(
            IBaseRepository<Industry> _IndustryRepo, 
            IBaseRepository<Category> _CategoryRepo, 
            IBaseRepository<Job> _JobRepository
            )
        {
            IndustryRepo = _IndustryRepo;
            CategoryRepo = _CategoryRepo;
            JobRepository = _JobRepository;
        }
        
        
        [HttpGet("Industries")]
        public async Task<IActionResult> Industries()
        {
            return Ok(await IndustryRepo.GetAllAsync());
        }


        [HttpPost("Industries/Add")]
        public async Task<IActionResult> AddIndustry([FromBody] Industry industry)
        {
            if(ModelState.IsValid && industry.Title != null)
            {
                if (await IndustryRepo.FindAsync(i => i.Title.ToLower() == industry.Title.ToLower()) != null)
                    return BadRequest(new ResponseDTO { Message = industry.Title + " already Exists" });
                IndustryRepo.AddAsync(industry);
                IndustryRepo.Save();
                return Ok(industry);
            }
            return BadRequest(industry.Title);
        }


        [HttpGet("Categories")]
        public async Task<IActionResult> Categories()
        {
            return Ok(await CategoryRepo.GetAllAsync());
        }

        [HttpPost("Categories/Add")]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (ModelState.IsValid && category.Title != null)
            {
                if (await CategoryRepo.FindAsync(i => i.Title.ToLower() == category.Title.ToLower()) != null)
                    return BadRequest(new ResponseDTO { Message = category.Title + " already Exists" });
                CategoryRepo.AddAsync(category);
                CategoryRepo.Save();
                return Ok(category);
            }
            return BadRequest(category.Title);
        }

        
        

    }
}

using AutoMapper;
using AutoMapper.Mappers;
using GalaxyHotel.Core.Models;
using GalaxyHotel.Core.Services;
using GalaxyHotel.Infrastructure.Data;
using GalaxyHotel.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GalaxyHotel.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GalaxyHotelContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, GalaxyHotelContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var roomService = new RoomService(new Repository<Room>(_context), _mapper);
            var rooms = await roomService.GetAll();

            return View(new RoomViewModel(rooms));
        }

        public IActionResult Booking()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

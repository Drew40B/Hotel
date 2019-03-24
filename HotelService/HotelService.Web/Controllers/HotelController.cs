using System.Threading.Tasks;
using AutoMapper;
using HotelService.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Web.Controllers
{
    /// <summary>
    /// Hotel dabatase administrtaion
    /// </summary>
    /// 
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {

        private IMapper _mapper;
        /// <summary>
        /// ctor
        /// </summary>
        public HotelController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public async Task<ActionResult> Init([FromBody] HotelInitModel hotel)
        {
            return Created("",null);
        }
    }
}
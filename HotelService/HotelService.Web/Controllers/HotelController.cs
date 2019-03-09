using System.Threading.Tasks;
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
        /// <summary>
        /// ctor
        /// </summary>
        public HotelController()
        {
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
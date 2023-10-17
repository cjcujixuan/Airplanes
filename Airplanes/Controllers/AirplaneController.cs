using Dapper;
using Airplanes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace Airplanes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {
        private readonly string _connectString = DBUtil.ConnectionString(); [HttpGet]
        public async Task<IEnumerable<Airplane>> GetAirplanes()
        {
            string sqlQuery = "SELECT * FROM MyAirplane"; 
            using (var connection = new SqlConnection(_connectString))
                { var Airplanes = await connection.QueryAsync<Airplane>(sqlQuery); 
                return Airplanes.ToList(); }
        }
        [HttpGet("{id}")]
        public async Task<Airplane> GetAirplane(int id)
        {
            string sqlQuery = "SELECT * FROM MyAirplane WHERE Cid = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                var Airplane = await connection.QueryFirstOrDefaultAsync<Airplane>(sqlQuery, new { Id = id });
                if (Airplane == null)
                {
                    return new Airplane();
                }
                return Airplane;
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddAirplane(Airplane Airplane)
        {
            string sqlQuery = "INSERT  INTO  MyAirplane  (Cname,  Cpriority,  Cfinish)  VALUES (@Cname, @Cpriority, @Cfinish)";
            using (var connection = new SqlConnection(_connectString)) 
            {
                await connection.ExecuteAsync(sqlQuery, Airplane);
                return Ok(); 
            }
        }
        [HttpPut] public async Task<IActionResult> UpdateAirplane(Airplane Airplane) 
        {
            string sqlQuery = "UPDATE MyAirplane SET Cname = @Cname, Cpriority = @Cpriority, Cfinish = @Cfinish, Cmemo=@CmemoWHERE Cid = @Cid";
            using (var connection = new SqlConnection(_connectString)) 
            {
                await connection.ExecuteAsync(sqlQuery, Airplane);
                return Ok();
            } 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendar(int id)
        {
            string sqlQuery = "DELETE FROM MyCalendar WHERE Cid = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = id});
                return Ok();
            }
        }
    }
}
























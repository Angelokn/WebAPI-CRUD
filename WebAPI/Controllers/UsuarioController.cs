using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT UsuarioId, Nome, Email FROM dbo.Usuario";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("{UsuarioId}")]
        public JsonResult Get(int UsuarioId)
        {
            string query = @"SELECT UsuarioId, Nome, Email
                            FROM dbo.Usuario WHERE UsuarioId = @UsuarioId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UsuarioId", UsuarioId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Usuario usuario)
        {
            string query = @"INSERT INTO dbo.Usuario
                            VALUES (@Nome, @Email)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
                    myCommand.Parameters.AddWithValue("@Email", usuario.Email);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPut]
        public JsonResult Put(Usuario usuario)
        {
            string query = @"UPDATE dbo.Usuario
                            SET Nome = @Nome, Email = @Email
                            WHERE UsuarioId = @UsuarioId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UsuarioId", usuario.UsuarioId);
                    myCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
                    myCommand.Parameters.AddWithValue("@Email", usuario.Email);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpDelete("{UsuarioId}")]
        public JsonResult Delete(int UsuarioId)
        {
            string query = @"DELETE FROM dbo.Usuario
                            WHERE UsuarioId = @UsuarioId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UsuarioId", UsuarioId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}

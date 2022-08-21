using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query1 = @"SELECT UsuarioId, Nome, Email FROM dbo.Usuario";
            string query2 = @"SELECT PostagemId, Titulo, Autor, DataPublicacao, Conteudo FROM dbo.Postagem";

            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("WebCon");
            SqlDataReader myReader1;
            SqlDataReader myReader2;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query1, myCon))
                {
                    myReader1 = myCommand.ExecuteReader();
                    table1.Load(myReader1);
                }
                using (SqlCommand myCommand = new SqlCommand(query2, myCon))
                {
                    myReader2 = myCommand.ExecuteReader();
                    table2.Load(myReader2);
                    myCon.Close();
                }
            }

            return new JsonResult((table1, table2));
        }

    }
}

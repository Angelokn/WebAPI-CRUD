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
    public class PostagemController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PostagemController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT PostagemId, Titulo, Autor, DataPublicacao, Conteudo FROM dbo.Postagem";

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
                    myReader.Close();
                    myCon.Close();
                }

            }

            return new JsonResult(table);
        }

        [HttpGet("{PostagemId}")]
        public JsonResult Get(int PostagemId)
        {
            string query = @"SELECT PostagemId, Titulo, Autor, DataPublicacao, Conteudo
                            FROM dbo.Postagem WHERE PostagemId = @PostagemId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PostagemId", PostagemId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Postagem postagem)
        {
            string query = @"INSERT INTO dbo.Postagem
                            VALUES (@Titulo, @Autor, @DataPublicacao, @Conteudo)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Titulo", postagem.Titulo);
                    myCommand.Parameters.AddWithValue("@Autor", postagem.Autor);
                    myCommand.Parameters.AddWithValue("@DataPublicacao", postagem.DataPublicacao);
                    myCommand.Parameters.AddWithValue("@Conteudo", postagem.Conteudo);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPut]
        public JsonResult Put(Postagem postagem)
        {
            string query = @"UPDATE dbo.Postagem
                            SET Titulo = @Titulo, Autor = @Autor, DataPublicacao = @DataPublicacao, Conteudo = @Conteudo
                            WHERE PostagemId = @PostagemId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PostagemId", postagem.PostagemId);
                    myCommand.Parameters["@PostagemId"].Value = postagem.PostagemId;
                    myCommand.Parameters.AddWithValue("@Titulo", postagem.Titulo);
                    myCommand.Parameters.AddWithValue("@Autor", postagem.Autor);
                    myCommand.Parameters.AddWithValue("@DataPublicacao", postagem.DataPublicacao);
                    myCommand.Parameters.AddWithValue("@Conteudo", postagem.Conteudo);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpDelete("{PostagemId}")]
        public JsonResult Delete(int PostagemId)
        {
            string query = @"DELETE FROM dbo.Postagem
                            WHERE PostagemId = @PostagemId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PostagemId", PostagemId);
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

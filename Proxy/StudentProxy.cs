using MVCAjax.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVCAjax.Proxy
{
    public class StudentProxy
    {
        public async Task<ResponseProxy<StudentModel>> GetStudentsAsync()
        {
            var client = new HttpClient();
            var urlBase = "https://localhost:44350";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/Api", "/Student", "/GetAllStudents");
            var response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<StudentModel>>(result);

                return new ResponseProxy<StudentModel>
                {
                    Exitoso = true,
                    Codigo = (int) HttpStatusCode.OK,
                    Mensaje = "Estudiantes",
                    Listado = students
                };
            } else
            {
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = false,
                    Codigo = (int) response.StatusCode,
                    Mensaje = "Error"
                };
            }
        }

        public async Task<ResponseProxy<StudentModel>> InsertAsync(StudentModel student)
        {

            var request = JsonConvert.SerializeObject(student);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var urlBase = "https://localhost:44350";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/Api", "/Student", "/InsertStudents");
            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);

                return new ResponseProxy<StudentModel>
                {
                    Exitoso = exito,
                    Codigo = (int)HttpStatusCode.Created,
                    Mensaje = "Estudiante creado exitosamente"
                };
            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = false,
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error al crear"
                };
            }
        }
    }
}
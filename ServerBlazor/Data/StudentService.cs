using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace ServerBlazor.Data
{
    public class StudentService
    {
        string baseUrl = "https://localhost:44380/";

        public async Task<Student[]> GetStudentsAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/students");
            return JsonConvert.DeserializeObject<Student[]>(json);
        }

        public async Task<Student> GetStudentsByIdAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/students/{id}");
            return JsonConvert.DeserializeObject<Student>(json);
        }

        public async Task<HttpResponseMessage> InsertStudentAsync(Student student)
        {
            var client = new HttpClient();
            return await client.PostAsync($"{baseUrl}api/students", getStringContentFromObject(student));
        }

        public async Task<HttpResponseMessage> UpdateStudentAsync(string id, Student student)
        {
            var client = new HttpClient();
            return await client.PutAsync($"{baseUrl}api/students/{id}", getStringContentFromObject(student));
        }

        public async Task<HttpResponseMessage> DeleteStudentAsync(string id)
        {
            var client = new HttpClient();
            return await client.DeleteAsync($"{baseUrl}api/students/{id}");
        }

        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}

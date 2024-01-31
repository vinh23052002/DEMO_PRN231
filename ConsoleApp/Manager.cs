using ConsoleApp.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ConsoleApp
{
    internal class Manager
    {
        string link = "http://localhost:5091/api/Categories";

        internal async Task ShowList()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        //await Console.Out.WriteLineAsync(data);
                        List<Category> list = JsonConvert.DeserializeObject<List<Category>>(data);
                        foreach (Category item in list)
                        {
                            await Console.Out.WriteLineAsync(item.CategoryId + "\t" + item.CategoryName);
                        }
                    }
                }
            }
        }

        internal async Task SerachByIdAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        Category category = JsonConvert.DeserializeObject<Category>(data);

                        Console.WriteLine("Category Id: " + category.CategoryId + "\tCategory Name: " + category.CategoryName);
                    }
                }
            }
        }



        internal async Task InsertAsync(string? name)
        {
            Category category = new Category()
            {
                CategoryName = name
            };
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage res = await client.PostAsJsonAsync(link, category))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Add success");
                    }
                    else
                    {
                        Console.WriteLine("Add Fail");
                    }
                }
            }
        }



        internal async Task UpdateAsync(int id, string? name)
        {
            Category category = new Category()
            {
                CategoryId = id,
                CategoryName = name
            };
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage res = await client.PutAsJsonAsync(link, category))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Update success");
                    }
                    else
                    {
                        Console.WriteLine("Update Fail");
                    }
                }
            }
        }
        internal async Task Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(link + "/" + id))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Delete succes");
                    }
                    else
                    {
                        Console.WriteLine("Delete Fail");
                    }
                }
            }
        }
    }
}

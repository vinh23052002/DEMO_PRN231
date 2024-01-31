using Dummy_API.DTO;
using Dummy_Client.DTO;
using Dummy_Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Dummy_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string detailName = "", string masterName = "")
        {
            var body = new FilterRequest()
            {
                detail_name = detailName ?? "",
                master_name = masterName ?? ""
            };

            List<DummyDetailResponse> listResponse = new List<DummyDetailResponse>();
            List<DummyMasterResponse> listMaster = new List<DummyMasterResponse>();
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage res = await httpClient.PostAsJsonAsync("https://localhost:7057/api/DummyDetails/Filter", body))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        listResponse = JsonConvert.DeserializeObject<List<DummyDetailResponse>>(data);
                    }

                }
            }
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage res = await httpClient.GetAsync("https://localhost:7057/api/DummyMasters"))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        listMaster = JsonConvert.DeserializeObject<List<DummyMasterResponse>>(data);
                    }

                }
            }
            listMaster.Insert(0, new DummyMasterResponse());
            ViewData["listM"] = new SelectList(listMaster, "MasterName", "MasterName");

            return View(listResponse);
        }

        public IActionResult Privacy()
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

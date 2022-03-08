//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace ShopBridge.Controllers
//{
//    public class ProductCard : Controller
//    {
//        public ProductCard()
//        {

//        }

//        [HttpGet]
//        [Route("GetStudents")]
//        public async Task<IActionResult> GetDetails()
//        {
//            return _studentRepo.GetDetails();
//            ;
//        }

//        [HttpPost]
//        [Route("AddStudents")]
//        public async Task<IActionResult> AddDetails(StudentData request)
//        {
//            string filter = JsonConvert.SerializeObject(request);
//            StudentDetails Sdata = JsonConvert.DeserializeObject<StudentDetails>(filter);
//            return _studentRepo.AddStudents(Sdata);
//        }

//        [HttpPost]
//        [Route("UpdateStudent")]
//        public async Task<IActionResult> UpdateDetails(StudentData request)
//        {
//            string filter = JsonConvert.SerializeObject(request);
//            StudentDetails Sdata = JsonConvert.DeserializeObject<StudentDetails>(filter);
//            var res = _studentRepo.UpdateStudents(Sdata);
//            return Ok(res);


//        }
//    }
//}

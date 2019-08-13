using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using магазин_авто.Models;
namespace магазин_авто.Controllers
{
    public class HomeController : Controller
    {
        AutoContext db = new AutoContext();
        static List<Car> Information;
        public ActionResult Index()
        {
            IEnumerable<Car> b =db.Cars.Include(x=>x.BuyCars).ThenInclude(x=>x.Buyer);
            Information = db.Cars.ToList();            
            return View(b);
        }

        public ActionResult About(int i=1)
        {            
            int size = 2;
            IEnumerable<Car> phonesPerPages = Information.Skip((i-1) * size).Take(size);
            PageInfo page = new PageInfo { PageSize=2, PageNumber=i, TotalItems=Information.Count};
            IndexViewModel index = new IndexViewModel { PageInfo=page, Cars= phonesPerPages };
            return View(index);
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(HttpPostedFileBase upload,string Name,string CarBrand, int Count_Of_Unit, double Price,string Info )
        {
            if (upload != null)
            {
                string fileName = Path.GetFileName(upload.FileName);
                string ext = Path.GetExtension(fileName);
                upload.SaveAs(Server.MapPath("~/Files/" + Name + ext));
                //byte[] avatar = new byte[upload.ContentLength];
                //upload.InputStream.Read(avatar, 0, upload.ContentLength);
                //string ext = Name + ".jpg";
                Car car = new Car(Name,CarBrand,Count_Of_Unit,Price);
                if (Info != null)
                    car.Info = Info;
                else
                    car.Info = "gg";

                car.ExtencionName = Name+ext;
                db.Cars.Add(car);
                db.SaveChanges();                
            }
            return View("Index");
        }

        public ActionResult ShowUsers_of_Car(int id=1)
        {
            List<Car> b = db.Cars.Where(x=>x.Id==id).Include(x=>x.BuyCars).ThenInclude(x=>x.Buyer).ToList();            
            return View(b);
        }

        public ActionResult ShowCars_of_User(int id = 1)
        {
            List<Buyer> b = db.Buyers.Where(x => x.Id == id).Include(x => x.BuyCars).ThenInclude(x => x.Car).ToList();
            return View(b);
        }

        [HttpGet]
        public ActionResult Buy(int Id)
        {
            ViewBag.CarId = Id;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(InfoToBuy buyer)
        {
            int buyerId = db.Buyers.FirstOrDefault(x=>x.Email==buyer.Email).Id;
            db.BuyCars.Add(new BuyCar{ BuyerId=buyerId, CarId=buyer.CarId });
            db.SaveChanges();
            Car car=db.Cars.Find(buyer.CarId);
            car.Count_Of_Unit--;
            db.Entry(car).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult UpdateCar(int Id)
        {            
            Car car = db.Cars.Find(Id);
            return View(car);
        }

        [HttpPost]
        public ActionResult UpdateCar(HttpPostedFileBase upload,Car newModel)
        {
            Car car = db.Cars.Find(newModel.Id);
            car.Count_Of_Unit = newModel.Count_Of_Unit;
            car.CarBrand = newModel.CarBrand;
            car.Name = newModel.Name;
            car.Price = newModel.Price;

            string fileName = Path.GetFileName(upload.FileName);
            string ext = Path.GetExtension(fileName);
            upload.SaveAs(Server.MapPath("~/Files/" + newModel.Name + ext));
            //byte[] avatar = new byte[upload.ContentLength];
            //upload.InputStream.Read(avatar, 0, upload.ContentLength);
            //string ext = Name + ".jpg";            
            car.ExtencionName = newModel.Name + ext;

            db.Entry(car).State = EntityState.Modified;
            db.SaveChanges();
            return View("Contact");
        }

        public ActionResult ShowCar(int id)
        {
            Car car = db.Cars.Find(id);
            return View(car);
        }

    }
}
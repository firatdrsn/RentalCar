﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static CarManager carManager = new CarManager(new EfCarDal());
        static BrandManager brandManager = new BrandManager(new EfBrandDal());
        static ColorManager colorManager = new ColorManager(new EfColorDal());
        static void Main(string[] args)
        {
            int menu = 1;
            while (menu != 0)
            {
                Console.WriteLine(" Marka işlemleri için 1'e basınız\nRenk işlemleri için 2'ye basınız\nAraç işlemleri için 3'e basınız\nÇıkış yapmak için 0'a basınız");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        BrandMenu();
                        break;
                    case 2:
                        ColorMenu();
                        break;
                    case 3:
                        CarMenu();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız");
                        break;
                }
            }
        }
        private static void BrandMenu()
        {
            int brandMenu = 1;
            while (brandMenu != 0)
            {
                Console.WriteLine("Marka eklemek için 1'e basınız\nMarka güncellemek için 2'ye basınız\nMarka silmek için 3'e basınız\nMarkaları listelemek için 4'e basınız\nBir üst menüye geçiş yapmak için 0'a basınız");
                brandMenu = int.Parse(Console.ReadLine());
                switch (brandMenu)
                {
                    case 1:
                        Console.WriteLine("Yeni Markayı giriniz");
                        Brand brand = new Brand();
                        brand.BrandName = Console.ReadLine();
                        //brandManager.Add(brand);
                        Console.WriteLine(brandManager.Add(brand).Message);
                        break;
                    case 2:
                        Console.WriteLine("Güncellemek istediğiniz markanın Idsini giriniz");
                        BrandWriteList();
                        Brand updateToBrand = new Brand();
                        updateToBrand.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Güncel marka adını giriniz");
                        updateToBrand.BrandName = Console.ReadLine();
                        Console.WriteLine(brandManager.Update(updateToBrand).Message);
                        break;
                    case 3:
                        Console.WriteLine("Silmek istediğiniz markanın Idsini giriniz");
                        BrandWriteList();
                        Brand deleteToBrand = new Brand();
                        deleteToBrand.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(brandManager.Delete(deleteToBrand).Message);
                        break;
                    case 4:
                        Console.WriteLine("\nMarkalar");
                        BrandWriteList();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız");
                        break;
                }
            }
        }

        private static void ColorMenu()
        {
            int colorMenu = 1;
            while (colorMenu != 0)
            {
                Console.WriteLine("Renk eklemek için 1'e basınız\nRenk güncellemek için 2'ye basınız\nRenk silmek için 3'e basınız\nRenkleri listelemek için 4'e basınız\nBir üst menüye geçiş yapmak için 0'a basınız");
                colorMenu = int.Parse(Console.ReadLine());
                switch (colorMenu)
                {
                    case 1:
                        Console.WriteLine("Yeni Renk giriniz");
                        Color color = new Color();
                        color.ColorName = Console.ReadLine();
                        Console.WriteLine(colorManager.Add(color).Message);
                        break;
                    case 2:
                        Console.WriteLine("Güncellemek istediğiniz markanın Idsini giriniz");
                        ColorWriteList();
                        Color updateToColor = new Color();
                        updateToColor.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Güncel Renk bilgisini giriniz");
                        updateToColor.ColorName = Console.ReadLine();
                        Console.WriteLine(colorManager.Update(updateToColor).Message);
                        break;
                    case 3:
                        Console.WriteLine("Silmek istediğiniz renk Idsini giriniz");
                        ColorWriteList();
                        Color deleteToColor = new Color();
                        deleteToColor.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(colorManager.Delete(deleteToColor).Message);
                        break;
                    case 4:
                        Console.WriteLine("\nRenkler");
                        ColorWriteList();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız");
                        break;
                }
            }
        }
        private static void CarMenu()
        {
            int carMenu = 1;
            while (carMenu != 0)
            {
                Console.WriteLine("Araç eklemek için 1'e basınız\nAraç güncellemek için 2'ye basınız\nAraç silmek için 3'e basınız\nAraçları listelemek için 4'e basınız\nAraçları markaya göre listelemek için 5'e basınız\nAraçları renge göre listelemek için 6'ya basınız\nBir üst menüye geçiş yapmak için 0'a basınız");
                carMenu = int.Parse(Console.ReadLine());
                switch (carMenu)
                {
                    case 1:
                        Car car = new Car();
                        Console.WriteLine("Araç adı giriniz");
                        car.CarName = Console.ReadLine();
                        Console.WriteLine("Marka Idsini giriniz");
                        car.BrandId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Renk Idsini giriniz");
                        car.ColorId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Günlük ücretini giriniz");
                        car.DailyPrice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Model yılını giriniz");
                        car.ModelYear = int.Parse(Console.ReadLine());
                        Console.WriteLine("Araçla ilgili açıklama giriniz");
                        car.Description = Console.ReadLine();
                        Console.WriteLine(carManager.Add(car).Message);
                        break;
                    case 2:
                        Console.WriteLine("Güncellemek istediğiniz aracın Idsini giriniz");
                        CarWriteList();
                        Car updateToCar = new Car();
                        updateToCar.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Güncel Araç adı giriniz");
                        updateToCar.CarName = Console.ReadLine();
                        Console.WriteLine("Güncel Marka Idsini giriniz");
                        updateToCar.BrandId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Güncel Renk Idsini giriniz");
                        updateToCar.ColorId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Güncel ücretini giriniz");
                        updateToCar.DailyPrice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Güncel Model yılını giriniz");
                        updateToCar.ModelYear = int.Parse(Console.ReadLine());
                        Console.WriteLine("Güncel Araç açıklamasını giriniz");
                        updateToCar.Description = Console.ReadLine();
                        Console.WriteLine(carManager.Update(updateToCar).Message);
                        break;
                    case 3:
                        Console.WriteLine("Silmek istediğiniz aracın Idsini giriniz");
                        CarWriteList();
                        Car deleteToCar = new Car();
                        deleteToCar.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(carManager.Delete(deleteToCar).Message);
                        break;
                    case 4:
                        Console.WriteLine("\nAraçlar");
                        CarWriteDetailList();
                        break;
                    case 5:
                        BrandWriteList();
                        Console.WriteLine("Markaya göre sıralama yapmak için marka Idsi giriniz");
                        int brandId = int.Parse(Console.ReadLine());
                        CarWriteByBrand(brandId);
                        break;
                    case 6:
                        ColorWriteList();
                        Console.WriteLine("Renklere göre sıralama yapmak için renk Idsini giriniz");
                        int colorId = int.Parse(Console.ReadLine());
                        CarWriteByColor(colorId);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız");
                        break;
                }
            }
        }

        private static void BrandWriteList()
        {
            try
            {
                foreach (var itemBrand in brandManager.GetAll().Data)
                {
                    Console.WriteLine(itemBrand.Id + " - " + itemBrand.BrandName);
                }
            }
            catch
            {
                Console.WriteLine(brandManager.GetAll().Message);
            }
        }
        private static void ColorWriteList()
        {
            try
            {
                foreach (var itemBrand in colorManager.GetAll().Data)
                {
                    Console.WriteLine(itemBrand.Id + " - " + itemBrand.ColorName);
                }
            }
            catch
            {
                Console.WriteLine(colorManager.GetAll().Message);
            }
        }
        private static void CarWriteList()
        {
            try
            {
                foreach (var carList in carManager.GetAll().Data)
                {
                    Console.WriteLine(carList.Id + " - " + carList.CarName + " - " + carList.Description + " - " + carList.ModelYear + " - " + carList.DailyPrice + "\n");
                }
            }
            catch
            {
                Console.WriteLine(carManager.GetAll().Message);
            }

        }
        private static void CarWriteDetailList()
        {
            try
            {
                foreach (var carDetail in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(carDetail.CarId + " - " + carDetail.CarName + " - " + carDetail.BrandName + " - " + carDetail.ColorName + " - " + carDetail.DailyPrice);
                }
            }
            catch
            {
                Console.WriteLine(carManager.GetCarDetails().Message);
            }
        }
        private static void CarWriteByColor(int colorId)
        {
            try
            {
                foreach (var carByColor in carManager.GetCarsByColorId(colorId).Data)
                {
                    Console.WriteLine(carByColor.CarName + " - " + carByColor.Description + " - " + carByColor.ModelYear + " - " + carByColor.DailyPrice + "\n");
                }
            }
            catch
            {
                Console.WriteLine(colorManager.GetByID(colorId).Message);
            }
        }

        private static void CarWriteByBrand(int brandId)
        {
            try
            {
                foreach (var carByBrand in carManager.GetCarsByBrandId(brandId).Data)
                {
                    Console.WriteLine(carByBrand.CarName + " - " + carByBrand.Description + " - " + carByBrand.ModelYear + " - " + carByBrand.DailyPrice + "\n");
                }
            }
            catch
            {
                Console.WriteLine(carManager.GetCarsByBrandId(brandId).Message);
            }
        }
    }
}

using DL;
using StoreBL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuString)
        {
            string connectionString = File.ReadAllText(@"../connectionString.txt");
            
            DbContextOptions<p0databaseContext> options = new DbContextOptionsBuilder<p0databaseContext>().UseSqlServer(connectionString).Options;

            
            p0databaseContext context = new p0databaseContext(options);

        // IRepo datalayer = new TempRepo();
        // IBL businessLogic = new BL(datalayer);
        // IMenu storeMenu = new MainMenu(businessLogic);

        // storeMenu.Start();

            switch (menuString.ToLower())
            {
                case "main":
                return new MainMenu(new BL(new DBRepo(context)));

                case "items":
                return new ItemsMenu(new BL(new DBRepo(context)));

                case "stores":
                return new StoresMenu(new BL(new DBRepo(context)));

                case "customer":
                return new CustomerMenu(new BL(new DBRepo((context))), new CustomerService());

                case "login":
                return new LoginMenu(new BL(new DBRepo((context))));

                default:
                return null;
            }
        }
    }
}
using System.Web;
using System.Web.Mvc;
using AutoLotDALEF.Repos;
namespace CarLotMVC {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportsStore.Models;
using SportsStore.Models.Repository;
using System.Linq;


namespace SportsStore.Pages
{
    public partial class Listing : System.Web.UI.Page

    {
        private Repository repo = new Repository();
        private int pageSize = 6;
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
          
        }
        protected IEnumerable<Product> GetProducts() {
            return repo.Products
            .OrderBy(p => p.ProductID)
            .Skip((CurrentPage -1) * pageSize)
            .Take(pageSize);

        }
        protected int CurrentPage
        {
            get
            {
                int page;
                //page=int.TryParse(Request.QueryString["page"], out page) ? page : 1;
                //return page > MaxPage ? MaxPage : page;
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }
        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((decimal)repo.Products.Count() / pageSize);
            }
        }
        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ??
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }
    }
}
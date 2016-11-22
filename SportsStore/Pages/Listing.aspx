<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs"
   MasterPageFile="/Pages/Store.Master"  Inherits="SportsStore.Pages.Listing"%>
    <%@ Import Namespace="System.Web.Routing" %>

    <asp:Content ContentPlaceHolderID="bodyContent" runat="server">
        
        <div style="width:100%;height:45em">
    <div id="content">
    <% foreach (SportsStore.Models.Product prod in GetProducts())
        {
            Response.Write("<div class='item'>");
            Response.Write(string.Format("<h3>{0}</h3>",prod.Name));
            Response.Write(prod.Description);
            Response.Write(string.Format("<h4>{0:c}</h4>", prod.Price));
            Response.Write(string.Format("<button name='add'type='submit'" + "value='{0}'>Add to Cart</button>", prod.ProductID));
            Response.Write("</div>");
        } %>
    </div>
   
    <div class="pager">
        <% for (int i = 1; i <= MaxPage; i++)
            {
                string path = RouteTable.Routes.GetVirtualPath(null, null, new
                    RouteValueDictionary()
                { { "page",i} }).VirtualPath;
                //Response.Write(
                //string.Format("<a href='/Pages/Listing.aspx?page={0}'{1}>{2}</a>",
                //i, i == CurrentPage ? "Class='selected'":"", i));
                Response.Write(string.Format("<a href='{0}' {1}>{2}</a>'",
                    path,i==CurrentPage?"class='selected'":"",i));
            }
           %>
    </div>
          </div>
        <p></p>
        <div id="page1" style="width:100%; height:40em;background-color:#b200ff "></div>
    </asp:Content>


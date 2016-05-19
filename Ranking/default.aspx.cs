using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ranking.Business.Logic;
using Class.Ranking;

namespace Ranking
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetRanking();
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            GetRankingByDate();
        }

        protected void GetRanking()
        {
            List<cl_Website> lstWebsite = new List<cl_Website>();
            string dtFrom = "";
            string dtUntil = "";
            WebsiteBL.GetWebsiteTop5(ref lstWebsite, ref dtFrom, ref dtUntil); 
            lstTop5.DataSource = lstWebsite;
            lstTop5.DataBind();
        }

        protected void GetRankingByDate()
        {
            lstTop5.DataSource = WebsiteBL.GetWebsiteByDate(calFrom.SelectedDate, calUntil.SelectedDate);
            lstTop5.DataBind();
        }

        
    }
}
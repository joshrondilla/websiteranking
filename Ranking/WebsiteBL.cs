using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Class.Ranking;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Ranking.Business.Logic
{
    public class WebsiteBL
    {
        public static List<cl_Website> GetWebsite()
        {
            List<cl_Website> lstWebsite = new List<cl_Website>();

            Database database = DatabaseFactory.CreateDatabase("WEBSITE");

            using (DbCommand command = database.GetStoredProcCommand("USP_SELECT_WEBSITE_ALL"))
            {
                using (IDataReader rdrEvents = database.ExecuteReader(command))
                {
                    while (rdrEvents.Read())
                    {
                        cl_Website website = new cl_Website();
                        website.Visits = rdrEvents["VISITS"].ToString();
                        website.Name = rdrEvents["WEBSITE"].ToString();
                        website.DateTime = Convert.ToDateTime(rdrEvents["SYS_DATE_TIME"]);

                        lstWebsite.Add(website);
                    }
                }
            }

            return lstWebsite;
        }

        public static List<cl_Website> GetWebsiteTop5(ref List<cl_Website> lstWebsite, ref string dtFrom, ref string dtUntil)
        {
            Database database = DatabaseFactory.CreateDatabase("WEBSITE");

            using (DbCommand command = database.GetStoredProcCommand("USP_SELECT_TOP5"))
            {
                using (IDataReader rdrWebsite = database.ExecuteReader(command))
                {
                    while (rdrWebsite.Read())
                    {
                        cl_Website website = new cl_Website();
                        website.Visits = rdrWebsite["VISITS"].ToString();
                        website.Name = rdrWebsite["WEBSITE"].ToString();
                        website.DateTime = Convert.ToDateTime(rdrWebsite["SYS_DATE_TIME"]);

                        lstWebsite.Add(website);
                    }
                    if (rdrWebsite.NextResult())
                    {
                        while (rdrWebsite.Read())
                        {
                            dtFrom = rdrWebsite["DTFROM"].ToString();
                        }
                    }
                    if (rdrWebsite.NextResult())
                    {
                        while (rdrWebsite.Read())
                        {
                            dtUntil = rdrWebsite["DTUNTIL"].ToString();
                        }
                    }
                }
            }

            return lstWebsite;
        }

        public static List<cl_Website> GetWebsiteByDate(DateTime dtFrom, DateTime dtUntil)
        {
            List<cl_Website> lstWebsite = new List<cl_Website>();

            Database database = DatabaseFactory.CreateDatabase("WEBSITE");

            using (DbCommand command = database.GetStoredProcCommand("USP_SELECT_TOP5_BY_DATE"))
            {

                database.AddInParameter(command, "@dateFrom", DbType.String, dtFrom);

                database.AddInParameter(command, "@dateUntil", DbType.String, dtUntil);


                using (IDataReader rdrEvents = database.ExecuteReader(command))
                {
                    while (rdrEvents.Read())
                    {
                        cl_Website website = new cl_Website();
                        website.Visits = rdrEvents["VISITS"].ToString();
                        website.Name = rdrEvents["WEBSITE"].ToString();
                        website.DateTime = Convert.ToDateTime(rdrEvents["SYS_DATE_TIME"]);

                        lstWebsite.Add(website);
                    }
                }
            }

            return lstWebsite;
        }

    }
}
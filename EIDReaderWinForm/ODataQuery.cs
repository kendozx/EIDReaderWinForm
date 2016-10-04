using SFODataRead;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace EIDReaderWinForm
{
    public static class ODataQuery
    {
        public static string companyID = Properties.Settings.Default.CompanyID; // "SFPART005872";
        public static string userID = Properties.Settings.Default.Username;
        public static string zpassword = Properties.Settings.Default.Password;
        public static Uri OdataUri = new Uri(Properties.Settings.Default.OdataUri + "/odata/v2");
        //public static Uri OdataUri = new Uri("https://apisalesdemo8.successfactors.com/odata/v2");

        private static void dc_SendingRequest(object sender, SendingRequestEventArgs e)
        {
            companyID = Properties.Settings.Default.CompanyID;
            userID = Properties.Settings.Default.Username;
            zpassword = Properties.Settings.Default.Password;
            OdataUri = new Uri(Properties.Settings.Default.OdataUri + "/odata/v2");
            e.RequestHeaders.Clear();
            e.RequestHeaders["Authorization"] = 
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(ODataQuery.userID + "@" + ODataQuery.companyID + ":" + ODataQuery.zpassword));
            ((HttpWebRequest)e.Request).Accept = "application/atom";
            ((HttpWebRequest)e.Request).ReadWriteTimeout = 60000;
        }

        public static List<User> getUser(string sUser)
        {
            List<User> lsUser = new List<User>();
            EntityContainerRead ec = new EntityContainerRead(OdataUri);
            ec.SendingRequest += dc_SendingRequest;
            // simple query
            System.Linq.IQueryable<User> pos;

            if (!String.IsNullOrEmpty(sUser.Trim()))
            {
                //pos = ec.User.Where(p => p.username.Contains(sUser));
                pos = from o in ec.User
                      where o.username.Contains(sUser)
                      orderby o.username
                      select o;
            }
            else
            {
                pos = from o in ec.User orderby o.username select o;
            }

            lsUser = pos.ToList<User>();
            return lsUser;

        }

        public static string addUser(SFOData.User oUser)
        {
            string result = "SUCCESS";
            SFOData.EntityContainer ec = new SFOData.EntityContainer(OdataUri);
            ec.SendingRequest += dc_SendingRequest;

            SFOData.PerPerson oPerPerson = new SFOData.PerPerson()
            {
                personIdExternal = oUser.userId,
                userId = oUser.userId,
                dateOfBirth = oUser.dateOfBirth
            };

            SFOData.PerPersonal oPerPersonal = new SFOData.PerPersonal()
            {
                personIdExternal = oUser.userId,
                gender = oUser.gender,
                firstName = oUser.firstName,
                lastName = oUser.lastName,
                nationality = "BEL"
            };

            // simple query
            DataServiceResponse serviceResponse;
            //ec.AddToUser(oUser);
            //ec.AddToPerPerson(oPerPerson);
            ec.AddToPerPersonal(oPerPersonal);

            try
            {
                serviceResponse = ec.SaveChanges();
            }
            catch (DataServiceRequestException ex)
            {
                result = ex.InnerException.Message;
                try
                {
                    var str = XElement.Parse(result);
                    result = str.Value;
                }
                catch (Exception e)
                {

                    result = ex.InnerException.Message;
                }
                
            }

            return result;
            
        }

        public static string addPhoto(SFOData.Photo oPhoto)
        {
            string result = "SUCCESS";
            SFOData.EntityContainer ec = new SFOData.EntityContainer(OdataUri);
            ec.SendingRequest += dc_SendingRequest;

            // simple query
            DataServiceResponse serviceResponse;
            ec.AddToPhoto(oPhoto);

            try
            {
                serviceResponse = ec.SaveChanges();
            }
            catch (DataServiceRequestException ex)
            {
                result = ex.InnerException.Message;
                try
                {
                    var str = XElement.Parse(result);
                    result = str.Value;
                }
                catch (Exception e)
                {
                    result = ex.InnerException.Message;
                }
            }

            return result;

        }

        public static bool isIDExisted(string sNationalId)
        {
            EntityContainerRead ec = new EntityContainerRead(OdataUri);
            ec.SendingRequest += dc_SendingRequest;
            // simple query
            System.Linq.IQueryable<PerNationalId> pos;

            if (!String.IsNullOrEmpty(sNationalId))
            {
                //pos = ec.User.Where(p => p.username.Contains(sUser));
                pos = from o in ec.PerNationalId
                      where o.nationalId == sNationalId
                            && o.cardType == "belnatid"
                            && o.country == "BEL"
                      select o;
            }
            else
            {
                throw new ArgumentException("Input national ID must not be blank");
            }

            List<PerNationalId> lsNationalId = pos.ToList<PerNationalId>();
            return lsNationalId.Count > 0 ? true : false;
        }
    }
}
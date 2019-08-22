
using System;
using System.Collections.Generic;
using System.Data;
using VirtualGit.Models;

namespace VirtualGit.Util
{
    public class JsonHelper
    {
        DBHelper dB;
  
        public List<VirtualModel> Get_VirtualResponse (string con, int id )
        {
            dB=new DBHelper ();
            DataTable dt = dB.GetVirtualResponseTest (id);
            List<VirtualModel> listGrid = new List<VirtualModel> ();
            foreach (DataRow dr in dt.Rows)
            {
                listGrid.Add ( new VirtualModel
                {
                    Buid=Convert.ToInt32 ( dr["Buid"].ToString () ),
                    OrderNumber=Convert.ToString ( dr["OrderNumber"].ToString () ),
                    DPID=Convert.ToString ( dr["DPID"].ToString () ),
                    GossResponse=Convert.ToString ( dr["GossResponse"].ToString () ),
                    ID=Convert.ToInt32 ( dr["ID"].ToString () ),
                    TestCase=Convert.ToString ( dr["TestCase"].ToString () ),
                    User=Convert.ToString ( dr["User"].ToString () ),
                    Date=Convert.ToString ( dr["Date"].ToString () ),
                } );
            }
            return (listGrid);
        }

        //public List<UserModel> Get_UsersResponse ( )
        //{
        //    dB=new DBHelper (true);
        //    DataTable dt = dB.GetAllUSers ();
        //    List<UserModel> listGrid = new List<UserModel> ();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        listGrid.Add ( new UserModel
        //        {
        //            ID=Convert.ToInt32 ( dr["ID"].ToString () ),
        //            TUser=Convert.ToString ( dr["TUser"].ToString () ),
        //            CountR=Convert.ToInt32 ( dr["CountR"].ToString () ),
        //            uTimeStamp=Convert.ToDateTime ( dr["uTimeStamp"].ToString () ),
        //            version=Convert.ToString ( dr["version"].ToString () ),

        //        } );
        //    }
        //    return (listGrid);
        //}

        //public List<Configuration> Get_VirtualConfig ( )
        //{
        //    dB=new DBHelper ( true );
        //    DataTable dt = dB.GetAllIP ();
        //    List<Configuration> listGrid = new List<Configuration> ();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        listGrid.Add ( new Configuration
        //        {
        //            ID=Convert.ToInt32 ( dr["ID"].ToString () ),
        //            EnvID=Convert.ToInt32 ( dr["EnvID"].ToString () ),
        //            IP=Convert.ToString ( dr["IP"].ToString () ),
        //            Site=Convert.ToString ( dr["Site"].ToString () ),
        //            Purpose=Convert.ToString ( dr["Purpose"].ToString () ),
        //            ChangedBy=Convert.ToString ( dr["ChangedBy"].ToString () ),
        //            Notes=Convert.ToString ( dr["Notes"].ToString () ),
        //            RequestedBy=Convert.ToString ( dr["RequestedBy"].ToString () ),
        //            Date=Convert.ToDateTime ( dr["Date"].ToString () ),
        //            Application=Convert.ToString ( dr["Application"].ToString () ),
        //            UDF=Convert.ToString ( dr["UDF"].ToString () ),
        //            Active=Convert.ToBoolean ( dr["Active"].ToString () ),

        //        } );
        //    }
        //    return listGrid;
        //}
    }
}

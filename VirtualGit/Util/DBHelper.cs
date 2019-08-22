using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VirtualGit.Models;
using Microsoft.Extensions.Configuration;

namespace VirtualGit.Util
{
    public class DBHelper
    {
        private SqlConnection con;
        public DBHelper ( bool flag = true )
        {
            var connectionH = @"Data Source=DESKTOP-7L5V023\SQLEXPRESS; Initial Catalog = TriageDB; Integrated Security = true";
            //var connection = flag ? _configuration["ConnectionOS"].ToString () : _configuration["ConnectionOS"].ToString ();
            con=new SqlConnection ();
            con.ConnectionString=connectionH;
        }

        public DataTable GetVirtualResponseTest (int id)
        {
            try
            {
                var Query = (id<=0) ? "Select * from [VirtualResponseTest]" : "Select top 1 * from [VirtualResponseTest] where id= "+id;
                if (con==null)
                    return new DataTable ();
                DataTable dt = SqlHelper.ExecuteDataset ( con, CommandType.Text, Query ).Tables[0];
                if (dt!=null&&dt!=null&&dt.Rows.Count>0)
                    return dt;
                else
                    return new DataTable ();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetAllIP ( )
        {
            try
            {
                if (con==null)
                    return new DataTable ();
                DataSet ds = SqlHelper.ExecuteDataset ( con, CommandType.Text, "Select * from [Host_Entries_1]" );
                if (ds!=null&&ds.Tables!=null&&ds.Tables.Count>0)
                    return ds.Tables[0];

                else
                    return new DataTable ();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetAllUSers ( )
        {
            try
            {
                if (con==null)
                    return new DataTable ();
                DataSet ds = SqlHelper.ExecuteDataset ( con, CommandType.Text, "Select * from [tblUserCheck] order by uTimeStamp desc" );
                if (ds!=null&&ds.Tables!=null&&ds.Tables.Count>0)
                    return ds.Tables[0];
                else
                    return new DataTable ();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertNew ( VirtualModel obj, string user, bool flag )
        {
            try
            {
                int iretVal = 0;
                SqlParameter[] Params = new SqlParameter[8];
                Params[0]=new SqlParameter ( "@OrderNumber", SqlDbType.VarChar );
                Params[0].Value=obj.OrderNumber;
                Params[1]=new SqlParameter ( "@Buid", SqlDbType.Int );
                Params[1].Value=obj.Buid;
                Params[2]=new SqlParameter ( "@DPID", SqlDbType.VarChar );
                Params[2].Value=obj.DPID;
                Params[3]=new SqlParameter ( "@TestCase", SqlDbType.VarChar );
                Params[3].Value=obj.TestCase;
                Params[4]=new SqlParameter ( "@User", SqlDbType.VarChar );
                Params[4].Value=user;
                Params[5]=new SqlParameter ( "@GossResponse", SqlDbType.VarChar );
                Params[5].Value=obj.GossResponse;
                Params[6]=new SqlParameter ( "@flag", SqlDbType.Bit );
                Params[6].Value=flag;
                Params[7]=new SqlParameter ( "@id", SqlDbType.Int );
                Params[7].Value=obj.ID;
                iretVal=SqlHelper.ExecuteNonQuery ( con, CommandType.StoredProcedure, "[spAddAndEditResponce]", Params );
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Delete ( int obj )
        {
            try
            {
                SqlHelper.ExecuteNonQuery ( con, CommandType.Text, "Delete from [VirtualResponseTest] where ID = "+obj );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

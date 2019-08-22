

using System.Collections.Generic;
using VirtualGit.Util;
namespace VirtualGit.Models.Repository
{
    public class VirtualModelRepository : IVirtualModelRepository
    {

        JsonHelper jsonHelper;
        DBHelper helper;
        public VirtualModelRepository()
        {

        }
        public IEnumerable<VirtualModel> GetVirtualModels(string con, int iD)
        {
            jsonHelper=new JsonHelper ();
            return jsonHelper.Get_VirtualResponse ( con , iD );
        }
        public void InsertNew( VirtualModel virtualModel, bool flag= true)
        {
            helper=new DBHelper ();
            helper.InsertNew (virtualModel, CommonHelper.GetCurrentUser(), flag );
        }
    }
}


using System.Collections.Generic;


namespace VirtualGit.Models.Repository
{
    public interface IVirtualModelRepository
    {
        IEnumerable<VirtualModel> GetVirtualModels (string Con, int id);
        void InsertNew ( VirtualModel virtualModel , bool flag);
    }
}

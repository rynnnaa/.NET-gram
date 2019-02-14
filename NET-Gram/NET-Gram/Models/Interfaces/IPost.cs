using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Gram.Models.Interfaces
{
    public interface IPost
    {

        //Delete
        Task DeleteAsync(int id);

        //Find
        Task<Post> FindPost(int id);

        //GetAll
        Task<List<Post>> GetPosts();      

        //Save
        Task SaveAsync(Post post);

      
    }
}

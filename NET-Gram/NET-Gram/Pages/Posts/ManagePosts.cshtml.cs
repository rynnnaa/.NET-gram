using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_Gram.Models;
using NET_Gram.Models.Interfaces;

namespace NET_Gram.Pages.Posts
{
    public class ManagePostsModel : PageModel
    {
        private readonly IPost _post;

        [FromRoute]
        public int ID { get; set; }

        //data thats saved inside user form is then bound to the post property
        [BindProperty]
        public Post Post { get; set; }

        public ManagePostsModel(IPost post)
        {
            _post = post;
        }

        //gets the data
        public async Task OnGet()
        {
            Post = await _post.FindPost(ID);
        }
        //posts back to the server
        public async Task OnPost()
        {
           await _post.SaveAsync(Post);
        }
            
        
    }
}
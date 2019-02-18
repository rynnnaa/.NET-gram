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
    public class IndexModel : PageModel
    {
        private readonly IPost _post;

        public IndexModel(IPost post)
        {
            _post = post;
        }

        [FromRoute]
        //id is captured in the route
        public int ID { get; set; }

        public Post Post { get; set; }

        public async Task OnGet()
        {
            //set data for .cshtml page

            //get specific post data for id that was sent
            //set data from db to the property from post
            Post = await _post.FindPost(ID);
        }
    }
}
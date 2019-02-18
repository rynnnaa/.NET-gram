using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public int? ID { get; set; }

        //data thats saved inside user form is then bound to the post property
        [BindProperty]
        public Post Post { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }


        public ManagePostsModel(IPost post)
        {
            _post = post;
        }

        /// <summary>
        /// Gets a post
        /// </summary>
        /// <returns>post</returns>
        public async Task OnGet()
        {
            //if there isn't a post, create a new one
            Post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();
        }
        //posts back to the server
        public async Task<IActionResult> OnPost()
        {
            var pst = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();

            //set data from the db to the new data from Post/user input
            pst.Title = Post.Title;
            pst.Caption = Post.Caption;

            await _post.SaveAsync(Post);
            return RedirectToPage("Index");
        }
    }
}
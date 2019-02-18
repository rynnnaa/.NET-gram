using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.WindowsAzure.Storage.Blob;
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
        public object BlobImage { get; private set; }

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

            if (Image != null)
            {
                //Azure blob
                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                //get container
                var container = await BlobImage.GetContainer("postimages");

                //upload image
                BlobImage.UploadFile(container, Image.FileName, filePath);

                //get uploaded image
                CloudBlob blob = await BlobImage.GetBlob(Image.FileName, container.Name);

                //update the db image for the post
                pst.URL = blob.Uri.ToString();
            }

            //save the post to the db
            await _post.SaveAsync(pst);

            return RedirectToPage("/Index");
        }

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <returns>home page</returns>
        public async Task<IActionResult> OnPostDelete()
        {
            await _post.DeleteAsync(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}
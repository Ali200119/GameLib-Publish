using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class BlogCommentService: IBlogCommentService
	{
		private readonly IBlogCommentRepository _blogCommentRepo;

        public BlogCommentService(IBlogCommentRepository blogCommentRepo)
        {
            _blogCommentRepo = blogCommentRepo;
        }



        public async Task<IEnumerable<BlogComment>> GetAllAsync(int? blogId)
        {
            if (blogId is null) throw new ArgumentNullException();

            IEnumerable<BlogComment> blogComment = await _blogCommentRepo.GetAllAsync(bc => bc.User);

            return blogComment.Where(gc => gc.BlogId == blogId);
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            BlogComment blogComment = await _blogCommentRepo.GetByIdAsync(id);

            if (blogComment is null) throw new NullReferenceException();

            await _blogCommentRepo.DeleteAsync(blogComment);
        }

        public async Task CreateAsync(BlogComment blogComment)
        {
            if (blogComment is null) throw new ArgumentNullException();

            await _blogCommentRepo.CreateAsync(blogComment);
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class PostRepo
    {
        internal async static Task<List<Post>> GetPostsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.ToListAsync();
            }
        }
        internal static async Task<Post> GetPostByIDAsync(int id)
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.FirstOrDefaultAsync(x => x.PostID == id);
            }
        }

        internal async static Task<Post> CreatePostAsync(Post Post)
        {
            using (var db = new AppDBContext())
            {
                await db.Posts.AddAsync(Post);
                await db.SaveChangesAsync();
                return Post;
            }
        }

        internal async static Task<bool> UpdatePostAsync(Post Post)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Posts.Update(Post);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal async static Task<bool> DeletePostAsync(int id)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    var post = await db.Posts.FirstOrDefaultAsync(x => x.PostID == id);
                    if (post != null)
                        db.Posts.Remove(post);
                    else
                        return false;

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }
}

namespace Mathesio.Discussion.DAL
{
    public class Comment : Thread
    {
        public virtual Comment Parent { get; set; }
    }
}
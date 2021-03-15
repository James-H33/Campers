namespace Campers.Models
{
  public class PagedQuery
  {
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 0;

    public string AsString()
    {
      return $"?skip={Skip}&take={Take}";
    }
  }
}

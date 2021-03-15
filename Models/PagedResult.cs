using System.Collections.Generic;

namespace Campers.Models
{
  public class PagedResult<T>
  {
    public int Count { get; set; } = 0;
    public List<T> Results { get; set; } = new List<T>();
  }
}

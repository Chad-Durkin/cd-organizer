using System.Collections.Generic;

namespace CdOrganizer.Objects
{
  public class Cd
  {
    private string _title;
    private static List<Cd> _instances = new List<Cd>{};
    private int _id;

    public Cd(string title)
    {
      _title = title;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetTitle()
    {
      return _title;
    }

    public void SetTitle(string newTitle)
    {
      _title = newTitle;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Cd> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Cd Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}

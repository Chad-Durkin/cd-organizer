using System.Collections.Generic;

namespace CdOrganizer.Objects
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist> {};
    private string _artist;
    private int _id;
    private List<Cd> _cds;

    public Artist(string artist)
    {
      _artist = artist;
      _instances.Add(this);
      _id = _instances.Count;
      _cds = new List<Cd> {};
    }

    public string GetArtist()
    {
      return _artist;
    }

    public int GetId()
    {
      return _id;
    }

    public List<Cd> GetCds()
    {
      return _cds;
    }

    public void AddCD(Cd cd)
    {
      _cds.Add(cd);
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static void Clear()
    {
      _instances.Clear();
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public static bool CheckArtist(string artist)
    {
      for(var index = 0; index < _instances.Count; index++)
      {
        if(artist.ToLower() == _instances[index].GetArtist().ToLower())
        {
          return true;
        }
      }
      return false;
    }

    public static Artist GrabArtist(string artist)
    {
      var ind = 0;
      for(var index = 0; index < _instances.Count; index++)
      {
        if(artist.ToLower() == _instances[index].GetArtist().ToLower())
        {
            ind = index;
        }
      }
      return _instances[ind];
    }
  }
}

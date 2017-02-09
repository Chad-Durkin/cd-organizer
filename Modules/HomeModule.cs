using Nancy;
using System.Collections.Generic;
using CdOrganizer.Objects;

namespace CdOrganizerApp
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/cd/new"] = _ => {
        return View["create_cd.cshtml"];
      };
      Post["/artists"] = _ => {
        var newCd = new Cd(Request.Form["title"]);
        if(Artist.CheckArtist(Request.Form["artist-name"]))
        {
          var currentArtist = Artist.GrabArtist(Request.Form["artist-name"]);
          currentArtist.AddCD(newCd);
        }
        else
        {
          var newArtist = new Artist(Request.Form["artist-name"]);
          newArtist.AddCD(newCd);
        }
        var allArtists = Artist.GetAll();
        return View["artists.cshtml", allArtists];
      };
      Get["/artists"] = _ => {
        var allArtists = Artist.GetAll();
        return View["artists.cshtml", allArtists];
      };
      Get["/artists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedArtist = Artist.Find(parameters.id);
        var artistCds = selectedArtist.GetCds();
        model.Add("artist", selectedArtist);
        model.Add("cds", artistCds);
        return View["artist_list.cshtml", model];
      };
      Get["/artist/search"] = _ => {
        return View["search_artist.cshtml"];
      };
      Post["/artists/search/results"] = _ => {
        if(Artist.CheckArtist(Request.Form["search-artist"]))
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          var searchArtist = Artist.GrabArtist(Request.Form["search-artist"]);
          var artistCds = searchArtist.GetCds();
          model.Add("artist", searchArtist);
          model.Add("cds", artistCds);
          return View["artist_list.cshtml", model];
        }
        return View["no_artist.cshtml"];
      };
    }
  }
}

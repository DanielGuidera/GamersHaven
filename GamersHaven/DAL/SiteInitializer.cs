using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersHaven.Models;

namespace GamersHaven.DAL
{
    public class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {
        protected override void Seed(SiteContext context)
        {
            var articles = new List<ArticleModels>
            {
                new ArticleModels {ID = 1, title = "God of War", thumbnail = "https://i.ytimg.com/vi/CJ_GCPaKywg/maxresdefault.jpg", blurb = "The latest issue of Weekly Famitsu is now available, providing our first look at Code Vein, the new Unreal Engine 4 action RPG from Bandai Namco led by key God Eater staff Keita Iizuka (producer), Hiroshi Yoshimura (director), and Yusuke Tomizawa (team leader).", link = "https://godofwar.playstation.com/", status = ArticleModels.Status.Approved, reported = false},
                new ArticleModels {ID = 2, title = "The Last of Us", thumbnail = "https://c2.staticflickr.com/6/5597/31396458265_93118cec4a_z.jpg", blurb = "the last of us blurb", link = "https://www.naughtydog.com/blog/the_last_of_us_part_ii", status = ArticleModels.Status.Approved, reported = false },
                new ArticleModels {ID = 3, title = "Shadow of War", thumbnail = "https://cdn.gamerant.com/wp-content/uploads/middle-earth-shadow-of-war-mithril-edition-title.jpg", blurb = "shadow of War blurb", link = "https://www.shadowofwar.com/", status = ArticleModels.Status.Approved, reported = false },
                new ArticleModels {ID = 4, title = "Persona 5", thumbnail = "http://vignette4.wikia.nocookie.net/megamitensei/images/6/68/P5_illustration_by_Shigenori_Soejima.jpg/revision/latest?cb=20150919150530", blurb = "persona blurb", link = "http://atlus.com/persona5/", status = ArticleModels.Status.Approved, reported = false  },
                new ArticleModels {ID = 5, title = "Horizon Zero Dawn", thumbnail = "https://i.ytimg.com/vi/GauAr4lWjyw/maxresdefault.jpg", blurb = "horizon blurb", link = "https://www.playstation.com/en-ie/games/horizon-zero-dawn-ps4/", status = ArticleModels.Status.Pending, reported = false  },
                new ArticleModels {ID = 6, title = "Ori and the Blind Forest", thumbnail = "http://cdn.edgecast.steamstatic.com/steam/apps/261570/header.jpg?t=1462923075", blurb = "ori blurb", link = "http://www.oriblindforest.com/", status = ArticleModels.Status.Pending, reported = false  }
            };

            articles.ForEach(s => context.Articles.Add(s));
            context.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCMS.Models.ViewModels
{
    public class vmPosts
    {
        public List<Models.POCOs.PostsModel> AllPosts { get; set; }
        public List<Models.POCOs.CategoriesModel> AllCategories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.ViewModels.Review
{
    public class ReviewDetailsViewModel
    {
        public int Rating { get; set; }
        public string Comment { get; internal set; }
    }
}

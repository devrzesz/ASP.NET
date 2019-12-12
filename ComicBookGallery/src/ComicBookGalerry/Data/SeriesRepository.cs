using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComicBookGalerry.Models;

namespace ComicBookGalerry.Data
{
    public class SeriesRepository
    {
        private static Series[] _series = new Series[]
        {
            new Series() {Title = "The Amazing Spider-Man"},
            new Series() {Title = "Bone"},
        };

    }
}
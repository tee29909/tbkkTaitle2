using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.HelpDesk
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<ShowReport> Report { get;set; }

        [BindProperty(SupportsGet = true)]

        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;

        public SelectList Type { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReportType { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.ReportList
                                            orderby m.Type
                                            select m.Type;

            var Reports = from m in _context.ReportList
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Reports = Reports.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ReportType))
            {
                Reports = Reports.Where(x => x.Type == ReportType);
            }
            Type = new SelectList(await genreQuery.Distinct().ToListAsync());

            Report = await Reports.ToListAsync();
        }
    }
}

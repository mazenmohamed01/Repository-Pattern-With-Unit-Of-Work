using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        private readonly ApplicationdbContext _context;

        public BooksRepository(ApplicationdbContext context) : base(context) { }
        
        public IEnumerable<Book> SpicialMethodOfBook()
        {
            throw new NotImplementedException();
        }
    }
}

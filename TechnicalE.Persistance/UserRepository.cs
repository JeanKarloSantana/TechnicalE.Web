using System;
using System.Collections.Generic;
using System.Text;
using TechnicalE.DAL.SQL;
using TechnicalE.Entities;
using TechnicalE.Interfaces;
using TechnicalE.Persistance.Generic;

namespace TechnicalE.Persistance
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public TechnicalEvDbContext _context { get { return context; } }

        public UserRepository(TechnicalEvDbContext dbContext) : base(dbContext)
        {
        }
    
    }
}

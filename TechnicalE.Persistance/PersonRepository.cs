using System;
using System.Collections.Generic;
using System.Text;
using TechnicalE.DAL.SQL;
using TechnicalE.Entities;
using TechnicalE.Interfaces;
using TechnicalE.Persistance.Generic;

namespace TechnicalE.Persistance
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public TechnicalEvDbContext _context { get { return context; } }

        public PersonRepository(TechnicalEvDbContext dbContext) : base(dbContext)
        {
        }
    }
}

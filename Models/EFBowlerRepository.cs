using System;
using System.Linq;

namespace Mission13.Models
{
    public class EFBowlerRepository : IBowlerRepository
    {
        private BowlerDBContext _context { get; set; }

        public EFBowlerRepository(BowlerDBContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;

        public void Add(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void Edit(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void Delete(Bowler b)
        {
            _context.Bowlers.Remove(b);
            _context.SaveChanges();
        }
    }
}

using System;
using System.Linq;

namespace Mission13.Models
{
    public interface IBowlerRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }
        void Add(Bowler b);
        void Edit(Bowler b);
        void Delete(Bowler b);
    }
}

using GoodLife_Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodLife_Asp.Services
{
    public interface IGoodLife
    {
        IEnumerable<GoodLife> GetMembers { get; }
        GoodLife GetMember(int Id);
        void Add(GoodLife _member);
        void remove(int Id);
    }
}

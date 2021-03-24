using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class EFAssignment3Repository : IAssignment3Repository
    {

        private Assignment3DbContext _context;

        //Constructor
        public EFAssignment3Repository (Assignment3DbContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationResponse> Responses => _context.Responses;
    }
}

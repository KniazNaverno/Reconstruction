using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconstruction
{
    public class Helper
    {
        private static SystemContext _context;
        public static User User { get; set; }
        public static SystemContext GetContext()
        {
            if (_context == null)
                _context = new SystemContext();
            return _context;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Models
{
    interface ICategoryRepository : IRepository<Category>
    {
        Category GetByID(int categoryID);
    }
}

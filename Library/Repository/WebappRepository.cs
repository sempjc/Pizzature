using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using Webapp.DataAccess.Models;

namespace Webapp.Library.Repository
{
    public class WebappRepository
    {
        private readonly PizzaStoreAppContext _db;

        public WebappRepository(PizzaStoreAppContext db)
        {
            _db = db ?? throw new ArgumentException(nameof(db));
        }
    }
}

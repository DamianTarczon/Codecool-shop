using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations.Database
{
    public class SupplierDaoDb : ISupplierDao
    {
        private readonly CodecoolShopContext _context;
        public SupplierDaoDb(CodecoolShopContext context)
        {
            _context = context;
        }

        public void Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Suppliers.Remove(this.Get(id));
            _context.SaveChanges();
        }

        public Supplier Get(int id)
        {
            return _context.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();
        }
    }
}

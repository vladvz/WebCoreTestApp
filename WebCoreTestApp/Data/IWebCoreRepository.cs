using System.Collections.Generic;
using WebCoreTestApp.Data.Entities;

namespace WebCoreTestApp.Data
{
    public interface IWebCoreRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCoreTestApp.Data.Entities;

namespace WebCoreTestApp.Data
{
    public class WebCoreRepository : IWebCoreRepository
    {
        private readonly WebCoreContext _context;
        private readonly ILogger<WebCoreRepository> _logger;

        public WebCoreRepository(WebCoreContext context, ILogger<WebCoreRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Get all products");

                return _context.Products.OrderBy(p => p.Title).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception has occured: {ex.Message}");
            }

            return null;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _context.Products.Where(p => p.Category.Equals(category)).ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}

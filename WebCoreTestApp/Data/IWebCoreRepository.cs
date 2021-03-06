﻿using System.Collections.Generic;
using WebCoreTestApp.Data.Entities;

namespace WebCoreTestApp.Data
{
    public interface IWebCoreRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);

        bool SaveAll();
        void AddEntity(object model);
    }
}
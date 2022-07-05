﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;


namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class CartDao : ICartDao
    {
        private Cart _data = new Cart();
        private static CartDao _instance = null;

        public static CartDao GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CartDao();
            }

            return _instance;
        }


        public Dictionary<Product,int> GetAll()
        {
            var productDict = new Dictionary<Product, int>();
            foreach (var cartDetail in _data.CartDetails)
            {
                if (productDict.ContainsKey(cartDetail.Product))
                {
                    productDict[cartDetail.Product] = cartDetail.Quantity;
                }
                else 
                    productDict.Add(cartDetail.Product, cartDetail.Quantity);
            }
            return productDict;
        }

        public void IncreaseProduct(Product product)
        {
            int id = _data.CartDetails.Count + 1;
            CartDetail cartDetail = new CartDetail() {Cart = _data, Id = id, Product = product, Quantity = 1 };

            if (_data.CartDetails.Count == 0)
            {
                _data.CartDetails.Add(cartDetail);
            }
            else if (_data.CartDetails.Where(x => x.Product == product).SingleOrDefault()==null)
            { _data.CartDetails.Add(cartDetail); }
            else
            _data.CartDetails.Where(x => x.Product == product).SingleOrDefault().Quantity++;
        }

        public void DecreaseProduct(Product product)
        {
            _data.CartDetails.Where(x => x.Product == product).FirstOrDefault().Quantity--;

        }

        public void RemoveProduct(Product product)
        {
            _data.CartDetails.Remove(_data.CartDetails.Where(x => x.Product == product).FirstOrDefault());
        }

        public void RemoveAllProducts()
        {
            _data.CartDetails.Clear();
        }
    }
}

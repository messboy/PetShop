using System;

//References to PetShop specific libraries
//PetShop busines entity library
using PetShop.Model;
using System.Collections.Generic;

namespace PetShop.IDAL{
	
	/// <summary>
	/// Interface for the Order DAL
	/// </summary>
	public interface IOrder {

		/// <summary>
		/// Method to insert an order header
		/// </summary>
		/// <param name="order">Business entity representing the order</param>
		/// <returns>OrderId</returns>
		void Insert(OrderInfo order);

		/// <summary>
		/// Reads the order information for a given orderId
		/// </summary>
		/// <param name="orderId">Unique identifier for an order</param>
		/// <returns>Business entity representing the order</returns>
		OrderInfo GetOrder(int orderId);

        void Update(OrderInfo order);


        List<OrderInfo> GetOrderByUserId(string UserId);

        void Delete(int orderId);
    }
}

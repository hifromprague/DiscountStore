using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountStore
{
    public class CartService : ICartService
    {
        Dictionary<string, Item> cart = new Dictionary<string, Item>();
        Dictionary<string, Offer> offers = new Dictionary<string, Offer>();

        public void Add(Item item)
        {
            if (!cart.ContainsKey(item.Name))
            {
                cart.Add(item.Name, item);
            }
            else
            {
                cart[item.Name].Quantity = cart[item.Name].Quantity + item.Quantity;
            }
        }

        public void Remove(Item item)
        {
            if (!cart.ContainsKey(item.Name))
                throw new InvalidOperationException();

            if ((cart[item.Name]).Quantity == item.Quantity)
            {
                cart.Remove(item.Name);
            }
            else
            {
                cart[item.Name].Quantity = cart[item.Name].Quantity - item.Quantity;
            }
        }

        public decimal GetTotal()
        {
            var result = 0m;
            foreach (string key in cart.Keys)
            {
                var item = cart[key];

                if (offers.ContainsKey(key))
                {
                    var offer = offers[key];

                    if (offer.Quantity < item.Quantity)
                    {
                        result += ((item.Quantity % offer.Quantity) * item.Price) + ((item.Quantity / offer.Quantity) * offer.Price);
                    }
                    else if (offer.Quantity == item.Quantity)
                    {
                        result += offer.Price;
                    }
                    else
                    {
                        result += item.Quantity * item.Price;
                    }
                }
                else
                {
                    result += item.Quantity * item.Price;
                }
            }

            return result;
        }

        public void AddOffer(Offer offer)
        {
            if (!offers.ContainsKey(offer.Name))
            {
                offers.Add(offer.Name, offer);
            }
        }

        public void RemoveOffer(Offer offer)
        {
            if (!offers.ContainsKey(offer.Name))
                throw new InvalidOperationException();
            else
            {
                offers.Remove(offer.Name);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountStore
{
    public interface ICartService
    {
        void Add(Item item);
        void Remove(Item item);
        void AddOffer(Offer offer);
        void RemoveOffer(Offer offer);
        decimal GetTotal();
    }
}

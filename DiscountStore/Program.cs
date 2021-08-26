using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var item1 = new Item("Vase", 1.2m);
            var item2 = new Item("Big mug", 1m);
            var item3 = new Item("Big mug", 1m);
            var item4 = new Item("Big mug", 1m);
            var item5 = new Item("Big mug", 1m);
            var item6 = new Item("Big mug", 1m);

            var item8 = new Item("Napkins pack", 0.45m);
            var item9 = new Item("Napkins pack", 0.45m);
            var item10 = new Item("Napkins pack", 0.45m);
            var item11 = new Item("Napkins pack", 0.45m);

            var offer1 = new Offer("Big mug", 1.5m, 2);
            var offer2 = new Offer("Napkins pack", 0.9m, 3);

            var cartService = new CartService();
            cartService.Add(item1);
            cartService.Add(item2);
            cartService.Add(item3);
            cartService.Add(item4);
            cartService.Add(item5);
            cartService.Add(item6);

            cartService.Add(item8);
            cartService.Add(item9);
            cartService.Add(item10);
            cartService.Add(item11);

            cartService.AddOffer(offer1);
            cartService.AddOffer(offer2);

            Console.WriteLine(cartService.GetTotal());

            Console.ReadLine();
        }
    }
}

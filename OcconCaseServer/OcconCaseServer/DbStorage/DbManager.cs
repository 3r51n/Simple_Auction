using System;
using System.Collections.Generic;
using System.Linq;
using Occon.Server.Api.Models;
using Occon.Server.Api.DataStorage.RedisConfig;

namespace Occon.Server.Api.DbStorage
{
    public static class DbManager
    {
        private const string RedisKey = "Occon";
        public static OcconModel List;
        private static RedisManager _redisManager;


        static DbManager() { _redisManager = new RedisManager(RedisKey); }

        public static OcconModel GetData(bool restore)
        {
            if (restore)
                List = null;

            if (List != null && List.EndTime > DateTime.Now)
            {
                var nowtime = DateTime.Now.ToLongTimeString();
                var finishtime = List.EndTime.ToLongTimeString();

                TimeSpan duration = DateTime.Parse(finishtime).Subtract(DateTime.Parse(nowtime));

                List.BalanceTime = duration.ToString(@"mm\:ss");
                return List;
            }
            else if (List == null || List.EndTime <= DateTime.Now)
            {
                if (List != null)
                {
                    OcconModel xxx = _redisManager.Get<OcconModel>(List.Key.ToString());
                }

                var r = new Random();
                var endtime = DateTime.Now.AddMinutes(2);
                List = new OcconModel{ Key = Guid.NewGuid(), EndTime = endtime, BalanceTime = endtime.ToString("dd.MM.yyyy HH:mm:ss"), Bidders = new List<Bidder>
                    {
                        new Bidder { Name = "User 1", Price = r.Next(1, 60) },
                        new Bidder { Name = "User 2", Price = r.Next(1, 60) },
                        new Bidder { Name = "User 3", Price = r.Next(1, 60) }
                    }
                };

                var highest = List.Bidders.OrderByDescending(x => x.Price).FirstOrDefault();
                List.HighestBid = highest.Price;
                List.HighestBidder = highest.Name;

                _redisManager.Set(List.Key.ToString(), List);

                return List;
            }

            return List;
        }

        public static OcconModel SetData(string user, decimal price, int id)
        {
            List.Bidders.Find(x => x.Name == user).Price = price;

            var highest = List.Bidders.OrderByDescending(x => x.Price).FirstOrDefault();
            List.HighestBid = highest.Price;
            List.HighestBidder = highest.Name;

            _redisManager.Set(List.Key.ToString(), List);

            return List;
        }
    }
}

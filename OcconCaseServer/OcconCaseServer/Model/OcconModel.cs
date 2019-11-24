using System;
using System.Collections.Generic;


namespace Occon.Server.Api.Models


{
    public class Bidder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class OcconModel
    {
        public Guid Key { get; set; }
        public DateTime EndTime { get; set; }
        public List<Bidder> Bidders { get; set; }
        public string HighestBidder { get; set; }
        public string HighestBidder2 { get; set; }
        public decimal HighestBid { get; set; }
        public decimal HighestBid2 { get; set; }
        public string BalanceTime { get; set; }
    }


}

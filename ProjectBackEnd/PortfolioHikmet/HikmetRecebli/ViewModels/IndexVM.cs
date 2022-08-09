using HikmetRecebli.Models;
using System.Collections.Generic;

namespace HikmetRecebli.ViewModels
{
    public class IndexVM
    {
        public IList<Portfolio> Portfolios { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}

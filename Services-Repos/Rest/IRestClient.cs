using Services_Repos.Models.Data_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Repos.Rest
{
    public interface IRestClient<T>
    {
        public Task<List<T>> RefreshDataAsync();
    }
}

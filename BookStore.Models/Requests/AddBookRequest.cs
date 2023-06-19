using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Requests
{
    public class AddBookRequest
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}

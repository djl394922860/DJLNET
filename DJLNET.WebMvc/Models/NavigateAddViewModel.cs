using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJLNET.WebMvc.Models
{
    public class NavigateAddViewModel
    {
        public IEnumerable<NavigateViewModel> NavigateViewModels { get; set; } = new List<NavigateViewModel>();
        public IEnumerable<string> Controllers { get; set; } = new List<string>();
    }
}
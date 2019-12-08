using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// The item with page number
    /// </summary>
    public class PagerItem : BaseModel
    {
        public int PageIndex
        {
            get; set;
        }

        public PagerItem(int index)
        {
            PageIndex = index;
        }
    }
}

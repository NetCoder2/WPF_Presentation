using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// The model to generate item for ListBox
    /// </summary>
    public class SelectionItem : BaseModel
    {

        private bool _showName = true;

        /// <summary>
        /// The display name of the item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The display Id of the item
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// True if this the name is visible
        /// </summary>        
        public bool ShowName
        {
            get { return _showName; }
            set
            {
                _showName = value;
            }
        }

        public SelectionItem()
        {

        }

        public SelectionItem(int? id, string name)
        {
            Id = id;
            Name = name;

        }
    }
}

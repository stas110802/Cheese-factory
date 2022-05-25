using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cheese_factory.Core.Command;

namespace Cheese_factory.Core.Interface
{
    public interface IInitializeCommands
    {
        protected void AddItem(object args = null);
        protected void DeleteSelectedItem(object args = null);
        /// <summary>
        /// Update all Observable collection items
        /// </summary>
        /// <param name="args"></param>
        protected void UpdateItems(object args = null);
        protected void ChangeExistingItem(object args = null);
        protected void ClickOnTable(object args = null);
    }
}

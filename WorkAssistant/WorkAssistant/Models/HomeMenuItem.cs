using System;
using System.Collections.Generic;
using System.Text;

namespace WorkAssistant.Models
{
    public enum MenuItemType
    {
        Start,
        Workdays,
        Filter
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

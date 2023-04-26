using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Avalonia;
using Avalonia.Controls;
using Avalonia.VisualTree;

namespace GAG.Helpers
{

    internal class ElementFinder
    {
        /**
         * FindElementInDescendants - find special Element with Type and xName
         */
        public static T? FindElementInDescendants<T>(IVisual visual, string xName) where T : Visual
        {
            foreach (var descendant in visual.GetVisualDescendants())
            {
                if (descendant is T el && el.Name == xName)
                {
                    return el;
                }
            }
            return null;
        }
    }
}

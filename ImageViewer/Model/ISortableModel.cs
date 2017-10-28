using System;
using System.Collections.Generic;

namespace ImageViewer.Model
{
    interface ISortableModel
    {
        Dictionary<string, Action> SortMap { get; }
    }
}

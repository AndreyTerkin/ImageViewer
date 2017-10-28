using System;
using System.Collections.Generic;

namespace ImageViewer
{
    interface ISortableModel
    {
        Dictionary<string, Action> SortMap { get; }
    }
}

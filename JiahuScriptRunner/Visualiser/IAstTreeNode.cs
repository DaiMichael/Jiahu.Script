using System.Collections.Generic;

namespace JiahuScriptRunner.Visualiser
{
    public interface IAstTreeNode
    {
        string Text { get; }
        int Count { get; }
        IEnumerable<IAstTreeNode> Children { get; }
    }
}

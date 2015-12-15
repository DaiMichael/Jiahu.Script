using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace JiahuScriptRunner.Visualiser
{
    public class AstTreeNode : IAstTreeNode
    {
        readonly ITree _tree;

        public AstTreeNode(ITree tree)
        {
            _tree = tree;
        }

        public string Text
        {
            get
            {
                ParserRuleContext context = _tree as ParserRuleContext;
                if (context != null)
                {
                    return JiahuScriptParser.ruleNames[context.RuleIndex] + Environment.NewLine + _tree;
                }
                return _tree.ToString();
            }
        }

        public int Count
        {
            get { return _tree.ChildCount; }
        }

        public IEnumerable<IAstTreeNode> Children
        {
            get
            {
                for (int i = 0; i < _tree.ChildCount; ++i)
                {
                    yield return new AstTreeNode(_tree.GetChild(i));
                }
            }
        }

    }
}

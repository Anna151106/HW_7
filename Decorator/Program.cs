using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample
{
    abstract class ChristmasTree
    {
        public abstract string GetDescription();
        public abstract void Shine();
    }

    class RealChristmasTree : ChristmasTree
    {
        public override string GetDescription()
        {
            return "Simple Fir Tree";
        }

        public override void Shine()
        {
            Console.WriteLine("The tree does not shine without garlands.");
        }
    }

    abstract class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        public TreeDecorator(ChristmasTree tree)
        {
            this.tree = tree;
        }

        public override string GetDescription()
        {
            return tree.GetDescription();
        }

        public override void Shine()
        {
            tree.Shine();
        }
    }

    class OrnamentDecorator : TreeDecorator
    {
        private string ornamentType;

        public OrnamentDecorator(ChristmasTree tree, string type)
            : base(tree)
        {
            this.ornamentType = type;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " with " + ornamentType;
        }

        public override void Shine()
        {
            base.Shine();
        }
    }

    class GarlandDecorator : TreeDecorator
    {
        private int lightCount;

        public GarlandDecorator(ChristmasTree tree, int count)
            : base(tree)
        {
            this.lightCount = count;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " and bright garlands (" + lightCount + " lights)";
        }

        public override void Shine()
        {
            base.Shine();
            Console.WriteLine("The garlands are shining brightly!");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            ChristmasTree myTree = new RealChristmasTree();
            Console.WriteLine("Base Tree: " + myTree.GetDescription());
            myTree.Shine();
            Console.WriteLine(new string('-', 20));

            ChristmasTree decoratedTree = new OrnamentDecorator(myTree, "red balls");
            decoratedTree = new GarlandDecorator(decoratedTree, 50);
            decoratedTree = new OrnamentDecorator(decoratedTree, "stars");

            Console.WriteLine("Decorated Tree: " + decoratedTree.GetDescription());
            decoratedTree.Shine();

            Console.ReadKey();
        }
    }
}
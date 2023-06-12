
class RedBlackTree
{
    int data;
    string color = "";
    RedBlackTree? parent;
    RedBlackTree? left;
    RedBlackTree? right;

    public void Add(int value)
    {
        if (data == 0)
        {
            data = value;
            color = "black";
        }
        else if (data != 0)
        {
            RedBlackTree root = new RedBlackTree();
            root.data = data;
            root.color = color;
            root.left = left;
            root.right = right;
            RedBlackTree item = new RedBlackTree();
            item.data = value;

            while (true)
            {
                if (root.data < item.data)
                {
                    if (root.right != null)
                        root = root.right;
                    else if (root.right == null)
                    {
                        root.right = item;
                        item.parent = root;
                        item.color = "black";
                        break;
                    }
                }
                else if (root.data > item.data)
                {
                    if (root.left != null)
                        root = root.left;
                    else if (root.left == null)
                    {
                        root.left = item;
                        item.parent = root;
                        item.color = "red";

                        break;
                    }
                }
            }
        }
    }

    public bool DepthFirstSearch(int value)
    {
        RedBlackTree? unit = new RedBlackTree();
        unit.left = left;
        unit.right = right;
        while (unit != null)
        {
            if (value == data)
                return true;
            else if (value > data)
            {
                unit = right;
            }
            else if (value < data)
            {
                unit = left;
            }
        }
        return false;
    }
}

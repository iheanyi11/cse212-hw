public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // Check if cvalue already exists in the tree
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Base case: if value is founf return true
        if (value == Data)
        {
            return true;
        }

        // Search left
        if (value < Data)
        {
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }

        // Search right
        if (value > Data)
        {
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }

        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Get left sub tree height
        int leftHeight = 0;
        if (Left is not null)
        {
            leftHeight = Left.GetHeight();
        }

        // Get right sub tree height
        int rightHeight = 0;
        if (Right is not null)
        {
            rightHeight = Right.GetHeight();
        }

        // Height = 1 + max of the two sub tree heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
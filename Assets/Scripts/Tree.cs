using UnityEngine;

public class Tree : Breakable
{
  
    protected override void Break()
    {
        Debug.Log("Tree is breaking");

        base.Break(); // performs the original behaviour in the parent
    }
    protected override void Drop()
    {
        Debug.Log("Wood Dropped");
        base.Drop();
    }
}
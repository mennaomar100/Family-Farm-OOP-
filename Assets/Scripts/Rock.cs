using UnityEngine;

public class Rock : Breakable
{
    protected override void Break()
    {
        Debug.Log("Rock is breaking");

        base.Break(); // performs the original behaviour in the parent
    }
    protected override void Drop()
    {
        Debug.Log("RockDrop Dropped");
        base.Drop();
    }

    //you can also leave it without overrides and it'll do the parent behavior
}
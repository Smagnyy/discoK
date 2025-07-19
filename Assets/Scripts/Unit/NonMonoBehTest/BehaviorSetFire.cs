using UnityEngine;
[System.Serializable]
public class BehaviorSetFire : IBehavior
{
    

    public override void Action(BaseUnit baseUnit)
    {
        //Debug.Log("Fire!");
        baseUnit.transform.position = new Vector2(2, -3);
    }
}

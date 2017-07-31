using UnityEngine;

public class DamageEvent : EgoEvent
{
	public readonly int playerID;
	public readonly bool damage;

	public DamageEvent(int playerID, bool damage)
	{
		this.playerID = playerID;
		this.damage = damage;
		Debug.Log ("Damaged" + playerID);
	}
}

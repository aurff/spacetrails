using UnityEngine;

public class OnSpeedUpPickUp : EgoEvent
{
	public readonly int playerID;

	public OnSpeedUpPickUp(int playerID)
	{
		this.playerID = playerID;
	}
}

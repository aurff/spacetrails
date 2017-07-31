using UnityEngine;

public class LifeUIEvent : EgoEvent
{
	public readonly int playerID;
	public readonly int lifes;

	public LifeUIEvent(int playerID, int lifes)
	{
		this.playerID = playerID;
		this.lifes = lifes;
	}
}

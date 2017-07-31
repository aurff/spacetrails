using UnityEngine;

public class OnActivatePowerUp : EgoEvent
{
	public readonly int playerID;
	public readonly EgoComponent player;

	public OnActivatePowerUp(int playerID, EgoComponent player)
	{
		this.playerID = playerID;
		this.player = player;
	}
}

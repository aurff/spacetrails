using UnityEngine;

public class GameOverEvent : EgoEvent
{
	public readonly int playerID;

	public GameOverEvent(int playerID)
	{
		this.playerID = playerID;
	}
}

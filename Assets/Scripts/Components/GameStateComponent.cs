using UnityEngine;

[DisallowMultipleComponent]
public class GameStateComponent : MonoBehaviour
{
	public enum GameState {Running, Menu, Paused, GameOver, Intro};
	public GameState myGameState = GameState.Intro;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)

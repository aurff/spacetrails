using UnityEngine;

[DisallowMultipleComponent]
public class HealthComponent : MonoBehaviour
{
	public int maxHealth = 3;
	public int health = 3;
	public Sprite[] lifeIcons = new Sprite[3];
	public Sprite lifeIcon;
	public Sprite lifeIconEmpty;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)

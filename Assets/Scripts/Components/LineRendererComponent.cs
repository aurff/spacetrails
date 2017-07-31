using UnityEngine;

[DisallowMultipleComponent]
public class LineRendererComponent : MonoBehaviour
{
	public int lineRendererPointCount = 0;
	public int lineLength = 0;
	public float timeElapsed = 0;
	public float lineRendererTimeThreshold = 0.2f;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)

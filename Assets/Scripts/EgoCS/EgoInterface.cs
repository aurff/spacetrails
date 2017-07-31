using UnityEngine;
using System.Collections.Generic;

public class EgoInterface : MonoBehaviour
{
	static EgoInterface()
	{
		EgoSystems.Add (
			new LineRendererSystem (),
			new HealthSystem(),
			new MovementSystem(),
			new GameOverUISystem(),
			new GameStateSystem(),
			new MainMenuSystem(),
			new CountDownSystem(),
			new CollisionSystem(),
			new PlayerSystem(),
			new HealthUISystem(),
			new AnimationSystem(),
			new PowerUpSystem(),
			new PlayerPowerUpSystem(),
			new PowerUpUISystem()
		);
    }

    void Start()
    {
    	EgoSystems.Start();
	}
	
	void Update()
	{
		EgoSystems.Update();
	}
	
	void FixedUpdate()
	{
		EgoSystems.FixedUpdate();
	}
}

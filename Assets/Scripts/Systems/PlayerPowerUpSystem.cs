using UnityEngine;

public class PlayerPowerUpSystem : EgoSystem<EgoConstraint<Transform, PlayerPowerUpComponent, MovementComponent>>
{
	public override void Start()
	{
		EgoEvents<OnActivatePowerUp>.AddHandler (Handle);
	}

	public override void Update()
	{
		//HasSpeedUpComponent speedUp;
		constraint.ForEachGameObject ((egoComponent, transform, powerUpComponent, movementComponent) => {
			if (powerUpComponent.powerUpActivated) {
				movementComponent.flySpeed = 4;
				movementComponent.curvspeed = 2.9f;
				Ego.DestroyComponent<HasSpeedUpComponent>(egoComponent);
			}

			if (powerUpComponent.powerUpActivated)
			{
				powerUpComponent.playerPowerUpTimer += Time.deltaTime;
			}
			if (powerUpComponent.playerPowerUpTimer >= 2) {
				powerUpComponent.playerPowerUpTimer = -1f;
				movementComponent.flySpeed = 2;
				movementComponent.curvspeed = 2;
				powerUpComponent.powerUpActivated = false;
			}

			HasSpeedUpComponent speed;
			if ((KutiInput.Instance.GetButtonDown(powerUpComponent.powerUpButton) || Input.GetKey(powerUpComponent.powerUpButtonPC) && egoComponent.TryGetComponents(out speed))) {
				var ev = new OnActivatePowerUp(powerUpComponent.playerID, egoComponent);
				EgoEvents<OnActivatePowerUp>.AddEvent(ev);
			}
		});
	}

	public override void FixedUpdate()
	{
		
	}

	void Handle(OnActivatePowerUp e) {
		constraint.ForEachGameObject ((egoComponent, transform, powerUpComponent, movementComponent) => {
			if (e.playerID == powerUpComponent.playerID) {
				powerUpComponent.powerUpActivated = true;
			}
		});
	}
}
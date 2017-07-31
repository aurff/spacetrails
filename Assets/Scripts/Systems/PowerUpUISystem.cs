using UnityEngine;

public class PowerUpUISystem : EgoSystem <EgoConstraint<Transform, PowerUpUIComponent>>
{
	public override void Start()
	{
		constraint.ForEachGameObject ((egoComponent, transform, powerUpUIComponent) => {
			egoComponent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		});

		EgoEvents<OnSpeedUpPickUp>.AddHandler (Handle);
		EgoEvents<OnActivatePowerUp>.AddHandler (Handle);
	}

	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		
	}

	void Handle(OnSpeedUpPickUp e) {
		constraint.ForEachGameObject((egoComponent, transform, powerUpUIComponent) => {
			if (e.playerID == 1) {
				if (powerUpUIComponent.playerID == 1) {
					egoComponent.gameObject.GetComponent<SpriteRenderer>().enabled = true;
				}
			} else if (e.playerID == 2) {
				if (powerUpUIComponent.playerID == 2) {
					egoComponent.gameObject.GetComponent<SpriteRenderer>().enabled = true;
				}
			}
		});
	}

	void Handle(OnActivatePowerUp e) {
		constraint.ForEachGameObject((egoComponent, transform, powerUpUIComponent) => {
			if (e.playerID == 1) {
				if (powerUpUIComponent.playerID == 1) {
					egoComponent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				}
			} else if (e.playerID == 2) {
				if (powerUpUIComponent.playerID == 2) {
					egoComponent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				}
			}
		});
	}
}
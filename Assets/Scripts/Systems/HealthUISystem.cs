using UnityEngine;

public class HealthUISystem : EgoSystem<EgoConstraint<HealthUIComponent, SpriteRenderer>>
{
	public override void Start()
	{
		EgoEvents<LifeUIEvent>.AddHandler (Handle);
		EgoEvents<GoToMenuEvent>.AddHandler (Handle);
	}

	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		
	}

	void Handle(LifeUIEvent e) {
		constraint.ForEachGameObject ((egoComponent, healthUI, spriteRenderer) => {
			if (e.playerID == healthUI.playerID) {
				if (healthUI.lifes > e.lifes) {
					egoComponent.gameObject.SetActive (false);
				}
			}
		});
	}

	void Handle(GoToMenuEvent e) {
		constraint.ForEachGameObject ((egoComponent, healthUI, spriteRenderer) => {
			egoComponent.gameObject.SetActive(true);
		});
	}
}
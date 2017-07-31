using UnityEngine;

public class HealthSystem : EgoSystem<EgoConstraint<HealthComponent, PlayerComponent>>
{
	public override void Start()
	{
		EgoEvents<DamageEvent>.AddHandler (Handle);
		EgoEvents<GoToMenuEvent>.AddHandler (Handle);
	}

	void Handle(DamageEvent e) {
		constraint.ForEachGameObject ((egoComponent, healthComponent, player) => {
			if (e.playerID == player.playerID) {
				if (healthComponent.health <= -2) {
					var eve = new GameOverEvent(player.playerID);
					EgoEvents<GameOverEvent>.AddEvent(eve);
				}
				else {
					//healthComponent.lifeIcons.SetValue(null, healthComponent.health - 1);
					if (e.damage == true) {
						healthComponent.health--;
					}
					var ev = new LifeUIEvent(e.playerID, healthComponent.health);
					EgoEvents<LifeUIEvent>.AddEvent(ev);
				}
			}
		});
	}

	void Handle(GoToMenuEvent e) {
		constraint.ForEachGameObject ((egoComponent, healthComponent, player) => {
			//for (int i = 0; i < healthComponent.maxHealth; i++) {
			//	healthComponent.lifeIcons.SetValue (healthComponent.lifeIcon, i);
				healthComponent.health = healthComponent.maxHealth;
			//}
		});
	}
}
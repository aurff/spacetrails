using UnityEngine;

public class GameOverUISystem : EgoSystem<EgoConstraint<GameOverUIComponent>>
{
	public override void Start()
	{
		EgoEvents<GameOverEvent>.AddHandler (Handle);
		EgoEvents<GameStartEvent>.AddHandler (Handle);
		EgoEvents<CountDownEvent>.AddHandler (Handle);

		constraint.ForEachGameObject ((egoComponent, gameOver) => {
			egoComponent.gameObject.SetActive(false);
		});
	}


	void Handle(GameOverEvent e) {
		constraint.ForEachGameObject ((egoComponent, gameOverUIComponent) => {
			if (e.playerID == 1) {
				if (gameOverUIComponent.playerID == 2) {
					egoComponent.gameObject.SetActive(true);
				}
			}
			else if (e.playerID == 2) {
				if (gameOverUIComponent.playerID == 1) {
					egoComponent.gameObject.SetActive(true);
				}
			}
		});
	}

	void Handle(GameStartEvent e) {
		constraint.ForEachGameObject ((egoComponent, gameOver) => {
			egoComponent.gameObject.SetActive(false);
		});
	}

	void Handle(CountDownEvent e) {
		constraint.ForEachGameObject ((egoComponent, gameOver) => {
			egoComponent.gameObject.SetActive (false);
		});
	}
}
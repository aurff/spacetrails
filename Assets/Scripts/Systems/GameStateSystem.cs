using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateSystem : EgoSystem<EgoConstraint<GameStateComponent>>
{
	public override void Start()
	{
		EgoEvents<GameOverEvent>.AddHandler (Handle);
		EgoEvents<GameStartEvent>.AddHandler (Handle);
	}

	public override void Update()
	{
		constraint.ForEachGameObject ((egoComponent, gameStateComponent) => {
			if (egoComponent.gameObject.activeSelf && gameStateComponent.myGameState == GameStateComponent.GameState.GameOver) {
				if (KutiInput.Instance.GetButtonDown(EKutiButton.P1Left) || KutiInput.Instance.GetButtonDown(EKutiButton.P1Right) || KutiInput.Instance.GetButtonDown(EKutiButton.P1Up) ||
					KutiInput.Instance.GetButtonDown(EKutiButton.P2Left) || KutiInput.Instance.GetButtonDown(EKutiButton.P2Up) || KutiInput.Instance.GetButtonDown(EKutiButton.P2Right) || Input.anyKeyDown) {
					var e = new GoToMenuEvent();
					EgoEvents<GoToMenuEvent>.AddEvent(e);
					gameStateComponent.myGameState = GameStateComponent.GameState.Menu;
				}
			}

			if (KutiInput.Instance.GetButtonDown(EKutiButton.Menu) || Input.GetKeyDown(KeyCode.Escape)) {
				Application.Quit();
			}
		});
	}

	public override void FixedUpdate()
	{
		
	}

	void Handle(GameOverEvent e) {
		constraint.ForEachGameObject ((egoComponent, gameStateComponent) => {
			gameStateComponent.myGameState = GameStateComponent.GameState.GameOver;
			Time.timeScale = 0;
		});
	}

	void Handle(GameStartEvent e) {
		constraint.ForEachGameObject ((egoComponent, gameStateComponent) => {
			gameStateComponent.myGameState = GameStateComponent.GameState.Running;
		});
	}

	void Handle(GoToMenuEvent e) {
		constraint.ForEachGameObject ((egoComponent, gameStateComponent) => {
			gameStateComponent.myGameState = GameStateComponent.GameState.Menu;
		});
	}
}
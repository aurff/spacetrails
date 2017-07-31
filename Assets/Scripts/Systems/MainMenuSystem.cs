using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSystem : EgoSystem<EgoConstraint<MainMenuComponent>>
{
	public override void Start()
	{
		EgoEvents<CountDownEvent>.AddHandler (Handle);
		EgoEvents<GoToMenuEvent>.AddHandler (Handle);
	}

	public override void Update()
	{		
		constraint.ForEachGameObject ((egoComponent, mainMenuComponent) => {
			if (mainMenuComponent.myMenuStatus == MainMenuComponent.MenuStatus.active) {
				if (KutiInput.Instance.GetButtonDown(EKutiButton.P1Left) || KutiInput.Instance.GetButtonDown(EKutiButton.P1Up) || KutiInput.Instance.GetButtonDown(EKutiButton.P1Right) ||
					KutiInput.Instance.GetButtonDown(EKutiButton.P2Left) || KutiInput.Instance.GetButtonDown(EKutiButton.P2Up) || KutiInput.Instance.GetButtonDown(EKutiButton.P2Right) || Input.anyKeyDown) {
					var e = new CountDownEvent();
					EgoEvents<CountDownEvent>.AddEvent(e);
					Debug.Log("Countdown Event startet");
				}
			}
		});
	}

	public override void FixedUpdate()
	{
		
	}

	void Handle(CountDownEvent e) {
		constraint.ForEachGameObject ((egoComponent, mainMenuComponent) => {
			mainMenuComponent.myMenuStatus = MainMenuComponent.MenuStatus.inactive;
			egoComponent.gameObject.SetActive(false);
		});
		InitializeNewGameEvent newGame = new InitializeNewGameEvent();
		EgoEvents<InitializeNewGameEvent>.AddEvent(newGame);
		Debug.Log ("started new game");
	}

	void Handle(GoToMenuEvent e) {
		constraint.ForEachGameObject ((egoComponent, mainMenuComponent) => {
			Time.timeScale = 0;
			mainMenuComponent.myMenuStatus = MainMenuComponent.MenuStatus.active;
			egoComponent.gameObject.SetActive (true);
			Debug.Log("menu done");
		});
	}
}
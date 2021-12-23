using UnityEngine;

public class MenuInstaller : MonoBehaviour
{
    [SerializeField] private MainMenuView mainMenuViewPrefab;
    [SerializeField] private Transform canvasParentViews;

    private void Start()
    {
        InitViews();
    }

    private void InitViews()
    {
        IMainMenuView mainMenuViewInstance = Instantiate(mainMenuViewPrefab, canvasParentViews);
        IMainMenuPresenter mainMenuPresenter = new MainMenuPresenter(mainMenuViewInstance);
        mainMenuViewInstance.Configure(mainMenuPresenter);
    }
}
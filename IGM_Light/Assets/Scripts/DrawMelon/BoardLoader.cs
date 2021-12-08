using System.Collections;
using UnityEngine;

public class BoardLoader : MonoBehaviour
{
    [SerializeField] private bool isHack;

    private WorldsLoader _worldsLoader;

    private void Start()
    {
        if(isHack)
        {
            GameController controller = FindObjectOfType<GameController>(); 
            UIManager.Instance.GetWindow<UIBackground>("UIBackground").gameController = controller;
            FindObjectOfType<Anim>().animator = controller.Player.GetComponent<Animator>();
            FindObjectOfType<SwipeInteract>()._player = controller.Player;
            Camera.main.GetComponent<CameraModify>().SetCameraPositionAndSize(
            controller.GetComponent<BoardManager>().Length
        );

        return;
        }

        _worldsLoader = GameManager.Instance.WorldsLoader;

        var board = _worldsLoader.WorldsTable[UserDataInstance.Instance.CurrentWorld-1].Stages[UserDataInstance.Instance.CurrentStage-1];
        var spawnedBoard = Instantiate(board);

        StartCoroutine(set(spawnedBoard));
    }

    private IEnumerator set(GameController controller)
    {
        while(controller == null)
            yield return new WaitForSeconds(0.05f);

        while(UIManager.Instance.GetWindow<UIBackground>("UIBackground")== null)
             yield return new WaitForSeconds(0.05f);

        
        UIManager.Instance.GetWindow<UIBackground>("UIBackground").gameController = controller;
        UIManager.Instance.GetWindow<UIScore>("UIScore").gameController = controller;
        FindObjectOfType<Anim>().animator = controller.Player.GetComponent<Animator>();
        FindObjectOfType<SwipeInteract>()._player = controller.Player;
        Camera.main.GetComponent<CameraModify>().SetCameraPositionAndSize(
            controller.GetComponent<BoardManager>().Length
        );
    }
}

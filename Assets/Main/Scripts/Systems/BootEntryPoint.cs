using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootEntryPoint : MonoBehaviour
{
    [SerializeField] private UIBoot UIStartGame;
    [SerializeField] private List<IGameSystem> gameSystems;


    private IEnumerator Start()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        UIStartGame.ShowLoadingScreen();


        foreach (var system in gameSystems) // очередность загрузки/включения систем игры которые будут работать на протяжении всего игрового процесса(savemanager,firebase, реклама, InApp, и другие SDK и системы 
        {
            system.Activate();
            Debug.Log($"<color=#20C30C>Load System = {system.gameObject.name}</color>");
        }

        yield return SceneManager.LoadSceneAsync(Scenes.MENU);


    }
}

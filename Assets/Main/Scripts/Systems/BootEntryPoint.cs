using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//точка входа в сцену в которой настраивается очередность включения игровых объектов/менеджеров
public class BootEntryPoint : MonoBehaviour
{
    [SerializeField] private UICanvas UIStartGame;
    [SerializeField] private List<IGameSystem> gameSystems;


    private IEnumerator Start()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        UIStartGame.SwitchOnCanvas();


        foreach (var system in gameSystems) // очередность загрузки/включения систем игры которые будут работать на протяжении всего игрового процесса(savemanager,firebase, реклама, InApp, и другие SDK и системы 
        {
            system.Activate();
            Debug.Log($"<color=#20C30C>Load System = {system.gameObject.name}</color>");
        }

        yield return new WaitForSeconds(2f); //задержка загрузки на 2 секунды по ТЗ

        yield return SceneManager.LoadSceneAsync(Scenes.MENU);


    }
}

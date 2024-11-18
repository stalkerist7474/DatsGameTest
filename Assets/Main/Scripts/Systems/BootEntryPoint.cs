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


        foreach (var system in gameSystems) // ����������� ��������/��������� ������ ���� ������� ����� �������� �� ���������� ����� �������� ��������(savemanager,firebase, �������, InApp, � ������ SDK � ������� 
        {
            system.Activate();
            Debug.Log($"<color=#20C30C>Load System = {system.gameObject.name}</color>");
        }

        yield return SceneManager.LoadSceneAsync(Scenes.MENU);


    }
}

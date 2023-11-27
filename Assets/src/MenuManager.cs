using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuType
{
    Pause,
    Death,
    Session
}
public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject DeathMenu;
    [SerializeField] GameObject SessionUI;

    public static MenuManager Instance;
    public void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Menu manager should be only one");
        }
        OpenMenu(MenuType.Session);
    }
    public void OpenMenu(MenuType type)
    {
        PauseMenu.SetActive(false);
        DeathMenu.SetActive(false);
        SessionUI.SetActive(false);
        switch (type)
        {
            case MenuType.Pause: PauseMenu.SetActive(true); break;
            case MenuType.Death: DeathMenu.SetActive(true); break;
            case MenuType.Session: SessionUI.SetActive(true); break;
            default: break;
        }
    }
    public void OpenMenu(string type)
    {
        switch (type)
        {
            case "Pause": OpenMenu(MenuType.Pause); break;
            case "Death": OpenMenu(MenuType.Death); break;
            case "Session": OpenMenu(MenuType.Session); break;
        }
    }
}

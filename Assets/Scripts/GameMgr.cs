using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : Singleton<GameMgr>
{
    public GameUI game;
    public HudUI hud;
    public void Initialize()
    {
        Time.timeScale = 1;
        // Application.runInBackground = true; 앱 최소화 시에도 사용 가능하게
        LoadFile();
        game.Initialize();
        hud.Initialize();
    }

    public void OnUpdate(float dTime)
    {
    }

    public void LoadFile()
    {
        DataManager.Inst.JsonLoad();
    }
    public void SaveFile()
    {
        DataManager.Inst.JsonLoad();
    }
}

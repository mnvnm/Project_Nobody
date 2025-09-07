using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임의 모든 데이터 를 가지고 있는 스크립트 / 플레이어, 적, 총알 등
public class GameUI : MonoBehaviour
{
    public PlayerController player;

    public void Initialize()
    {
        player.Initialize();
    }
    void Update()
    {
    }
}

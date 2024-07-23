using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTabMenu : MonoBehaviour
{
    // 아이템을 담을 인벤토리 칸
    public GameObject[] ScrollViews;
    // 탭 버튼의 Image 컴포넌트들을 담을 배열
    public Image[] TabButtons;
    // 선택되지 않은 탭 배경과 선택된 탭 배경을 위한 스프라이트
    public Sprite DeselectedTabBG, SelectedTabBG;
    private void Start()
    {
        // 시작할 때 Element0(장비창)을 활성화합니다
        SwitchToTab(0);
    }
    // 주어진 TabID에 따라 특정 탭으로 전환하는 메서드
    public void SwitchToTab(int TabID)
    {
        // 모든 탭을 비활성화합니다
        for (int i = 0; i < ScrollViews.Length; i++)
        {
            ScrollViews[i].SetActive(false);
        }

        // 주어진 TabID에 해당하는 탭을 활성화합니다
        ScrollViews[TabID].SetActive(true);

        // 모든 탭 버튼을 반복하면서 해당하지 않는 탭 버튼을 DeselectedTabBG로 설정
        for (int i = 0; i < TabButtons.Length; i++)
        {
            TabButtons[i].sprite = DeselectedTabBG;
        }
        // 주어진 TabID에 해당하는 탭 버튼을 SelectedTabBG로 설정
        TabButtons[TabID].sprite = SelectedTabBG;
    }
}

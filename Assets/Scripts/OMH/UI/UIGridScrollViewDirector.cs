using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGridScrollViewDirector : MonoBehaviour
{
    public UIGridScrollView scrollview;
    // 모든 UI 초기화
    public void Init()
    {
        this.scrollview.Init();
    }
}

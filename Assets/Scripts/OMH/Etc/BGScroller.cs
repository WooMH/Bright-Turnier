using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    // MeshRenderer 변수를 선언한다
    private MeshRenderer renderer;
    // speed를 float형 변수로 만든다
    public float speed;
    // offset을 float형 변수로 만든다
    private float offset;
    void Start()
    {
        // GetComponent를 이용해 renderer를 초기화
        renderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        // offset을 deltatime을 이용해 계속 증가시킨다.
        offset += Time.deltaTime * speed;
        // 업데이트 함수에서 Material의 offset을 변경한다
        renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    // MeshRenderer ������ �����Ѵ�
    private MeshRenderer renderer;
    // speed�� float�� ������ �����
    public float speed;
    // offset�� float�� ������ �����
    private float offset;
    void Start()
    {
        // GetComponent�� �̿��� renderer�� �ʱ�ȭ
        renderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        // offset�� deltatime�� �̿��� ��� ������Ų��.
        offset += Time.deltaTime * speed;
        // ������Ʈ �Լ����� Material�� offset�� �����Ѵ�
        renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}

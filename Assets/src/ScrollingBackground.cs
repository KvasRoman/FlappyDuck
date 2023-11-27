using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Renderer bgRenderer;

    private void FixedUpdate()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.fixedDeltaTime, 0);
    }
}

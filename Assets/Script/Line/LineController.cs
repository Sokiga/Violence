using BehaviorDesigner.Runtime.Tasks.Unity.UnityQuaternion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineCtrler : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private Material material;
    private Vector2 tiling;
    private Vector2 offset;
    private int lineMainTexProperty;
    private float lineTimer = 0;
    private float lineFrequency = 0.03f;
    private float lineMoveSpeed = 0.04f;
    private float lineLen;
    private float lineDensity = 2f;
    void Start()
    {
        lineMainTexProperty = Shader.PropertyToID("_MainTex");
        tiling = new Vector2(20, 0);
        offset = new Vector2(0, 0);
        material.SetTextureScale(lineMainTexProperty, tiling);
        material.SetTextureOffset(lineMainTexProperty, offset);
    }
    private void Update()
    {
        lineLen = (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).magnitude;
        tiling = new Vector2(lineLen * lineDensity, 0);
        material.SetTextureScale(lineMainTexProperty, tiling);
        lineTimer += Time.deltaTime;
        if (lineTimer >= lineFrequency)
        {
            lineTimer = 0;
            offset -= new Vector2(lineMoveSpeed, 0);
            material.SetTextureOffset(lineMainTexProperty, offset);
        }
    }
}

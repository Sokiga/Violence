using UnityEngine;
using UnityEngine.Rendering;

// CreateAssetMenu 属性让您可以在 Unity Editor 中创建此类的实例。
[CreateAssetMenu(menuName = "Rendering/ExampleRenderPipelineAsset")]
public class ExampleRenderPipelineAsset : RenderPipelineAsset
{
    // Unity 在渲染第一帧之前调用此方法。
    // 如果渲染管线资源上的设置改变，Unity 将销毁当前的渲染管线实例，并在渲染下一帧之前再次调用此方法。
    protected override RenderPipeline CreatePipeline()
    {
        // 实例化此自定义 SRP 用于渲染的渲染管线。
        return new ExampleRenderPipelineInstance();
    }
}
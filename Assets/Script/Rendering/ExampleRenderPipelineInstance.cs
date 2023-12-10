using UnityEngine;
using UnityEngine.Rendering;

public class ExampleRenderPipelineInstance : RenderPipeline
{
    public ExampleRenderPipelineInstance()
    {
    }

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        // 可以在此处编写自定义渲染代码。通过自定义此方法可以自定义 SRP。
    }
}
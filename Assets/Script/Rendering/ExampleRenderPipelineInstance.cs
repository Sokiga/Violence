using UnityEngine;
using UnityEngine.Rendering;

public class ExampleRenderPipelineInstance : RenderPipeline
{
    public ExampleRenderPipelineInstance()
    {
    }

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        // �����ڴ˴���д�Զ�����Ⱦ���롣ͨ���Զ���˷��������Զ��� SRP��
    }
}
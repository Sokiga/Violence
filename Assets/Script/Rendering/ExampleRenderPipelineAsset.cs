using UnityEngine;
using UnityEngine.Rendering;

// CreateAssetMenu �������������� Unity Editor �д��������ʵ����
[CreateAssetMenu(menuName = "Rendering/ExampleRenderPipelineAsset")]
public class ExampleRenderPipelineAsset : RenderPipelineAsset
{
    // Unity ����Ⱦ��һ֮֡ǰ���ô˷�����
    // �����Ⱦ������Դ�ϵ����øı䣬Unity �����ٵ�ǰ����Ⱦ����ʵ����������Ⱦ��һ֮֡ǰ�ٴε��ô˷�����
    protected override RenderPipeline CreatePipeline()
    {
        // ʵ�������Զ��� SRP ������Ⱦ����Ⱦ���ߡ�
        return new ExampleRenderPipelineInstance();
    }
}
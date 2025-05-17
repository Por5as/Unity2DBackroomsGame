using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class RedShadowRendererFeature : ScriptableRendererFeature
{
    public Material redShadowMaterial;  // Material to apply the red shadow effect

    class RedShadowPass : ScriptableRenderPass
    {
        Material material;

        public RedShadowPass(Material mat)
        {
            material = mat;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get("RedShadow");

            // Apply the red shadow effect using a custom material
            Blitter.BlitCameraTexture(cmd, renderingData.cameraData.renderer.cameraColorTargetHandle, renderingData.cameraData.renderer.cameraColorTargetHandle, material, 0);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }

    RedShadowPass redShadowPass;

    public override void Create()
    {
        if (redShadowMaterial != null)
        {
            redShadowPass = new RedShadowPass(redShadowMaterial);
            redShadowPass.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
        }
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (redShadowMaterial != null)
        {
            renderer.EnqueuePass(redShadowPass);
        }
    }
}

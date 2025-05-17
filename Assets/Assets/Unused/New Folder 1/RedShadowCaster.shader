Shader "Custom/RedShadowShader"
{
    SubShader
    {
        Tags { "Queue" = "Overlay" }
        
        Pass
        {
            Name "RedShadow"
            Tags { "LightMode" = "ShadowCaster" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float4 color : COLOR;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = v.vertex;
                o.color = v.color;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return float4(1, 0, 0, 1); // Red color
            }
            ENDCG
        }
    }
}

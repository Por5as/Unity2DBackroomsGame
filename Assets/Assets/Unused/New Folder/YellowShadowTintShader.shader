Shader "Custom/YellowShadowShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _YellowColor ("Yellow Shadow Color", Color) = (1, 1, 0, 1) // Yellow color for shadows
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase // Ensures correct lighting & shadows

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc" // Enables shadow calculations

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldNormal : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
                SHADOW_COORDS(3) // Stores shadow coordinates
            };

            sampler2D _MainTex;
            float4 _YellowColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.uv = v.uv;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                TRANSFER_SHADOW(o); // Correct shadow calculation

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Sample the texture
                fixed4 texColor = tex2D(_MainTex, i.uv);

                // Get shadow attenuation (0 = full shadow, 1 = fully lit)
                float shadow = SHADOW_ATTENUATION(i);

                // Apply yellow shadow effect
                fixed4 finalColor = lerp(_YellowColor, texColor, shadow);
                return finalColor;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}

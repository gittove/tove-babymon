Shader "Unlit/InteractionRing"
{
    Properties
    {
        _ColorBottom ("Color Bottom", Color) = (0,0,0,0)
        _ColorTop ("Color Top", Color) = (0,0,0,0)
    }
    SubShader
    {
        Tags { 
            "RenderType"="Transparent"
            "Queue" = "Transparent" 
            }

        Pass
        {
            Cull Off
            ZWrite Off
            Blend One One
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            #define TAU 6.28318530718
            
            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                float2 uv0 : TEXCOORD0;
            };

            struct Interpolators
            {
                float2 uv : TEXCOORD1;
                float3 normal : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _ColorBottom;
            float4 _ColorTop;

            Interpolators vert (MeshData v)
            {
                Interpolators i;
                i.vertex = UnityObjectToClipPos(v.vertex);
                i.normal = UnityObjectToWorldNormal(v.normals);
                i.uv = v.uv0;
                return i;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                float xOffset = cos(i.uv.x * TAU * 1) * 0.01;
                float t = cos((i.uv.y + xOffset - _Time.y * 0.5) * TAU * 1) * 0.5 + 0.5;
                t *= 1 - i.uv.y;
                float topBottomRemover = (abs(i.normal.y) < 0.999);
                float waves = t * topBottomRemover;
                float4 gradient = lerp(_ColorBottom, _ColorTop, i.uv.y);
                return gradient * waves;
            }
            ENDCG
        }
    }
}

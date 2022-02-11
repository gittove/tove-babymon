Shader "Unlit/CarryBabyTimer"
{
    Properties
    {
        [NoScaleOffset]_Foreground ("Foreground", 2D) = "white" {}
        [NoScaleOffset]_Background ("Background", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _Foreground;
            sampler2D _Background;
            float Time;
            uniform float _TimeValue;
            uniform float _StartTime;

            Interpolators vert (MeshData v)
            {
                Interpolators i;
                i.vertex = UnityObjectToClipPos(v.vertex);
                i.uv = v.uv;
                return i;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                _TimeValue *= 1/_StartTime;
                
                float timeBarMask = _TimeValue > i.uv.x;
                fixed3 timeBarColor = tex2D(_Foreground, i.uv);
                fixed3 bgColor = tex2D(_Background, i.uv);

                float3 outColor = lerp(bgColor, timeBarColor, timeBarMask);
                return float4(outColor,0);
            }
            ENDCG
        }
    }
}

Shader "Unlit/Hapiness"
{
    Properties
    {
        [NoScaleOffset]_Foreground ("Foreground", 2D) = "white" {}
        [NoScaleOffset]_Background ("Background", 2D) = "white" {}
        //_Happiness ("Happiness", Range(0,1)) = 1
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
            float _Happiness;
            uniform float _HappinessValue;

            Interpolators vert (MeshData v)
            {
                Interpolators i;
                i.vertex = UnityObjectToClipPos(v.vertex);
                i.uv = v.uv;
                return i;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                _HappinessValue *= 0.01; //Change happiness value!!

                //rounded corner , but can't make to square
                // float2 coords = i.uv;
                // coords.x *= 8;
                // float2 pointOnLineSeg = float2(clamp(coords.x, 0.5, 7.5), 0.5);
                // float sdf = distance(coords, pointOnLineSeg) *2-1;
                //
                // float borderSdf = sdf + 0.3;
                // float borderMask = step(0,borderSdf);
                //
                // return float4(borderMask.xxx,0);
                
                
                float happinessbarMask = _HappinessValue > i.uv.x;
                fixed3 happinessbarColor = tex2D(_Foreground, i.uv);
                fixed3 bgColor = tex2D(_Background, i.uv);
                
                 if (_HappinessValue < 0.3)
                {
                    float flash = cos(_Time.y * 4) * 0.4 + 1;
                    happinessbarColor *= flash;
                }

                float3 outColor = lerp(bgColor, happinessbarColor, happinessbarMask);
                return float4(outColor,0);
            }
            ENDCG
        }
    }
}

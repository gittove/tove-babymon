Shader "Unlit/Timerbar"
{
   Properties
    {
        [NoScaleOffset]_Foreground ("Foreground", 2D) = "white" {}
        [NoScaleOffset]_Background ("Background", 2D) = "white" {}
        
//        _ColorA ("Time color A", Color) = (0,0,0,0)
//        _ColorB ("Time color B", Color) = (0,0,0,0)
//        _BarBackgroundColor ("Bar background color", Color) = (0,0,0,0)
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
            // float4 _ColorA;
            // float4 _ColorB;
            // float4 _BarBackgroundColor;
            uniform float _Timer;
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
                _Timer *= 1/_StartTime;

                //With textures
                float3 timeColor = tex2D(_Foreground, i.uv);
                float3 colorB = tex2D(_Background,i.uv);
                
                //With color properties
                //float3 timeColor = lerp(_ColorA, _ColorB, _Timer);

                float timebarMask = _Timer > i.uv.x; 
                if (_Timer < 0.4)
                {
                    float flash = cos(_Time.y * 6) * 0.4 + 1;
                    timeColor *= flash;
                }

                //With color properties
                // float3 outputColor = lerp(_BarBackgroundColor, timeColor, timebarMask);

                //With textures
                float3 outputColor = lerp(colorB, timeColor, timebarMask);
                
                return float4(outputColor,1);
            }
            ENDCG
        }
    }
}
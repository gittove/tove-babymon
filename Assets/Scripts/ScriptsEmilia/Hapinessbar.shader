Shader "Unlit/Hapinessbar"
{
    Properties
    {
        [NoScaleOffset]_MainTex ("Texture", 2D) = "black" {}
        _Happiness ("Happiness", Range(0,1)) = 1
        _LowHappinessColor ("Low happiness color", Color) = (0,0,0,0)
        _FullHappinessColor ("Full happiness color", Color) = (0,0,0,0)
        _BarBackgroundColor ("Happinessbar background color", Color) = (0,0,0,0)
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

            //Variables
            sampler2D _MainTex;
            float _Happiness;
            float3 _LowHappinessColor;
            float3 _FullHappinessColor;
            float3 _BarBackgroundColor;

            Interpolators vert (MeshData v)
            {
                Interpolators i;
                i.vertex = UnityObjectToClipPos(v.vertex);
                i.uv = v.uv;
                return i;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                // // sample the texture
                // float4 col = tex2D(_MainTex, i.uv);

                float3 happinessbarColor =  lerp(_LowHappinessColor, _FullHappinessColor, _Happiness);
                
                //Create mask that change when happiness changes, across x-axis, linear gradient
                //compare _Happiness with bar coord
                float happinessbarMask = _Happiness > i.uv.x; //_health less than current health coord being rendered
                
                float3 outputColor = lerp(_BarBackgroundColor, happinessbarColor, happinessbarMask);
                return float4(outputColor,0);
                
            }
            ENDCG
        }
    }
}

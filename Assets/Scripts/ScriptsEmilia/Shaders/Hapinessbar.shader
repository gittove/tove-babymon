Shader "Unlit/Hapinessbar"
{
    Properties
    {
        [NoScaleOffset]_MainTex ("Texture", 2D) = "black" {}
        _Happiness ("Happiness", Range(0,1)) = 1
        _LowHappinessColor ("Low happiness color", Color) = (0,0,0,0)
        _FullHappinessColor ("Full happiness color", Color) = (0,0,0,0)
        _BarBackgroundColor ("Happinessbar background color", Color) = (0,0,0,0)
        _Transparency ("Color transparency", Range(0,1)) = 1
        _BorderSize("Border Size", Range(0,0.5)) = 0.5
        
        
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        //Alpha blending
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }

        Pass
        {
            //Alpha blending
            ZWrite Off
            BLend SrcAlpha OneMinusSrcAlpha
            
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
            float _Happiness; //How to get happiness from script to this var? Also remap to range 0-1?
            float3 _LowHappinessColor;
            float3 _FullHappinessColor;
            float3 _BarBackgroundColor;
            float _Transparency;
            float _BorderSize;
            uniform float _HappinessValue;

            Interpolators vert (MeshData v)
            {
                Interpolators i;
                i.vertex = UnityObjectToClipPos(v.vertex);
                i.uv = v.uv;
                return i;
            }

            float InverseLerp(float a, float b, float v)
            {
                return (v-a)/(b-a);
            }

            float4 frag (Interpolators i) : SV_Target
            {
                _HappinessValue / 100;
                //set up coord system
                float2 coords = i.uv;
                coords.x *= 8;
                //rounded corner clipping
                float2 pointOnLineSeg = float2(clamp(coords.x, 0.5, 7.5), 0.5);
                float sdf = distance(coords, pointOnLineSeg) *2 -1;
                clip(-sdf);

                float borderSdf = sdf + _BorderSize;

                float pd = fwidth(borderSdf); //screen space partial derivative
                float borderMask = 1-saturate(borderSdf/pd);
                
                //return float4(borderMask.xxx,1);
                //Use texture
                //Mask, happiness more than current coord being rendered
                float happinessbarMask = _HappinessValue > i.uv.x; 
                
                float3 happinessbarColor = tex2D(_MainTex, float2(_HappinessValue,i.uv.y));

                if (_HappinessValue < 0.3)
                {
                    //time * frequency * magnitude, +1 scaling to keep saturation
                    float flash = cos(_Time.y * 4) * 0.4 + 1;
                    happinessbarColor *= flash;
                }
                if (_HappinessValue > 0.9)
                {
                    //math for sparkle???
                    float flash = cos(_Time.y * 4) * 0.4 + 1;
                    happinessbarColor *= flash;
                }
                
                return float4(happinessbarColor * happinessbarMask * borderMask, 1);
            }
            ENDCG
        }
    }
}

//Simple happiness-bar with or without transparency
//  //Mask, happiness more than current coord being rendered
//                float happinessbarMask = _Happiness > i.uv.x; 
//                
//                //Remove bg-color either discard fragment or thrpugh alpha blending
//                //clip(happinessbarMask - 0.5);
//                
//                //Add threshold through remapping happiness value
//                float tHappinessColor = saturate(InverseLerp(0.2, 0.8,_Happiness));
//                float3 happinessbarColor =  lerp(_LowHappinessColor, _FullHappinessColor, tHappinessColor);
//
//                //W. bg-color
//                // float3 outputColor = lerp(_BarBackgroundColor, happinessbarColor, happinessbarMask);
//                // return float4(outputColor,1);
//
//                return float4(happinessbarColor * happinessbarMask, 1);
//                return float4(happinessbarColor,happinessbarMask * _Transparency);
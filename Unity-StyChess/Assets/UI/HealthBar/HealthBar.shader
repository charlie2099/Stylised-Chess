Shader "HealthBarShader/HealthBar"
{
    Properties
    {
        _Health("Health", Range(0, 1)) = 0
        _FullHp("Low Health Colour", Color) = (0, 1, 0, 1)
        _LowHp("Low Health Colour", Color) = (1, 0, 0, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _Health;
            fixed4 _FullHp;
            fixed4 _LowHp;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                if(i.uv.x > _Health)
                {
                    return 1;
                }
                return lerp(_LowHp, _FullHp, _Health);
            }
            ENDCG
        }
    }
}

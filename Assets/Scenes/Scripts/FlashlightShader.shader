Shader "Custom/FlashlightEffect"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _MousePos ("Mouse Position", Vector) = (0.5, 0.5, 0, 0)
        _Radius ("Radius", Float) = 0.2
        _EdgeSoftness ("Edge Softness", Float) = 0.05
        _EllipseScale ("Ellipse Scale", Vector) = (0.1, 1.0, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            ZTest Always

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float2 _MousePos;
            float _Radius;
            float _EdgeSoftness;
            float4 _EllipseScale;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                fixed4 col = tex2D(_MainTex, uv);

                // Skalierung der UV-Koordinaten für die Ellipse
                float2 scaledUV = (uv - _MousePos) * float2(1.0 / _EllipseScale.x, 1.0 / _EllipseScale.y);

                // Berechnung der Distanz
                float dist = length(scaledUV);

                // Weicher Übergang am Rand
                float edgeStart = _Radius - _EdgeSoftness;
                float edgeEnd = _Radius;
                float alpha = smoothstep(edgeStart, edgeEnd, dist);

                // Umkehr der Farben (Kreis sichtbar, Rest dunkel)
                col.a *= 1.0 - alpha;

                return col;
            }
            ENDCG
        }
    }
}

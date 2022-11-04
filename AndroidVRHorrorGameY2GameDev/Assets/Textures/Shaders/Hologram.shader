Shader "Unlit/Hologram"
{
    Properties
    {
        _MainTex("Albedo Texture", 2D) = "white" {}
        _TintColor("Tint Color" , Color) = (1,1,1,1) //New public property that adds the colour chosen to the object material via shader
        _Transparency("Transparency", Range(0.0,1)) = 0.5
    }
        SubShader
        {
            Tags { "Opueue" = "Transparent" "RenderType" = "Transparent" }
            LOD 100

            ZWrite Off //Stops rendering to the depth buffer
            Blend SrcAlpha OneMinusSRCAlpha //Makes it see through by blending them using the Alpha channel




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

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _TintColor;
                float _Transparency;

                v2f vert(appdata v) //Takes the shape of he model and can change it
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                   return o;
                }

                fixed4 frag(v2f i) : SV_Target //Applies color to the shape output by the vert function
                {
                    // sample the texture
                    fixed4 col = tex2D(_MainTex, i.uv) + _TintColor;
                    col.a = _Transparency;
                    return col;
                }
                ENDCG
            }
        }
}

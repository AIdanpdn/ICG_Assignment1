Shader "Custom/Slag"
{
    Properties
    {
        _MainTex("Diffuse", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _NormalSlider ("Bump factor", Range(0,10)) = 1 
    }    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        struct Input 
        {
            float2 uv_MainTex;
            float2 uv_NormalMap;
        };

        half _NormalSlider;

        struct appdata 
        {
            float4 tangent: TANGENT;
        };


        sampler2D _MainTex;
        sampler2D _NormalMap;
        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D (_MainTex, IN.uv_MainTex);
            o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));
            o.Normal *= float3(_NormalSlider,_NormalSlider,1);
        }

        ENDCG
    }
}

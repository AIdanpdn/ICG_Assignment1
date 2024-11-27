Shader "Custom/Lava"
{
    Properties
    {
        _MainTex("Diffuse", 2D) = "white" {}
        _Emission ("Emission", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}

        _NormalSlider ("Bump factor", Range(0,10)) = 1 


        _Freq("Frequency", Range(0,5)) = 3
        _Speed("Speed", Range(0,100)) = 10
        _Amp("Amplitude", Range(0,1)) = 0.5

        _ScrollX("Scroll X", Range(-5,5)) = 1
        _ScrollY("Scroll Y", Range(-5,5)) = 1


    }    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert vertex:vert

        struct Input 
        {
            float2 uv_MainTex;
            float2 uv_Emission;
            float2 uv_NormalMap;
            float3 vertColor;
        };

        half _NormalSlider;

        float _Freq;
        float _Speed;
        float _Amp;

        float _ScrollX;
        float _ScrollY;

        struct appdata 
        {
            float4 vertex: POSITION;
            float3 normal: NORMAL;
            float4 texcoord: TEXCOORD0;
            float4 texcoord1: TEXCOORD1;
            float4 texcoord2: TEXCOORD2;
            float4 tangent: TANGENT;
        };

        void vert (inout appdata v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input,o);
            float t = _Time * _Speed;
            float waveheight = sin(t + v.vertex.x * _Freq) * _Amp + sin(t*2 + v.vertex.x * _Freq*2) * _Amp;
            v.vertex.y = v.vertex.y + waveheight;
            v.normal = normalize(float3(v.normal.x + waveheight, v.normal.y, v.normal.z));
            o.vertColor = waveheight + 2;
        }

        sampler2D _MainTex;
        sampler2D _Emission;
        sampler2D _NormalMap;
        void surf (Input IN, inout SurfaceOutput o)
        {
            _ScrollX *= _Time;
            _ScrollY *= _Time;
            float2 newuv = IN.uv_MainTex + float2(_ScrollX, _ScrollY);
            o.Albedo = tex2D (_MainTex, newuv);
            o.Emission = tex2D (_Emission, newuv);
            o.Normal = UnpackNormal(tex2D(_NormalMap, newuv));
            o.Normal *= float3(_NormalSlider,_NormalSlider,1);
        }

        ENDCG
    }
}

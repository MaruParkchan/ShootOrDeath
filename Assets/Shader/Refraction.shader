Shader "Custom/Refraction" {
	Properties{
		_MainTex("Albedo (RGB)", 2D) = ""{}
		_RefStrength ("Refraction Strength", Range(0, 0.1)) = 0.01

	}
	SubShader{
		Tags {
			"Queue" = "Transparent"
			"RenderType" = "Transparent"
		}

		zwrite off
		GrabPass{} // 화면캡처
		CGPROGRAM

		#pragma surface surf Refraction noambient
		#pragma target 3.0

		sampler2D _GrabTexture;
		sampler2D _MainTex;
		float _RefStrength;

	struct Input
	{
		float4 screenPos;
		float2 uv_MainTex;
	};

	void surf(Input IN, inout SurfaceOutput o)
	{
		float4 refraction = tex2D(_MainTex, IN.uv_MainTex);

		float3 screenUV = IN.screenPos.rgb / IN.screenPos.a;
		o.Emission = tex2D(_GrabTexture, screenUV.xy + refraction.x * _RefStrength);
	}

	float4 LightingRefraction(SurfaceOutput o, float3 lightDir, float atten)
	{
		return float4(0, 0, 0, 1);
	}

	ENDCG

	}
}
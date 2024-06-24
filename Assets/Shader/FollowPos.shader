

Shader "Shader Forge/SH_Floor_Base" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Mask ("Mask", 2D) = "white" {}
        _Tile ("Tile", Range(0, 50)) = 1
        _Intensity ("Intensity", Range(0, 10)) = 0
        _ReflectionMap ("ReflectionMap", Cube) = "_Skybox" {}
        _Position ("Position", Vector) = (0,0,0,0)
        _Distance ("Distance", Range(0, 10)) = 1
        _Size ("Size", Range(0, 1)) = 0.1
        _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
			
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            //#pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _Tile;
            uniform float _Intensity;
            uniform samplerCUBE _ReflectionMap;
            uniform float4 _Position;
            uniform float _Distance;
            uniform float _Size;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );

                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float2 node_6008 = (i.uv0*_Tile);
                float4 node_3225 = tex2D(_Mask,TRANSFORM_TEX(node_6008, _Mask));
                float3 emissive = (texCUBE(_ReflectionMap,viewReflectDirection).rgb+(_Color.rgb*node_3225.r*_Intensity));
                float3 finalColor = emissive;
                return fixed4(finalColor,(node_3225.r*saturate((_Distance-(distance(i.posWorld,_Position.rgb)*_Size)))));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

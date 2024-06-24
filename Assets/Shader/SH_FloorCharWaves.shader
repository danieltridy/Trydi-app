// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33038,y:32582,varname:node_3138,prsc:2|emission-4265-OUT,alpha-4985-OUT,clip-942-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32601,y:32394,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:1,c3:0.7,c4:1;n:type:ShaderForge.SFN_TexCoord,id:8459,x:31228,y:32680,varname:node_8459,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:291,x:31413,y:32680,varname:node_291,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-8459-UVOUT;n:type:ShaderForge.SFN_Length,id:3062,x:31563,y:32680,varname:node_3062,prsc:2|IN-291-OUT;n:type:ShaderForge.SFN_OneMinus,id:5957,x:31716,y:32680,varname:node_5957,prsc:2|IN-3062-OUT;n:type:ShaderForge.SFN_Multiply,id:2746,x:31907,y:32680,varname:node_2746,prsc:2|A-5957-OUT,B-8821-OUT;n:type:ShaderForge.SFN_Add,id:5343,x:32106,y:32736,varname:node_5343,prsc:2|A-2746-OUT,B-1264-OUT;n:type:ShaderForge.SFN_Multiply,id:1264,x:31870,y:32908,varname:node_1264,prsc:2|A-8336-T,B-2752-OUT;n:type:ShaderForge.SFN_Time,id:8336,x:31670,y:32854,varname:node_8336,prsc:2;n:type:ShaderForge.SFN_Slider,id:2752,x:31513,y:32993,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_2752,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3,max:10;n:type:ShaderForge.SFN_Vector1,id:8821,x:31773,y:32808,varname:node_8821,prsc:2,v1:8;n:type:ShaderForge.SFN_Sin,id:486,x:32265,y:32736,varname:node_486,prsc:2|IN-5343-OUT;n:type:ShaderForge.SFN_Clamp01,id:4461,x:32265,y:32486,varname:node_4461,prsc:2|IN-5957-OUT;n:type:ShaderForge.SFN_Clamp01,id:8891,x:32431,y:32736,varname:node_8891,prsc:2|IN-486-OUT;n:type:ShaderForge.SFN_Power,id:3519,x:32596,y:32752,varname:node_3519,prsc:2|VAL-8891-OUT,EXP-2279-OUT;n:type:ShaderForge.SFN_Slider,id:2279,x:32218,y:32913,ptovrint:False,ptlb:Edge Thikness,ptin:_EdgeThikness,varname:node_2279,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:20,max:30;n:type:ShaderForge.SFN_Multiply,id:4985,x:32780,y:32831,varname:node_4985,prsc:2|A-4461-OUT,B-3519-OUT;n:type:ShaderForge.SFN_Multiply,id:4265,x:32849,y:32572,varname:node_4265,prsc:2|A-7241-RGB,B-2901-OUT;n:type:ShaderForge.SFN_Slider,id:2901,x:32519,y:32621,ptovrint:False,ptlb:Intensity,ptin:_Intensity,varname:node_2901,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1.2,max:3;n:type:ShaderForge.SFN_Vector1,id:942,x:32812,y:32961,varname:node_942,prsc:2,v1:0.95;proporder:7241-2752-2279-2901;pass:END;sub:END;*/

Shader "Shader Forge/SH_FloorCharWaves" {
    Properties {
        _Color ("Color", Color) = (0.07843138,1,0.7,1)
        _Speed ("Speed", Range(0, 10)) = 3
        _EdgeThikness ("Edge Thikness", Range(0, 30)) = 20
        _Intensity ("Intensity", Range(1, 3)) = 1.2
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _Speed)
                UNITY_DEFINE_INSTANCED_PROP( float, _EdgeThikness)
                UNITY_DEFINE_INSTANCED_PROP( float, _Intensity)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                clip(0.95 - 0.5);
////// Lighting:
////// Emissive:
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float _Intensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Intensity );
                float3 emissive = (_Color_var.rgb*_Intensity_var);
                float3 finalColor = emissive;
                float node_5957 = (1.0 - length((i.uv0*2.0+-1.0)));
                float4 node_8336 = _Time;
                float _Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Speed );
                float node_486 = sin(((node_5957*8.0)+(node_8336.g*_Speed_var)));
                float _EdgeThikness_var = UNITY_ACCESS_INSTANCED_PROP( Props, _EdgeThikness );
                return fixed4(finalColor,(saturate(node_5957)*pow(saturate(node_486),_EdgeThikness_var)));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                clip(0.95 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

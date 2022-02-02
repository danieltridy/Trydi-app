// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:False,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33260,y:32662,varname:node_3138,prsc:2|emission-7241-RGB,alpha-9873-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32235,y:32511,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_TexCoord,id:9750,x:31345,y:32780,varname:node_9750,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:9873,x:32917,y:32795,varname:node_9873,prsc:2|A-4633-OUT,B-3043-OUT,C-5155-OUT,D-6241-OUT;n:type:ShaderForge.SFN_OneMinus,id:4750,x:31559,y:32523,varname:node_4750,prsc:2|IN-9750-V;n:type:ShaderForge.SFN_Power,id:9966,x:31765,y:32523,varname:node_9966,prsc:2|VAL-4750-OUT,EXP-4956-OUT;n:type:ShaderForge.SFN_Vector1,id:9580,x:31537,y:32655,varname:node_9580,prsc:2,v1:4;n:type:ShaderForge.SFN_OneMinus,id:4633,x:31958,y:32523,varname:node_4633,prsc:2|IN-9966-OUT;n:type:ShaderForge.SFN_Time,id:147,x:31333,y:32930,varname:node_147,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1848,x:31546,y:32993,varname:node_1848,prsc:2|A-147-T,B-8208-OUT;n:type:ShaderForge.SFN_Slider,id:8208,x:31176,y:33074,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_8208,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:0.3,max:10;n:type:ShaderForge.SFN_Sin,id:4521,x:32117,y:32922,varname:node_4521,prsc:2|IN-4973-OUT;n:type:ShaderForge.SFN_Add,id:4973,x:31900,y:32949,varname:node_4973,prsc:2|A-4320-OUT,B-1848-OUT;n:type:ShaderForge.SFN_Multiply,id:4320,x:31713,y:32843,varname:node_4320,prsc:2|A-9750-V,B-7885-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7885,x:31483,y:32908,ptovrint:False,ptlb:Waves,ptin:_Waves,varname:node_7885,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Power,id:5133,x:31835,y:32668,varname:node_5133,prsc:2|VAL-9750-V,EXP-9580-OUT;n:type:ShaderForge.SFN_OneMinus,id:5155,x:32023,y:32693,varname:node_5155,prsc:2|IN-5133-OUT;n:type:ShaderForge.SFN_Clamp01,id:7879,x:32371,y:32950,varname:node_7879,prsc:2|IN-4521-OUT;n:type:ShaderForge.SFN_Vector1,id:4956,x:31522,y:32733,varname:node_4956,prsc:2,v1:2;n:type:ShaderForge.SFN_Round,id:3043,x:32650,y:32932,varname:node_3043,prsc:2|IN-7879-OUT;n:type:ShaderForge.SFN_Slider,id:6241,x:32444,y:33125,ptovrint:False,ptlb:Active,ptin:_Active,varname:node_6241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;proporder:7241-8208-7885-6241;pass:END;sub:END;*/

Shader "Unlit/SH_Floor_Waves" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Speed ("Speed", Range(-10, 10)) = 0.3
        _Waves ("Waves", Float ) = 1
        _Active ("Active", Range(0, 1)) = 0
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
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _Speed)
                UNITY_DEFINE_INSTANCED_PROP( float, _Waves)
                UNITY_DEFINE_INSTANCED_PROP( float, _Active)
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
////// Lighting:
////// Emissive:
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float3 emissive = _Color_var.rgb;
                float3 finalColor = emissive;
                float _Waves_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Waves );
                float4 node_147 = _Time;
                float _Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Speed );
                float _Active_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Active );
                return fixed4(finalColor,((1.0 - pow((1.0 - i.uv0.g),2.0))*round(saturate(sin(((i.uv0.g*_Waves_var)+(node_147.g*_Speed_var)))))*(1.0 - pow(i.uv0.g,4.0))*_Active_var));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33268,y:33189,varname:node_3138,prsc:2|emission-1300-OUT,alpha-1107-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32610,y:33377,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.0627451,c2:0.8313726,c3:1,c4:1;n:type:ShaderForge.SFN_TexCoord,id:3593,x:31643,y:32975,varname:node_3593,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:295,x:31864,y:33049,varname:node_295,prsc:2|A-3593-V,B-9457-T;n:type:ShaderForge.SFN_Time,id:9457,x:31643,y:33123,varname:node_9457,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2181,x:32025,y:33119,varname:node_2181,prsc:2|A-295-OUT,B-317-OUT;n:type:ShaderForge.SFN_Vector1,id:317,x:31864,y:33193,varname:node_317,prsc:2,v1:5;n:type:ShaderForge.SFN_Sin,id:6664,x:32174,y:33119,varname:node_6664,prsc:2|IN-2181-OUT;n:type:ShaderForge.SFN_Multiply,id:115,x:32411,y:33136,varname:node_115,prsc:2|A-6664-OUT,B-9483-OUT;n:type:ShaderForge.SFN_Slider,id:4885,x:31914,y:33392,ptovrint:False,ptlb:Contrast_Alpha,ptin:_Contrast_Alpha,varname:node_4885,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7,max:1;n:type:ShaderForge.SFN_Multiply,id:9483,x:32252,y:33286,varname:node_9483,prsc:2|A-8151-OUT,B-4885-OUT;n:type:ShaderForge.SFN_Vector1,id:8151,x:32061,y:33285,varname:node_8151,prsc:2,v1:0.3;n:type:ShaderForge.SFN_OneMinus,id:6987,x:32411,y:33286,varname:node_6987,prsc:2|IN-9483-OUT;n:type:ShaderForge.SFN_Add,id:9255,x:32623,y:33213,varname:node_9255,prsc:2|A-115-OUT,B-6987-OUT;n:type:ShaderForge.SFN_Fresnel,id:1418,x:32116,y:33618,varname:node_1418,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9850,x:32302,y:33618,varname:node_9850,prsc:2|A-4885-OUT,B-1418-OUT;n:type:ShaderForge.SFN_Add,id:1107,x:32533,y:33618,varname:node_1107,prsc:2|A-9482-OUT,B-9850-OUT;n:type:ShaderForge.SFN_OneMinus,id:9482,x:32411,y:33428,varname:node_9482,prsc:2|IN-4885-OUT;n:type:ShaderForge.SFN_Multiply,id:1300,x:32865,y:33277,varname:node_1300,prsc:2|A-9255-OUT,B-7241-RGB;proporder:7241-4885;pass:END;sub:END;*/

Shader "Shader Forge/Aura_Pin" {
    Properties {
        _Color ("Color", Color) = (0.0627451,0.8313726,1,1)
        _Contrast_Alpha ("Contrast_Alpha", Range(0, 1)) = 0.7
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
            Cull Off
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
                UNITY_DEFINE_INSTANCED_PROP( float, _Contrast_Alpha)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 node_9457 = _Time;
                float _Contrast_Alpha_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Contrast_Alpha );
                float node_9483 = (0.3*_Contrast_Alpha_var);
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float3 emissive = (((sin(((i.uv0.g+node_9457.g)*5.0))*node_9483)+(1.0 - node_9483))*_Color_var.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,((1.0 - _Contrast_Alpha_var)+(_Contrast_Alpha_var*(1.0-max(0,dot(normalDirection, viewDirection))))));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

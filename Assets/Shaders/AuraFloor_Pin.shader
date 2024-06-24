// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32677,y:32404,varname:node_3138,prsc:2|emission-7241-RGB,alpha-1046-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31935,y:32277,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.0627451,c2:0.8313726,c3:1,c4:1;n:type:ShaderForge.SFN_TexCoord,id:5742,x:30259,y:32614,varname:node_5742,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ToggleProperty,id:9993,x:30160,y:32372,ptovrint:False,ptlb:vertical_horizontal_UVm,ptin:_vertical_horizontal_UVm,varname:node_9993,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Multiply,id:7257,x:30675,y:32674,varname:node_7257,prsc:2|A-3169-OUT,B-5742-V;n:type:ShaderForge.SFN_Multiply,id:4277,x:30675,y:32554,varname:node_4277,prsc:2|A-9993-OUT,B-5742-U;n:type:ShaderForge.SFN_OneMinus,id:3169,x:30259,y:32471,varname:node_3169,prsc:2|IN-9993-OUT;n:type:ShaderForge.SFN_Multiply,id:2880,x:30675,y:32417,varname:node_2880,prsc:2|A-3169-OUT,B-5742-U;n:type:ShaderForge.SFN_Multiply,id:1806,x:30675,y:32293,varname:node_1806,prsc:2|A-9993-OUT,B-5742-V;n:type:ShaderForge.SFN_Add,id:8372,x:30902,y:32346,varname:node_8372,prsc:2|A-1806-OUT,B-2880-OUT;n:type:ShaderForge.SFN_Add,id:7326,x:30884,y:32645,varname:node_7326,prsc:2|A-4277-OUT,B-7257-OUT,C-8879-T;n:type:ShaderForge.SFN_Time,id:8879,x:30675,y:32783,varname:node_8879,prsc:2;n:type:ShaderForge.SFN_Append,id:9805,x:31162,y:32522,varname:node_9805,prsc:2|A-8372-OUT,B-7326-OUT;n:type:ShaderForge.SFN_Slider,id:9605,x:30775,y:32131,ptovrint:False,ptlb:Contrast,ptin:_Contrast,varname:node_9605,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7,max:1;n:type:ShaderForge.SFN_OneMinus,id:374,x:31149,y:32078,varname:node_374,prsc:2|IN-9605-OUT;n:type:ShaderForge.SFN_Multiply,id:7095,x:31149,y:32245,varname:node_7095,prsc:2|A-9605-OUT,B-5742-V;n:type:ShaderForge.SFN_Multiply,id:2466,x:31356,y:32618,varname:node_2466,prsc:2|A-9805-OUT,B-8050-XYZ;n:type:ShaderForge.SFN_Tex2d,id:1917,x:31523,y:32618,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_1917,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2466-OUT;n:type:ShaderForge.SFN_Add,id:1444,x:31405,y:32196,varname:node_1444,prsc:2|A-374-OUT,B-7095-OUT;n:type:ShaderForge.SFN_Add,id:2657,x:31588,y:32311,varname:node_2657,prsc:2|A-1444-OUT,B-632-OUT;n:type:ShaderForge.SFN_Slider,id:632,x:31248,y:32391,ptovrint:False,ptlb:Amplitud,ptin:_Amplitud,varname:node_632,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_OneMinus,id:8567,x:31702,y:32635,varname:node_8567,prsc:2|IN-1917-R;n:type:ShaderForge.SFN_Subtract,id:196,x:31935,y:32516,varname:node_196,prsc:2|A-2657-OUT,B-8567-OUT;n:type:ShaderForge.SFN_Multiply,id:4500,x:32182,y:32594,varname:node_4500,prsc:2|A-7241-A,B-196-OUT;n:type:ShaderForge.SFN_Clamp01,id:1046,x:32363,y:32641,varname:node_1046,prsc:2|IN-4500-OUT;n:type:ShaderForge.SFN_Vector4Property,id:8050,x:31162,y:32682,ptovrint:False,ptlb:UV,ptin:_UV,varname:node_8050,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1,v2:1,v3:0,v4:0;proporder:7241-9993-9605-1917-632-8050;pass:END;sub:END;*/

Shader "Shader Forge/AuraFloor_Pin" {
    Properties {
        _Color ("Color", Color) = (0.0627451,0.8313726,1,1)
        [MaterialToggle] _vertical_horizontal_UVm ("vertical_horizontal_UVm", Float ) = 0
        _Contrast ("Contrast", Range(0, 1)) = 0.7
        _Noise ("Noise", 2D) = "white" {}
        _Amplitud ("Amplitud", Range(0, 1)) = 0
        _UV ("UV", Vector) = (1,1,0,0)
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
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _vertical_horizontal_UVm)
                UNITY_DEFINE_INSTANCED_PROP( float, _Contrast)
                UNITY_DEFINE_INSTANCED_PROP( float, _Amplitud)
                UNITY_DEFINE_INSTANCED_PROP( float4, _UV)
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float3 emissive = _Color_var.rgb;
                float3 finalColor = emissive;
                float _Contrast_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Contrast );
                float _Amplitud_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Amplitud );
                float _vertical_horizontal_UVm_var = UNITY_ACCESS_INSTANCED_PROP( Props, _vertical_horizontal_UVm );
                float node_3169 = (1.0 - _vertical_horizontal_UVm_var);
                float4 node_8879 = _Time;
                float4 _UV_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UV );
                float3 node_2466 = (float3(float2(((_vertical_horizontal_UVm_var*i.uv0.g)+(node_3169*i.uv0.r)),((_vertical_horizontal_UVm_var*i.uv0.r)+(node_3169*i.uv0.g)+node_8879.g)),0.0)*_UV_var.rgb);
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_2466, _Noise));
                return fixed4(finalColor,saturate((_Color_var.a*((((1.0 - _Contrast_var)+(_Contrast_var*i.uv0.g))+_Amplitud_var)-(1.0 - _Noise_var.r)))));
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

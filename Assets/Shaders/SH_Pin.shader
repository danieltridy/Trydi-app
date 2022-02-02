// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:False,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:False,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33307,y:32834,varname:node_2865,prsc:2|normal-9367-RGB,emission-1059-OUT;n:type:ShaderForge.SFN_Color,id:6665,x:32033,y:33237,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5019608,c2:0.5019608,c3:0.5019608,c4:1;n:type:ShaderForge.SFN_Fresnel,id:2924,x:32313,y:33434,varname:node_2924,prsc:2|EXP-4903-OUT;n:type:ShaderForge.SFN_Slider,id:4903,x:31988,y:33434,ptovrint:False,ptlb:Fressnel Pow,ptin:_FressnelPow,varname:node_4903,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:2.166209,max:5;n:type:ShaderForge.SFN_Multiply,id:4383,x:32821,y:33364,varname:node_4383,prsc:2|A-2924-OUT,B-7889-RGB,C-8118-OUT;n:type:ShaderForge.SFN_Color,id:7889,x:32313,y:33579,ptovrint:False,ptlb:Hover Color,ptin:_HoverColor,varname:node_7889,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.2196366,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:8118,x:32156,y:33741,ptovrint:False,ptlb:Active,ptin:_Active,varname:node_8118,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:3;n:type:ShaderForge.SFN_Add,id:1059,x:33086,y:32955,varname:node_1059,prsc:2|A-1706-OUT,B-4383-OUT;n:type:ShaderForge.SFN_Slider,id:4255,x:31988,y:32660,ptovrint:False,ptlb:Add MidFress,ptin:_AddMidFress,varname:node_4255,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:5465,x:31797,y:33144,ptovrint:False,ptlb:PowSS,ptin:_PowSS,varname:node_5465,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:1.5,max:10;n:type:ShaderForge.SFN_Slider,id:4024,x:31306,y:33157,ptovrint:False,ptlb:Spec,ptin:_Spec,varname:node_4024,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:9367,x:32677,y:32683,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_9367,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Add,id:296,x:32654,y:32975,varname:node_296,prsc:2|A-7699-OUT,B-6303-OUT;n:type:ShaderForge.SFN_ViewVector,id:7032,x:31153,y:32862,varname:node_7032,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:1037,x:31463,y:32953,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:5874,x:31681,y:32833,varname:node_5874,prsc:2,dt:1|A-8209-OUT,B-1037-OUT;n:type:ShaderForge.SFN_Add,id:8209,x:31463,y:32817,varname:node_8209,prsc:2|A-7032-OUT,B-7192-XYZ;n:type:ShaderForge.SFN_Subtract,id:420,x:31954,y:32873,varname:node_420,prsc:2|A-5874-OUT,B-9305-OUT;n:type:ShaderForge.SFN_OneMinus,id:9305,x:31752,y:32996,varname:node_9305,prsc:2|IN-4024-OUT;n:type:ShaderForge.SFN_Clamp01,id:3261,x:32346,y:32884,varname:node_3261,prsc:2|IN-1450-OUT;n:type:ShaderForge.SFN_Multiply,id:7699,x:32460,y:32873,varname:node_7699,prsc:2|A-3261-OUT,B-5318-OUT;n:type:ShaderForge.SFN_Vector1,id:5318,x:32249,y:33020,varname:node_5318,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Vector4Property,id:7192,x:31153,y:33040,ptovrint:False,ptlb:LightPosition,ptin:_LightPosition,varname:node_7192,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Fresnel,id:3054,x:32215,y:33122,varname:node_3054,prsc:2|EXP-5465-OUT;n:type:ShaderForge.SFN_Multiply,id:6303,x:32654,y:33167,varname:node_6303,prsc:2|A-7896-OUT,B-6665-RGB;n:type:ShaderForge.SFN_RemapRange,id:7896,x:32460,y:33060,varname:node_7896,prsc:2,frmn:0,frmx:1,tomn:0.8,tomx:1.1|IN-3054-OUT;n:type:ShaderForge.SFN_Multiply,id:1450,x:32145,y:32817,varname:node_1450,prsc:2|A-6656-OUT,B-420-OUT;n:type:ShaderForge.SFN_Vector1,id:6656,x:31933,y:32783,varname:node_6656,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:1706,x:32910,y:32955,varname:node_1706,prsc:2|A-296-OUT,B-6896-OUT;n:type:ShaderForge.SFN_Vector1,id:6896,x:32800,y:33096,varname:node_6896,prsc:2,v1:0.9;proporder:6665-4903-7889-8118-4255-5465-4024-9367-7192;pass:END;sub:END;*/

Shader "PBL/SH_Pin" {
    Properties {
        _Color ("Color", Color) = (0.5019608,0.5019608,0.5019608,1)
        _FressnelPow ("Fressnel Pow", Range(0.1, 5)) = 2.166209
        _HoverColor ("Hover Color", Color) = (1,0.2196366,0,1)
        _Active ("Active", Range(0, 3)) = 0
        _AddMidFress ("Add MidFress", Range(0, 1)) = 0
        _PowSS ("PowSS", Range(0.1, 10)) = 1.5
        _Spec ("Spec", Range(0, 1)) = 0
        _Normal ("Normal", 2D) = "bump" {}
        _LightPosition ("LightPosition", Vector) = (0,0,0,0)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _FressnelPow)
                UNITY_DEFINE_INSTANCED_PROP( float4, _HoverColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _Active)
                UNITY_DEFINE_INSTANCED_PROP( float, _PowSS)
                UNITY_DEFINE_INSTANCED_PROP( float, _Spec)
                UNITY_DEFINE_INSTANCED_PROP( float4, _LightPosition)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
////// Lighting:
////// Emissive:
                float4 _LightPosition_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LightPosition );
                float _Spec_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Spec );
                float node_3261 = saturate((3.0*(max(0,dot((viewDirection+_LightPosition_var.rgb),normalDirection))-(1.0 - _Spec_var))));
                float _PowSS_var = UNITY_ACCESS_INSTANCED_PROP( Props, _PowSS );
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float _FressnelPow_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FressnelPow );
                float4 _HoverColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _HoverColor );
                float _Active_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Active );
                float3 emissive = ((((node_3261*0.2)+((pow(1.0-max(0,dot(normalDirection, viewDirection)),_PowSS_var)*0.3+0.8)*_Color_var.rgb))*0.9)+(pow(1.0-max(0,dot(normalDirection, viewDirection)),_FressnelPow_var)*_HoverColor_var.rgb*_Active_var));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

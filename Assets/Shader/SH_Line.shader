// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:False,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32751,y:32690,varname:node_3138,prsc:2|emission-6120-OUT,alpha-4753-OUT;n:type:ShaderForge.SFN_Vector1,id:3532,x:32213,y:33067,varname:node_3532,prsc:2,v1:2;n:type:ShaderForge.SFN_Clamp01,id:4753,x:32557,y:32946,varname:node_4753,prsc:2|IN-4148-OUT;n:type:ShaderForge.SFN_Multiply,id:4148,x:32394,y:32946,varname:node_4148,prsc:2|A-9251-OUT,B-3532-OUT;n:type:ShaderForge.SFN_Add,id:9251,x:32213,y:32946,varname:node_9251,prsc:2|A-4369-OUT,B-2305-OUT;n:type:ShaderForge.SFN_Power,id:4369,x:31593,y:32938,varname:node_4369,prsc:2|VAL-4075-OUT,EXP-6612-OUT;n:type:ShaderForge.SFN_Multiply,id:2305,x:31978,y:33016,varname:node_2305,prsc:2|A-62-OUT,B-4369-OUT,C-1562-OUT;n:type:ShaderForge.SFN_Vector1,id:1562,x:31757,y:33050,varname:node_1562,prsc:2,v1:2;n:type:ShaderForge.SFN_OneMinus,id:62,x:31557,y:32404,varname:node_62,prsc:2|IN-3642-R;n:type:ShaderForge.SFN_Tex2d,id:3642,x:31247,y:32381,ptovrint:False,ptlb:arrows,ptin:_arrows,varname:node_3642,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4121-OUT;n:type:ShaderForge.SFN_Subtract,id:4075,x:31343,y:32938,varname:node_4075,prsc:2|A-8206-OUT,B-3588-OUT;n:type:ShaderForge.SFN_Slider,id:6612,x:31186,y:33091,ptovrint:False,ptlb:contrastFade,ptin:_contrastFade,varname:node_6612,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:3.52,max:40;n:type:ShaderForge.SFN_Clamp01,id:8206,x:31088,y:32808,varname:node_8206,prsc:2|IN-8932-OUT;n:type:ShaderForge.SFN_Clamp01,id:3588,x:31067,y:33031,varname:node_3588,prsc:2|IN-9994-OUT;n:type:ShaderForge.SFN_Lerp,id:6120,x:32557,y:32807,varname:node_6120,prsc:2|A-9405-OUT,B-9651-RGB,T-3642-R;n:type:ShaderForge.SFN_Color,id:9651,x:32213,y:32817,ptovrint:False,ptlb:arrowsColor,ptin:_arrowsColor,varname:node_9651,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9411765,c2:0.6705883,c3:0.09019608,c4:1;n:type:ShaderForge.SFN_Lerp,id:9405,x:31945,y:32758,varname:node_9405,prsc:2|A-8380-RGB,B-4527-RGB,T-8647-OUT;n:type:ShaderForge.SFN_Color,id:8380,x:31578,y:32611,ptovrint:False,ptlb:color1,ptin:_color1,varname:node_8380,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.0509804,c2:0.9215687,c3:0.6392157,c4:1;n:type:ShaderForge.SFN_Color,id:4527,x:31578,y:32774,ptovrint:False,ptlb:color2,ptin:_color2,varname:node_4527,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.09019608,c2:0.9411765,c3:0.9843138,c4:1;n:type:ShaderForge.SFN_Clamp01,id:8647,x:31385,y:32800,varname:node_8647,prsc:2|IN-2215-OUT;n:type:ShaderForge.SFN_Divide,id:9994,x:30895,y:33031,varname:node_9994,prsc:2|A-3357-OUT,B-8736-OUT;n:type:ShaderForge.SFN_Subtract,id:3357,x:30637,y:32965,varname:node_3357,prsc:2|A-8076-OUT,B-374-OUT;n:type:ShaderForge.SFN_Slider,id:8736,x:30480,y:33106,ptovrint:False,ptlb:fadeFistance,ptin:_fadeFistance,varname:node_8736,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:20,max:40;n:type:ShaderForge.SFN_Slider,id:374,x:30281,y:33020,ptovrint:False,ptlb:farDistance,ptin:_farDistance,varname:node_374,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:40,cur:53,max:150;n:type:ShaderForge.SFN_Distance,id:8076,x:30016,y:33021,varname:node_8076,prsc:2|A-4529-XYZ,B-6931-XYZ;n:type:ShaderForge.SFN_FragmentPosition,id:4529,x:29620,y:32916,varname:node_4529,prsc:2;n:type:ShaderForge.SFN_Vector4Property,id:6931,x:29620,y:33069,ptovrint:False,ptlb:playerPosition,ptin:_playerPosition,varname:node_6931,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:1;n:type:ShaderForge.SFN_Subtract,id:2100,x:30372,y:33201,varname:node_2100,prsc:2|A-8076-OUT,B-4798-OUT;n:type:ShaderForge.SFN_Vector1,id:4798,x:30190,y:33221,varname:node_4798,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Subtract,id:2746,x:30713,y:33207,varname:node_2746,prsc:2|A-2100-OUT,B-58-OUT;n:type:ShaderForge.SFN_Vector1,id:58,x:30524,y:33252,varname:node_58,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Add,id:2934,x:30679,y:33381,varname:node_2934,prsc:2|A-374-OUT,B-1337-OUT;n:type:ShaderForge.SFN_Slider,id:1337,x:30229,y:33400,ptovrint:False,ptlb:colorFarDistance,ptin:_colorFarDistance,varname:node_1337,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:9.64,max:20;n:type:ShaderForge.SFN_Divide,id:2215,x:31016,y:33307,varname:node_2215,prsc:2|A-2746-OUT,B-2934-OUT;n:type:ShaderForge.SFN_Divide,id:8932,x:30869,y:32808,varname:node_8932,prsc:2|A-2100-OUT,B-8736-OUT;n:type:ShaderForge.SFN_Append,id:4121,x:31036,y:32381,varname:node_4121,prsc:2|A-5478-R,B-4858-OUT;n:type:ShaderForge.SFN_Add,id:4858,x:30793,y:32426,varname:node_4858,prsc:2|A-5478-G,B-6170-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5478,x:30502,y:32365,varname:node_5478,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-4521-OUT;n:type:ShaderForge.SFN_Multiply,id:6170,x:30502,y:32509,varname:node_6170,prsc:2|A-7837-T,B-1587-OUT;n:type:ShaderForge.SFN_Slider,id:1587,x:29975,y:32644,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_1587,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:-0.91,max:1;n:type:ShaderForge.SFN_Time,id:7837,x:30089,y:32495,varname:node_7837,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4521,x:30254,y:32350,varname:node_4521,prsc:2|A-3030-UVOUT,B-7900-XYZ;n:type:ShaderForge.SFN_Vector4Property,id:7900,x:29875,y:32409,ptovrint:False,ptlb:UVTile,ptin:_UVTile,varname:node_7900,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1,v2:0.2,v3:1,v4:1;n:type:ShaderForge.SFN_TexCoord,id:3030,x:29875,y:32254,varname:node_3030,prsc:2,uv:0,uaff:False;proporder:8380-4527-9651-3642-7900-1587-6931-374-8736-6612-1337;pass:END;sub:END;*/

Shader "customeUi/SH_Line" {
    Properties {
        _color1 ("color1", Color) = (0.0509804,0.9215687,0.6392157,1)
        _color2 ("color2", Color) = (0.09019608,0.9411765,0.9843138,1)
        _arrowsColor ("arrowsColor", Color) = (0.9411765,0.6705883,0.09019608,1)
        _arrows ("arrows", 2D) = "white" {}
        _UVTile ("UVTile", Vector) = (1,0.2,1,1)
        _speed ("speed", Range(-1, 1)) = -0.91
        _playerPosition ("playerPosition", Vector) = (0,0,0,1)
        _farDistance ("farDistance", Range(40, 150)) = 53
        _fadeFistance ("fadeFistance", Range(1, 40)) = 20
        _contrastFade ("contrastFade", Range(1, 40)) = 3.52
        _colorFarDistance ("colorFarDistance", Range(1, 20)) = 9.64
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
            //#pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            //#pragma target 3.0
            uniform sampler2D _arrows; uniform float4 _arrows_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _contrastFade)
                UNITY_DEFINE_INSTANCED_PROP( float4, _arrowsColor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _color1)
                UNITY_DEFINE_INSTANCED_PROP( float4, _color2)
                UNITY_DEFINE_INSTANCED_PROP( float, _fadeFistance)
                UNITY_DEFINE_INSTANCED_PROP( float, _farDistance)
                UNITY_DEFINE_INSTANCED_PROP( float4, _playerPosition)
                UNITY_DEFINE_INSTANCED_PROP( float, _colorFarDistance)
                UNITY_DEFINE_INSTANCED_PROP( float, _speed)
                UNITY_DEFINE_INSTANCED_PROP( float4, _UVTile)
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
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
////// Lighting:
////// Emissive:
                float4 _color1_var = UNITY_ACCESS_INSTANCED_PROP( Props, _color1 );
                float4 _color2_var = UNITY_ACCESS_INSTANCED_PROP( Props, _color2 );
                float4 _playerPosition_var = UNITY_ACCESS_INSTANCED_PROP( Props, _playerPosition );
                float node_8076 = distance(i.posWorld.rgb,_playerPosition_var.rgb);
                float node_2100 = (node_8076-0.2);
                float _farDistance_var = UNITY_ACCESS_INSTANCED_PROP( Props, _farDistance );
                float _colorFarDistance_var = UNITY_ACCESS_INSTANCED_PROP( Props, _colorFarDistance );
                float4 _arrowsColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _arrowsColor );
                float4 _UVTile_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UVTile );
                float2 node_5478 = (float3(i.uv0,0.0)*_UVTile_var.rgb).rg;
                float4 node_7837 = _Time;
                float _speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _speed );
                float2 node_4121 = float2(node_5478.r,(node_5478.g+(node_7837.g*_speed_var)));
                float4 _arrows_var = tex2D(_arrows,TRANSFORM_TEX(node_4121, _arrows));
                float3 emissive = lerp(lerp(_color1_var.rgb,_color2_var.rgb,saturate(((node_2100-0.3)/(_farDistance_var+_colorFarDistance_var)))),_arrowsColor_var.rgb,_arrows_var.r);
                float3 finalColor = emissive;
                float _fadeFistance_var = UNITY_ACCESS_INSTANCED_PROP( Props, _fadeFistance );
                float _contrastFade_var = UNITY_ACCESS_INSTANCED_PROP( Props, _contrastFade );
                float node_4369 = pow((saturate((node_2100/_fadeFistance_var))-saturate(((node_8076-_farDistance_var)/_fadeFistance_var))),_contrastFade_var);
                return fixed4(finalColor,saturate(((node_4369+((1.0 - _arrows_var.r)*node_4369*2.0))*2.0)));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

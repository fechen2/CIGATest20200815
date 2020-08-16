// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33101,y:32746,varname:node_3138,prsc:2|emission-1248-OUT;n:type:ShaderForge.SFN_VertexColor,id:803,x:32040,y:32952,varname:node_803,prsc:2;n:type:ShaderForge.SFN_Lerp,id:1248,x:32773,y:33163,varname:node_1248,prsc:2|A-1862-OUT,B-281-OUT,T-3271-OUT;n:type:ShaderForge.SFN_ScreenPos,id:2179,x:30941,y:32681,varname:node_2179,prsc:2,sctp:0;n:type:ShaderForge.SFN_Length,id:9028,x:31400,y:32707,varname:node_9028,prsc:2|IN-2179-UVOUT;n:type:ShaderForge.SFN_Lerp,id:1862,x:32469,y:32810,varname:node_1862,prsc:2|A-2553-RGB,B-7443-RGB,T-1212-OUT;n:type:ShaderForge.SFN_Color,id:2553,x:31400,y:32366,ptovrint:False,ptlb:Incolor,ptin:_Incolor,varname:node_878,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3333333,c2:0.5686275,c3:0.6039216,c4:1;n:type:ShaderForge.SFN_Color,id:7443,x:31400,y:32539,ptovrint:False,ptlb:OutColor,ptin:_OutColor,varname:node_9470,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1647059,c2:0.1843137,c3:0.282353,c4:1;n:type:ShaderForge.SFN_Ceil,id:868,x:31756,y:32740,varname:node_868,prsc:2|IN-9395-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:9395,x:31602,y:32729,varname:node_9395,prsc:2|IN-9028-OUT,IMIN-912-OUT,IMAX-248-OUT,OMIN-912-OUT,OMAX-5210-OUT;n:type:ShaderForge.SFN_Vector1,id:912,x:31206,y:32812,varname:node_912,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:248,x:31238,y:32869,varname:node_248,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:5210,x:31320,y:32954,ptovrint:False,ptlb:layer,ptin:_layer,varname:node_7570,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:20;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1212,x:31921,y:32775,varname:node_1212,prsc:2|IN-868-OUT,IMIN-912-OUT,IMAX-5210-OUT,OMIN-912-OUT,OMAX-248-OUT;n:type:ShaderForge.SFN_Power,id:3271,x:32293,y:33069,varname:node_3271,prsc:2|VAL-803-A,EXP-2099-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2099,x:32037,y:33153,ptovrint:False,ptlb:power,ptin:_power,varname:node_2099,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ScreenPos,id:4950,x:31034,y:33486,varname:node_4950,prsc:2,sctp:0;n:type:ShaderForge.SFN_RemapRange,id:523,x:31229,y:33486,varname:node_523,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-4950-V;n:type:ShaderForge.SFN_Lerp,id:281,x:31974,y:33481,varname:node_281,prsc:2|A-8981-RGB,B-4881-RGB,T-439-OUT;n:type:ShaderForge.SFN_Power,id:4134,x:31428,y:33486,varname:node_4134,prsc:2|VAL-523-OUT,EXP-9939-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9939,x:31229,y:33695,ptovrint:False,ptlb:screenRampPower,ptin:_screenRampPower,varname:node_9750,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Color,id:4881,x:31645,y:33307,ptovrint:False,ptlb:UpColor,ptin:_UpColor,varname:node_2762,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9676375,c3:0.6862745,c4:1;n:type:ShaderForge.SFN_Color,id:8981,x:31674,y:33686,ptovrint:False,ptlb:DownColor,ptin:_DownColor,varname:node_6277,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3882353,c2:0.02352941,c3:0.2196079,c4:1;n:type:ShaderForge.SFN_Multiply,id:439,x:31627,y:33503,varname:node_439,prsc:2|A-4134-OUT,B-1516-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1516,x:31444,y:33686,ptovrint:False,ptlb:ScreenMulti,ptin:_ScreenMulti,varname:node_2521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:2553-7443-5210-2099-9939-4881-8981-1516;pass:END;sub:END;*/

Shader "Shader Forge/FloorRampOp" {
    Properties {
        _Incolor ("Incolor", Color) = (0.3333333,0.5686275,0.6039216,1)
        _OutColor ("OutColor", Color) = (0.1647059,0.1843137,0.282353,1)
        _layer ("layer", Float ) = 20
        _power ("power", Float ) = 1
        _screenRampPower ("screenRampPower", Float ) = 1
        _UpColor ("UpColor", Color) = (1,0.9676375,0.6862745,1)
        _DownColor ("DownColor", Color) = (0.3882353,0.02352941,0.2196079,1)
        _ScreenMulti ("ScreenMulti", Float ) = 1
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
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Incolor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _OutColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _layer)
                UNITY_DEFINE_INSTANCED_PROP( float, _power)
                UNITY_DEFINE_INSTANCED_PROP( float, _screenRampPower)
                UNITY_DEFINE_INSTANCED_PROP( float4, _UpColor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _DownColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _ScreenMulti)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
////// Lighting:
////// Emissive:
                float4 _Incolor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Incolor );
                float4 _OutColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OutColor );
                float node_912 = 0.0;
                float node_248 = 1.0;
                float _layer_var = UNITY_ACCESS_INSTANCED_PROP( Props, _layer );
                float4 _DownColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DownColor );
                float4 _UpColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UpColor );
                float _screenRampPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _screenRampPower );
                float _ScreenMulti_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScreenMulti );
                float3 node_281 = lerp(_DownColor_var.rgb,_UpColor_var.rgb,(pow(((sceneUVs * 2 - 1).g*0.5+0.5),_screenRampPower_var)*_ScreenMulti_var));
                float _power_var = UNITY_ACCESS_INSTANCED_PROP( Props, _power );
                float3 emissive = lerp(lerp(_Incolor_var.rgb,_OutColor_var.rgb,(node_912 + ( (ceil((node_912 + ( (length((sceneUVs * 2 - 1).rg) - node_912) * (_layer_var - node_912) ) / (node_248 - node_912))) - node_912) * (node_248 - node_912) ) / (_layer_var - node_912))),node_281,pow(i.vertexColor.a,_power_var));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

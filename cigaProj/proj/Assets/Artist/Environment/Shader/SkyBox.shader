// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33433,y:32594,varname:node_3138,prsc:2|emission-4825-OUT;n:type:ShaderForge.SFN_ScreenPos,id:3560,x:32257,y:32774,varname:node_3560,prsc:2,sctp:0;n:type:ShaderForge.SFN_Length,id:5973,x:32716,y:32800,varname:node_5973,prsc:2|IN-3560-UVOUT;n:type:ShaderForge.SFN_Lerp,id:4825,x:33041,y:32675,varname:node_4825,prsc:2|A-878-RGB,B-9470-RGB,T-4521-OUT;n:type:ShaderForge.SFN_Color,id:878,x:32716,y:32459,ptovrint:False,ptlb:Incolor,ptin:_Incolor,varname:node_878,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7169812,c2:0.5715557,c3:0.6833908,c4:1;n:type:ShaderForge.SFN_Color,id:9470,x:32716,y:32632,ptovrint:False,ptlb:OutColor,ptin:_OutColor,varname:node_9470,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2924528,c2:0.1641598,c3:0.2351792,c4:1;n:type:ShaderForge.SFN_Ceil,id:6218,x:33072,y:32833,varname:node_6218,prsc:2|IN-4893-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:4893,x:32918,y:32822,varname:node_4893,prsc:2|IN-5973-OUT,IMIN-6991-OUT,IMAX-2213-OUT,OMIN-6991-OUT,OMAX-7570-OUT;n:type:ShaderForge.SFN_Vector1,id:6991,x:32522,y:32905,varname:node_6991,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2213,x:32554,y:32962,varname:node_2213,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:7570,x:32636,y:33047,ptovrint:False,ptlb:layer,ptin:_layer,varname:node_7570,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:20;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:4521,x:33224,y:32896,varname:node_4521,prsc:2|IN-6218-OUT,IMIN-6991-OUT,IMAX-7570-OUT,OMIN-6991-OUT,OMAX-2213-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:4443,x:32979,y:32508,ptovrint:False,ptlb:node_4443,ptin:_node_4443,varname:node_4443,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;proporder:878-9470-7570;pass:END;sub:END;*/

Shader "Shader Forge/SkyBox" {
    Properties {
        _Incolor ("Incolor", Color) = (0.7169812,0.5715557,0.6833908,1)
        _OutColor ("OutColor", Color) = (0.2924528,0.1641598,0.2351792,1)
        _layer ("layer", Float ) = 20
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
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 projPos : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
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
                float node_6991 = 0.0;
                float node_2213 = 1.0;
                float _layer_var = UNITY_ACCESS_INSTANCED_PROP( Props, _layer );
                float3 emissive = lerp(_Incolor_var.rgb,_OutColor_var.rgb,(node_6991 + ( (ceil((node_6991 + ( (length((sceneUVs * 2 - 1).rg) - node_6991) * (_layer_var - node_6991) ) / (node_2213 - node_6991))) - node_6991) * (node_2213 - node_6991) ) / (_layer_var - node_6991)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

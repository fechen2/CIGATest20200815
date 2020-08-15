// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34208,y:32710,varname:node_3138,prsc:2|normal-2886-RGB,emission-4443-OUT;n:type:ShaderForge.SFN_Tex2d,id:2886,x:32384,y:32662,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_2886,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_LightVector,id:7204,x:31475,y:32905,varname:node_7204,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:5085,x:31475,y:33049,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:3768,x:31667,y:32905,varname:node_3768,prsc:2,dt:0|A-7204-OUT,B-5085-OUT;n:type:ShaderForge.SFN_RemapRange,id:2658,x:31865,y:32905,varname:node_2658,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-3768-OUT;n:type:ShaderForge.SFN_Tex2d,id:8983,x:32071,y:32715,ptovrint:False,ptlb:ColorMap,ptin:_ColorMap,varname:node_8983,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5529,x:32294,y:32905,ptovrint:False,ptlb:RampMap,ptin:_RampMap,varname:node_5529,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5962-OUT;n:type:ShaderForge.SFN_Vector1,id:6039,x:31865,y:33121,varname:node_6039,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:5962,x:32071,y:32905,varname:node_5962,prsc:2|A-2658-OUT,B-6039-OUT;n:type:ShaderForge.SFN_Multiply,id:7807,x:32509,y:32886,varname:node_7807,prsc:2|A-8983-RGB,B-5529-RGB;n:type:ShaderForge.SFN_RgbToHsv,id:3368,x:32718,y:32815,varname:node_3368,prsc:2|IN-7807-OUT;n:type:ShaderForge.SFN_Multiply,id:3416,x:32907,y:32836,varname:node_3416,prsc:2|A-3368-SOUT,B-6557-OUT;n:type:ShaderForge.SFN_HsvToRgb,id:3269,x:33718,y:32847,varname:node_3269,prsc:2|H-3368-HOUT,S-3416-OUT,V-6981-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6557,x:32693,y:33004,ptovrint:False,ptlb:SaturationMulti,ptin:_SaturationMulti,varname:node_6557,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:3069,x:32907,y:32970,varname:node_3069,prsc:2|A-3368-VOUT,B-3705-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3705,x:32693,y:33067,ptovrint:False,ptlb:ValueMulti,ptin:_ValueMulti,varname:_SaturationMulti_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_RemapRange,id:9835,x:33078,y:32970,varname:node_9835,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3069-OUT;n:type:ShaderForge.SFN_Power,id:5308,x:33252,y:32970,varname:node_5308,prsc:2|VAL-9835-OUT,EXP-7017-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7017,x:33090,y:32902,ptovrint:False,ptlb:ValuePower,ptin:_ValuePower,varname:node_7017,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_RemapRange,id:6981,x:33439,y:32970,varname:node_6981,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-5308-OUT;n:type:ShaderForge.SFN_ScreenPos,id:5224,x:32647,y:33439,varname:node_5224,prsc:2,sctp:0;n:type:ShaderForge.SFN_RemapRange,id:2810,x:32842,y:33439,varname:node_2810,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-5224-V;n:type:ShaderForge.SFN_Lerp,id:638,x:33588,y:33434,varname:node_638,prsc:2|A-6277-RGB,B-2762-RGB,T-9915-OUT;n:type:ShaderForge.SFN_RemapRange,id:3155,x:32554,y:33283,varname:node_3155,prsc:2,frmn:-1,frmx:1,tomn:1,tomx:-1|IN-3768-OUT;n:type:ShaderForge.SFN_Clamp01,id:5966,x:32770,y:33283,varname:node_5966,prsc:2|IN-3155-OUT;n:type:ShaderForge.SFN_Lerp,id:4443,x:33999,y:32906,varname:node_4443,prsc:2|A-3269-OUT,B-638-OUT,T-5966-OUT;n:type:ShaderForge.SFN_Power,id:851,x:33041,y:33439,varname:node_851,prsc:2|VAL-2810-OUT,EXP-9750-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9750,x:32842,y:33648,ptovrint:False,ptlb:screenRampPower,ptin:_screenRampPower,varname:node_9750,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Color,id:2762,x:33141,y:33292,ptovrint:False,ptlb:UpColor,ptin:_UpColor,varname:node_2762,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9676375,c3:0.6862745,c4:1;n:type:ShaderForge.SFN_Color,id:6277,x:33286,y:33639,ptovrint:False,ptlb:DownColor,ptin:_DownColor,varname:node_6277,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3882353,c2:0.02352941,c3:0.2196079,c4:1;n:type:ShaderForge.SFN_Multiply,id:9915,x:33240,y:33456,varname:node_9915,prsc:2|A-851-OUT,B-2521-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2521,x:33057,y:33639,ptovrint:False,ptlb:ScreenMulti,ptin:_ScreenMulti,varname:node_2521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:8983-2886-6557-3705-7017-5529-2762-6277-9750-2521;pass:END;sub:END;*/

Shader "Shader Forge/BoxShader" {
    Properties {
        _ColorMap ("ColorMap", 2D) = "white" {}
        _Normal ("Normal", 2D) = "bump" {}
        _SaturationMulti ("SaturationMulti", Float ) = 1
        _ValueMulti ("ValueMulti", Float ) = 1
        _ValuePower ("ValuePower", Float ) = 1
        _RampMap ("RampMap", 2D) = "white" {}
        _UpColor ("UpColor", Color) = (1,0.9676375,0.6862745,1)
        _DownColor ("DownColor", Color) = (0.3882353,0.02352941,0.2196079,1)
        _screenRampPower ("screenRampPower", Float ) = 1
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
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _ColorMap; uniform float4 _ColorMap_ST;
            uniform sampler2D _RampMap; uniform float4 _RampMap_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _SaturationMulti)
                UNITY_DEFINE_INSTANCED_PROP( float, _ValueMulti)
                UNITY_DEFINE_INSTANCED_PROP( float, _ValuePower)
                UNITY_DEFINE_INSTANCED_PROP( float, _screenRampPower)
                UNITY_DEFINE_INSTANCED_PROP( float4, _UpColor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _DownColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _ScreenMulti)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
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
                float4 projPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
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
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float4 _ColorMap_var = tex2D(_ColorMap,TRANSFORM_TEX(i.uv0, _ColorMap));
                float node_3768 = dot(lightDirection,i.normalDir);
                float2 node_5962 = float2((node_3768*0.5+0.5),0.0);
                float4 _RampMap_var = tex2D(_RampMap,TRANSFORM_TEX(node_5962, _RampMap));
                float3 node_7807 = (_ColorMap_var.rgb*_RampMap_var.rgb);
                float4 node_3368_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_3368_p = lerp(float4(float4(node_7807,0.0).zy, node_3368_k.wz), float4(float4(node_7807,0.0).yz, node_3368_k.xy), step(float4(node_7807,0.0).z, float4(node_7807,0.0).y));
                float4 node_3368_q = lerp(float4(node_3368_p.xyw, float4(node_7807,0.0).x), float4(float4(node_7807,0.0).x, node_3368_p.yzx), step(node_3368_p.x, float4(node_7807,0.0).x));
                float node_3368_d = node_3368_q.x - min(node_3368_q.w, node_3368_q.y);
                float node_3368_e = 1.0e-10;
                float3 node_3368 = float3(abs(node_3368_q.z + (node_3368_q.w - node_3368_q.y) / (6.0 * node_3368_d + node_3368_e)), node_3368_d / (node_3368_q.x + node_3368_e), node_3368_q.x);;
                float _SaturationMulti_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SaturationMulti );
                float _ValueMulti_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ValueMulti );
                float _ValuePower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ValuePower );
                float4 _DownColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DownColor );
                float4 _UpColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UpColor );
                float _screenRampPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _screenRampPower );
                float _ScreenMulti_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScreenMulti );
                float3 emissive = lerp((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_3368.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),(node_3368.g*_SaturationMulti_var))*(pow(((node_3368.b*_ValueMulti_var)*2.0+-1.0),_ValuePower_var)*0.5+0.5)),lerp(_DownColor_var.rgb,_UpColor_var.rgb,(pow(((sceneUVs * 2 - 1).g*0.5+0.5),_screenRampPower_var)*_ScreenMulti_var)),saturate((node_3768*-1.0+0.0)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma target 3.0
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _ColorMap; uniform float4 _ColorMap_ST;
            uniform sampler2D _RampMap; uniform float4 _RampMap_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _SaturationMulti)
                UNITY_DEFINE_INSTANCED_PROP( float, _ValueMulti)
                UNITY_DEFINE_INSTANCED_PROP( float, _ValuePower)
                UNITY_DEFINE_INSTANCED_PROP( float, _screenRampPower)
                UNITY_DEFINE_INSTANCED_PROP( float4, _UpColor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _DownColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _ScreenMulti)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
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
                float4 projPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
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
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float3 finalColor = 0;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

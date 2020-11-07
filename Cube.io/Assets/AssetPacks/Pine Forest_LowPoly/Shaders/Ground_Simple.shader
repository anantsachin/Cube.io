// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:0,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32937,y:32730,varname:node_4013,prsc:2|diff-3521-OUT,emission-3369-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:31841,y:32701,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:3369,x:32684,y:32831,varname:node_3369,prsc:2|A-3521-OUT,B-9909-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9909,x:32488,y:33104,ptovrint:False,ptlb:EmissiveAmnt,ptin:_EmissiveAmnt,varname:node_9909,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_TexCoord,id:9942,x:31546,y:32949,varname:node_9942,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:4803,x:31546,y:33154,ptovrint:False,ptlb:Steps,ptin:_Steps,varname:node_4803,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Noise,id:5152,x:31916,y:32974,varname:node_5152,prsc:2|XY-2119-OUT;n:type:ShaderForge.SFN_Posterize,id:2119,x:31756,y:33018,varname:node_2119,prsc:2|IN-9942-UVOUT,STPS-4803-OUT;n:type:ShaderForge.SFN_Multiply,id:408,x:32142,y:32952,varname:node_408,prsc:2|A-1304-RGB,B-5152-OUT,C-1271-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1271,x:31972,y:33183,ptovrint:False,ptlb:NoiseAmnt,ptin:_NoiseAmnt,varname:node_1271,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:3521,x:32423,y:32705,varname:node_3521,prsc:2|A-1304-RGB,B-408-OUT;proporder:1304-9909-4803-1271;pass:END;sub:END;*/

Shader "Shader Forge/Ground_Simple" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _EmissiveAmnt ("EmissiveAmnt", Float ) = 0
        _Steps ("Steps", Float ) = 2
        _NoiseAmnt ("NoiseAmnt", Float ) = 0
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
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _EmissiveAmnt;
            uniform float _Steps;
            uniform float _NoiseAmnt;
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
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float2 node_2119 = floor(i.uv0 * _Steps) / (_Steps - 1);
                float2 node_5152_skew = node_2119 + 0.2127+node_2119.x*0.3713*node_2119.y;
                float2 node_5152_rnd = 4.789*sin(489.123*(node_5152_skew));
                float node_5152 = frac(node_5152_rnd.x*node_5152_rnd.y*(1+node_5152_skew.x));
                float3 node_3521 = (_Color.rgb+(_Color.rgb*node_5152*_NoiseAmnt));
                float3 diffuseColor = node_3521;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (node_3521*_EmissiveAmnt);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

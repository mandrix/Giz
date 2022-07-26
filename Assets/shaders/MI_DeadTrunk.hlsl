#define NUM_TEX_COORD_INTERPOLATORS 1
#define NUM_CUSTOM_VERTEX_INTERPOLATORS 0

struct Input
{
	//float3 Normal;
	float2 uv_MainTex : TEXCOORD0;
	float2 uv2_Material_Texture2D_0 : TEXCOORD1;
	float4 color : COLOR;
	float4 tangent;
	//float4 normal;
	float3 viewDir;
	float4 screenPos;
	float3 worldPos;
	//float3 worldNormal;
	float3 normal2;
};
struct SurfaceOutputStandard
{
	float3 Albedo;		// base (diffuse or specular) color
	float3 Normal;		// tangent space normal, if written
	half3 Emission;
	half Metallic;		// 0=non-metal, 1=metal
	// Smoothness is the user facing name, it should be perceptual smoothness but user should not have to deal with it.
	// Everywhere in the code you meet smoothness it is perceptual smoothness
	half Smoothness;	// 0=rough, 1=smooth
	half Occlusion;		// occlusion (default 1)
	float Alpha;		// alpha for transparencies
};

//#define Texture2D sampler2D
//#define TextureCube samplerCUBE
//#define SamplerState int

#define URP 1
//#define UE5
#define MATERIAL_TANGENTSPACENORMAL 1
//struct Material
//{
	//samplers start
SAMPLER( SamplerState_Linear_Repeat );
SAMPLER( SamplerState_Linear_Clamp );
TEXTURE2D(       Material_Texture2D_0 );
SAMPLER( sampler_Material_Texture2D_0);
TEXTURE2D(       Material_Texture2D_1 );
SAMPLER( sampler_Material_Texture2D_1);
TEXTURE2D(       Material_Texture2D_2 );
SAMPLER( sampler_Material_Texture2D_2);
TEXTURE2D(       Material_Texture2D_3 );
SAMPLER( sampler_Material_Texture2D_3);
TEXTURE2D(       Material_Texture2D_4 );
SAMPLER( sampler_Material_Texture2D_4);
TEXTURE2D(       Material_Texture2D_5 );
SAMPLER( sampler_Material_Texture2D_5);

//};

#ifdef UE5
	#define UE_LWC_RENDER_TILE_SIZE			2097152.0
	#define UE_LWC_RENDER_TILE_SIZE_SQRT	1448.15466
	#define UE_LWC_RENDER_TILE_SIZE_RSQRT	0.000690533954
	#define UE_LWC_RENDER_TILE_SIZE_RCP		4.76837158e-07
	#define UE_LWC_RENDER_TILE_SIZE_FMOD_PI		0.673652053
	#define UE_LWC_RENDER_TILE_SIZE_FMOD_2PI	0.673652053
	#define INVARIANT(X) X
	#define PI 					(3.1415926535897932)

	#include "LargeWorldCoordinates.hlsl"
#endif
struct MaterialStruct
{
	float4 VectorExpressions[48 ];
	float4 ScalarExpressions[41 ];
	float VTPackedPageTableUniform[ 4 ];
};
SamplerState View_MaterialTextureBilinearWrapedSampler;
SamplerState View_MaterialTextureBilinearClampedSampler;
struct ViewStruct
{
	float GameTime;
	float MaterialTextureMipBias;
	float4 PrimitiveSceneData[ 40 ];
	float2 TemporalAAParams;
	float2 ViewRectMin;
	float4 ViewSizeAndInvSize;
	float MaterialTextureDerivativeMultiply;
	uint StateFrameIndexMod8;
};
struct ResolvedViewStruct
{
	#ifdef UE5
		FLWCVector3 WorldCameraOrigin;
	#else
		float3 WorldCameraOrigin;
	#endif
	float4 ScreenPositionScaleBias;
	float4x4 TranslatedWorldToView;
	float4x4 TranslatedWorldToCameraView;
	float4x4 ViewToTranslatedWorld;
	float4x4 CameraViewToTranslatedWorld;
};
struct PrimitiveStruct
{
	float4x4 WorldToLocal;
	float4x4 LocalToWorld;
};

ViewStruct View;
ResolvedViewStruct ResolvedView;
PrimitiveStruct Primitive;
uniform float4 View_BufferSizeAndInvSize;
uniform SamplerState Material_Wrap_WorldGroupSettings;
uniform SamplerState Material_Clamp_WorldGroupSettings;

#include "UnrealCommon.cginc"

MaterialStruct Material;
void InitializeExpressions()
{
	Material.VectorExpressions[0] = float4(0.000000,0.000000,0.000000,0.000000);//SelectionColor
	Material.VectorExpressions[1] = float4(0.000000,0.000000,0.000000,0.000000);//(Unknown)
	Material.VectorExpressions[2] = float4(0.540897,0.663963,0.689236,1.000000);//Color_Tint
	Material.VectorExpressions[3] = float4(0.540897,0.663963,0.689236,0.000000);//(Unknown)
	Material.ScalarExpressions[0] = float4(5.000000,3.000000,10.000000,1.000000);//Details_Scale Moss_Tiling Blend_Normal WorldBlendMax
	Material.ScalarExpressions[1] = float4(1.000000,0.000000,0.500000,1.000000);//Moss_Opacity (Unknown) Albedo_Brightness Moss_Power
	Material.ScalarExpressions[2] = float4(0.500000,0.500000,0.500000,1.350000);//Moss_Edge_Brightness Moss_Darkness_Core Specular Roughness
	Material.ScalarExpressions[3] = float4(1.500000,1.000000,0.000000,0.000000);//Moss_Roughness AO_power (Unknown) (Unknown)
}void CalcPixelMaterialInputs(in out FMaterialPixelParameters Parameters, in out FPixelMaterialInputs PixelMaterialInputs)
{
	float3 WorldNormalCopy = Parameters.WorldNormal;

	// Initial calculations (required for Normal)
	MaterialFloat Local0 = MaterialStoreTexCoordScale(Parameters, Parameters.TexCoords[0].xy, 0);
	MaterialFloat4 Local1 = UnpackNormalMap(Texture2DSampleBias(Material_Texture2D_0, sampler_Material_Texture2D_0,Parameters.TexCoords[0].xy,View.MaterialTextureMipBias));
	MaterialFloat Local2 = MaterialStoreTexSample(Parameters, Local1, 0);
	MaterialFloat3 Local3 = (Local1.rgb * MaterialFloat3(1.00000000,1.00000000,0.80000001));
	MaterialFloat Local4 = (Local3.b + 1.00000000);
	MaterialFloat2 Local5 = (Parameters.TexCoords[0].xy * Material.ScalarExpressions[0].x);
	MaterialFloat Local6 = MaterialStoreTexCoordScale(Parameters, Local5, 0);
	MaterialFloat4 Local7 = UnpackNormalMap(Texture2DSampleBias(Material_Texture2D_1, sampler_Material_Texture2D_1,Local5,View.MaterialTextureMipBias));
	MaterialFloat Local8 = MaterialStoreTexSample(Parameters, Local7, 0);
	MaterialFloat2 Local9 = (Local7.rgb.rg * -1.00000000);
	MaterialFloat Local10 = dot(MaterialFloat3(Local3.rg,Local4), MaterialFloat3(Local9,Local7.rgb.b));
	MaterialFloat3 Local11 = (MaterialFloat3(Local3.rg,Local4) * Local10);
	MaterialFloat3 Local12 = (Local4 * MaterialFloat3(Local9,Local7.rgb.b));
	MaterialFloat3 Local13 = (Local11 - Local12);
	MaterialFloat2 Local14 = (Parameters.TexCoords[0].xy * 8.00000000);
	MaterialFloat2 Local15 = (Local14 * Material.ScalarExpressions[0].y);
	MaterialFloat Local16 = MaterialStoreTexCoordScale(Parameters, Local15, 4);
	MaterialFloat4 Local17 = UnpackNormalMap(Texture2DSampleBias(Material_Texture2D_2, sampler_Material_Texture2D_2,Local15,View.MaterialTextureMipBias));
	MaterialFloat Local18 = MaterialStoreTexSample(Parameters, Local17, 4);
	MaterialFloat3 Local19 = lerp(MaterialFloat3(0.00000000,0.00000000,1.00000000),Local13,MaterialFloat(Material.ScalarExpressions[0].z));
	MaterialFloat3 Local20 = mul(Local19, (MaterialFloat3x3)(Parameters.TangentToWorld));
	MaterialFloat Local21 = dot(Local20, Local20);
	MaterialFloat Local22 = sqrt(Local21);
	MaterialFloat3 Local23 = (Local20 / Local22);
	MaterialFloat Local24 = dot(Local23, MaterialFloat3(0.00000000,0.00000000,1.00000000));
	MaterialFloat Local25 = (1.00000000 + Local24);
	MaterialFloat Local26 = (Local25 * 0.50000000);
	MaterialFloat Local27 = lerp(-4.00000000,Material.ScalarExpressions[0].w,Local26);
	MaterialFloat Local28 = min(max(Local27,0.00000000),1.00000000);
	MaterialFloat Local29 = lerp(0.00000000,Local28,Parameters.VertexColor.a);
	MaterialFloat Local30 = (Local29 * Material.ScalarExpressions[1].x);
	MaterialFloat3 Local31 = lerp(Local13.rgb,Local17.rgb.rgb,MaterialFloat(Local30));

	// The Normal is a special case as it might have its own expressions and also be used to calculate other inputs, so perform the assignment here
	PixelMaterialInputs.Normal = Local31;


	// Note that here MaterialNormal can be in world space or tangent space
	float3 MaterialNormal = GetMaterialNormal(Parameters, PixelMaterialInputs);

#if MATERIAL_TANGENTSPACENORMAL
#if SIMPLE_FORWARD_SHADING
	Parameters.WorldNormal = float3(0, 0, 1);
#endif

#if FEATURE_LEVEL >= FEATURE_LEVEL_SM4
	// Mobile will rely on only the final normalize for performance
	MaterialNormal = normalize(MaterialNormal);
#endif

	// normalizing after the tangent space to world space conversion improves quality with sheared bases (UV layout to WS causes shrearing)
	// use full precision normalize to avoid overflows
	Parameters.WorldNormal = TransformTangentNormalToWorld(Parameters.TangentToWorld, MaterialNormal);

#else //MATERIAL_TANGENTSPACENORMAL

	Parameters.WorldNormal = normalize(MaterialNormal);

#endif //MATERIAL_TANGENTSPACENORMAL

#if MATERIAL_TANGENTSPACENORMAL
	// flip the normal for backfaces being rendered with a two-sided material
	Parameters.WorldNormal *= Parameters.TwoSidedSign;
#endif

	Parameters.ReflectionVector = ReflectionAboutCustomWorldNormal(Parameters, Parameters.WorldNormal, false);

#if !PARTICLE_SPRITE_FACTORY
	Parameters.Particle.MotionBlurFade = 1.0f;
#endif // !PARTICLE_SPRITE_FACTORY

	// Now the rest of the inputs
	MaterialFloat3 Local32 = lerp(MaterialFloat3(0.00000000,0.00000000,0.00000000).rgb,Material.VectorExpressions[1].rgb,MaterialFloat(Material.ScalarExpressions[1].y));
	MaterialFloat Local33 = MaterialStoreTexCoordScale(Parameters, Parameters.TexCoords[0].xy, 2);
	MaterialFloat4 Local34 = ProcessMaterialColorTextureLookup(Texture2DSampleBias(Material_Texture2D_3, sampler_Material_Texture2D_3,Parameters.TexCoords[0].xy,View.MaterialTextureMipBias));
	MaterialFloat Local35 = MaterialStoreTexSample(Parameters, Local34, 2);
	MaterialFloat3 Local36 = (Local34.rgb * Material.ScalarExpressions[1].z);
	MaterialFloat3 Local37 = (Material.VectorExpressions[3].rgb * Local36);
	MaterialFloat3 Local38 = (MaterialFloat3(0.00000000,0.00000000,1.00000000) * MaterialFloat3(MaterialFloat2(1.00000000,1.00000000),Parameters.TwoSidedSign));
	MaterialFloat3 Local39 = mul(Local38, (MaterialFloat3x3)(Parameters.TangentToWorld));
	MaterialFloat Local40 = dot(Parameters.CameraVector, Local39);
	MaterialFloat Local41 = min(max(Local40,0.00000000),1.00000000);
	MaterialFloat Local42 = (1.00000000 - Local41);
	MaterialFloat Local43 = PositiveClampedPow(Local42,Material.ScalarExpressions[1].w);
	MaterialFloat Local44 = (Local43 * Material.ScalarExpressions[2].x);
	MaterialFloat Local45 = (Local41 * Material.ScalarExpressions[2].y);
	MaterialFloat Local46 = (1.00000000 - Local45);
	MaterialFloat Local47 = (Local46 + 0.00000000);
	MaterialFloat Local48 = (Local44 + Local47);
	MaterialFloat Local49 = MaterialStoreTexCoordScale(Parameters, Local15, 3);
	MaterialFloat4 Local50 = ProcessMaterialColorTextureLookup(Texture2DSampleBias(Material_Texture2D_4, sampler_Material_Texture2D_4,Local15,View.MaterialTextureMipBias));
	MaterialFloat Local51 = MaterialStoreTexSample(Parameters, Local50, 3);
	MaterialFloat3 Local52 = (Local48 * Local50.rgb);
	MaterialFloat3 Local53 = lerp(Local37.rgb,Local52.rgb,MaterialFloat(Local30));
	MaterialFloat Local54 = PositiveClampedPow(Local50.r,1.00000000);
	MaterialFloat Local55 = min(max(Local54,0.00000000),0.50000000);
	MaterialFloat3 Local56 = lerp(Material.ScalarExpressions[2].z.rrr,Local55.rrr,MaterialFloat(Local30));
	MaterialFloat Local57 = MaterialStoreTexCoordScale(Parameters, Parameters.TexCoords[0].xy, 1);
	MaterialFloat4 Local58 = ProcessMaterialLinearColorTextureLookup(Texture2DSampleBias(Material_Texture2D_5, sampler_Material_Texture2D_5,Parameters.TexCoords[0].xy,View.MaterialTextureMipBias));
	MaterialFloat Local59 = MaterialStoreTexSample(Parameters, Local58, 1);
	MaterialFloat Local60 = (1.00000000 - Local34.b);
	MaterialFloat Local61 = (Local58.g * Local60);
	MaterialFloat Local62 = (Local61 * Material.ScalarExpressions[2].w);
	MaterialFloat Local63 = lerp((0.00000000 - 0.05000000),(0.05000000 + 1.00000000),Local50.r);
	MaterialFloat Local64 = min(max(Local63,0.00000000),1.00000000);
	MaterialFloat Local65 = min(max(Local64.r,0.00000000),1.00000000);
	MaterialFloat Local66 = lerp(0.50000000,1.00000000,Local65);
	MaterialFloat Local67 = (Local66 * Material.ScalarExpressions[3].x);
	MaterialFloat3 Local68 = lerp(Local62.rrr,Local67.rrr,MaterialFloat(Local30));
	MaterialFloat Local69 = (Local58.r + Material.ScalarExpressions[3].z);
	MaterialFloat3 Local70 = lerp(Local69.rrr,1.00000000.rrr,MaterialFloat(Local30));

	PixelMaterialInputs.EmissiveColor = Local32;
	PixelMaterialInputs.Opacity = 1.00000000;
	PixelMaterialInputs.OpacityMask = 1.00000000;
	PixelMaterialInputs.BaseColor = Local53;
	PixelMaterialInputs.Metallic = 0.00000000.rrr.r;
	PixelMaterialInputs.Specular = Local56;
	PixelMaterialInputs.Roughness = Local68;
	PixelMaterialInputs.Anisotropy = 0.00000000;
	PixelMaterialInputs.Tangent = MaterialFloat3(1.00000000,0.00000000,0.00000000);
	PixelMaterialInputs.Subsurface = 0;
	PixelMaterialInputs.AmbientOcclusion = Local70;
	PixelMaterialInputs.Refraction = 0;
	PixelMaterialInputs.PixelDepthOffset = 0.00000000.rrr.r;
	PixelMaterialInputs.ShadingModel = 1;


#if MATERIAL_USES_ANISOTROPY
	Parameters.WorldTangent = CalculateAnisotropyTangent(Parameters, PixelMaterialInputs);
#else
	Parameters.WorldTangent = 0;
#endif
}

#define UnityObjectToWorldDir TransformObjectToWorld
void SurfaceReplacement( Input In, out SurfaceOutputStandard o )
{
	InitializeExpressions();

	float3 Z3 = float3( 0, 0, 0 );
	float4 Z4 = float4( 0, 0, 0, 0 );

	float3 UnrealWorldPos = float3( In.worldPos.x, In.worldPos.y, In.worldPos.z );

	float3 UnrealNormal = In.normal2;

	View_MaterialTextureBilinearWrapedSampler = SamplerState_Linear_Repeat;
	View_MaterialTextureBilinearClampedSampler = SamplerState_Linear_Clamp;

	Material_Wrap_WorldGroupSettings = SamplerState_Linear_Repeat;
	Material_Clamp_WorldGroupSettings = SamplerState_Linear_Clamp;

	FMaterialPixelParameters Parameters = (FMaterialPixelParameters)0;
#if NUM_TEX_COORD_INTERPOLATORS > 0			
	Parameters.TexCoords[ 0 ] = float2( In.uv_MainTex.x, In.uv_MainTex.y );
#endif
#if NUM_TEX_COORD_INTERPOLATORS > 1
	Parameters.TexCoords[ 1 ] = float2( In.uv2_Material_Texture2D_0.x, In.uv2_Material_Texture2D_0.y );
#endif
#if NUM_TEX_COORD_INTERPOLATORS > 2
	for( int i = 2; i < NUM_TEX_COORD_INTERPOLATORS; i++ )
	{
		Parameters.TexCoords[ i ] = float2( In.uv_MainTex.x, In.uv_MainTex.y );
	}
#endif
	Parameters.VertexColor = In.color;
	Parameters.WorldNormal = UnrealNormal;
	Parameters.ReflectionVector = half3( 0, 0, 1 );
	//Parameters.CameraVector = normalize( _WorldSpaceCameraPos.xyz - UnrealWorldPos.xyz );
	Parameters.CameraVector = mul( ( float3x3 )unity_CameraToWorld, float3( 0, 0, 1 ) ) * -1;
	Parameters.LightVector = half3( 0, 0, 0 );
	float4 screenpos = In.screenPos;
	screenpos /= screenpos.w;
	//screenpos.y = 1 - screenpos.y;
	Parameters.SvPosition = float4( screenpos.x, screenpos.y, 0, 0 );
	Parameters.ScreenPosition = Parameters.SvPosition;

	Parameters.UnMirrored = 1;

	Parameters.TwoSidedSign = 1;


	float3 InWorldNormal = UnrealNormal;
	float4 InTangent = In.tangent;
	float4 tangentWorld = float4( UnityObjectToWorldDir( InTangent.xyz ), InTangent.w );
	tangentWorld.xyz = normalize( tangentWorld.xyz );
	//float3x3 tangentToWorld = CreateTangentToWorldPerVertex( InWorldNormal, tangentWorld.xyz, tangentWorld.w );
	Parameters.TangentToWorld = float3x3( normalize( cross( InWorldNormal, tangentWorld.xyz ) * tangentWorld.w ), tangentWorld.xyz, InWorldNormal );

	//WorldAlignedTexturing in UE relies on the fact that coords there are 100x larger, prepare values for that
	//but watch out for any computation that might get skewed as a side effect
	UnrealWorldPos = ToUnrealPos( UnrealWorldPos );
	Parameters.TangentToWorld[ 0 ] = Parameters.TangentToWorld[ 0 ].xzy;
	Parameters.TangentToWorld[ 1 ] = Parameters.TangentToWorld[ 1 ].xzy;
	Parameters.TangentToWorld[ 2 ] = Parameters.TangentToWorld[ 2 ].xzy;//WorldAligned texturing uses normals that think Z is up

	//Parameters.TangentToWorld = half3x3( float3( 1, 1, 1 ), float3( 1, 1, 1 ), UnrealNormal.xyz );
	Parameters.AbsoluteWorldPosition = UnrealWorldPos;
	Parameters.WorldPosition_CamRelative = UnrealWorldPos;
	Parameters.WorldPosition_NoOffsets = UnrealWorldPos;

	Parameters.WorldPosition_NoOffsets_CamRelative = Parameters.WorldPosition_CamRelative;
	Parameters.LightingPositionOffset = float3( 0, 0, 0 );

	Parameters.AOMaterialMask = 0;

	Parameters.Particle.RelativeTime = 0;
	Parameters.Particle.MotionBlurFade;
	Parameters.Particle.Random = 0;
	Parameters.Particle.Velocity = half4( 1, 1, 1, 1 );
	Parameters.Particle.Color = half4( 1, 1, 1, 1 );
	Parameters.Particle.TranslatedWorldPositionAndSize = float4( UnrealWorldPos, 0 );
	Parameters.Particle.MacroUV = half4( 0, 0, 1, 1 );
	Parameters.Particle.DynamicParameter = half4( 0, 0, 0, 0 );
	Parameters.Particle.LocalToWorld = float4x4( Z4, Z4, Z4, Z4 );
	Parameters.Particle.Size = float2( 1, 1 );
	Parameters.TexCoordScalesParams = float2( 0, 0 );
	Parameters.PrimitiveId = 0;
	Parameters.VirtualTextureFeedback = 0;

	FPixelMaterialInputs PixelMaterialInputs = (FPixelMaterialInputs)0;
	PixelMaterialInputs.Normal = float3( 0, 0, 1 );
	PixelMaterialInputs.ShadingModel = 0;
	PixelMaterialInputs.FrontMaterial = 0;

	//Extra
	View.GameTime = _Time.y;// _Time is (t/20, t, t*2, t*3)
	View.MaterialTextureMipBias = 0.0;
	View.TemporalAAParams = float2( 0, 0 );
	View.ViewRectMin = float2( 0, 0 );
	View.ViewSizeAndInvSize = View_BufferSizeAndInvSize;
	View.MaterialTextureDerivativeMultiply = 1.0f;
	View.StateFrameIndexMod8 = 0;

	for( int i2 = 0; i2 < 40; i2++ )
		View.PrimitiveSceneData[ i2 ] = float4( 0, 0, 0, 0 );

	uint PrimitiveBaseOffset = Parameters.PrimitiveId * PRIMITIVE_SCENE_DATA_STRIDE;
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 0 ] = unity_ObjectToWorld[ 0 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 1 ] = unity_ObjectToWorld[ 1 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 2 ] = unity_ObjectToWorld[ 2 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 3 ] = unity_ObjectToWorld[ 3 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 6 ] = unity_WorldToObject[ 0 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 7 ] = unity_WorldToObject[ 1 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 8 ] = unity_WorldToObject[ 2 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 9 ] = unity_WorldToObject[ 3 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 10 ] = unity_WorldToObject[ 0 ];//PreviousLocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 11 ] = unity_WorldToObject[ 1 ];//PreviousLocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 12 ] = unity_WorldToObject[ 2 ];//PreviousLocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 13 ] = unity_WorldToObject[ 3 ];//PreviousLocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 19 ] = float4( 1, 1, 1, 0 );//ObjectBounds

	#ifdef UE5
		ResolvedView.WorldCameraOrigin = LWCPromote( ToUnrealPos( _WorldSpaceCameraPos.xyz ) );
	#else
		ResolvedView.WorldCameraOrigin = ToUnrealPos( _WorldSpaceCameraPos.xyz );
	#endif
	ResolvedView.ScreenPositionScaleBias = float4( 1, 1, 0, 0 );
	ResolvedView.TranslatedWorldToView = unity_MatrixV;
	ResolvedView.TranslatedWorldToCameraView = unity_MatrixV;
	ResolvedView.ViewToTranslatedWorld = unity_MatrixInvV;
	ResolvedView.CameraViewToTranslatedWorld = unity_MatrixInvV;
	Primitive.WorldToLocal = unity_WorldToObject;
	Primitive.LocalToWorld = unity_ObjectToWorld;
	CalcPixelMaterialInputs( Parameters, PixelMaterialInputs );

	#define HAS_WORLDSPACE_NORMAL 0
	#if HAS_WORLDSPACE_NORMAL
		PixelMaterialInputs.Normal = mul( PixelMaterialInputs.Normal, (MaterialFloat3x3)( transpose( Parameters.TangentToWorld ) ) );
	#endif

	o.Albedo = PixelMaterialInputs.BaseColor.rgb;
	o.Alpha = PixelMaterialInputs.Opacity;
	//if( PixelMaterialInputs.OpacityMask < 0.333 ) discard;

	o.Metallic = PixelMaterialInputs.Metallic;
	o.Smoothness = 1.0 - PixelMaterialInputs.Roughness;
	o.Normal = normalize( PixelMaterialInputs.Normal );
	o.Emission = PixelMaterialInputs.EmissiveColor.rgb;
	o.Occlusion = PixelMaterialInputs.AmbientOcclusion;

	//BLEND_ADDITIVE o.Alpha = ( o.Emission.r + o.Emission.g + o.Emission.b ) / 3;
}
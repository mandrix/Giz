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
	float4 VectorExpressions[178 ];
	float4 ScalarExpressions[101 ];
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
	Material.VectorExpressions[2] = float4(0.885056,0.947917,0.574346,1.000000);//albedo_color
	Material.VectorExpressions[3] = float4(0.885056,0.947917,0.574346,0.000000);//(Unknown)
	Material.VectorExpressions[4] = float4(1.000000,0.000000,0.000000,1.000000);//Wind_WPO
	Material.VectorExpressions[5] = float4(1.000000,0.000000,0.000000,0.000000);//(Unknown)
	Material.VectorExpressions[6] = float4(1.000000,0.000000,-10.000000,0.000000);//(Unknown)
	Material.VectorExpressions[7] = float4(1.000000,0.000000,0.000000,1.000000);//Normalized Wind Direction X Axis
	Material.VectorExpressions[8] = float4(9.000000,2.000000,1.000000,0.000000);//(Unknown)
	Material.VectorExpressions[9] = float4(1.000000,0.000000,0.000000,0.000000);//(Unknown)
	Material.VectorExpressions[10] = float4(0.000000,1.000000,0.000000,1.000000);//Normalized Wind Direction Y Axis
	Material.VectorExpressions[11] = float4(0.000000,1.000000,0.000000,0.000000);//(Unknown)
	Material.VectorExpressions[12] = float4(-1.250000,-0.444000,-0.444000,-0.444000);//(Unknown)
	Material.VectorExpressions[13] = float4(0.010000,0.030000,0.030000,0.030000);//(Unknown)
	Material.VectorExpressions[14] = float4(-1.250000,-0.444000,-0.444000,-0.444000);//(Unknown)
	Material.VectorExpressions[15] = float4(0.589717,0.807292,0.194798,1.000000);//Translucency_Color
	Material.VectorExpressions[16] = float4(0.589717,0.807292,0.194798,0.000000);//(Unknown)
	Material.ScalarExpressions[0] = float4(1.000000,0.000000,0.200000,0.250000);//Normal_strengh (Unknown) color_variation desaturate
	Material.ScalarExpressions[1] = float4(1.000000,0.220000,1.000000,1.000000);//Brightness Specular Roughness Translucency_Opacity
	Material.ScalarExpressions[2] = float4(0.009174,0.010000,1.000000,0.030000);//Max Rotation 1 Wind Speed Local Wind Scale 1 Wind Horizontal Speed 
	Material.ScalarExpressions[3] = float4(9.000000,0.300000,0.000000,-0.444000);//(Unknown) Wind Gust World Scale Wind Angle Offset 1 Wind 1 Shelter Dot Product Modulation 
	Material.ScalarExpressions[4] = float4(-1.250000,-1.250000,-0.444000,2.000000);//Wind 1 Shelter Dot Product Bias  (Unknown) (Unknown) Dampening Radius Multiplier 1
	Material.ScalarExpressions[5] = float4(200.000000,0.250000,0.000000,1.000000);//Wind 1 Random Rotation Change Rate Wind 1 Random Rotation Influence Wind 1's Angle Contribution to Wind 2 Local Wind Scale 2
	Material.ScalarExpressions[6] = float4(0.010000,0.000000,0.050000,-0.444000);//(Unknown) Wind Angle offset 2 Max Rotation 2 Wind 2 Shelter Dot Product Modulation 
	Material.ScalarExpressions[7] = float4(-1.250000,-1.250000,-0.444000,0.000000);//Wind 2 Shelter Dot Product Bias  (Unknown) (Unknown) Dampening Radius Multiplier 2
	Material.ScalarExpressions[8] = float4(200.000000,0.250000,131.000000,131.000000);//Wind 2 Random Rotation Change Rate Wind 2 Random Rotation Influence Sphere_Mask Radius (Unknown)
	Material.ScalarExpressions[9] = float4(0.007634,32.000000,3.000000,0.000000);//(Unknown) Object_Scale translucency_blend_albedo __SubsurfaceProfile
}struct MaterialCollection0Type
{
	float4 Vectors[1];
};
MaterialCollection0Type MaterialCollection0;
void Initialize_MaterialCollection0()
{
	MaterialCollection0.Vectors[0] = float4(0.000000,0.000000,0.000000,0.000000);//PlayerLocation
}
struct MaterialCollection1Type
{
	float4 Vectors[3];
};
MaterialCollection1Type MaterialCollection1;
void Initialize_MaterialCollection1()
{
	MaterialCollection1.Vectors[0] = float4(0.100000,0.250000,2.000000,1.000000);//MorphAmount,Wind_Intensity,Wind_Weight,Wind_Speed
	MaterialCollection1.Vectors[1] = float4(0.000000,0.000000,0.000000,0.000000);//PlayersFootLocation
	MaterialCollection1.Vectors[2] = float4(1.000000,0.000000,0.000000,1.000000);//WindDirection RGB Speed A
}
void CalcPixelMaterialInputs(in out FMaterialPixelParameters Parameters, in out FPixelMaterialInputs PixelMaterialInputs)
{
	float3 WorldNormalCopy = Parameters.WorldNormal;

	// Initial calculations (required for Normal)
	MaterialFloat Local0 = MaterialStoreTexCoordScale(Parameters, Parameters.TexCoords[0].xy, 7);
	MaterialFloat4 Local1 = UnpackNormalMap(Texture2DSampleBias(Material_Texture2D_0, sampler_Material_Texture2D_0,Parameters.TexCoords[0].xy,View.MaterialTextureMipBias));
	MaterialFloat Local2 = MaterialStoreTexSample(Parameters, Local1, 7);
	MaterialFloat Local3 = (Local1.r * Material.ScalarExpressions[0].x);
	MaterialFloat Local4 = (Local1.g * Material.ScalarExpressions[0].x);
	MaterialFloat3 Local5 = (MaterialFloat3(MaterialFloat2(Local3,Local4),Local1.b) * MaterialFloat3(1.00000000,1.00000000,0.50000000));

	// The Normal is a special case as it might have its own expressions and also be used to calculate other inputs, so perform the assignment here
	PixelMaterialInputs.Normal = Local5;


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
	MaterialFloat3 Local6 = lerp(MaterialFloat3(0.00000000,0.00000000,0.00000000),Material.VectorExpressions[1].rgb,MaterialFloat(Material.ScalarExpressions[0].y));
	MaterialFloat3 Local7 = (MaterialFloat3(100.00000000,10.00000000,1.00000000) * GetPerInstanceRandom(Parameters));
	MaterialFloat3 Local8 = (GetObjectWorldPosition(Parameters) * 0.01000000);
	MaterialFloat3 Local9 = (Local7 + Local8);
	MaterialFloat3 Local10 = frac(Local9);
	MaterialFloat Local11 = dot(Local10.rg, Local10.gb);
	MaterialFloat Local12 = (-0.50000000 + Local11);
	MaterialFloat Local13 = (Local12 * 2.00000000);
	MaterialFloat Local14 = (Material.ScalarExpressions[0].z * Local13);
	MaterialFloat Local15 = dot(Local10, Local10);
	MaterialFloat Local16 = sqrt(Local15);
	MaterialFloat3 Local17 = (Local10 / Local16);
	MaterialFloat3 Local18 = (Local14 * Local17);
	MaterialFloat3 Local19 = (Local18 + Material.VectorExpressions[3].rgb);
	MaterialFloat Local20 = MaterialStoreTexCoordScale(Parameters, Parameters.TexCoords[0].xy, 0);
	MaterialFloat4 Local21 = ProcessMaterialColorTextureLookup(Texture2DSampleBias(Material_Texture2D_1, sampler_Material_Texture2D_1,Parameters.TexCoords[0].xy,View.MaterialTextureMipBias));
	MaterialFloat Local22 = MaterialStoreTexSample(Parameters, Local21, 0);
	MaterialFloat3 Local23 = (Local19 * Local21.rgb);
	MaterialFloat Local24 = dot(Local23, MaterialFloat3(0.30000001,0.58999997,0.11000000));
	MaterialFloat3 Local25 = lerp(Local23,MaterialFloat3(Local24,Local24,Local24),MaterialFloat(Material.ScalarExpressions[0].w));
	MaterialFloat3 Local26 = (Local25 * Material.ScalarExpressions[1].x);
	MaterialFloat Local27 = MaterialStoreTexCoordScale(Parameters, Parameters.TexCoords[0].xy, 1);
	MaterialFloat4 Local28 = ProcessMaterialLinearColorTextureLookup(Texture2DSampleBias(Material_Texture2D_2, sampler_Material_Texture2D_2,Parameters.TexCoords[0].xy,View.MaterialTextureMipBias));
	MaterialFloat Local29 = MaterialStoreTexSample(Parameters, Local28, 1);
	MaterialFloat Local30 = (Local28.g * Material.ScalarExpressions[1].z);
	MaterialFloat Local31 = (1.00000000 - Parameters.VertexColor.r);
	MaterialFloat Local32 = min(max(Local31,0.00000000),1.00000000);
	MaterialFloat Local33 = lerp(Local30,1.00000000,Local32);
	MaterialFloat Local34 = (Material.ScalarExpressions[1].w * Local28.b);
	MaterialFloat3 Local296 = (Local21.rgb * Local28.b);
	MaterialFloat3 Local297 = (Local296 * Material.VectorExpressions[16].rgb);
	MaterialFloat3 Local298 = (Local297 * Material.ScalarExpressions[9].z);

	PixelMaterialInputs.EmissiveColor = Local6;
	PixelMaterialInputs.Opacity = Local34;
	PixelMaterialInputs.OpacityMask = Local21.a;
	PixelMaterialInputs.BaseColor = Local26;
	PixelMaterialInputs.Metallic = 0.00000000;
	PixelMaterialInputs.Specular = Material.ScalarExpressions[1].y;
	PixelMaterialInputs.Roughness = Local33;
	PixelMaterialInputs.Anisotropy = 0.00000000;
	PixelMaterialInputs.Tangent = MaterialFloat3(1.00000000,0.00000000,0.00000000);
	PixelMaterialInputs.Subsurface = MaterialFloat4(Local298,Material.ScalarExpressions[9].w);
	PixelMaterialInputs.AmbientOcclusion = Local28.r;
	PixelMaterialInputs.Refraction = 0;
	PixelMaterialInputs.PixelDepthOffset = 0.00000000;
	PixelMaterialInputs.ShadingModel = 6;


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
	Initialize_MaterialCollection0();

	Initialize_MaterialCollection1();


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

	#define HAS_WORLDSPACE_NORMAL 1
	#if HAS_WORLDSPACE_NORMAL
		PixelMaterialInputs.Normal = mul( PixelMaterialInputs.Normal, (MaterialFloat3x3)( transpose( Parameters.TangentToWorld ) ) );
	#endif

	o.Albedo = PixelMaterialInputs.BaseColor.rgb;
	o.Alpha = PixelMaterialInputs.Opacity;
	if( PixelMaterialInputs.OpacityMask < 0.333 ) discard;

	o.Metallic = PixelMaterialInputs.Metallic;
	o.Smoothness = 1.0 - PixelMaterialInputs.Roughness;
	o.Normal = normalize( PixelMaterialInputs.Normal );
	o.Emission = PixelMaterialInputs.EmissiveColor.rgb;
	o.Occlusion = PixelMaterialInputs.AmbientOcclusion;

	//BLEND_ADDITIVE o.Alpha = ( o.Emission.r + o.Emission.g + o.Emission.b ) / 3;
}
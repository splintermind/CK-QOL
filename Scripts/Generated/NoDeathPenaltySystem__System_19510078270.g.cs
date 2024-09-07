#pragma warning disable 0219
#line 1 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL-Collection//NoDeathPenaltySystem__System_19510078270.g.cs"
using CK_QOL_Collection.Core.Configuration;
using Inventory;
using Unity.Burst;
using Unity.Entities;
using Unity.NetCode;
namespace CK_QOL_Collection.Features.NoDeathPenalty.Systems
{
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    public partial class NoDeathPenaltySystem
    {
        [global::Unity.Entities.DOTSCompilerPatchedMethod("OnUpdate_T0")]
		void __OnUpdate_450AADF4()
		{
			#line 37 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/NoDeathPenalty/Systems/NoDeathPenaltySystem.cs"
			if (!ConfigurationManager.IsModEnabled)
			#line 38 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/NoDeathPenalty/Systems/NoDeathPenaltySystem.cs"
			{
				#line 39 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/NoDeathPenalty/Systems/NoDeathPenaltySystem.cs"
				return;
			}
			#line 42 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/NoDeathPenalty/Systems/NoDeathPenaltySystem.cs"

			var initialMoveInventoryFromLookup = GetComponentLookup<InitialMoveInventoryFromCD>();
			#line 44 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/NoDeathPenalty/Systems/NoDeathPenaltySystem.cs"

			NoDeathPenaltySystem_6C1B8903_LambdaJob_0_Execute(initialMoveInventoryFromLookup);
			#line 59 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/NoDeathPenalty/Systems/NoDeathPenaltySystem.cs"

			base.OnUpdate();
#line hidden
		}

        #line 36 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL-Collection//NoDeathPenaltySystem__System_19510078270.g.cs"
        [global::Unity.Burst.NoAlias]
        [global::Unity.Burst.BurstCompile]
        struct NoDeathPenaltySystem_6C1B8903_LambdaJob_0_Job : global::Unity.Entities.IJobChunk
        {
            public global::Unity.Entities.ComponentLookup<global::InitialMoveInventoryFromCD> initialMoveInventoryFromLookup;
            [global::Unity.Collections.ReadOnly] public global::Unity.Entities.EntityTypeHandle __entityTypeHandle;
            
            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            void OriginalLambdaBody(global::Unity.Entities.Entity entity)
            {
#line 47 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/NoDeathPenalty/Systems/NoDeathPenaltySystem.cs"
initialMoveInventoryFromLookup.SetComponentEnabled(entity, false);
#line 49 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/NoDeathPenalty/Systems/NoDeathPenaltySystem.cs"
var initialMoveInventoryFromCD = initialMoveInventoryFromLookup.GetRefRW(entity).ValueRW;
#line 50 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/NoDeathPenalty/Systems/NoDeathPenaltySystem.cs"
if (initialMoveInventoryFromCD.entityFrom == Entity.Null)
				{
#line 52 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/NoDeathPenalty/Systems/NoDeathPenaltySystem.cs"
return;
				}
#line 56 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/NoDeathPenalty/Systems/NoDeathPenaltySystem.cs"
initialMoveInventoryFromCD.entityFrom = Entity.Null;
			}
            #line 60 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL-Collection//NoDeathPenaltySystem__System_19510078270.g.cs"
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            public void Execute(in global::Unity.Entities.ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in global::Unity.Burst.Intrinsics.v128 chunkEnabledMask)
            {
                #line 64 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL-Collection//NoDeathPenaltySystem__System_19510078270.g.cs"
                var __entityArrayPtr = global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
                int chunkEntityCount = chunk.Count;
                if (!useEnabledMask)
                {
                    for(var entityIndex = 0; entityIndex < chunkEntityCount; ++entityIndex)
                    {
                        OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(__entityArrayPtr, entityIndex));
                    }
                }
                else
                {
                    int edgeCount = global::Unity.Mathematics.math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + global::Unity.Mathematics.math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1;
                    bool useRanges = edgeCount <= 4;
                    if (useRanges)
                    {
                        int entityIndex = 0;
                        int batchEndIndex = 0;
                        while (global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, batchEndIndex, out entityIndex, out batchEndIndex))
                        {
                            while (entityIndex < batchEndIndex)
                            {
                                OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(__entityArrayPtr, entityIndex));
                                entityIndex++;
                            }
                        }
                    }
                    else
                    {
                        ulong mask64 = chunkEnabledMask.ULong0;
                        int count = global::Unity.Mathematics.math.min(64, chunkEntityCount);
                        for (var entityIndex = 0; entityIndex < count; ++entityIndex)
                        {
                            if ((mask64 & 1) != 0)
                            {
                                OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(__entityArrayPtr, entityIndex));
                            }
                            mask64 >>= 1;
                        }
                        mask64 = chunkEnabledMask.ULong1;
                        for (var entityIndex = 64; entityIndex < chunkEntityCount; ++entityIndex)
                        {
                            if ((mask64 & 1) != 0)
                            {
                                OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(__entityArrayPtr, entityIndex));
                            }
                            mask64 >>= 1;
                        }
                    }
                }
            }
        }
        void NoDeathPenaltySystem_6C1B8903_LambdaJob_0_Execute(global::Unity.Entities.ComponentLookup<global::InitialMoveInventoryFromCD> initialMoveInventoryFromLookup)
        {
            __TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
            var __job = new NoDeathPenaltySystem_6C1B8903_LambdaJob_0_Job
            {
                initialMoveInventoryFromLookup = initialMoveInventoryFromLookup,
                __entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle
            };
            
            this.CheckedStateRef.Dependency = global::Unity.Entities.Internal.InternalCompilerInterface.JobChunkInterface.Schedule(__job, __query_1451888473_0, this.CheckedStateRef.Dependency);
        }
        
        TypeHandle __TypeHandle;
        global::Unity.Entities.EntityQuery __query_1451888473_0;
        struct TypeHandle
        {
            [global::Unity.Collections.ReadOnly] public global::Unity.Entities.EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            public void __AssignHandles(ref global::Unity.Entities.SystemState state)
            {
                __Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
            }
            
        }
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void __AssignQueries(ref global::Unity.Entities.SystemState state)
        {
            var entityQueryBuilder = new global::Unity.Entities.EntityQueryBuilder(global::Unity.Collections.Allocator.Temp);
            __query_1451888473_0 = 
                entityQueryBuilder
                    .WithAll<global::InitialMoveInventoryFromCD>()
                    .Build(ref state);
            entityQueryBuilder.Reset();
            entityQueryBuilder.Dispose();
        }
        
        protected override void OnCreateForCompiler()
        {
            base.OnCreateForCompiler();
            __AssignQueries(ref this.CheckedStateRef);
            __TypeHandle.__AssignHandles(ref this.CheckedStateRef);
        }
    }
}

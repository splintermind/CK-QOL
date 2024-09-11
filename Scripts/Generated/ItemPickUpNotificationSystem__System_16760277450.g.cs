#pragma warning disable 0219
#line 1 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL//ItemPickUpNotificationSystem__System_16760277450.g.cs"
using CK_QOL.Core.Helpers;
using Inventory;
using Unity.Collections;
using Unity.Entities;
namespace CK_QOL.Features.ItemPickUpNotifier.Systems
{
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    public partial class ItemPickUpNotificationSystem
    {
        [global::Unity.Entities.DOTSCompilerPatchedMethod("OnUpdate_T0")]

		void __OnUpdate_450AADF4()
		{
			#line 74 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
			if (isServer || !ItemPickUpNotifier.Instance.IsEnabled)
			#line 75 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
			{
				#line 76 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
				return;
			}
			#line 79 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

			if (_localPlayerEntity == Entity.Null)
			#line 80 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
			{
				#line 81 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
				var playerController = Manager.main?.player;
				#line 82 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
				if (playerController?.isLocal ?? false)
				#line 83 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
				{
					#line 84 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
					_localPlayerEntity = playerController.entity;
				}
				else
				#line 87 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
				{
					#line 88 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
					return;
				}
			}
			#line 92 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

			var containedObjectsBufferLookup = GetBufferLookup<ContainedObjectsBuffer>(true);
			#line 93 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
			var cachedPickups = _cachedPickups;
			#line 94 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
			var localPlayerEntity = _localPlayerEntity;
			#line 96 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

			ItemPickUpNotificationSystem_7CD61C77_LambdaJob_0_Execute(containedObjectsBufferLookup, cachedPickups, localPlayerEntity);
			#line 145 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

			_timeSinceLastLog += this.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
			#line 147 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

			if (_timeSinceLastLog >= ItemPickUpNotifier.Instance.AggregateDelay)
			#line 148 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
			{
				#line 149 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
				CompleteDependency();
				#line 151 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

				foreach (var item in _cachedPickups)
				#line 152 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
				{
					#line 153 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
					var (amount, rarity, text) = item.Value;
					#line 154 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
					TextHelper.DisplayText($"{text} x{amount}", rarity);
				}
				#line 157 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

				_cachedPickups.Clear();
				#line 158 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
				_timeSinceLastLog = 0f;
			}
			#line 161 "D:/CK-ModSDK/Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

			base.OnUpdate();
#line hidden
		}

        #line 87 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL//ItemPickUpNotificationSystem__System_16760277450.g.cs"
        struct ItemPickUpNotificationSystem_7CD61C77_LambdaJob_0_Job : global::Unity.Entities.IJobChunk
        {
            public global::Unity.Entities.BufferLookup<global::ContainedObjectsBuffer> containedObjectsBufferLookup;
            public global::Unity.Collections.NativeParallelHashMap<int, (int totalAmount, global::Rarity rarity, global::Unity.Collections.FixedString64Bytes displayName)> cachedPickups;
            public global::Unity.Entities.Entity localPlayerEntity;
            [global::Unity.Collections.ReadOnly] public global::Unity.Entities.EntityTypeHandle ___TypeHandle;
            public BufferTypeHandle<Inventory.InventoryChangeBuffer> __inventoryChangesTypeHandle;
            
            void OriginalLambdaBody(global::Unity.Entities.Entity _, DynamicBuffer<Inventory.InventoryChangeBuffer> inventoryChanges)
            {
#line 101 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
foreach (var change in inventoryChanges)
					{
#line 103 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (change.inventoryChangeData.inventoryAction != InventoryAction.MoveOrDropAllItems)
						{
#line 105 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
continue;
						}
#line 108 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (change.playerEntity != localPlayerEntity)
						{
#line 110 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
continue;
						}
#line 113 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var sourceInventory = change.inventoryChangeData.inventory1;
#line 114 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (!containedObjectsBufferLookup.HasBuffer(sourceInventory))
						{
#line 116 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
continue;
						}
#line 119 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var itemsBuffer = containedObjectsBufferLookup[sourceInventory];
#line 120 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
foreach (var item in itemsBuffer)
						{
#line 122 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (item.objectID is ObjectID.None or ObjectID.CattleCage)
							{
#line 124 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
continue;
							}
#line 127 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var objectIdHash = item.objectData.objectID.GetHashCode();
#line 128 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (cachedPickups.TryGetValue(objectIdHash, out var existing))
							{
#line 130 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
cachedPickups[objectIdHash] = (existing.totalAmount + item.amount, existing.rarity, existing.displayName);
							}
							else
							{
#line 134 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var text = PlayerController.GetObjectName(item, true).text;
#line 135 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var rarity = PugDatabase.GetObjectInfo(item.objectData.objectID).rarity;
#line 137 "D:\CK-ModSDK\Assets/CK-QOL/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
cachedPickups[objectIdHash] = (item.amount, rarity, text);
							}
						}
					}
				}
            #line 152 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL//ItemPickUpNotificationSystem__System_16760277450.g.cs"
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            public void Execute(in global::Unity.Entities.ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in global::Unity.Burst.Intrinsics.v128 chunkEnabledMask)
            {
                #line 156 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL//ItemPickUpNotificationSystem__System_16760277450.g.cs"
                var ___ArrayPtr = global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, ___TypeHandle);
                var inventoryChangesAccessor = chunk.GetBufferAccessor(ref __inventoryChangesTypeHandle);
                int chunkEntityCount = chunk.Count;
                if (!useEnabledMask)
                {
                    for(var entityIndex = 0; entityIndex < chunkEntityCount; ++entityIndex)
                    {
                        OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(___ArrayPtr, entityIndex), inventoryChangesAccessor[entityIndex]);
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
                                OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(___ArrayPtr, entityIndex), inventoryChangesAccessor[entityIndex]);
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
                                OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(___ArrayPtr, entityIndex), inventoryChangesAccessor[entityIndex]);
                            }
                            mask64 >>= 1;
                        }
                        mask64 = chunkEnabledMask.ULong1;
                        for (var entityIndex = 64; entityIndex < chunkEntityCount; ++entityIndex)
                        {
                            if ((mask64 & 1) != 0)
                            {
                                OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(___ArrayPtr, entityIndex), inventoryChangesAccessor[entityIndex]);
                            }
                            mask64 >>= 1;
                        }
                    }
                }
            }
        }
        void ItemPickUpNotificationSystem_7CD61C77_LambdaJob_0_Execute(global::Unity.Entities.BufferLookup<global::ContainedObjectsBuffer> containedObjectsBufferLookup,global::Unity.Collections.NativeParallelHashMap<int, (int totalAmount, global::Rarity rarity, global::Unity.Collections.FixedString64Bytes displayName)> cachedPickups,global::Unity.Entities.Entity localPlayerEntity)
        {
            __TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
            __TypeHandle.__Inventory_InventoryChangeBuffer_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
            var __job = new ItemPickUpNotificationSystem_7CD61C77_LambdaJob_0_Job
            {
                containedObjectsBufferLookup = containedObjectsBufferLookup,
                cachedPickups = cachedPickups,
                localPlayerEntity = localPlayerEntity,
                ___TypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
                __inventoryChangesTypeHandle = __TypeHandle.__Inventory_InventoryChangeBuffer_RO_BufferTypeHandle
            };
            
            this.CheckedStateRef.Dependency = global::Unity.Entities.Internal.InternalCompilerInterface.JobChunkInterface.ScheduleParallel(__job, __query_911957037_0, this.CheckedStateRef.Dependency);
        }
        
        TypeHandle __TypeHandle;
        global::Unity.Entities.EntityQuery __query_911957037_0;
        struct TypeHandle
        {
            [global::Unity.Collections.ReadOnly] public global::Unity.Entities.EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
            [global::Unity.Collections.ReadOnly] public Unity.Entities.BufferTypeHandle<global::Inventory.InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RO_BufferTypeHandle;
            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            public void __AssignHandles(ref global::Unity.Entities.SystemState state)
            {
                __Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
                __Inventory_InventoryChangeBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<global::Inventory.InventoryChangeBuffer>(true);
            }
            
        }
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void __AssignQueries(ref global::Unity.Entities.SystemState state)
        {
            var entityQueryBuilder = new global::Unity.Entities.EntityQueryBuilder(global::Unity.Collections.Allocator.Temp);
            __query_911957037_0 = 
                entityQueryBuilder
                    .WithNone<global::EntityDestroyedCD>()
                    .WithNone<global::CattleCD>()
                    .WithAll<global::Inventory.InventoryChangeBuffer>()
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

#pragma warning disable 0219
#line 1 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL-Collection//ItemPickUpNotificationSystem__System_19055065920.g.cs"
using CK_QOL_Collection.Core.Feature;
using CK_QOL_Collection.Core.Helpers;
using Inventory;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
namespace CK_QOL_Collection.Features.ItemPickUpNotifier.Systems
{
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    public partial class ItemPickUpNotificationSystem
    {
        [global::Unity.Entities.DOTSCompilerPatchedMethod("OnUpdate_T0")]

        
        
        
        void __OnUpdate_450AADF4()
        {
            #line 55 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
            if (!_isEnabled)
            #line 56 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
            {
                #line 57 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                return;
            }
            #line 60 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            if (_localPlayerEntity == Entity.Null)
            #line 61 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
            {
                #line 62 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                _localPlayerEntity = Manager.main?.player?.isLocal ?? false
                    ? Manager.main?.player?.entity ?? Entity.Null
                    : Entity.Null;
            }
            #line 67 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            if (_localPlayerEntity == Entity.Null)
            #line 68 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
            {
                #line 69 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                return;
            }
            #line 72 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            var containedObjectsBufferLookup = GetBufferLookup<ContainedObjectsBuffer>(true);
            #line 73 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
            var cachedPickups = _cachedPickups;
            #line 74 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
            var localPlayerEntity = _localPlayerEntity;
            #line 76 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            ItemPickUpNotificationSystem_5E188CCE_LambdaJob_0_Execute(containedObjectsBufferLookup, cachedPickups, localPlayerEntity);
            #line 124 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            _timeSinceLastLog += this.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
            #line 126 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            if (_timeSinceLastLog >= _logDelay)
            #line 127 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
            {
                #line 128 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                CompleteDependency();
                #line 130 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

                foreach (var itemPickup in _cachedPickups)
                #line 131 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                {
                    #line 132 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                    var (amount, rarity, text) = itemPickup.Value;
                    #line 133 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                    TextHelper.DisplayText($"{text} x{amount}", rarity);
                }
                #line 136 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

                _cachedPickups.Clear();
                #line 137 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                _timeSinceLastLog = 0f;
            }
            #line 140 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            base.OnUpdate();
#line hidden
        }

        #line 89 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL-Collection//ItemPickUpNotificationSystem__System_19055065920.g.cs"
        struct ItemPickUpNotificationSystem_5E188CCE_LambdaJob_0_Job : global::Unity.Entities.IJobChunk
        {
            public global::Unity.Entities.BufferLookup<global::ContainedObjectsBuffer> containedObjectsBufferLookup;
            public global::Unity.Collections.NativeParallelHashMap<int, (int totalAmount, global::Rarity rarity, global::Unity.Collections.FixedString64Bytes displayName)> cachedPickups;
            public global::Unity.Entities.Entity localPlayerEntity;
            [global::Unity.Collections.ReadOnly] public global::Unity.Entities.EntityTypeHandle __entityTypeHandle;
            public BufferTypeHandle<Inventory.InventoryChangeBuffer> __inventoryChangesTypeHandle;
            
            void OriginalLambdaBody(global::Unity.Entities.Entity entity, DynamicBuffer<Inventory.InventoryChangeBuffer> inventoryChanges)
            {
#line 80 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
foreach (var change in inventoryChanges)
                    {
#line 82 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (change.inventoryChangeData.inventoryAction != InventoryAction.MoveOrDropAllItems)
                        {
#line 84 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
continue;
                        }
#line 87 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (change.playerEntity != localPlayerEntity)
                        {
#line 89 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
continue;
                        }
#line 92 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var sourceInventory = change.inventoryChangeData.inventory1;
#line 93 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (!containedObjectsBufferLookup.HasBuffer(sourceInventory))
                        {
#line 95 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
continue;
                        }
#line 98 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var itemsBuffer = containedObjectsBufferLookup[sourceInventory];
#line 99 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
foreach (var item in itemsBuffer)
                        {
#line 101 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (item.objectData.objectID == ObjectID.None)
                            {
#line 103 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
continue;
                            }
#line 106 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var objectIdHash = item.objectData.objectID.GetHashCode();
#line 107 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (cachedPickups.TryGetValue(objectIdHash, out var existing))
                            {
#line 109 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
cachedPickups[objectIdHash] = (existing.totalAmount + item.amount, existing.rarity, existing.displayName);
                            }
                            else
                            {
#line 113 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var text = PlayerController.GetObjectName(item, true).text;
#line 114 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var rarity = PugDatabase.GetObjectInfo(item.objectData.objectID).rarity;
#line 116 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
cachedPickups[objectIdHash] = (item.amount, rarity, text);
                            }
                        }
                    }
                }
            #line 154 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL-Collection//ItemPickUpNotificationSystem__System_19055065920.g.cs"
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            public void Execute(in global::Unity.Entities.ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in global::Unity.Burst.Intrinsics.v128 chunkEnabledMask)
            {
                #line 158 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL-Collection//ItemPickUpNotificationSystem__System_19055065920.g.cs"
                var __entityArrayPtr = global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
                var inventoryChangesAccessor = chunk.GetBufferAccessor(ref __inventoryChangesTypeHandle);
                int chunkEntityCount = chunk.Count;
                if (!useEnabledMask)
                {
                    for(var entityIndex = 0; entityIndex < chunkEntityCount; ++entityIndex)
                    {
                        OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(__entityArrayPtr, entityIndex), inventoryChangesAccessor[entityIndex]);
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
                                OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(__entityArrayPtr, entityIndex), inventoryChangesAccessor[entityIndex]);
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
                                OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(__entityArrayPtr, entityIndex), inventoryChangesAccessor[entityIndex]);
                            }
                            mask64 >>= 1;
                        }
                        mask64 = chunkEnabledMask.ULong1;
                        for (var entityIndex = 64; entityIndex < chunkEntityCount; ++entityIndex)
                        {
                            if ((mask64 & 1) != 0)
                            {
                                OriginalLambdaBody(global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<global::Unity.Entities.Entity>(__entityArrayPtr, entityIndex), inventoryChangesAccessor[entityIndex]);
                            }
                            mask64 >>= 1;
                        }
                    }
                }
            }
        }
        void ItemPickUpNotificationSystem_5E188CCE_LambdaJob_0_Execute(global::Unity.Entities.BufferLookup<global::ContainedObjectsBuffer> containedObjectsBufferLookup,global::Unity.Collections.NativeParallelHashMap<int, (int totalAmount, global::Rarity rarity, global::Unity.Collections.FixedString64Bytes displayName)> cachedPickups,global::Unity.Entities.Entity localPlayerEntity)
        {
            __TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
            __TypeHandle.__Inventory_InventoryChangeBuffer_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
            var __job = new ItemPickUpNotificationSystem_5E188CCE_LambdaJob_0_Job
            {
                containedObjectsBufferLookup = containedObjectsBufferLookup,
                cachedPickups = cachedPickups,
                localPlayerEntity = localPlayerEntity,
                __entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
                __inventoryChangesTypeHandle = __TypeHandle.__Inventory_InventoryChangeBuffer_RO_BufferTypeHandle
            };
            
            this.CheckedStateRef.Dependency = global::Unity.Entities.Internal.InternalCompilerInterface.JobChunkInterface.ScheduleParallel(__job, __query_911957012_0, this.CheckedStateRef.Dependency);
        }
        
        TypeHandle __TypeHandle;
        global::Unity.Entities.EntityQuery __query_911957012_0;
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
            __query_911957012_0 = 
                entityQueryBuilder
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

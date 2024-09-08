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
            #line 41 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
            var itemPickUpNotifierFeature = FeatureManager.Instance.GetFeature<ItemPickUpNotifierFeature>();
            #line 42 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
            if (itemPickUpNotifierFeature is not { IsEnabled: true })
            #line 43 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
            {
                #line 44 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                return;
            }
            #line 47 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            _logDelay = itemPickUpNotifierFeature.Config.LogDelay;
            #line 49 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            var containedObjectsBufferLookup = GetBufferLookup<ContainedObjectsBuffer>(true);
            #line 51 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            ItemPickUpNotificationSystem_5E188CCE_LambdaJob_0_Execute(ref containedObjectsBufferLookup);
            #line 94 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            _timeSinceLastLog += this.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
            #line 96 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            if (_timeSinceLastLog >= _logDelay)
            #line 97 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
            {
                #line 98 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                foreach (var itemPickup in _cachedPickups)
                #line 99 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                {
                    #line 100 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                    var (amount, rarity, text) = itemPickup.Value;
                    #line 101 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                    TextHelper.DisplayText($"{text} x{amount}", rarity);
                    #line 102 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                    Debug.Log($"Player picked up {text} (Qty: {amount})");
                }
                #line 105 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

                _cachedPickups.Clear();
                #line 106 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
                _timeSinceLastLog = 0f;
            }
            #line 109 "D:/CK-ModSDK/Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"

            base.OnUpdate();
#line hidden
        }

        #line 71 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL-Collection//ItemPickUpNotificationSystem__System_19055065920.g.cs"
        struct ItemPickUpNotificationSystem_5E188CCE_LambdaJob_0_Job : global::Unity.Entities.IJobChunk
        {
            public global::CK_QOL_Collection.Features.ItemPickUpNotifier.Systems.ItemPickUpNotificationSystem __this;
            public global::Unity.Entities.BufferLookup<global::ContainedObjectsBuffer> containedObjectsBufferLookup;
            public BufferTypeHandle<Inventory.InventoryChangeBuffer> __inventoryChangesTypeHandle;
            
            void OriginalLambdaBody(DynamicBuffer<Inventory.InventoryChangeBuffer> inventoryChanges)
            {
#line 55 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
foreach (var change in inventoryChanges)
                    {
#line 57 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (change.inventoryChangeData.inventoryAction != InventoryAction.MoveOrDropAllItems)
                        {
#line 59 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
continue;
                        }
#line 62 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var sourceInventory = change.inventoryChangeData.inventory1;
#line 63 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (!containedObjectsBufferLookup.HasBuffer(sourceInventory))
                        {
#line 65 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
continue;
                        }
#line 68 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var itemsBuffer = containedObjectsBufferLookup[sourceInventory];
#line 69 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
foreach (var item in itemsBuffer)
                        {
#line 71 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (item.objectData.objectID == ObjectID.None)
                            {
#line 73 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
continue;
                            }
#line 76 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var objectIdHash = item.objectData.objectID.GetHashCode();
#line 77 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
if (__this._cachedPickups.TryGetValue(objectIdHash, out var existing))
                            {
#line 79 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
__this.                                _cachedPickups[objectIdHash] = (existing.totalAmount + item.amount, existing.rarity, existing.displayName);
                            }
                            else
                            {
#line 83 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var text = PlayerController.GetObjectName(item, true).text;
#line 84 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
var rarity = PugDatabase.GetObjectInfo(item.objectData.objectID).rarity;
#line 86 "D:\CK-ModSDK\Assets/CK-QOL-Collection/Features/ItemPickUpNotifier/Systems/ItemPickUpNotificationSystem.cs"
__this.
                                _cachedPickups[objectIdHash] = (item.amount, rarity, text);
                            }
                        }
                    }
                }
            #line 129 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL-Collection//ItemPickUpNotificationSystem__System_19055065920.g.cs"
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            public void Execute(in global::Unity.Entities.ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in global::Unity.Burst.Intrinsics.v128 chunkEnabledMask)
            {
                #line 133 "D:/CK-ModSDK/Temp/GeneratedCode/CK-QOL-Collection//ItemPickUpNotificationSystem__System_19055065920.g.cs"
                var inventoryChangesAccessor = chunk.GetBufferAccessor(ref __inventoryChangesTypeHandle);
                int chunkEntityCount = chunk.Count;
                if (!useEnabledMask)
                {
                    for(var entityIndex = 0; entityIndex < chunkEntityCount; ++entityIndex)
                    {
                        OriginalLambdaBody(inventoryChangesAccessor[entityIndex]);
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
                                OriginalLambdaBody(inventoryChangesAccessor[entityIndex]);
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
                                OriginalLambdaBody(inventoryChangesAccessor[entityIndex]);
                            }
                            mask64 >>= 1;
                        }
                        mask64 = chunkEnabledMask.ULong1;
                        for (var entityIndex = 64; entityIndex < chunkEntityCount; ++entityIndex)
                        {
                            if ((mask64 & 1) != 0)
                            {
                                OriginalLambdaBody(inventoryChangesAccessor[entityIndex]);
                            }
                            mask64 >>= 1;
                        }
                    }
                }
            }
            public static void RunWithoutJobSystem(ref global::Unity.Entities.EntityQuery query, global::System.IntPtr jobPtr)
            {
                try
                {
                    ref var jobData = ref global::Unity.Entities.Internal.InternalCompilerInterface.UnsafeAsRef<ItemPickUpNotificationSystem_5E188CCE_LambdaJob_0_Job>(jobPtr);
                    global::Unity.Entities.Internal.InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref jobData, ref query);
                }
                finally
                {
                }
            }
        }
        void ItemPickUpNotificationSystem_5E188CCE_LambdaJob_0_Execute(ref global::Unity.Entities.BufferLookup<global::ContainedObjectsBuffer> containedObjectsBufferLookup)
        {
            __TypeHandle.__Inventory_InventoryChangeBuffer_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
            var __job = new ItemPickUpNotificationSystem_5E188CCE_LambdaJob_0_Job
            {
                __this = this,
                containedObjectsBufferLookup = containedObjectsBufferLookup,
                __inventoryChangesTypeHandle = __TypeHandle.__Inventory_InventoryChangeBuffer_RO_BufferTypeHandle
            };
            
            if(!__query_911957012_0.IsEmptyIgnoreFilter)
            {
                this.CheckedStateRef.CompleteDependency();
                var __jobPtr = global::Unity.Entities.Internal.InternalCompilerInterface.AddressOf(ref __job);
                ItemPickUpNotificationSystem_5E188CCE_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_911957012_0, __jobPtr);
            }
            containedObjectsBufferLookup = __job.containedObjectsBufferLookup;
        }
        
        TypeHandle __TypeHandle;
        global::Unity.Entities.EntityQuery __query_911957012_0;
        struct TypeHandle
        {
            [global::Unity.Collections.ReadOnly] public Unity.Entities.BufferTypeHandle<global::Inventory.InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RO_BufferTypeHandle;
            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            public void __AssignHandles(ref global::Unity.Entities.SystemState state)
            {
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

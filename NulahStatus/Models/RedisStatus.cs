using System;

namespace NulahStatus.Models
{
    public class RedisStatus
    {
        //public string RedisVersion { get; set; }
        //public string RedisGitSha1 { get; set; }
        //public string RedisGitDirty { get; set; }
        //public string RedisBuildId { get; set; }
        //public string RedisMode { get; set; }
        //public string Os { get; set; }
        //public string ArchBits { get; set; }
        //public string MultiplexingApi { get; set; }
        //public string GccVersion { get; set; }
        //public string ProcessId { get; set; }
        //public string RunId { get; set; }
        //public string TcpPort { get; set; }
        public int UptimeInSeconds { get; set; }
        //public string UptimeInDays { get; set; }
        //public string Hz { get; set; }
        //public string LruClock { get; set; }
        //public string Executable { get; set; }
        //public string ConfigFile { get; set; }
        //public string ConnectedClients { get; set; }
        //public string ClientLongestOutputList { get; set; }
        //public string ClientBiggestInputBuf { get; set; }
        //public string BlockedClients { get; set; }
        public int UsedMemory { get; set; }
        //public string UsedMemoryHuman { get; set; }
        public int UsedMemoryRss { get; set; }
        //public string UsedMemoryRssHuman { get; set; }
        public int UsedMemoryPeak { get; set; }
        //public string UsedMemoryPeakHuman { get; set; }
        public int TotalSystemMemory { get; set; }
        //public string TotalSystemMemoryHuman { get; set; }
        //public string UsedMemoryLua { get; set; }
        //public string UsedMemoryLuaHuman { get; set; }
        //public string Maxmemory { get; set; }
        //public string MaxmemoryHuman { get; set; }
        //public string MaxmemoryPolicy { get; set; }
        //public string MemFragmentationRatio { get; set; }
        //public string MemAllocator { get; set; }
        //public string Loading { get; set; }
        //public string RdbChangesSinceLastSave { get; set; }
        //public string RdbBgsaveInProgress { get; set; }
        //public string RdbLastSaveTime { get; set; }
        //public string RdbLastBgsaveStatus { get; set; }
        //public string RdbLastBgsaveTimeSec { get; set; }
        //public string RdbCurrentBgsaveTimeSec { get; set; }
        //public string AOFEnabled { get; set; }
        //public string AOFRewriteInProgress { get; set; }
        //public string AOFRewriteScheduled { get; set; }
        //public string AOFLastRewriteTimeSec { get; set; }
        //public string AOFCurrentRewriteTimeSec { get; set; }
        //public string AOFLastBgrewriteStatus { get; set; }
        //public string AOFLastWriteStatus { get; set; }
        public int TotalConnectionsReceived { get; set; }
        public int TotalCommandsProcessed { get; set; }
        //public string InstantaneousOpsPerSec { get; set; }
        //public string TotalNetInputBytes { get; set; }
        //public string TotalNetOutputBytes { get; set; }
        //public string InstantaneousInputKbps { get; set; }
        //public string InstantaneousOutputKbps { get; set; }
        //public string RejectedConnections { get; set; }
        //public string SyncFull { get; set; }
        //public string SyncPartialOk { get; set; }
        //public string SyncPartialErr { get; set; }
        public int ExpiredKeys { get; set; }
        //public string EvictedKeys { get; set; }
        public int KeyspaceHits { get; set; }
        public int KeyspaceMisses { get; set; }
        //public string PubsubChannels { get; set; }
        //public string PubsubPatterns { get; set; }
        //public string LatestForkUsec { get; set; }
        //public string MigrateCachedSockets { get; set; }
        //public string Role { get; set; }
        //public string ConnectedSlaves { get; set; }
        //public string MasterReplOffset { get; set; }
        //public string ReplBacklogActive { get; set; }
        //public string ReplBacklogSize { get; set; }
        //public string ReplBacklogFirstByteOffset { get; set; }
        //public string ReplBacklogHistlen { get; set; }
        public float UsedCpuSys { get; set; }           // in seconds
        public float UsedCpuUser { get; set; }          // in seconds
        public float UsedCpuSysChildren { get; set; }   // in seconds
        public float UsedCpuUserChildren { get; set; }  // in seconds
        //public string ClusterEnabled { get; set; }
        public DateTime Updated { get; set; }
        public string NulahStatusVersion { get; set; }
    }
}

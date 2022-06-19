﻿namespace XplLib.Objects
{
    public class BaseData
    {
        protected string Number { get; init; }
        protected string Description { get; init; }
        protected string Type { get; init; }
        protected string ExecutionRate { get; set; }
        protected string LastBackupTimestamp { get; set; }
        protected string Fingerprint { get; set; }
    }
}
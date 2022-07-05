namespace XplLib.Objects
{
    public abstract class BaseData
    {
        protected string Number { get; init; }
        protected string Description { get; init; }
        protected string Type { get; init; }
        protected string ExecutionRate { get; set; }
        protected string LastBackupTimestamp { get; set; }
        protected string Fingerprint { get; set; }

        public abstract string ReturnPrintString();

        public static List<BaseData?> GetList() => Func.ConvertEntriesToObjects(Func.ReadEntriesFile());
    }
}
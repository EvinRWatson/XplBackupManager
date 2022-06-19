namespace XplLib.Objects
{
    public class LocalData : BaseData
    {
        protected string SourcePath { get; set; }
        protected string DestinationPath { get; set; }

        public LocalData(string[] entry)
        {
            Number = entry[0];
            Type = entry[1];
            SourcePath = entry[2];
            DestinationPath = entry[3];
        }
    }
}
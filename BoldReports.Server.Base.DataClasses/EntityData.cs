namespace BoldReports.Server.Base.DataClasses
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class EntityData<T>
    {
        [DataMember]
        public int Count
        {
            get;
            set;
        }

        [DataMember]
        public IEnumerable<T> Result
        {
            get;
            set;
        }
    }
}

#region

using System.Runtime.Serialization;

#endregion

namespace WebApp.Transversales
{
    [DataContract]
    public class Session
    {
        #region Properties

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string ConnectionString { get; set; }

        [DataMember]
        public string IdCache { get; set; }

        [DataMember]
        public int[] Permissions { get; set; }

        [DataMember]
        public string Theme { get; set; }
        [DataMember]
        public string Color { get; set; }


        #endregion
    }
}

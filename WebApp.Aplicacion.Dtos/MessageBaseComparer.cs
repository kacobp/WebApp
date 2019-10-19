// -----------------------------------------------------------------------
// <copyright file="MessageBaseComparer.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Aplicacion.Dtos
{
    #region Using Directives

    using System.Collections.Generic;

    #endregion

    public class MessageBaseComparer : IEqualityComparer<MessageBase>
    {
        private int _hash;

        #region IEqualityComparer<MessageBase> Members

        public bool Equals(MessageBase x, MessageBase y)
        {
            return x != null && y != null && x.CorrelationId == y.CorrelationId;
        }

        public int GetHashCode(MessageBase obj)
        {
            if (this._hash == 0)
                this._hash = obj.CorrelationId.GetHashCode();
            return this._hash;
        }

        #endregion
    }
}
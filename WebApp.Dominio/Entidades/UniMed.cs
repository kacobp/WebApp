//===================================================================================
// © CBP - linkedin.com/in/
//===================================================================================

#region

using WebApp.Datos.Core;
using System.ComponentModel.DataAnnotations;

#endregion

namespace WebApp.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class UniMed : Entity
    {
        public UniMed()
        {
            this.Alim = new HashSet<Alim>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CodUMed { get; set; }
    
        public virtual ICollection<Alim> Alim { get; set; }
    }
}

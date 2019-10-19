//===================================================================================
// © CBP - linkedin.com/in/
//===================================================================================

#region

using WebApp.Aplicacion.Resx;
using WebApp.Datos.Core;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

#endregion

namespace WebApp.Aplicacion.Dtos
{
    using System;
    
    public partial class Usp_Nutrientes_ShowAll_Result : Entity
    {
        public int IdNut { get; set; }
        public string Nutriente { get; set; }
        public string Simbolo { get; set; }
        public Nullable<int> IdUniMed { get; set; }
        public string UniMed { get; set; }
        public Nullable<int> IdGrpCantNT { get; set; }
        public string Clasificacion { get; set; }
        public Nullable<int> IdGrpNT { get; set; }
        public string TipoNutriente { get; set; }
        public Nullable<int> IdFuncNT { get; set; }
        public string Funcion { get; set; }
    }
}

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
    
    public partial class Usp_Nutrientes_ShowAll_Result
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

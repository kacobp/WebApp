using WebApp.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace WebApp.Datos.DataModel
{
    public interface IDatabaseStoredProcedures
{
    IEnumerable<InfoNutriFindByIdProducto> Usp_InfoNutri_FindBy_IdProducto(int? IdProducto);
    //IList<Usp_ProdInfoNutricional> Usp_ProdInfoNutricional_ShowAll();
    //IEnumerable<Usp_Nutrientes> Usp_Nutrientes_ShowAll();
}
}
// -----------------------------------------------------------------------
// <copyright file="AutoMapping.Mix.Extended.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Aplicacion.AutoMapping
{
    using AutoMapper;
    using WebApp.Aplicacion.Dtos;

    public partial class Profiles
    {
        #region Methods

        /// <summary>
        ///     AutoMapper custom configuration
        /// </summary>
        private void ConfigureMappingCustom()
        {
            // Map Account Type Enumeration from domain layer to Application layer enumeration
            //Mapper.CreateMap<Dominio.Entidades.AccountTypes, AccountTypes>().ConvertUsing(at => (AccountTypes)((int)at));
            //Mapper.CreateMap<AccountTypes, Domain.BankingContext.Entities.AccountTypes>().ConvertUsing(at => (Domain.BankingContext.Entities.AccountTypes)((int)at));

            //// Map LookupType Enumeration from domain layer to Application layer LookupType enumeration
            //Mapper.CreateMap<Domain.BankingContext.Entities.LookupTypes, LookupTypes>().ConvertUsing(at => (LookupTypes)((int)at));
            //Mapper.CreateMap<LookupTypes, Domain.BankingContext.Entities.LookupTypes>().ConvertUsing(at => (Domain.BankingContext.Entities.LookupTypes)((int)at));


        }

        #endregion
    }
}
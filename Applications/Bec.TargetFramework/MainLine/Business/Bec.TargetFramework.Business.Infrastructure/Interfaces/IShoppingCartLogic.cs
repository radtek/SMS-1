using System;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;


    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    //using Bec.TargetFramework.Entities;
//using Bec.TargetFramework.Entities.Enums;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/ShoppingCartLogic")]

    public interface IShoppingCartLogic : IBusinessLogicService
    {
        [OperationContract]
        bool DoesShoppingCartExist(Guid shoppingCartId);

        [OperationContract]
        List<VCountryDeductionDTO> GetCountryDeductions(string countryCode);
        [OperationContract]
        List<VOrganisationCheckoutDiscountDTO> GetOrganisationCheckoutDiscounts(Guid organisationID);

        [OperationContract]
        ShoppingCartDTO CalculateShoppingCart(ShoppingCartDTO dto,Guid? organisationID);

        [OperationContract]
        ShoppingCartDTO CreateShoppingCart(VUserAccountOrganisationDTO userAccountOrganisation,
            PaymentCardTypeIDEnum cardTypeEnum, PaymentMethodTypeIDEnum paymentTypeEnum, string countryCode = "UK");

        [OperationContract]
        Bec.TargetFramework.Entities.ShoppingCartItemDTO CreateShoppingCartItem(Bec.TargetFramework.Entities.ShoppingCartDTO dto, Guid cartID);

        [OperationContract]
        void DeleteShoppingCartAndInvoice(ShoppingCartDTO dto);
        [OperationContract]
        void DeleteShoppingCartItem(Bec.TargetFramework.Entities.ShoppingCartItemDTO dto);
        [OperationContract]
        Bec.TargetFramework.Entities.ShoppingCartDTO GetShoppingCart(Guid shoppingCartID);
        [OperationContract]
        Bec.TargetFramework.Entities.ShoppingCartItemDTO GetShoppingCartItem(Guid itemID);
        [OperationContract]
        ShoppingCartDTO SaveShoppingCart(ShoppingCartDTO dto);
        [OperationContract]
        void InsertShoppingCartItem(Bec.TargetFramework.Entities.ShoppingCartItemDTO dto);
        [OperationContract]
        void UpdateShoppingCart(Bec.TargetFramework.Entities.ShoppingCartDTO dto);
        [OperationContract]
        void UpdateShoppingCartItem(Bec.TargetFramework.Entities.ShoppingCartItemDTO dto);
        [OperationContract]

        ShoppingCartDTO AddProductToShoppingCartFromProductID(ShoppingCartDTO dto, Guid productID, int versionNumber, int quantity);
        [OperationContract]

        ShoppingCartDTO UpdateProductWithinShoppingCart(ShoppingCartDTO dto, ShoppingCartItemDTO itemDto);

        [OperationContract]
        ShoppingCartDTO RemoveProductFromShoppingCart(ShoppingCartDTO dto, ShoppingCartItemDTO itemDto);
    }
}

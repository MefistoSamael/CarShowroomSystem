using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.View
{
    public enum RegistrationCommands
    {
        SignIn = 1,
        SignUp = 2,
    }

    public enum CustomerSellerCommands
    {
        ProductList = 1,
        ProductInfo,
        AddProductInBucket,
        DeleteProductFromBucket,
        CreateOrder,
        CancelOrder,
        ShwoMyOrders,
        ShowMyBucket,
        ShowMyCertainOrder,
        Help,
        LogOut,
        SwitchUser,

        // это команда должна идти последней, потому что
        // список команд инициализируется до ее номера
        Costil1,
    }

    public enum AdminCommand
    {
        AddUser = (int)CustomerSellerCommands.Costil1,
        DeleteUser,
        ShowAllOrders,
        ShowAllUsers,
        ShowCertainOrder,
        ShowCertainUser,
        ChangeUserInfo,
        AddCar,
        DeleteCar,
        ChangeCarInfo,
        AddEngineOil,
        DeleteEngineOil,
        ChangeEngineOilInfo,
        AddTires,
        DeleteTires,
        ChangeTiresInfo,

        // это команда должна идти последней, потому что
        // список команд инициализируется до ее номера
        Costil2,

    }


}
